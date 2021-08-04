using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Lab11_1
{
    class Circle
    {
        private int radius1;
        public int Radius
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
        public int Radius1
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

        private int radius2;
        public int Radius2
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

        private int x;
        public int X
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

        private int y;
        public int Y
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

        private int color;
        public int Color
        {
            get
            {
                return color;
            }
            set
            {
                this.color = value;
            }
        }

        private string type;
        public string Type { get { return this.type; } }

        public Circle()
        {

        }

        public Circle(int radius, int x, int y, int color)
        {
            this.radius1 = radius;
            this.x = x;
            this.y = y;
            this.color = color;
            this.type = "round";
        }

        public Circle(int radius1, int radius2, int x, int y, int color)
        {
            this.radius1 = radius1;
            this.radius2 = radius2;
            this.x = x;
            this.y = y;
            this.color = color;
            this.type = "ellipse";
        }

        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return this.x;
                    case 1: return this.y;
                    case 2: return this.radius1;
                    case 3: return this.radius2;
                    case 4: return this.color;
                    default:
                        Console.WriteLine("\nError! ");
                        return 0;
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    case 2:
                        radius1 = value;
                        break;
                    case 3:
                        radius2 = value;
                        break;
                    case 4:
                        color = value;
                        break;
                }
            }
        }
        
        
        public static Circle operator ++(Circle circle)
        {
            circle.x++;
            circle.y++;
            return circle;
        }

        public static Circle operator --(Circle circle)
        {
            circle.x--;
            circle.y--;
            return circle;
        }

        public static bool operator true(Circle circle)
        {
            bool flag = circle.type == "ellipse";
            return flag;
        }

        public static bool operator false(Circle circle)
        {
            bool flag = circle.type != "ellipse";
            return flag;
        }

        public static Circle operator *(Circle circle, int num)
        {
            circle.x = circle.x * num;
            circle.y = circle.y * num;
            return circle;
        }

        public static explicit operator string(Circle circle)
        {
            string json;
            if (circle.type == "round")
            {
                json = "{\"Radius\":" + circle.radius1 + ", \"X\":" + circle.x + ", \"Y\":" + circle.y + ", \"Color\":" + circle.color + ", \"Type\":\"" + circle.type + "\"}";
            }
            else
            {
                json = "{\"Radius1\":" + circle.radius1 + ", \"Radius2\":" + circle.radius2 +  ", \"X\":" + circle.x + ", \"Y\":" + circle.y + ", \"Color\":" + circle.color + ", \"Type\":\"" + circle.type + "\"}";
            }
            //string json = JsonSerializer.Serialize<Circle>(circle);
            return json;
        }

        public static implicit operator Circle(string json)
        {
            Circle circle = JsonSerializer.Deserialize<Circle>(json);
            return circle;
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
                Console.WriteLine($"Diameter : {this.radius1 * 2}\nCoordinates : ({this.x}; {this.y})\nCircle color : {this.color}");
            }
            else
            {
                Console.WriteLine($"Diameter1 : {this.radius1 * 2}\nDiameter2 : {this.radius2 * 2}\nCoordinates : ({this.x}; {this.y})\nCircle color : {color}");
            }
        }

        public void InputCoordinates()
        {
            int x, y;
            while (true)
            {
                Console.WriteLine("Input x : ");
                if (!int.TryParse(Console.ReadLine(), out x))
                {
                    Console.WriteLine("Value error!");
                }
                else
                {
                    Console.WriteLine("Input y : ");
                    if (!int.TryParse(Console.ReadLine(), out y))
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
