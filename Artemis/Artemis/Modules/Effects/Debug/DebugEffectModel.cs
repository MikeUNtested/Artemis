﻿using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using Artemis.Managers;
using Artemis.Models;
using Artemis.Utilities.Keyboard;

namespace Artemis.Modules.Effects.Debug
{
    internal class DebugEffectModel : EffectModel
    {
        public DebugEffectModel(MainManager mainManager, DebugEffectSettings settings) : base(mainManager)
        {
            Name = "Debug Effect";
            Settings = settings;
            Scale = 4;
        }

        public int Scale { get; set; }

        public DebugEffectSettings Settings { get; set; }

        public KeyboardRectangle KeyboardRectangle { get; set; }

        public override void Dispose()
        {
        }

        public override void Enable()
        {
            KeyboardRectangle = new KeyboardRectangle(MainManager.KeyboardManager.ActiveKeyboard, 0, 0, new List<Color>
            {
                Color.Red,
                Color.OrangeRed,
                Color.Yellow,
                Color.Green,
                Color.Blue,
                Color.Purple,
                Color.DeepPink
            }, LinearGradientMode.Horizontal);
        }

        public override void Update()
        {
            KeyboardRectangle.Height = Settings.Height;
            KeyboardRectangle.Width = Settings.Width;
            KeyboardRectangle.GradientMode = Settings.Type;
            KeyboardRectangle.Rotate = Settings.Rotate;
            KeyboardRectangle.Scale = Settings.Scale;
            Scale = Settings.Scale;
        }

        public override Bitmap GenerateBitmap()
        {
            var bitmap = new Bitmap(21*Scale, 6*Scale);

            using (var g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);
                KeyboardRectangle.Draw(g);
            }
            return bitmap;
        }
    }
}