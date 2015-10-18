using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;


    public abstract class Canvas
    {
        public Graphics canvas;
        public StreamWriter writer;

        public abstract void DrawLine(int x1, int y1, int x2, int y2);
        public abstract void DrawCircle(int x, int y, int size);
    }

    class SVG_Canvas : Canvas
    {
        public override void DrawLine(int x1, int y1, int x2, int y2)
        {
            writer.WriteLine("<polyline points=\"{0},{1}, {2}, {3}, {0},{1}\"\nstyle=\"fill:none;stroke:black;stroke-width:1\" />", x1, y1, x2, y2);           
        }

        public override void DrawCircle(int x, int y, int size)
        {
            int radius = size / 2;
            writer.WriteLine("<circle cx=\"{0}\" cy=\"{1}\" r=\"{2}\" stroke-width=\"1\"\nfill=\"none\" stroke=\"black\" />", x + radius, y + radius, radius); 
        }
    }

    class CSharp_Canvas : Canvas
    {
        public override void DrawLine(int x1, int y1, int x2, int y2)
        {
            Pen pen = new Pen(Color.Black);
            canvas.DrawLine(pen ,x1,y1,x2,y2);
        }

        public override void DrawCircle(int x, int y, int size)
        {
            Pen pen = new Pen(Color.Black);
            canvas.DrawEllipse(pen, x, y, size, size);
        }
    }
    
        

