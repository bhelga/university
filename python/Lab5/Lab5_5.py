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

def correct_input(string):
    while True:
        try:
            point = int(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            return point

value = correct_int("Введiть кiлькiсть рядкiв:\t")
array = [ [int(x) for x in input(f"Введiть елементи [{item+1}] рядка:\t").split()] for item in range(value)]
for row in array:
    print(row)

number = correct_input("Введiть ваше число:\t")
vect = []
for i in range(value):
    counter = 0
    for j in range(len(array[i])):
        if array[i][j] > number:
            counter += 1
    vect.append(counter)
    print(f"Кiльксть бiльших чисел в {i + 1} рядку:\t{vect[i]}")