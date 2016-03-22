using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Filters
{
    class Move:Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor;
            Color resultColor;
            sourceColor = sourceImage.GetPixel(Clamp(x + 50, 0, sourceImage.Width - 1), Clamp(y, 0, sourceImage.Height - 1));
            resultColor = Color.FromArgb(sourceColor.R, sourceColor.G, sourceColor.B);
            return resultColor;
        }
    }
}
