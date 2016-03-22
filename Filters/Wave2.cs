using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Filters
{
    class Wave2:Filters
    {
            protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
            {
                Color sourceColor;
                Color resultColor;
                sourceColor = sourceImage.GetPixel(Clamp((int)((x + 20 * Math.Sin(2 * (x % 30)))), 0, sourceImage.Width - 1), y);
                resultColor = Color.FromArgb(sourceColor.R, sourceColor.G, sourceColor.B);
                return resultColor;
            }
    }
}
