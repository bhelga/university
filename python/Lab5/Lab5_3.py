import random

val = 20
array = [[random.randint(0, 100) for j in range(val)] for item in range(val)]
# for i in range(val):
#     array.append([])
#     for j in range(val):
#         array[i].append(random.randint(0, 100))
for row in array:
    print(row)

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