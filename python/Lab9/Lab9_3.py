import msvcrt
from os import read

key = ""
line = ""
path1 = "D:\\helga\\university\\programming\\university\\python\\lab9\\calculator.txt"
path2 = "D:\\helga\\university\\programming\\university\\python\\lab9\\result.txt"
index = 0
oprt = ' '
result = 0.0
while True:
    print("Update your data and press any cay to continue!")
    msvcrt.getch()
    sr = open(path1, 'r', encoding="utf8")
    line = sr.read()
    line = line.replace(" ", "")
    for i in range(len(line)):
        if line[i] == '+' or line[i] == '-' or line[i] == '*' or line[i] == '/':
            oprt = line[i]
            index = i
    if index == 0:
        print("Error! Change data and try again!")
        continue
    first = line[0:index]
    second = line[index + 1:len(line)]
    try:
        first_digit = float(first)
        second_digit = float(second)
    except ValueError:
        print("Value error! Try again!")
        continue
    else:
        try:
            if oprt == '+': result = first_digit + second_digit
            elif oprt == '-': result = first_digit - second_digit
            elif oprt == '*': result = first_digit * second_digit
            elif oprt == '/': result = first_digit / second_digit
            else: 
                print("Something is wrong!")
                continue
        except ZeroDivisionError:
            print("Error! Zero Division! Try again!")
            continue
    sw = open(path2, 'w+', encoding="utf8")
    sw.write(line + f"\nThe result : {result}\n")
    print(f"\nThe result : {result}\n")
    key = input("\nWrite exit to break the program : ")
    if key == "exit": break
