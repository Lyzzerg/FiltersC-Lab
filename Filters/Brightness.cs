using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Filters
{
    class Brightness : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int addbrightness=128;
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(Clamp(sourceColor.R + addbrightness, 0, 255), Clamp(sourceColor.G + addbrightness, 0, 255), Clamp(sourceColor.B + addbrightness, 0, 255));
            return resultColor;
        }
    }
}
