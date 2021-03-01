from sys import exit
from math import sqrt, pow,fabs

def correct_float(string):
    while True:
        try:
            point = float(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            return point

print("Чи лежить точка всерединi заштрихованої областi?")
R = fabs(correct_float("Введiть |R|:\t"))
header = " {0:<20}| {1:<25}| {2:<15}".format("Номер пострiлу", "Координати пострiлу", "Результат")
#print(header)
output = ""
for i in range(0, 10):
    print(f"Введiть (x, y) вистрiлу {i + 1}:\t")
    x = correct_float("Введiть координату x:\t")
    y = correct_float("Введiть координату y:\t")

    if (x > R or x < -R or y > R or y < -R):
        output = "\n {0:<20}| {1:<25}| {2:<15}".format(i + 1, f"({x}, {y}", "Промах")
        header += output
        print("Нi!")
        continue

    round_y = sqrt(pow(R, 2) - pow(x, 2))
    round_x = sqrt(pow(R, 2) - pow(y, 2))

    if (x < -round_x or x > round_x or y < -round_y or y > round_y):
        print("Нi!")
        output = "\n {0:<20}| {1:<25}| {2:<15}".format(i + 1, f"({x}, {y}", "Промах")
    elif(x == -round_x or x == round_x or y == -round_y or y == round_y):
        print("На межi!")
        output = "\n {0:<20}| {1:<25}| {2:<15}".format(i + 1, f"({x}, {y}", "На межi!")
    else: 
        if ((x >= 0 and y > 0) or (x < 0 and y <= 0) or (x < 0 and y < x + R)):
            print("Так!")
            output = "\n {0:<20}| {1:<25}| {2:<15}".format(i + 1, f"({x}, {y}", "В цiль!")
        elif (x < 0 and y > x + R):
            print("Нi!")
            output = "\n {0:<20}| {1:<25}| {2:<15}".format(i + 1, f"({x}, {y}", "Промах")
        elif (x > 0 and y < 0):
            print("Нi!")
            output = "\n {0:<20}| {1:<25}| {2:<15}".format(i + 1, f"({x}, {y}", "Промах")
        else:
            print("На межi!")
            output = "\n {0:<20}| {1:<25}| {2:<15}".format(i + 1, f"({x}, {y})", "На межi!")
    header += output
print(header)