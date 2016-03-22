using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Filters
{
    class Turn:Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor;
            Color resultColor;
            int x0=sourceImage.Width/2, y0=sourceImage.Height/2;
            sourceColor = sourceImage.GetPixel(Clamp(((int)((x -x0)*Math.Cos(Math.PI/2)-(y-y0)*Math.Sin(Math.PI/2)+x0)), 0, sourceImage.Width - 1), Clamp(((int)((x - x0) * Math.Sin(Math.PI / 2) + (y - y0) * Math.Cos(Math.PI / 2) + y0)), 0, sourceImage.Height - 1));
            resultColor = Color.FromArgb(sourceColor.R, sourceColor.G, sourceColor.B);
            return resultColor;
        }
    }
}
