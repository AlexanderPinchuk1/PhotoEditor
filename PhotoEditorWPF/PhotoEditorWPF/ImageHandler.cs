using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows;

namespace PhotoEditorWPF
{
    class ImageHandler
    {
        private readonly List<BitmapImage> BitmapImages;
        private readonly List<byte[]> BitmapsPixelsData;

        private delegate bool CheckByteNumber(int num);

        public ImageHandler()
        {
            BitmapImages = new List<BitmapImage>();
            BitmapsPixelsData = new List<byte[]>();
        }

        public void AddBitmapImage(BitmapImage bitmapImage)
        {
            BitmapImages.Add(bitmapImage);
            BitmapsPixelsData.Add(GetBitmapPixelsData(new WriteableBitmap(bitmapImage)));
        }

        public void ResetBitmapsPixelsData(int num)
        {
            BitmapsPixelsData[num] = GetBitmapPixelsData(new WriteableBitmap(BitmapImages[num]));
        }

        public BitmapImage GetBitmapImageByNumber(int num)
        {
            return BitmapImages[num];
        }

        public int GetCountBitmapImages()
        {
            return BitmapImages.Count;
        }

        public WriteableBitmap ChangeBrightness(int numImage, double value)
        {
            return GetNewWriteableBitmap(numImage, value, IsRGBBytes);
        }

        public WriteableBitmap ChangeQuantityOfRedColor(int numImage, double value)
        {
            return GetNewWriteableBitmap(numImage, value, IsRByte);
        }

        public WriteableBitmap ChangeQuantityOfBlueColor(int numImage, double value)
        {
            return GetNewWriteableBitmap(numImage, value, IsBByte);
        }

        public WriteableBitmap ChangeQuantityOfGreenColor(int numImage, double value)
        {
            return GetNewWriteableBitmap(numImage, value, IsGByte);
        }

        public WriteableBitmap ChangeContrast(int numImage, double value)
        {
            WriteableBitmap result = new WriteableBitmap(BitmapImages[numImage]);
            var bitmapPixelsData = BitmapsPixelsData[numImage];
            var newBitmapPixelsData = new byte[bitmapPixelsData.Length];
            int j = 0;
            while (j < bitmapPixelsData.Length)
            {
                if (IsRGBBytes(j))
                {
                    var imageByte = ((((bitmapPixelsData[j] / 255.0) - 0.5) * value) + 0.5) * 255.0;
                    if (imageByte >= 255)
                        newBitmapPixelsData[j] = bitmapPixelsData[j];
                    else if (imageByte <= 0)
                        newBitmapPixelsData[j] = 0;
                    else
                        newBitmapPixelsData[j] = (byte)(imageByte);
                }
                else
                {
                    newBitmapPixelsData[j] = bitmapPixelsData[j];
                }
                j++;
            }
            result.WritePixels(new Int32Rect(0, 0, (int)result.PixelWidth, (int)result.PixelHeight), newBitmapPixelsData, GetStride(result), 0);

            return result;
        }

        private WriteableBitmap GetNewWriteableBitmap(int numImage, double value, CheckByteNumber checkByteNumber)
        {
            WriteableBitmap result = new WriteableBitmap(BitmapImages[numImage]);

            var bitmapPixelsData = BitmapsPixelsData[numImage];
            var newBitmapPixelsData = GetNewBitmapPixelsData(bitmapPixelsData, value, checkByteNumber);

            BitmapsPixelsData[numImage] = newBitmapPixelsData;
            
            result.WritePixels(new Int32Rect(0, 0, (int)result.PixelWidth, (int)result.PixelHeight), newBitmapPixelsData, GetStride(result), 0);
            return result;
        }

        private bool IsRGBBytes(int num)
        {
            if ((num % 4) != 3)
                return true;
            else
                return false;
        }
 
        private bool IsRByte(int num)
        {
            if ((num % 4) == 2)
                return true;
            else
                return false;

        }

        private bool IsGByte(int num)
        {
            if ((num % 4) == 1)
                return true;
            else
                return false;

        }

        private bool IsBByte(int num)
        {
            if ((num % 4) == 0)
                return true;
            else
                return false;
        }

        private byte[] GetBitmapPixelsData(WriteableBitmap writeableBitmap)
        {
            var height = writeableBitmap.PixelHeight;
            var stride = GetStride(writeableBitmap);

            var bitmapData = new byte[height * stride];
            writeableBitmap.CopyPixels(bitmapData, stride, 0);

            return bitmapData;
        }

        private int GetStride(WriteableBitmap writeableBitmap)
        {
            return writeableBitmap.PixelWidth * ((writeableBitmap.Format.BitsPerPixel + 7) / 8);
        } 

        private byte[] GetNewBitmapPixelsData(byte[] bitmapPixelsData, double value, CheckByteNumber checkByteNumber)
        {
            var newBitmapPixelsData = new byte[bitmapPixelsData.Length];
            int j = 0;
            while (j < bitmapPixelsData.Length)
            {
                if (checkByteNumber(j))
                {
                    if (bitmapPixelsData[j] + value >= 255)                                                                 
                        newBitmapPixelsData[j] = bitmapPixelsData[j];
                    else if (bitmapPixelsData[j] + value <= 0)
                        newBitmapPixelsData[j] = 0;
                    else
                        newBitmapPixelsData[j] = (byte)(bitmapPixelsData[j] + value);
                }
                else
                    newBitmapPixelsData[j] = bitmapPixelsData[j];
                j++;
            }

            return newBitmapPixelsData;
        }

        public string GetFileName(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }
    }
}

