from random import randint
def correct_int(string):
    while True:
        try:
            point = int(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            if 18 >= point > 0:
                return point
            print("Range error! Try again!\n")

carriage = 18
sets = 54
train = [[randint(0, 1) for i in range(sets)] for i in range(carriage)]
for row in train:
    print(row)     
users_carr = correct_int("Ваш вагон:\t")
counter = 0
for i in range(sets):
    if train[users_carr - 1][i] == 0:
        print(f"Мiсце {i + 1} вiльне")
        counter += 1
if counter == 0:
    print("Вiльних мiсць немає!")