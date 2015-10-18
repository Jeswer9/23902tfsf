using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class Rectangle : Shape
{

    private int x;
	private int y;
	private int width;
	private int height;

    public Rectangle(int x, int y, int width, int height)
    {
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;
    }
    
	public override void Draw(Graphics Canvas)
    {
		Pen pen = new Pen(Color.Black);
		Canvas.DrawLine(pen,x,y,x + width,y);
		Canvas.DrawLine(pen,x+width,y,x+width,y+height);
		Canvas.DrawLine(pen,x+width,y+height,x,y+height);
		Canvas.DrawLine(pen,x,y+height,x,y);
    }

    public override void SVGDraw(StreamWriter writer)
    {      
        writer.WriteLine("<polyline points=\"{0},{1} {2},{1} {2},{3} {0},{3} {0},{1}\"\nstyle=\"fill:none;stroke:black;stroke-width:1\" />"
            , x,y,x+width,y+height);
    }
      
                        
}

