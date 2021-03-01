import math
def correct_float(string):
    while True:
        try:
            point = float(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            if(point > 0):
               return point
            print("Range error! Try again!")

weight = correct_float("Введiть вагу зернятка в кг:\t")
sum = 0
for i in range(0, 64):
    cell = int(math.pow(2, i))
    sum += cell
    print(f"На клiтинцi {i+1} – {cell} зерен")
weight *= sum
print(f"Всього:\t{sum}\nВага:\t{weight} кг")