using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PhotoEditorLIB
{
    public class LineDots
    {
        public float CurX { get; set; } = -1;
        public float CurY { get; set; } = -1;
        public float PrevX { get; set; } = -1;
        public float PrevY { get; set; } = -1;
        public Color PenColor { get; set; } = Color.Black;
        public float PenSize { get; set; } = -1;

        public LineDots(float prevX, float prevY, float curX, float curY, Color penColor, float penSize)
        {
            CurX = curX;
            CurY = curY;
            PrevX = prevX;
            PrevY = prevY;
            PenColor = penColor;
            PenSize = penSize;
        }
        public LineDots()
        {
        }
    }
}
