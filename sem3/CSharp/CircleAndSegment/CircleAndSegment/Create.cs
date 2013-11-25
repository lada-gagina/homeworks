using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Lib;

namespace CircleAndSegment
{
    public class Figures
    {
        public Point circleCenter;
        public int radius;
        public Point lineSegment1;
        public Point lineSegment2;


        static Random rnd = new Random();

        public Figures()
        {
            this.circleCenter = new Point();
            this.lineSegment1 = new Point();
            this.lineSegment2 = new Point();
        }

        public void CreateRandom()
        {
            this.radius = rnd.Next(10, 65);
            this.circleCenter = new Point(rnd.Next(radius, 200 - radius), rnd.Next(radius, 200 - radius));
            this.lineSegment1 = new Point(rnd.Next(0, 200), rnd.Next(0, 200));
            this.lineSegment2 = new Point(rnd.Next(0, 200), rnd.Next(0, 200));
        }

        public bool AreIntersecting()
        {
            return Geom.AreIntersecting(circleCenter, radius, lineSegment1, lineSegment2);
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(new Pen(Color.Aquamarine, 4), circleCenter.X, circleCenter.Y, 2 * radius, 2 * radius);
            graphics.DrawLine(new Pen(Color.Black, 4), lineSegment1.X, lineSegment1.Y, lineSegment2.X, lineSegment2.Y);
        }
    }
}
