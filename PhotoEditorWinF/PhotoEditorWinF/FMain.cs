using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PhotoEditorWinF
{
    public partial class FMain : Form
    {
        private readonly ImageHandler ImageHandler;
        private readonly DrawingHandler DrawHandler;
        private readonly TrackBarsHandler TrackBarsHandler;

        public FMain()
        {
            InitializeComponent();

            ImageHandler = new ImageHandler();
            DrawHandler = new DrawingHandler(TrackBarPenSize.Value,PicBox.Width,PicBox.Height);
            TrackBarsHandler = new TrackBarsHandler(TrackBarRedColor.Value, TrackBarGreenColor.Value, TrackBarBlueColor.Value,
                                                       TrackBarContrast.Value , TrackBarBrightness.Value);

            saveFileDialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
        }

        private void FMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            ImageHandler.AddImages(droppedFiles);

            foreach (string file in droppedFiles)
            {
                string fileName = ImageHandler.GetFileName(file);
                ListBoxPhotos.Items.Add(fileName);
            }

            if (ImageHandler.GetCountImagesInList() == droppedFiles.Length)
            {
                ListBoxPhotos.SelectedIndex = 0;
            }
        }

        private void FMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void ListBoxPhotos_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedImage();
            TrackBarBrightness.Value = 0;
            TrackBarContrast.Value = 30;
            TrackBarRedColor.Value = 30;
            TrackBarGreenColor.Value = 30;
            TrackBarBlueColor.Value = 30;
            TrackBarsHandler.UpdateValues(TrackBarRedColor.Value, TrackBarGreenColor.Value, TrackBarBlueColor.Value,
                                          TrackBarContrast.Value, TrackBarBrightness.Value);
        }

        private void LoadSelectedImage()
        {
            if (ListBoxPhotos.SelectedIndex != -1)
            {
                PicBox.Image = ImageHandler.GetImageByNumber(ListBoxPhotos.SelectedIndex);
            }
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            if (PicBox.Image != null)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;

                string filePath = saveFileDialog.FileName;

                try
                {
                    PicBox.Image.Save(filePath, ImageFormat.Png);
                }
                catch (Exception exeption)
                {
                    MessageBox.Show(exeption.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TextBoxAngle_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void ButTurn_Click(object sender, EventArgs e)
        {
            if (PicBox.Image != null)
            {
                if (TextBoxAngle.Text.Length != 0)
                {
                    PicBox.Image = ImageHandler.RotateImage(PicBox.Image, Convert.ToInt32(TextBoxAngle.Text));
                }
                else
                {
                    MessageBox.Show("Введите угол поворота!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TrackBarBrightness_Scroll(object sender, EventArgs e)
        {
            if (ListBoxPhotos.SelectedIndex != -1)
            {
               PicBox.Image = ImageHandler.ChangeBtightness(ListBoxPhotos.SelectedIndex, TrackBarsHandler.GetValueForBrightnessChange(TrackBarBrightness.Value + 110));
            }
        }

        private void TrackBarContrast_Scroll(object sender, EventArgs e)
        {
            if (ListBoxPhotos.SelectedIndex != -1)
            {
                PicBox.Image = ImageHandler.ChangeContrast(ListBoxPhotos.SelectedIndex, TrackBarsHandler.GetValueForContrastChange(TrackBarContrast.Value));
            }
        }

        private void TrackBarRedColor_Scroll(object sender, EventArgs e)
        {
            if (ListBoxPhotos.SelectedIndex != -1)
            {
                PicBox.Image = ImageHandler.ChangeQuantityOfRedColor(ListBoxPhotos.SelectedIndex, TrackBarsHandler.GetValueForRedColorChange(TrackBarRedColor.Value));
            }
        }
        private void TrackBarGreenColor_Scroll(object sender, EventArgs e)
        {
            if (ListBoxPhotos.SelectedIndex != -1)
            {
                PicBox.Image = ImageHandler.ChangeQuantityOfGreenColor(ListBoxPhotos.SelectedIndex, TrackBarsHandler.GetValueForGreenColorChange(TrackBarGreenColor.Value));
            }
        }

        private void TrackBarBlue_Scroll(object sender, EventArgs e)
        {
            if (ListBoxPhotos.SelectedIndex != -1)
            {
                PicBox.Image = ImageHandler.ChangeQuantityOfBlueColor(ListBoxPhotos.SelectedIndex, TrackBarsHandler.GetValueForBlueColorChange(TrackBarBlueColor.Value));
            }
        }


        private void ButIncrease_Click(object sender, EventArgs e)
        {
            if (PicBox.Image != null)
            {
                PicBox.Image = ImageHandler.ResizeImage(PicBox.Image, 1.1f);
            }
        }

        private void ButDecrease_Click(object sender, EventArgs e)
        {
            if (PicBox.Image != null)
            {
                PicBox.Image = ImageHandler.ResizeImage(PicBox.Image, 0.9f);
            }
        }

        private void PicBox_MouseDown(object sender, MouseEventArgs e)
        {
            DrawHandler.MouseDown(new Point(e.X,e.Y));
        }

        private void PicBox_MouseUp(object sender, MouseEventArgs e)
        {
            DrawHandler.MouseUp(new Point(e.X, e.Y));
        }

        private void PicBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (PicBox.Image == null)
                return;

            PicBox.Image = DrawHandler.MouseMove(PicBox.Image, new Point(e.X, e.Y));
        }

        private void TrackBarPenSize_Scroll(object sender, EventArgs e)
        { 
            DrawHandler.ChangePenWidth(TrackBarPenSize.Value * 0.5f);
        }
        private void ButChooseColor_Click(object sender, EventArgs e)
        {
            if (ColorDialog.ShowDialog() == DialogResult.Cancel)
                return;

            DrawHandler.ChangePenColor(ColorDialog.Color);
        }
    }
}
