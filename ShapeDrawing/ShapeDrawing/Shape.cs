using System;
using System.Drawing;
using System.IO;

public abstract class Shape
{
    //Reference of the Bridge
    public Canvas canvas;

	public Shape()
	{
	}

    public abstract void Draw(Graphics Canvas);

    public abstract void SVGDraw(StreamWriter writer);

	
}