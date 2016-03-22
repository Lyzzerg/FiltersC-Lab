using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Filters
{
    class Circuit:MatrixFilter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                }
            return Color.FromArgb(Clamp((int)resultR + 128, 0, 255), Clamp((int)resultG + 128, 0, 255), Clamp((int)resultB + 128, 0, 255));
        }
        public void createcircuitKernel()
        {
            kernel = new float[3, 3];
            kernel[0, 0] =  1;
            kernel[0, 1] =  0;
            kernel[0, 2] =  1;
            kernel[1, 0] =  0;
            kernel[1, 1] = -4;
            kernel[1, 2] =  0;
            kernel[2, 0] =  1;
            kernel[2, 1] =  0;
            kernel[2, 2] =  1;
        }
        public Circuit()
        {
            createcircuitKernel();
        }
    }
}
