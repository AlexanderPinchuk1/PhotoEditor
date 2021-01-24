using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoEditorWPF
{
    class ImageTrackBarsHandler
    {
        private double R;
        private double G;
        private double B;
        private double Contrast;
        private double Brightness;

        public ImageTrackBarsHandler(double r, double g, double b, double contrast, double brightness)
        {
            R = r;
            G = g;
            B = b;
            Contrast = contrast;
            Brightness = brightness;
        }

        public void UpdateValues(double r, double g, double b, double contrast, double brightness)
        {
            R = r;
            G = g;
            B = b;
            Contrast = contrast;
            Brightness = brightness;
        }

        public double GetValueForRedColorChange(double sliderValue, double value)
        {
            if (sliderValue < R)
            {
                value *= -1;
            }

            if (((int)Math.Abs(sliderValue - R)) < 1)
                value = 0;
            else
                R = Math.Abs(sliderValue);

            return value;
        }

        public double GetValueForGreenColorChange(double sliderValue, double value)
        {
            if (sliderValue < G)
            {
                value *= -1;
            }
            if (((int)Math.Abs(sliderValue - G)) < 1)
                value = 0;
            else
                G = Math.Abs(sliderValue);

            return value;
        }

        public double GetValueForBlueColorChange(double sliderValue, double value)
        {
            if (sliderValue < B)
            {
                value *= -1;
            }

            if (((int)Math.Abs(sliderValue - B)) < 1)
                value = 0;
            else
                B = Math.Abs(sliderValue);

            return value;
        }

        public double GetValueForContrastChange(double sliderValue, double value)
        {
            if (sliderValue < Contrast)
            {
                value *= -1;
            }
            if (((int)Math.Abs(sliderValue - Contrast)) < 1)
                value = 0;
            else
                Contrast = Math.Abs(sliderValue);

            return value;
        }

        public double GetValueForBrightnessChange(double sliderValue, double value)
        {
            if (sliderValue < Brightness)
            {
                value *= -1;
            }

            if (((int)Math.Abs(sliderValue - Brightness)) < 1)
                value = 0;
            else
                Brightness = Math.Abs(sliderValue);

            return value;
        }
    }
}
