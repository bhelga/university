import math

def Func(x, i=1):
    if x > 3 and i < 17:
        return (math.sin(x) ** i) + Func(x, i + 1)
    elif x <= 3:
        if i > 5:
            return 15
        else:
            return math.tan(x) + Func(math.tan(x), i + 1)
    else:
        return 0

def correct_float(string):
    while True:
        try:
            point = float(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            return point

a = correct_float("Enter a:\t")
b = correct_float("Enter b:\t")
print("The result is:\t", min(Func(a), Func(b)))