from random import randint

a = 6 
b = 4
matrix = [[randint(0, 100) for item in range(b)] for row in range(a)]
for row in matrix:
    print(row)

max = index = 0
for i in range(b):
    sum = 0
    for j in range(a):
        sum += matrix[j][i]
    if max < sum:
        max = sum
        index = i + 1
print(f"Стовпець {index} мiстить найбiльшу суму елементiв – {max}")