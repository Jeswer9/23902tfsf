using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class Star : Shape
{
	private int width;
	private int height;
    private Point[] pts;
    private int numPoints;

	public Star (int x, int y, int width, int height)
        : base(x, y)
	{
		this.width = width;
		this.height = height;
	}

    private void SetLinePoints()
    {
        numPoints = 5;
        pts = new Point[numPoints];

        double rx = width / 2;
        double ry = height / 2;
        double cx = x + rx;
        double cy = y + ry;

        double theta = -Math.PI / 2;
        double dtheta = 4 * Math.PI / numPoints;
 
        int i;
        for (i = 0; i < numPoints; i++)
        {
            pts[i] = new Point(
                Convert.ToInt32(cx + rx * Math.Cos(theta)),
                Convert.ToInt32(cy + ry * Math.Sin(theta)));
            theta += dtheta;
        }
    }

    public override void Draw()
	{
        SetLinePoints();
		for (int i = 0; i < numPoints; i++) 
		{
			canvas.DrawLine(pts[i].X,
                                pts[i].Y,
                                pts[(i+1) % numPoints].X,
                                pts[(i+1) % numPoints].Y);
		}		
	}

}


