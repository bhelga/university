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

value = correct_int("Введiть розмiрнiсть масиву:\t")
array = []
sum = 0.0
for i in range(0, value):
    array.append(correct_float(f"Введiть {i + 1} елемент масиву:\t"))
print("Ваш масив:\n", array)
print(f"\nВведiть дiапазон вiд 1 до {value}:")
x = correct_int("Початок:\t")
y = correct_int("Кiнець:\t")
sum = 0.0
for i in range (x - 1, y):
    sum += array[i]
print("Сума:\t", sum)