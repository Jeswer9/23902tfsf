using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class Circle : Shape
{

    private int x;
	private int y;
	private int size;

    public Circle(int x, int y, int size)
    {
		this.x = x;
		this.y = y;
		this.size = size;
    }

    public override void Draw(Graphics Canvas)
    {
		Pen pen = new Pen(Color.Black);
        Canvas.DrawEllipse(pen, this.x, this.y, this.size, this.size);
    }

    public override void SVGDraw(StreamWriter writer)
    {
        int radius = size / 2;
         writer.WriteLine("<circle cx=\"{0}\" cy=\"{1}\" r=\"{2}\" stroke-width=\"1\"\nfill=\"none\" stroke=\"black\" />",x+radius,y+radius,radius);                                     
    }

}
