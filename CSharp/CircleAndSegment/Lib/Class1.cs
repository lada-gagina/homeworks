using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Geom
    {
        public static bool Intersect(int x0, int y0, int r, int x1, int y1, int x2, int y2)
        {

            double a = (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1);
            double b = 2 * ((x1 - x0) * (x2 - x1) + (y1 - y0) * (y2 - y1));
            double c = (x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0) - r * r;
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
