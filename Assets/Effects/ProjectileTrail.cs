﻿using _0rison;
using OozeDemo;
using OozeDemo.Effects;
using System;
namespace OozeDemo.Effects
{
    public class ProjectileTrail : ProjectileParticle
    {
        public const int DESTROY_FRAME = 3;
        public ProjectileTrail(float x, float y)
            : base(x, y)
        {
            destroyFrame = DESTROY_FRAME;
            sprite = new Spritemap<string>(Assets.PROJECTILE_PARTICLE, 32, 40);
            sprite.Add("Emit", new int[] { 0, 1, 2, 3 }, new float[] { 10f, 10f, 10f, 10f });
            sprite.Play("Emit");
            Graphic = sprite;
        }
    }
}
