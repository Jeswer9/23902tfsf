using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;


public class CanvasFactory
{
    private Canvas canvas;

    public Canvas FabricateCanvas(string canvasType, object OutputObject)
    {
        switch (canvasType)
        {
            case ("SVG"):
                canvas = new SVG_Canvas(OutputObject as StreamWriter);
                break;
            case ("CSharp"):
                canvas = new CSharp_Canvas(OutputObject as Graphics);
                break;
        }

        return canvas;
    }
}

