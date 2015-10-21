using System;
using System.Drawing;
using System.IO;

public abstract class Shape
{
    public Canvas canvas;
    protected int x;
    protected int y;

    public Shape(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public abstract void Draw();
	
}