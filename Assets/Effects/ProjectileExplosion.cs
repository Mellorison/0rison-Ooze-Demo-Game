using _0rison;
using OozeDemo;
using OozeDemo.Effects;
using System;

namespace OozeDemo.Effects
{
    // ProjectileExplosion will extend ParticleEffect
    public class ProjectileExplosion : ProjectileParticle
    {
        // Used to keep track of when to remove explosion from the scene
        public const int DESTROY_FRAME = 3;

        // Sound that is played when to remove explosion from the scene
        private Sound projectileExplodeSnd = new Sound(Assets.SND_PROJECTILE_EXPLODE);

        public ProjectileExplosion(float x, float y)
            : base(x, y)
        {
            destroyFrame = DESTROY_FRAME;

            // Set up our explosion animation, and play it. Lastly, set our graphic.
            sprite = new Spritemap<string>(Assets.PROJECTILE_EXPLOSION, 32, 40);
            sprite.Add("Emit", new int[] { 0, 1, 2, 3 }, new float[] { 10f, 10f, 10f, 10f });
            sprite.Play("Emit");
            Graphic = sprite;

            projectileExplodeSnd.Play();

            // Shake the camera each time we explode
            Global.camShaker.ShakeCamera();
        }
    }
}