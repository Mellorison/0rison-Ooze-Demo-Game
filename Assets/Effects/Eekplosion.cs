﻿using _0rison;
using OozeDemo.Scenes;

using OozeDemo;

using System;

namespace OozeDemo.Entities
{
    public class Eekplosion : Entity
    {
        public Image img;

        // Default color is white
        public Color color = new Color("FFFFFF");

        public Sound explode = new Sound(Assets.SND_PROJECTILE_EXPLODE);

        public bool bossExplode = false;
        
        

        public Eekplosion(float x, float y, bool boss = false, int width = 32, int height = 40, Color expColor = null, int radius = 20)

        {
            X = x + width / 2;
            Y = y;

            // You can pass in a custom color, if desired
            if (expColor != null)
            {
                color = expColor;
            }

            // Center ourselves and set the graphic
            img = Image.CreateCircle(radius, color);
            img.CenterOrigin();
            Graphic = img;

            Global.camShaker.ShakeCamera(40f);
            explode.Play();

            bossExplode = boss;
        }

        

        public override void Update()
        {
            base.Update();

            // Gradually grow, in the fashion of an explosion
            // If you want to get fancy, perhaps you could make this
            // a decaying growth, or even Tween it so it grows faster
            // at the beginning
            img.ScaleX += 0.10f;
            img.ScaleY += 0.10f;

            img.CenterOrigin();

            // Gradually phase to invisible
            img.Alpha -= 0.04f;
            if (img.Alpha <= 0)
            {
                RemoveSelf();
            }

            if (bossExplode)
            {
                Global.gameMusic.Stop();
                Global.demo.Scene.RemoveAll();
                Global.demo.SwitchScene(new EndScene());
            }
        }
    }
}