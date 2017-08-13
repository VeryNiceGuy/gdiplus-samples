using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace AnimationGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var frames = new Image[60];
            var frameBitmap = new Bitmap(1920, 1920);
            var graphics = Graphics.FromImage(frameBitmap);

            int frameNumber = 0;

            for (int c1 = 0; c1 < 6; ++c1)
            {
                for(int c2 = 0; c2 < 10; ++c2)
                {
                    var originalFrame = Image.FromFile("Wild_idle_300x300_000" + c1.ToString() + c2.ToString() + ".png");
                    var downsizedFrame = new Bitmap(originalFrame, 200, 200);

                    frames[frameNumber++] = downsizedFrame;
                }
            }

            frameNumber = 0;

            for(int r = 0; r < 7; ++r)
            {
                for(int c = 0; c < 9; ++c)
                {
                    if (frameNumber == 60)
                        break;

                    graphics.DrawImage(frames[frameNumber], 200 * c, 200 * r);
                    ++frameNumber;
                }
            }

            frameBitmap.Save("frames.png", ImageFormat.Png);
        }
    }
}
