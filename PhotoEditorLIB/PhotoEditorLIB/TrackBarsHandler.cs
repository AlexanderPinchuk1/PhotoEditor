using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoEditorLIB
{
    public class TrackBarsHandler
    {
        private int R;
        private int G;
        private int B;
        private int Contrast;
        private int Brightness;

        public TrackBarsHandler(int r, int g, int b, int contrast, int brightness)
        {
            R = r;
            G = g;
            B = b;
            Contrast = contrast;
            Brightness = brightness;
        }

        public void UpdateValues(int r, int g, int b, int contrast, int brightness)
        {
            R = r;
            G = g;
            B = b;
            Contrast = contrast;
            Brightness = brightness;
        }

        public int GetValueForRedColorChange(int value)
        {
            if (value < R)
            {
                value *= -1;
            }
            R = Math.Abs(value);

            return value;
        }

        public int GetValueForGreenColorChange(int value)
        {
            if (value < G)
            {
                value *= -1;
            }
            G = Math.Abs(value);

            return value;
        }

        public int GetValueForBlueColorChange(int value)
        {
            if (value < B)
            {
                value *= -1;
            }
            B = Math.Abs(value);

            return value;
        }

        public int GetValueForContrastChange(int value)
        {
            if (value < Contrast)
            {
                value *= -1;
            }
            Contrast = Math.Abs(value);

            return value;
        }

        public int GetValueForBrightnessChange(int value)
        {
            if (value < Brightness)
            {
                value *= -1;
            }
            Brightness = Math.Abs(value);

            return value;
        }
    }
}
