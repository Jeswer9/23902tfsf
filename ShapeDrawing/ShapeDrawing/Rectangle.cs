using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class Rectangle : Shape
{
	private int width;
	private int height;

    public Rectangle(int x, int y, int width, int height)
        : base(x, y)
    {
		this.width = width;
		this.height = height;
    }
    
	public override void Draw()
    {
        canvas.DrawLine(x, y, x + width, y);
        canvas.DrawLine(x + width, y, x + width, y + height);
        canvas.DrawLine(x + width, y + height, x, y + height);
        canvas.DrawLine(x, y + height, x, y);
    }     
                        
}

