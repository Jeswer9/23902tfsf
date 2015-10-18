using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


    public abstract class Canvas
    {
        public abstract void Draw();
    }

    class SVG_Canvas: Canvas
    {
        public override void Draw()
        {

        }
    }

    class CSharp_Canvas : Canvas
    {
        private Graphics Canvas;

        public override void Draw()
        {

        }
    }

