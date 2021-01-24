using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PhotoEditorWPF
{
    class DrawingHandler
    {
        private bool IsPressed;
        private bool IsImageSelected;
        Point Point;
        private readonly Canvas Canvas;
        private System.Windows.Media.Brush PenBrush;
        private double PenSize;

        public DrawingHandler(Canvas canvas, RGB penColor, double penSize)
        {
            Canvas = canvas;
            IsPressed = false;
            IsImageSelected = false;
            Point.X = Point.Y = -1;
            PenBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(penColor.R,penColor.G,penColor.B));
            PenSize = penSize;
        }


        public void ImageSelected()
        {
            IsImageSelected = true;
        }

        public bool ImageIsSelected()
        {
            if (IsImageSelected)
                return true;
            else
                return false;
        }

        public void ChangePenColor(RGB penColor)
        {
            PenBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(penColor.R, penColor.G, penColor.B));
        }

        public void ChangePenWidth(double penSize)
        {
            PenSize = penSize;
        }

        public void MouseDown(Point newPoint)
        {
            IsPressed = true;
            Point = newPoint;
        }

        public void MouseUp()
        {
            IsPressed = false;
            Point.X = Point.Y = -1;
        }

        private void Drawing(LineDots lineDots)
        {
            if (ImageIsSelected())
            {
                Line line = new Line
                {
                    X1 = lineDots.PrevPoint.X,
                    Y1 = lineDots.PrevPoint.Y,
                    X2 = lineDots.CurPoint.X,
                    Y2 = lineDots.CurPoint.Y,
                    StrokeStartLineCap = PenLineCap.Round,
                    StrokeEndLineCap = PenLineCap.Round,
                    StrokeThickness = PenSize,
                    Stroke = PenBrush,
                };
                Canvas.Children.Add(line);
            }
        }

        public void MouseMove(Point newPoint)
        {
            if ((IsPressed) && (Point.X != -1) && (Point.Y != -1))
            {
                LineDots lineDots = new LineDots(Point , newPoint);

                Drawing(lineDots);

                Point = newPoint;
            }
        }
    }
}
