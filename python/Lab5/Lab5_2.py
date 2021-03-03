import random

val = 20
array = []
for i in range(0, val):
    array.append(random.randint(-11, 20))
print("Your array is:\t", array)
min = array[0]
min_index = 0
max = array[0]
max_index = 0
for i in range(0, val):
    if min > array[i]:
        min = array[i]
        min_index = i
    if max < array[i]:
        max = array[i]
        max_index = i
print(f"\nMin element is: {min}\tPosition:\t[{min_index}]\nMax element is: {max}\tPosition:\t[{max_index}]\n")
array[min_index], array[max_index] = array[max_index], array[min_index]
sum = 0
if min_index > max_index:
    min_index, max_index = max_index, min_index
for i in range(min_index, max_index + 1):
    sum += array[i]
print("New array:\t", array, "\nThe sum is:\t", sum)
