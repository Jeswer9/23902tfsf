using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class Star : Shape
{

	private int x;
	private int y;
	private int width;
	private int height;
    private Point[] pts;
    private int numPoints;

	public Star (int x, int y, int width, int height)
	{
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;
	}

    private void SetPoints()
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
	public override void Draw (Graphics Canvas)
	{
		Pen pen = new Pen (Color.Black);
        SetPoints();
		for (int i = 0; i < numPoints; i++) 
		{
			Canvas.DrawLine(pen,pts[i].X,
                                pts[i].Y,
                                pts[(i+1) % numPoints].X,
                                pts[(i+1) % numPoints].Y);
		}
		
	}

     public override void SVGDraw(StreamWriter writer)
    {
        SetPoints();
        writer.WriteLine("<polyline points=\"{0},{1} {2},{3} {4},{5} {6},{7} {8},{9} {10},{11}\"\nstyle=\"fill:none;stroke:black;stroke-width:1\" />",
            pts[0].X, pts[0].Y, pts[1].X, pts[1].Y, pts[2].X, pts[2].Y,
            pts[3].X, pts[3].Y, pts[4].X, pts[4].Y,pts[0].X, pts[0].Y);
    }

}


