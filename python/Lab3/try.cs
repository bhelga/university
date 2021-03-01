while (x <= 5 && flag)
            {
                k = 0;
                while (true)
                {
                    checked
                    {
                        try
                        {
                            factorial = Factorial(k + 2);
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Error! More than max-value-size");
                            flag = false;
                            break;
                        }
                    }
                    //factorial = Factorial(k + 2);
                    if (factorial == 0)
                    {
                        flag = false;
                        break;
                    }
                    Console.WriteLine("factorial " + factorial);
                    //if (((k + 1) * factorial) >= long.MaxValue || ((k + 1) * factorial) <= long.MinValue)
                    //{
                    //    Console.WriteLine("Error! Denominator more than max-value-size");
                    //    flag = false;
                    //    break;
                    //}
                    flag = CheckedMethod(((k + 1) * factorial));
                    denominator = (k + 1) * factorial;
                    Console.WriteLine("denominator " + denominator);
                    if (denominator == 0)
                    {
                        Console.WriteLine($"Error! When k = {k} denominator is zero");
                        flag = false;
                        break;
                    }
                    else if (Math.Pow(-1, k) * Math.Pow(x, k + 2) / denominator >= double.MaxValue || Math.Pow(-1, k) * Math.Pow(x, k + 2) / denominator <= double.MinValue)
                    {

                    }
                    num = Math.Pow(-1, k) * Math.Pow(x, k + 2) / denominator;
                    Console.WriteLine("num " + num);
                    if (num + sum1 > double.MaxValue || num + sum1 < double.MinValue)
                    {
                        Console.WriteLine("Error! Sum is more than max-value-size");
                        flag = false;
                        break;
                    }
                    if (Math.Abs(num) >= eps)
                    {
                        sum1 += num;
                        k++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (sum1 + sum2 > double.MaxValue)
                {
                    Console.WriteLine("Error! More than max-value-size");
                    break;
                }
                sum2 += sum1;
                x++;
                Console.WriteLine($"k is {k}");
            }