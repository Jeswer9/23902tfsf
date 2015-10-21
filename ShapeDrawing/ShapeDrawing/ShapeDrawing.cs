using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

public class ShapeDrawingForm : Form
{
	private List<Shape> shapes;

	public ShapeDrawingForm()
	{
        MenuStrip menuStrip;
        menuStrip = new MenuStrip();

        ToolStripDropDownItem menu;
        menu = new ToolStripMenuItem("File");
		menu.DropDownItems.Add("Open...", null, this.openFileHandler);
		menu.DropDownItems.Add("Export...", null, this.exportHandler);
        menu.DropDownItems.Add("Exit", null, this.closeHandler);
        menuStrip.Items.Add(menu);

        this.Controls.Add(menuStrip);
		// Some basic settings
		Text = "Shape Drawing and Converter";
		Size = new Size(400, 400);
		CenterToScreen();
		SetStyle(ControlStyles.ResizeRedraw, true);
		
		// Initialize shapes
        shapes = new List<Shape>();
		
		// Listen to Paint event to draw shapes
		this.Paint += new PaintEventHandler(this.OnPaint); 
	}

    // What to do when the user closes the program
    private void closeHandler(object sender, EventArgs e)
    {
        this.Close();
    }

    // What to do when the user opens a file
    private void openFileHandler(object sender, EventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filter = "";
        dialog.Title = "Open file...";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            shapes = Parser.ParseShapes(dialog.FileName);
            this.Refresh();
        }

    }

    // What to do when the user wants to export a SVG file
	private void exportHandler (object sender, EventArgs e)
	{
		Stream stream;
		SaveFileDialog saveFileDialog = new SaveFileDialog();

		saveFileDialog.Filter = "SVG files|*.svg";
		saveFileDialog.RestoreDirectory = true;
		
		if(saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			if((stream = saveFileDialog.OpenFile()) != null)
			{
				// Insert code here that generates the string of SVG
                //   commands to draw the shapes
                using(StreamWriter writer = new StreamWriter(stream))
                {

                    GenerateDefaultStartingSVG(writer);

                    // Reference SVG_Canvas to each Shape, such that the shapes will use SVG_Canvas to Draw. 
                    ReferenceCanvasToShapes("SVG", writer);
                 
                    GenerateDefaultEndingSVG(writer);
                }				
			}
		}
	}

    private void GenerateDefaultEndingSVG(StreamWriter writer)
    {
        writer.WriteLine("</svg>");
    }

    private void GenerateDefaultStartingSVG(StreamWriter writer)
    {
        writer.WriteLine("<?xml version=\"1.0\" standalone=\"no\"?>");
        writer.WriteLine("<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.1//EN\"");
        writer.WriteLine("\"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\">");
        writer.WriteLine("<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">");
    }

    private void ReferenceCanvasToShapes(string canvasName, object outputObject)
    {
        foreach (Shape shape in shapes)
        {
            shape.canvas = SelectCanvasFromFactory(canvasName, outputObject);
            shape.Draw();
        }

    }

    private Canvas SelectCanvasFromFactory(string canvasName, object outputObject)
    {
        CanvasFactory canvasFactory = new CanvasFactory();
        return canvasFactory.FabricateCanvas(canvasName, outputObject);
    }

    private void OnPaint(object sender, PaintEventArgs e)
	{
        // Reference CSharp_Canvas to each Shape, such that the shapes will use CSharp_Canvas  to Draw. 
        ReferenceCanvasToShapes("CSharp", e.Graphics);

     
	}
}