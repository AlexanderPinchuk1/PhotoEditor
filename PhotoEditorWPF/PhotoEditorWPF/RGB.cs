using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoEditorWPF
{
    class RGB
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public RGB(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}
