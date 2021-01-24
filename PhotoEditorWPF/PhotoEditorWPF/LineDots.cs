using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PhotoEditorWPF
{
    class LineDots
    {
        public Point CurPoint { get; set; }
        public Point PrevPoint { get; set; }

        public LineDots(Point prevPoint, Point curPoint)
        {
            CurPoint = curPoint;
            PrevPoint = prevPoint; 
        }
    }
}
