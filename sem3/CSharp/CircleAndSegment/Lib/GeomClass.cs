using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lib
{
    public class Geom
    {
        public static bool AreIntersecting(Point circleCenter, int r, Point lineSegmentA, Point lineSegmentB)
        {
            int x0 = circleCenter.X;
            int y0 = circleCenter.Y;
            int x1 = lineSegmentA.X;
            int y1 = lineSegmentA.Y;
            int x2 = lineSegmentB.X;
            int y2 = lineSegmentB.Y;

            double a = Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2);
            double b = 2 * ((x1 - x0) * (x2 - x1) + (y1 - y0) * (y2 - y1));
            double c = Math.Pow(x1 - x0, 2) + Math.Pow(y1 - y0, 2) - Math.Pow(r, 2);
            double d = b * b - 4 * a * c;
            if (d < 0) return false;
            else 
            {
                double res1 = (-b + Math.Sqrt(d)) / (2 * a);
                double res2 = (-b - Math.Sqrt(d)) / (2 * a);
                return (res1 >= 0 && res1 <= 1) || (res2 >= 0 && res2 <= 1);
            }

        }
    }
}
