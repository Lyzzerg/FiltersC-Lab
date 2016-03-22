using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Filters
{
    class GreyWorld : Filters
    {
        int R1, G1, B1;
        int avg;
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(Clamp(sourceColor.R*avg/R1,0,255), Clamp(sourceColor.G*avg/G1, 0, 255), Clamp(sourceColor.B*avg/B1, 0, 255));
            return resultColor;
        }
        public GreyWorld(Bitmap sourceImage)
        {
            R1 = 0; G1 = 0; B1 = 0;
            for (int i = 0; i < sourceImage.Width; i++)
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    R1 += sourceImage.GetPixel(i, j).R;
                    G1 += sourceImage.GetPixel(i, j).G;
                    B1 += sourceImage.GetPixel(i, j).B;
                }
            R1 /= sourceImage.Width * sourceImage.Height;
            G1 /= sourceImage.Width * sourceImage.Height;
            B1 /= sourceImage.Width * sourceImage.Height;
            avg = (R1 + G1 + B1) / 3;
        }
    }
}
