using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace PhotoEditorLIB
{
    public class ImageHandler
    {
        const double DEG_TO_RAD = 0.017453292519943295;

        private readonly List<Image> Images;
        private readonly List<float[][]> ImageColorMatricesElements;

        public ImageHandler()
        {
            Images = new List<Image>();
            ImageColorMatricesElements = new List<float[][]>();
        }

        public void AddImages(string[] imagePaths)
        {
            foreach (string path in imagePaths)
            {
                Images.Add(Image.FromFile(path));
                ImageColorMatricesElements.Add(InitColorMatrixElements());
            }
        }

        public Image GetImageByNumber(int num)
        {
            return Images[num];
        }

        public void SetImageByNumber(Image image, int num)
        {
            Images[num] = image;
        }

        public int GetCountImagesInList()
        {
            return Images.Count;
        }
        public string GetFileName(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }
        public float[][] InitColorMatrixElements()
        {
            float[][] colorMatrixElements =
{
                    new float[] {1f,0f,0f,0f,0f},
                    new float[] {0f,1f,0f,0f,0f},
                    new float[] {0f,0f,1f,0f,0f},
                    new float[] {0f,0f,0f,1f,0f},
                    new float[] {0.001f, 0.001f, 0.001f, 0f,1f}
            };

            return colorMatrixElements;
        }

        private int NormalizeAngle(int angle)
        {
            angle %= 360;
            if (angle < 0)
                angle += 360;
            return angle;
        }

        public Image RotateImage(Image image, int angle)
        {
            angle = NormalizeAngle(angle);

            if (angle % 90 == 0)
                switch (angle)
                {
                    case 0:
                        return image;
                    case 90:
                        image.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
                        return image;
                    case 180:
                        image.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
                        return image;
                    case 270:
                        image.RotateFlip(System.Drawing.RotateFlipType.Rotate270FlipNone);
                        return image;
                }


            float sin = (float)Math.Sin(angle % 90 * DEG_TO_RAD);
            float cos = (float)Math.Cos(angle % 90 * DEG_TO_RAD);
            float oldWidth = image.Width;
            float oldHeight = image.Height;
            float newWidth = 0f;
            float newHeight = 0f;
            float originX = 0f;
            float originY = 0f;

            if ((angle > 0 && angle < 90) || (angle > 180 && angle < 270))
            {
                newWidth = sin * oldHeight + cos * oldWidth;
                newHeight = sin * oldWidth + cos * oldHeight;

                if (angle < 90)
                {
                    originX = sin * oldHeight;
                    originY = 0f;
                }
                else
                {
                    originX = cos * oldWidth;
                    originY = newHeight;
                }
            }
            else if ((angle > 90 && angle < 180) || (angle > 270 && angle < 360))
            {
                newHeight = sin * oldHeight + cos * oldWidth;
                newWidth = sin * oldWidth + cos * oldHeight;
                if (angle < 180)
                {
                    originX = newWidth;
                    originY = sin * oldHeight;
                }
                else
                {
                    originX = 0f;
                    originY = cos * oldWidth;
                }
            }

            Bitmap bmp = new Bitmap((int)newWidth, (int)newHeight);
            bmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.TranslateTransform(originX, originY);
                gr.RotateTransform(angle);
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.DrawImage(image, new Point(0, 0));
            }

            return bmp;
        }

        public Image ChangeBtightness(int numImage, float value)
        {
            value *= 0.0001f;
            ColorMatrix colorMatrix = GetNewColorMatrixAccordingBrightnessValue(numImage, value);
            Image newImage = ApplyPictureChanges(Images[numImage], colorMatrix);

            return newImage;
        }

        public Image ChangeQuantityOfRedColor(int numImage, float value)
        {
            value *= 0.005f;
            ColorMatrix colorMatrix = GetNewColorMatrixAccordingRedColor(numImage, value);

            return ApplyPictureChanges(Images[numImage], colorMatrix);
        }

        public Image ChangeQuantityOfBlueColor(int numImage, float value)
        {
            value *= 0.005f;
            ColorMatrix colorMatrix = GetNewColorMatrixAccordingBlueColor(numImage, value);

            return ApplyPictureChanges(Images[numImage], colorMatrix);
        }

        public Image ChangeQuantityOfGreenColor(int numImage, float value)
        {
            value *= 0.005f;
            ColorMatrix colorMatrix = GetNewColorMatrixAccordingGreenColor(numImage, value);

            return ApplyPictureChanges(Images[numImage], colorMatrix);
        }

        private ColorMatrix GetNewColorMatrixAccordingBrightnessValue(int numImage, float value)
        {
            ImageColorMatricesElements[numImage][4][0] += value;
            ImageColorMatricesElements[numImage][4][1] += value;
            ImageColorMatricesElements[numImage][4][2] += value;

            return CreateNewColorMatrix(ImageColorMatricesElements[numImage]);
        }

        private ColorMatrix GetNewColorMatrixAccordingRedColor(int numImage, float value)
        {
            ImageColorMatricesElements[numImage][0][0] += value;

            return CreateNewColorMatrix(ImageColorMatricesElements[numImage]);
        }

        private ColorMatrix GetNewColorMatrixAccordingGreenColor(int numImage, float value)
        {
            ImageColorMatricesElements[numImage][1][1] += value;

            return CreateNewColorMatrix(ImageColorMatricesElements[numImage]);
        }

        private ColorMatrix GetNewColorMatrixAccordingBlueColor(int numImage, float value)
        {
            ImageColorMatricesElements[numImage][2][2] += value;

            return CreateNewColorMatrix(ImageColorMatricesElements[numImage]);
        }

        public Image ChangeContrast(int numImage, float value)
        {
            value *= 0.0004f;
            ColorMatrix colorMatrix = GetNewColorMatrixAccordingContrastValue(numImage, value);

            return ApplyPictureChanges(Images[numImage], colorMatrix);
        }

        private ColorMatrix GetNewColorMatrixAccordingContrastValue(int numImage, float value)
        {
            ImageColorMatricesElements[numImage][0][0] += value;
            ImageColorMatricesElements[numImage][1][1] += value;
            ImageColorMatricesElements[numImage][2][2] += value;

            return CreateNewColorMatrix(ImageColorMatricesElements[numImage]);
        }

        private ColorMatrix CreateNewColorMatrix(float[][] colorMatrixElements)
        {
            return new ColorMatrix(colorMatrixElements);
        }

        private Image ApplyPictureChanges(Image image, ColorMatrix colorMatrix)
        {
            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            Bitmap resImage = new Bitmap(Convert.ToInt32(image.Width), Convert.ToInt32(image.Height));

            Graphics graphics = Graphics.FromImage(resImage);
            graphics.DrawImage(image, new Rectangle(0, 0, resImage.Width + 1, resImage.Height + 1), 0, 0, resImage.Width + 1, resImage.Height + 1, GraphicsUnit.Pixel, imageAttributes);

            return resImage;
        }

        public Image ResizeImage(Image image, float scale)
        {
            Bitmap bitmap = new Bitmap((int)(image.Width * scale), (int)(image.Height * scale));

            using var graphics = Graphics.FromImage(bitmap);

            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(image, 0, 0, bitmap.Width, bitmap.Height);

            return bitmap;
        }
    }
}
