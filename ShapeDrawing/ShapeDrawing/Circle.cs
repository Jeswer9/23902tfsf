using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class Circle : Shape
{
	private int size;

    public Circle(int x, int y, int size)
        : base(x, y)
    {
		this.size = size;        
    }

    public override void Draw()
    {
        canvas.DrawCircle(x, y, size);       
    }


}
