from math import factorial, pow, fabs
import sys

def correct_float(string):
    while True:
        try:
            point = float(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            if point > 0:
                return point
            print("Range error! Try again!\n")

eps = correct_float("Введiть точнiсть:\t")
x = 1
flag = True
sum1 = sum2 = 0.0

while(x <= 5 and flag):
    k = 0
    while(True):
        my_factorial = factorial(k + 2)
        if(my_factorial > sys.maxsize):
            print("Error! More than max-value-size")
            flag = False
            break
        print("factoral: ", my_factorial)
        denominator = (k + 1) * my_factorial
        if(denominator > sys.maxsize):
            print("Error! More than max-value-size")
            flag = False
            break
        print("denominator: ", denominator)
        if denominator == 0:
            print("Error! When k = {} denominator is zero".format(k))
            flag = False
            break
        num = pow(-1, k) * pow(x, k + 2) / denominator
        print("Num: ", num)
        if(num + sum1 > sys.maxsize):
            print("Error! More than max-value-size")
            flag = False
            break
        if(fabs(num) >= eps):
            sum1 += num
            k += 1
        else:
            break
    if(sum1 + sum2 > sys.maxsize):
        print("Error! More than max-value-size")
        break
    sum2 += sum1
    x += 1
    print("k is ", k)

print("The result is:\t", sum2)