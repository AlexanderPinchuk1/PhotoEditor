using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PhotoEditorWinF
{
    public class LineDots
    {
        public Point CurPoint { get; set; }
        public Point PrevPoint { get; set; } 
        public Color PenColor { get; set; } 
        public float PenSize { get; set; }

        public LineDots(Point prevPoint, Point curPoint, Color penColor, float penSize)
        {
            PrevPoint = prevPoint;
            CurPoint = curPoint;
            PenColor = penColor;
            PenSize = penSize;
        }
    }
}
