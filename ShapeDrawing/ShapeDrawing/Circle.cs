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

    public override void Draw(Graphics Canvas, StreamWriter writer)
    {
        canvas.canvas = Canvas;
        canvas.writer = writer;
        canvas.DrawCircle(x, y, size);
        
    }


}
