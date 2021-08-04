from random import randint

#Послідовне порівняння сусідніх елементів
def bubble_sort(array, k = 0):
    value = len(array)
    for i in range(value):
        for j in range(value - 1):
            if k == 0 and array[j] > array[j + 1]:
                array[j], array[j + 1] = array[j + 1], array[j]
            elif k == 1 and array[j] < array[j + 1]:
                array[j], array[j + 1] = array[j + 1], array[j]
    return array

#Бульбашка в дві сторони
def coctail_sort(array, k = 0):
    flag = True
    start = 0
    end = len(array) - 1
    while(flag):
        flag = False
        for i in range(start, end):
            if k == 0 and array[i] > array[i + 1]:
                array[i], array[i + 1] = array[i + 1], array[i]
                flag = True
            elif k == 1 and array[i] < array[i + 1]:
                array[i], array[i + 1] = array[i + 1], array[i]
                flag = True
        if flag == False: break
        flag = False
        end -= 1
        flag = False
        for i in range(end - 1, start - 1, -1):
            if k == 0 and array[i] > array[i + 1]:
                array[i], array[i + 1] = array[i + 1], array[i]
                flag = True
            elif k == 1 and array[i] < array[i + 1]:
                array[i], array[i + 1] = array[i + 1], array[i]
                flag = True
        start += 1
    return array

#Послідовно знаходимо місце елемента в масиві і вставляємо 
def insertion_sort(array, k = 0):
    value = len(array)
    for i in range(1, value):
        key = array[i]
        j = i - 1
        while j >= 0:
            if array[j] < key and k == 0:
                break
            elif array[j] > key and k == 1:
                break
            array[j + 1] = array[j]
            j -= 1
        array[j + 1] = key
    return array

#Сортування частинами
def stooge_sort(array, start, end, k = 0):
    if start >= end: return
    if k == 0:
        if array[start] > array[end]:
            array[start], array[end] = array[end], array[start]
        if (end - start) > 1:
            temp = (end - start + 1) / 3
            stooge_sort(array, start, end - temp)
            stooge_sort(array, start + temp, end)
            stooge_sort(array, start, end - temp)
    elif k == 1:
        if array[start] < array[end]:
            array[start], array[end] = array[end], array[start]
        if (end - start) > 1:
            temp = (int)((end - start + 1) / 3)
            stooge_sort(array, start, end - temp, 1)
            stooge_sort(array, start + temp, end, 1)
            stooge_sort(array, start, end - temp, 1)
    return array

#Сортування вставками на відстані
def shell_sort(array, k = 0):
    value = len(array)
    h = value // 2
    while h > 0:
        for i in range(h, value):
            temp = array[i]
            j = i
            if k == 0:
                while j >= h and array[j - h] > temp:
                    array[j] = array[j - h]
                    j -= h
            if k == 1:
                while j >= h and array[j - h] < temp:
                    array[j] = array[j - h]
                    j -= h
            array[j] = temp
        h //= 2
    return array

#Сортування розбиттям і злиттям відсортованих
def merge_sort(array):
    if len(array) > 1:
        mid = len(array) // 2
        left = array[:mid]
        right = array[mid:]

        merge_sort(left)
        merge_sort(right)
        i = 0
        j = 0
        k = 0
        while i < len(left) and j < len(right):
            if left[i] < right[j]:
                array[k] = left[i]
                i += 1
            else:
                array[k] = right[j]
                j += 1
            k += 1
        while i < len(left):
            array[k] = left[i]
            i += 1
            k += 1
        while j < len(right):
            array[k] = right[j]
            j += 1
            k += 1
    return array

#вибираємо знаходження мінімальних елементів і ставленням їх на місце
def selection_sort(array, k = 0):
    if k == 0:
        for i in range(0, len(array) - 1):
            min = i
            j = i + 1
            while j < len(array):
                if array[j] < array[min]:
                    min = j
                array[i], array[min] = array[min], array[i]
                j += 1
    if k == 1:
        for i in range(0, len(array) - 1):
            max = i
            j = i + 1
            while j < len(array):
                if array[j] > array[max]:
                    max = j
                array[i], array[max] = array[max], array[i]
                j += 1
    return array    

#беремо рандомний алгоритм за точку опори і послідовно переставляємо елементи так,
#щоб кожен елемент 1 був е більше елементу 2
def quick_sort(array, left, right):
    i = left
    j = right
    pivot = array[randint(0, right - left) + left]
    while i <= j:
        while array[i] < pivot:
            i += 1
        while array[j] > pivot:
            j -= 1
        if i <= j:
            array[i], array[j] = array[j], array[i]
            i += 1
            j -= 1
        if left < j:
            quick_sort(array, left, j)
        if i < right:
            quick_sort(array, i, right)
    return array

value = 10
array_a = [randint(-49, 50) for item in range(value)]
array_b = [randint(-49, 50) for item in range(value)]

print("*** Array A ***")
print(array_a)

#Bubble Sort
print("\n\n#Bubble Sort:")
print(bubble_sort(array_a))

#Coctail Sort
print("\n\n#Coctail Sort:")
print(coctail_sort(array_a, 1))

#Insertion Sort
print("\n\n#Insertion Sort")
print(insertion_sort(array_a))

#Stooge Sort
print("\n\n#Stooge Sort")
print(stooge_sort(array_a, 0, value - 1, 1))

print("\n_______________________________________________\n*** Array B ***")
print(array_b)

#Shell Sort
print("\n\n#Shell Sort")
print(shell_sort(array_b, 1))

#Merge Sort
print("\n\n#Merge Sort")
print(merge_sort(array_b))

#Selection Sort
print("\n\n#Selection Sort")
print(selection_sort(array_b, 1))

#Quick Sort
print("\n\n#Quick Sort")
print(quick_sort(array_b, 0, len(array_b) - 1))

