using System;
using System.Collections.Generic;
using System.Text;

namespace Lab12_4
{
    class Barn : IBuilding
    {
        public double Width { get; set; }
        public double Lenght { get; set; }
        public double Height { get; set; }

        public Barn(double width, double lenght, double height)
        {
            Width = width;
            Lenght = lenght;
            Height = height;
        }

        public double GetArea()
        {
            return this.Width * this.Lenght;
        }

        public double GetVolume()
        {
            return this.Width * this.Lenght * this.Height;
        }
    }
}
