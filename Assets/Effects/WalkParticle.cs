using _0rison;
using OozeDemo;
using OozeDemo.Effects;

using System;

namespace OozeDemo.Effects
{
    public class WalkParticle : Entity
    {
        // Number of frames to remain on screen for
        public const int PARTICLE_FRAMES = 5;

        // Our graphic will be a simple image
        public Image image;

        public int direction = 0;
        public int particleTimer = 0;

        public WalkParticle(float x, float y)
            : base(x, y)
        {
            // Our graphic will be a purple circle, with a 4 pixel radius
            Color col = new Color("Green");
            image = Image.CreateCircle(4, col);
            Graphic = image;
        }

        public override void Update()
        {
            // Float upward
            Y -= (float)(1.5 / _0rison.Rand.Float(1, 3));

            // Gradually become transparent before disappearing
            image.Alpha -= 0.10f;

            particleTimer++;
            if (particleTimer >= PARTICLE_FRAMES)
            {
                RemoveSelf();
            }
        }
    }
}