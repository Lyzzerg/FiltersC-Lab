using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Filters
{
    class Sepia:Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int koeffSepia=2;
            Color sourceColor = sourceImage.GetPixel(x, y);
            int Intensity = (int)(0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B);
            Color resultColor = Color.FromArgb(Clamp(Intensity + 2 * koeffSepia, 0, 255), Clamp((int)(Intensity + 0.5 * koeffSepia),0,255), Clamp(Intensity-1*koeffSepia,0,255));
            return resultColor;
        }
    }
}
