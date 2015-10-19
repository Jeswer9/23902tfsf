using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;


public class DrawingFactory
{
    private Drawing drawing;

    public Drawing FabricateDrawing(string drawingType, object OutputObject)
    {
        switch (drawingType)
        {
            case ("SVG"):
                drawing = new SVG_Drawing(OutputObject as StreamWriter);
                break;
            case ("CSharp"):
                drawing = new CSharp_Drawing(OutputObject as Graphics);
                break;
        }

        return drawing;
    }
}

