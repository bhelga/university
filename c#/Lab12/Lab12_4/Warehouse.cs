using System;
using System.Collections.Generic;
using System.Text;

namespace Lab12_4
{
    class Warehouse : IBuilding
    {
        public double Width { get; set; }
        public double Lenght { get; set; }
        public double Height { get; set; }
        public double NumberOfFloors { get; set; }

        public Warehouse(double width, double lenght, double height, double numberOfFloors)
        {
            Width = width;
            Lenght = lenght;
            Height = height;
            NumberOfFloors = numberOfFloors;
        }

        public double GetArea()
        {
            return this.Width * this.Lenght;
        }

        public double GetVolume()
        {
            return this.Width * this.Lenght * this.Height * this.NumberOfFloors;
        }
    }
}
