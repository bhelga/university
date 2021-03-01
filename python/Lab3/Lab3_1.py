from math import log, fabs, pow

def correct_int(string):
    while True:
        try:
            point = int(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            if point > 0:
                return point
            print("Range error! Try again!\n")

def correct_float(string):
    while True:
        try:
            point = float(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            if(point != 0):
                return point

a = correct_float("Введiть дiйсне a:\t")
n = correct_int("Введiть натуральне n(>0):\t")
sum = 0

for i in range(n, 0, -1):
    sum += log(fabs(pow(a, i)))

print("The result is:\t", sum)