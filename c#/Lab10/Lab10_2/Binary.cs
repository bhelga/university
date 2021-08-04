using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10_2
{
    class Binary
    {
        private int binaryNumber;
        public int BinaryNumber
        {
            set
            {
                try
                {
                    this.binaryNumber = Convert.ToInt32(value.ToString(), 2);
                    this.convertStatus = "Successfully converted";
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input string is not a sequence of digits.");
                    this.convertStatus = "Error! String isn't digit!";
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number cannot fit in an Int32.");
                    this.convertStatus = "Error! Cannot fit in format!";
                }
            }
            get
            {
                return this.binaryNumber;
            }
        }

        private string convertStatus;
        public string ConvertStatus { get { return this.convertStatus; } }

        private string binaryStatus;
        public string BinaryStatus { get { return this.binaryStatus; } }

        public Binary()
        {

        }
        public Binary(string binary)
        {
            try
            {
                this.binaryNumber = Convert.ToInt32(binary, 2);
                this.convertStatus = "Successfully converted";
            }
            catch (FormatException)
            {
                Console.WriteLine("Input string is not a sequence of digits.");
                this.convertStatus = "Error! String isn't digit!";
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number cannot fit in an Int32.");
                this.convertStatus = "Error! Cannot fit in format!";
            }
        }
        
        public void InputBinary()
        {
            while (true)
            {
                Console.Write("Input binary number : ");
                var i = 0;
                try
                {
                    this.binaryNumber = Convert.ToInt32(Console.ReadLine(), 2);
                    this.convertStatus = "Successfully converted";
                    i++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input string is not a sequence of digits.");
                    this.convertStatus = "Error! String isn't digit!";
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number cannot fit in an Int32.");
                    this.convertStatus = "Error! Cannot fit in format!";
                }
                if (i != 0) break;
            }
        }

        public int LogicMultiplication(Binary number)
        {
            int result = -48753975;
            if (this.convertStatus == "Successfully converted")
            {
                result = this.binaryNumber & number.binaryNumber;
                this.binaryStatus = "The number is logically multiplied";
            }
            else
            {
                Console.WriteLine("Error! The number is not in correct format!");
            }
            return result;
        }

        public int LogicAddition(Binary number)
        {
            int result = -48753975;
            if (this.convertStatus == "Successfully converted")
            {
                result = this.binaryNumber | number.binaryNumber;
                this.binaryStatus = "The number is logically added";
            }
            else
            {
                Console.WriteLine("Error! The number is not in correct format!");
            }
            return result;
        }

        public int XOR(Binary key)
        {
            int result = -48753975;
            if (this.convertStatus == "Successfully converted")
            {
                result = this.binaryNumber ^ key.binaryNumber;
                this.binaryStatus = "The number is encrypted";
            }
            else
            {
                Console.WriteLine("Error! The number is not in correct format!");
            }
            return result;
        }
        
        public int Inverse()
        {
            int result = -48753975;
            if (this.convertStatus == "Successfully converted")
            {
                result = ~this.binaryNumber;
                this.binaryStatus = "The number is inversed";
            }
            else
            {
                Console.WriteLine("Error! The number is not in correct format!");
            }
            return result;
        }

        public int TwosComplement()
        {
            int result = -48753975;
            if (this.convertStatus == "Successfully converted")
            {
                result = ~this.binaryNumber + 1;
                this.binaryStatus = "Number converted to two's complement";
            }
            else
            {
                Console.WriteLine("Error! The number is not in correct format!");
            }
            return result;
        }
        
        public int LeftShift(int count)
        {
            int result = -48753975;
            if (this.convertStatus == "Successfully converted")
            {
                result = this.binaryNumber << count;
                this.binaryStatus = $"The number shifted left {count} places";
            }
            else
            {
                Console.WriteLine("Error! The number is not in correct format!");
            }
            return result;
        }
       
        public int RightShift(int count)
        {
            int result = -48753975;
            if (this.convertStatus == "Successfully converted")
            {
                result = this.binaryNumber >> count;
                this.binaryStatus = $"The number shifted right {count} places";
            }
            else
            {
                Console.WriteLine("Error! The number is not in correct format!");
            }
            return result;
        }
        
        public int Addition(Binary number)
        {
            int result = -48753975;
            if (this.convertStatus == "Successfully converted")
            {
                result = this.binaryNumber + number.binaryNumber;
                this.binaryStatus = $"The number is added to {number.binaryNumber}";
            }
            else
            {
                Console.WriteLine("Error! The number is not in correct format!");
            }
            return result;
        }
        
        public int Subtraction(Binary number)
        {
            int result = -48753975;
            if (this.convertStatus == "Successfully converted")
            {
                result = this.binaryNumber - number.binaryNumber;
                this.binaryStatus = $"{number.binaryNumber} units are substracted from the number";
            }
            else
            {
                Console.WriteLine("Error! The number is not in correct format!");
            }
            return result;
        }
        
        public int Multiplication(Binary number)
        {
            int result = -48753975;
            if (this.convertStatus == "Successfully converted")
            {
                result = this.binaryNumber * number.binaryNumber;
                this.binaryStatus = $"The number is multiplied by {number.binaryNumber}";
            }
            else
            {
                Console.WriteLine("Error! The number is not in correct format!");
            }
            return result;
        }
        
        public int Division(Binary number)
        {
            int result = -48753975;
            if (this.convertStatus == "Successfully converted")
            {
                result = this.binaryNumber / number.binaryNumber;
                this.binaryStatus = $"The number is divided by {number.binaryNumber}";
            }
            else
            {
                Console.WriteLine("Error! The number is not in correct format!");
            }
            return result;
        }
    }
}
