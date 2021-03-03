import random

def correct_int(string):
    while True:
        try:
            point = int(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            if 20 >= point > 0:
                return point
            print("Range error! Try again!\n")

val = correct_int("Введiть розмiрнiсть матрицi:\t")
array = [[random.randint(0, 1) for j in range(val)] for item in range(val)]
max_len = max([len(str(e)) for r in array for e in r])
for row in array:
    print(*list(map('{{:>{length}}}'.format(length=max_len).format, row)))
# for row in array:
#     print(row)

colomnums = []
rows = []

for i in range(val):
    sumCol = 0
    sumRow = 0
    for j in range(val):
        sumCol += array[j][i]
        sumRow += array[i][j]
    colomnums.append(sumCol)
    rows.append(sumRow)
counter = 0
for i in range(val - 1):
    for j in range(i + 1, val):
        if colomnums[i] == colomnums[j] and i != j:
            print(f"Сума елементiв колонки {i + 1} дорiвнює сумi елементiв колонки {j + 1}")
            counter += 1
        if rows[i] == rows[j] and i != j:
            print(f"Сума елементiв рядка {i + 1} дорiвнює сумi елементiв рядка {j + 1}")
            counter += 1

if counter == 0:
    print("Немає однакових сум!")