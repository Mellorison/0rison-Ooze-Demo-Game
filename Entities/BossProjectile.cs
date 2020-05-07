using _0rison;
using OozeDemo;
using OozeDemo.Effects;
using System;

namespace OozeDemo.Entities
{
    public class BossProjectile : Entity
    {
        public float projectileSpeed = 10.0f;
        public int direction = 0;
        public float distanceTraveled = 0f;
        public float maxDistance = 350f;
        public Image image;
        public Sound shootSnd = new Sound(Assets.SND_BOSS_SHOOT);

        public BossProjectile(float x, float y, int dir)
        {
            X = x;
            Y = y;
            direction = dir;

            image = new Image(Assets.BOSS_PROJECTILE);
            Graphic = image;

            Global.demo.Scene.Add(new BossTrail(X, Y));
            SetHitbox(16, 14, (int)Global.Type.BOSS_PROJECTILE);

            shootSnd.Play();
        }

        public override void Update()
        {
            switch (direction)
            {
                case Global.DIR_UP:
                    {
                        Y -= projectileSpeed;
                        break;
                    }
                case Global.DIR_DOWN:
                    {
                        Y += projectileSpeed;
                        break;
                    }
                case Global.DIR_LEFT:
                    {
                        X -= projectileSpeed;
                        break;
                    }
                case Global.DIR_RIGHT:
                    {
                        X += projectileSpeed;
                        break;
                    }
            }

            if (distanceTraveled % 60 == 0)
            {
                Global.demo.Scene.Add(new BossTrail(X, Y));
            }

            distanceTraveled += projectileSpeed;
            if (distanceTraveled >= maxDistance)
            {
                RemoveSelf();
            }
        }
    }
}