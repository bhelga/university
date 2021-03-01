from sys import exit
from math import sqrt, pow, fabs

def correct_float(string):
    while True:
        try:
            point = float(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            return point

print("Чи лежить точка всерединi заштрихованої областi?")
R = fabs(correct_float("Введiть R:\t"))
x = correct_float("Введiть координату x:\t")
y = correct_float("Введiть координату y:\t")


if (x > R or x < -R or y > R or y < -R):
    print("Нi!")
    exit()

round_y = sqrt(pow(R, 2) - pow(x, 2))
round_x = sqrt(pow(R, 2) - pow(y, 2))

if (x < -round_x or x > round_x or y < -round_y or y > round_y):
    print("Нi!")
elif(x == -round_x or x == round_x or y == -round_y or y == round_y):
    print("На межi!")
else: 
    if ((x >= 0 and y > 0) or (x < 0 and y <= 0) or (x < 0 and y < x + R)):
        print("Так!")
    elif (x < 0 and y > x + R):
        print("Нi!")
    elif (x > 0 and y < 0):
        print("Нi!")
    else:
        print("На межi!")