using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Lib;

namespace CircleAndSegment
{
    public class Create
    {
        int x;
        int y;
        int r;
        int x1;
        int y1;
        int x2;
        int y2;

        static Random rnd = new Random();

        public Create(int x = 0, int y = 0, int r = 0, int x1 = 0, int y1 = 0, int x2 = 0, int y2 = 0)
        {
            this.x = x;
            this.y = y;
            this.r = r;
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public void CreateRandom()
        {
            this.r = rnd.Next(10, 65);
            this.x = rnd.Next(r, 200 - r);
            this.y = rnd.Next(r, 200 - r);
            this.x1 = rnd.Next(0, 200);
            this.y1 = rnd.Next(0, 200);
            this.x2 = rnd.Next(0, 200);
            this.y2 = rnd.Next(0, 200);
        }

        public bool Intersect()
        {
            return Geom.Intersect(x, y, r, x1, y1, x2, y2);
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(new Pen(Color.Aquamarine, 4), x - r, y - r, 2 * r, 2 * r);
            graphics.DrawLine(new Pen(Color.Black, 4), x1, y1, x2, y2);
        }
    }
}
