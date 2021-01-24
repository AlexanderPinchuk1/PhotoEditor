using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace PhotoEditorWinF
{
    public class DrawingHandler
    {
        private readonly int PictureBoxWidth;
        private readonly int PictureBoxHeight;
        private readonly Pen UserPen;
        private bool IsPressed;
        private Point Point;

        public DrawingHandler(int penSize, int pictureBoxWidth, int pictureBoxHeight)
        {
            PictureBoxHeight = pictureBoxHeight;
            PictureBoxWidth = pictureBoxWidth;
            UserPen = new Pen(Color.Black, penSize * 0.5f);
            IsPressed = false;
            Point.Y = Point.X = -1;
        }

        public void ChangePenColor(Color color)
        {
            UserPen.Color = color;
        }

        public void ChangePenWidth(float width)
        {
            UserPen.Width = width;
        }

        public void MouseDown(Point point)
        {
            IsPressed = true;
            Point = point;
        }

        public void MouseUp(Point point)
        {
            IsPressed = false;
            Point = point;
        }
        private void Drawing(Graphics graphics, LineDots lineDots)
        {
            Pen pen = new Pen(lineDots.PenColor, lineDots.PenSize);
            pen.StartCap = pen.EndCap = LineCap.Round;
            graphics.DrawLine(pen, lineDots.PrevPoint, lineDots.CurPoint);
        }

        public Image MouseMove(Image image, Point newPoint)
        {
            if ((IsPressed) && (Point.X != -1) && (Point.Y != -1))
            {
                int deltaWidth = (PictureBoxWidth - image.Width) / 2;
                int deltaHeight = (PictureBoxHeight - image.Height) / 2;
                LineDots lineDots = new LineDots(new Point(Point.X - deltaWidth, Point.Y - deltaHeight), new Point(newPoint.X - deltaWidth, newPoint.Y - deltaHeight), UserPen.Color, UserPen.Width);

                Bitmap bitmap = new Bitmap(image.Width, image.Height);
                using var graphics = Graphics.FromImage(bitmap);
                graphics.DrawImage(image, 0, 0, bitmap.Width, bitmap.Height);

                Drawing(graphics, lineDots);

                Point.X = newPoint.X;
                Point.Y = newPoint.Y;

                return bitmap;
            }

            return image;
        }
    }
}
