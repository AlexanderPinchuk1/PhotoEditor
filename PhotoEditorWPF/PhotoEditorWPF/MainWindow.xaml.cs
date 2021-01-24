using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PhotoEditorWPF
{
    public partial class MainWindow : Window
    {
        private readonly ImageHandler ImageHandler;
        private readonly DrawingHandler DrawingHandler;
        private readonly ImageTrackBarsHandler TrackBarsHandler;
        private double CurrentScale;

        private const int ADD_VALUE = 1;
        private const double SCALE_ADD_VALUE = 0.01;
        private const double MAX_NUM_SCALE = 0.5;


        public MainWindow()
        {
            InitializeComponent();
            CurrentScale = 1;
            ImageHandler = new ImageHandler();
            DrawingHandler = new DrawingHandler(DrawArea, new RGB((byte)SliderPenRedColor.Value, (byte)SliderPenBlueColor.Value, (byte)SliderPenBlueColor.Value), SliderPenSize.Value);
            TrackBarsHandler = new ImageTrackBarsHandler((int)SliderRedColor.Value, (int)SliderGreenColor.Value, (int)SliderBlueColor.Value,
                                                       (int)SliderContrast.Value, (int)SliderBrightness.Value);
        }


        private void SaveImage(string filePath) 
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Create);
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)DrawAreaBorder.ActualWidth, (int)DrawAreaBorder.ActualHeight, 1 / 96, 1 / 96, PixelFormats.Pbgra32);
            renderTargetBitmap.Render(DrawArea);
            PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
            pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
            pngBitmapEncoder.Save(fileStream);
            fileStream.Close();

        }

        private void ButSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Image Files(*.JPG)|*.JPG|Image Files(*.BMP)|*.BMP|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                SaveImage(saveFileDialog.FileName);
            }
        }

        private void UpdateCurrentScale()
        {
            CurrentScale = 1;
        }

        private  bool ImageLessThanBorder()
        {
            if ((SelectedImage.ActualWidth * CurrentScale > DrawAreaBorder.ActualWidth) || (SelectedImage.ActualHeight * CurrentScale > DrawAreaBorder.ActualHeight))
                return false;
            else
                return true;
        }

        private void IncreaseImage()
        {
            CurrentScale += SCALE_ADD_VALUE;
            if (ImageLessThanBorder())
                SelectedImage.RenderTransform = new ScaleTransform(CurrentScale, CurrentScale);
            else
                CurrentScale -= SCALE_ADD_VALUE;
        }

        private void DecreaseImage()
        {
            CurrentScale -= SCALE_ADD_VALUE;
            if (CurrentScale < MAX_NUM_SCALE)
                CurrentScale = MAX_NUM_SCALE;
            SelectedImage.RenderTransform = new ScaleTransform(CurrentScale, CurrentScale);
        }

        private void ButIncrease_Click(object sender, RoutedEventArgs e)
        {
            IncreaseImage();
            ChangeCanvas(SelectedImage.ActualWidth * CurrentScale, SelectedImage.ActualHeight * CurrentScale);
        }

        private void ButDecrease_Click(object sender, RoutedEventArgs e)
        {
            DecreaseImage();
            ChangeCanvas(SelectedImage.ActualWidth * CurrentScale, SelectedImage.ActualHeight * CurrentScale);
        }

        private void TurnImage()
        {
            var transform = new RotateTransform(Convert.ToInt32(TextBoxTurnAngle.Text))
            {
                CenterX = DrawArea.ActualWidth / 2,
                CenterY = DrawArea.ActualHeight / 2
            };
            DrawArea.RenderTransform = transform;
        }

        private void ButTurnImage_Click(object sender, RoutedEventArgs e)
        {
            TurnImage();
        }

        private void ChangeCanvas(double width, double height)
        {
            DrawArea.Width = width;
            DrawArea.Height = height;
        }

        private void CleanCanvas()
        {
            DrawArea.Children.RemoveRange(1, DrawArea.Children.Count - 1);
        }

        private bool ImageMoreThanBorder(BitmapImage image)
        {
            if ((image.Width * CurrentScale + 5 >= DrawAreaBorder.ActualWidth) || (image.Height * CurrentScale + 5 >= DrawAreaBorder.ActualHeight))
                return true;
            else
                return false;
        }

        private BitmapImage ImageAdapt(BitmapImage image)
        {
            while (ImageMoreThanBorder(image))
            {
                DecreaseImage();
            }

            return image;
        }

        private bool DrawingHandlerIsCreated()
        {
            if (DrawingHandler == null)
                return false;
            else
                return true;
        }

        private bool PictureIsSelected()
        {
            if (ListBoxPhotos.SelectedIndex != -1)
                return true;
            else
                return false;
                    
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BitmapImage selectedImage = ImageHandler.GetBitmapImageByNumber(ListBoxPhotos.SelectedIndex);

            UpdateCurrentScale();
            selectedImage = ImageAdapt(selectedImage);
            SelectedImage.Source = selectedImage;
            DrawingHandler.ImageSelected();
            ChangeCanvas(selectedImage.Width * CurrentScale,selectedImage.Height*CurrentScale);
            SelectedImage.RenderTransform = new ScaleTransform(CurrentScale, CurrentScale);
            CleanCanvas();
            ImageHandler.ResetBitmapsPixelsData(ListBoxPhotos.SelectedIndex);
            InitSlidersValues();
            TrackBarsHandler.UpdateValues((int)SliderRedColor.Value, (int)SliderGreenColor.Value,(int)SliderBlueColor.Value,
                                          (int)SliderContrast.Value, (int)SliderBrightness.Value);
        }

        private void InitSlidersValues()
        {
            SliderBrightness.Value = 40;
            SliderContrast.Value = 10;
            SliderRedColor.Value = 10;
            SliderGreenColor.Value = 10;
            SliderBlueColor.Value = 10;

        }

        private void Window_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effects = DragDropEffects.All;
            }
        }

        private void ReceiveFiles(string[] droppedFiles)
        {
            foreach (string filePath in droppedFiles)
            {
                ImageHandler.AddBitmapImage(new BitmapImage(new Uri(filePath, UriKind.Absolute)));
            }

            foreach (string file in droppedFiles)
            {
                string fileName = ImageHandler.GetFileName(file);
                ListBoxPhotos.Items.Add(fileName);
            }

            if (ImageHandler.GetCountBitmapImages() == droppedFiles.Length)
            {
                ListBoxPhotos.SelectedIndex = 0;
            }
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            ReceiveFiles(droppedFiles);
        }

        private void SliderBrightness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (PictureIsSelected())
            {
                SelectedImage.Source = ImageHandler.ChangeBrightness(ListBoxPhotos.SelectedIndex, TrackBarsHandler.GetValueForBrightnessChange(SliderBrightness.Value, ADD_VALUE));
            }
        }

        private void SliderContrast_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (PictureIsSelected())
            {
                SelectedImage.Source = ImageHandler.ChangeContrast(ListBoxPhotos.SelectedIndex, Math.Pow((100.0 + SliderContrast.Value) / 100.0, 2));
            }
        }

        private void SliderRedColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (PictureIsSelected())
            {
                SelectedImage.Source = ImageHandler.ChangeQuantityOfRedColor(ListBoxPhotos.SelectedIndex, TrackBarsHandler.GetValueForRedColorChange(SliderRedColor.Value, ADD_VALUE));
            }
        }

        private void SliderGreenColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (PictureIsSelected())
            {
                SelectedImage.Source = ImageHandler.ChangeQuantityOfGreenColor(ListBoxPhotos.SelectedIndex, TrackBarsHandler.GetValueForGreenColorChange(SliderGreenColor.Value, ADD_VALUE));
            }
        }

        private void SliderBlueColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (PictureIsSelected())
            {
                SelectedImage.Source = ImageHandler.ChangeQuantityOfBlueColor(ListBoxPhotos.SelectedIndex, TrackBarsHandler.GetValueForBlueColorChange(SliderBlueColor.Value, ADD_VALUE)); 
            }
        }

        private void SliderPenSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (DrawingHandlerIsCreated())
                DrawingHandler.ChangePenWidth(SliderPenSize.Value);
        }

        private void DrawArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DrawingHandler.MouseDown(GetPoint(e));
        }

        private System.Drawing.Point GetPoint(MouseEventArgs e)
        {
            System.Drawing.Point point = new System.Drawing.Point()
            {
                X = (int)e.GetPosition(DrawArea).X,
                Y = (int)e.GetPosition(DrawArea).Y,
            };

            return point;
        }

        private void DrawArea_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DrawingHandler.MouseUp();
        }

        private void DrawArea_MouseMove(object sender, MouseEventArgs e)
        {
            DrawingHandler.MouseMove(GetPoint(e));
        }

        private void SliderPenRedColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (DrawingHandlerIsCreated())
                DrawingHandler.ChangePenColor(new RGB((byte)SliderPenRedColor.Value, (byte)SliderPenGreenColor.Value, (byte)SliderPenBlueColor.Value));
        }

        private void SliderPenGreenColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(DrawingHandlerIsCreated())
                DrawingHandler.ChangePenColor(new RGB((byte)SliderPenRedColor.Value, (byte)SliderPenGreenColor.Value, (byte)SliderPenBlueColor.Value));
        }

        private void SliderPenBlueColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (DrawingHandlerIsCreated())
                DrawingHandler.ChangePenColor(new RGB((byte)SliderPenRedColor.Value, (byte)SliderPenGreenColor.Value, (byte)SliderPenBlueColor.Value));
                
        }

        private void TextBoxTurnAngle_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) 
                e.Handled = true;
        }
    }
}
