using _0rison;
using OozeDemo;
using System;

namespace OozeDemo.Effects
{
    // ProjectileParticle extends the Entity class
    public class ProjectileParticle : Entity
    {
        // Our projectile particle graphics contain multiple frames. Spritemap makes sense here.
        public Spritemap<string> sprite;

        // Once the animation hits this frame, remove ourself from the Scene
        public int destroyFrame = 1;

        public ProjectileParticle(float x, float y)
            : base(x, y)
        {

        }

        public override void Update()
        {
            base.Update();

            // Have our particle drift up a bit as it dissolves
            Y -= (float)(1.5 / _0rison.Rand.Float(1, 3));

            // Check if we have finished playing. If so, remove self
            if (sprite.CurrentFrame == destroyFrame)
            {
                RemoveSelf();
            }
        }
    }
}
