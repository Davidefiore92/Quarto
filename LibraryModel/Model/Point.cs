using System.Collections.Generic;
using System.Windows.Documents;
using System;

namespace LibraryModel.Model
{
    public class Point : ICloneable
    {
        public int PosX { get; set; }

        public int PosY { get; set; }

        public Point(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }

        public Point()
        {

        }

        public override bool Equals(object obj)
        {
            var point = obj as Point;
            return PosX == point.PosX && PosY == point.PosY;
        }

        public object Clone()
        {
            return new Point()
            {
                PosX = PosX,
                PosY = PosY
            };
        }
    }
}
