using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PhotoEditorLIB
{
    public class DrawingHandler
    {
        private readonly int PictureBoxWidth;
        private readonly int PictureBoxHeight;
        private readonly Pen UserPen;
        private bool IsPressed;
        private int X;
        private int Y;

        public DrawingHandler(int penSize, int pictureBoxWidth, int pictureBoxHeight)
        {
            PictureBoxHeight = pictureBoxHeight;
            PictureBoxWidth = pictureBoxWidth;
            UserPen = new Pen(Color.Black, penSize * 0.5f);
            IsPressed = false;
            X = Y = -1;
        }

        public void ChangePenColor(Color color)
        {
            UserPen.Color = color;
        }

        public void ChangePenWidth(float width)
        {
            UserPen.Width = width;
        }

        public void MouseDown(int newX, int newY)
        {
            IsPressed = true;
            X = newX;
            Y = newY;
        }

        public void MouseUp()
        {
            IsPressed = false;
            X = -1;
            Y = -1;
        }
        private void Drawing(Graphics graphics, LineDots lineDots)
        {
            Pen pen = new Pen(lineDots.PenColor, lineDots.PenSize);
            pen.StartCap = pen.EndCap = LineCap.Round;
            graphics.DrawLine(pen, lineDots.PrevX, lineDots.PrevY, lineDots.CurX, lineDots.CurY);
        }

        public Image MouseMove(Image image,int newX, int newY)
        {
            if ((IsPressed) && (X != -1) && (Y != -1))
            {
                int deltaHeight = (PictureBoxWidth - image.Width) / 2;
                int deltaWidth = (PictureBoxHeight - image.Height) / 2;
                LineDots lineDots = new LineDots(X - deltaHeight, Y - deltaWidth, newX - deltaHeight, newY - deltaWidth, UserPen.Color, UserPen.Width);

                Bitmap bitmap = new Bitmap(image.Width, image.Height);
                using var graphics = Graphics.FromImage(bitmap);
                graphics.DrawImage(image, 0, 0, bitmap.Width, bitmap.Height);


                Drawing(graphics, lineDots);

                X = newX;
                Y = newY;

                return bitmap;
            }

            return image;
        }
    }
}
