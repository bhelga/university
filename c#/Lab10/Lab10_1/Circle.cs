using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10_1
{
    
    class Circle
    {

        private double radius1;
        public double Radius
        {
            get
            {
                return radius1;
            }
            set
            {
                this.radius1 = value;
                this.type = "round";
            }
        }
        public double Radius1
        {
            get
            {
                return radius1;
            }
            set
            {
                this.radius1 = value;
                this.type = "ellipse";
            }
        }

        private double radius2;
        public double Radius2
        {
            get
            {
                return radius2;
            }
            set
            {
                this.radius2 = value;
            }
        }
        
        private double x { get; set; }
        public double X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        private double y { get; set; }
        public double Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        private string type;
        public string Type { get { return this.type; } }

        public Circle()
        {

        }

        public Circle(double radius, double x, double y)
        {
            this.radius1 = radius;
            this.x = x;
            this.y = y;
            this.type = "round";
        }

        public Circle(double radius1, double radius2, double x, double y)
        {
            this.radius1 = radius1;
            this.radius2 = radius2;
            this.x = x;
            this.y = y;
            this.type = "ellipse";
        }

        public double GetArea()
        {
            double area;
            if (this.type == "round")
            {
                area = Math.PI * Math.Pow(this.radius1, 2);
            }
            else
            {
                area = Math.PI * this.radius2 * this.radius1;
            }
            return area;
        }

        public double GetCircumference()
        {
            double carcumference;
            if (this.type == "round")
            {
                carcumference = 2 * Math.PI * this.radius1;
            }
            else
            {
                carcumference = Math.PI * (this.radius1 + this.radius2);
            }
            return carcumference;
        }

        public void GetInfo()
        {
            if (this.type == "round")
            {
                Console.WriteLine($"Diameter : {this.radius1 * 2}\nCoordinates : ({this.x}; {this.y})");
            }
            else
            {
                Console.WriteLine($"Diameter1 : {this.radius1 * 2}\nDiameter2 : {this.radius2 * 2}\nCoordinates : ({this.x}; {this.y})");
            }
        }

        public void InputCoordinates()
        {
            double x, y;
            while (true)
            {
                Console.WriteLine("Input x : ");
                if (!double.TryParse(Console.ReadLine(), out x))
                {
                    Console.WriteLine("Value error!");
                }
                else
                {
                    Console.WriteLine("Input y : ");
                    if (!double.TryParse(Console.ReadLine(), out y))
                    {
                        Console.WriteLine("Value error!");
                    }
                    else break;
                }
            }
            this.x = x;
            this.y = y;
        }
    }
}
