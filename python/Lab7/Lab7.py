from array import array
from random import randint


def line_search(array_a, array_b):
    key = 3409
    value_a = len(array_a)
    value_b = len(array_b)
    if value_a <= 1 or value_b <= 1:
        print("\nError!")
    print("\n\nSearching elements:")
    for i in range(value_a - 1):
        for j in range(i + 1, value_a):
            if array_a[i] == array_a[j]:
                for k in range(value_b):
                    if array_a[i] == array_b[k]: break
                    if k == value_b - 1:
                        if array_a[i] != key:
                            print(f"{array_a[i]} | ")
                        key = array_a[i]

def binary(array, key, first, last):
    if first > last: return -78
    middle = (first + last) // 2
    middle_value = array[middle]
    if middle_value == key: return middle
    else:
        if middle_value > key:
            return binary(array, key, first, middle - 1)
        else:
            return binary(array, key, middle + 1, last)

def binary_search(array_a, array_b):
    key = 8898
    array_a.sort()
    array_b.sort()
    print("\n\nSearching elements:")
    for i in range(len(array_a) - 1):
        if array_a[i] == key: continue
        for j in range(i + 1, len(array_a)):
            if array_a[i] == array_a[j]:
                if binary(array_b, array_a[i], 0, len(array_b) - 1) == -78:
                    print(f"{array_a[i]} | ")
                    key = array_a[i]
                    break

# def long_com_substr(a, b):
#     x = ' '.join(str(e) for e in a)
#     y = ' '.join(str(e) for e in b)
#     m = len(x)
#     n = len(y)
#     counter = [[0]*(n+1) for x in range(m+1)]
#     longest = 0
#     lcs_set = set()
#     for i in range(m):
#         for j in range(n):
#             if x[i] == y[j]:
#                 c = counter[i][j] + 1
#                 counter[i+1][j+1] = c
#                 if c > longest:
#                     lcs_set = set()
#                     longest = c
#                     lcs_set.add(x[i-c+1:i+1])
#                 elif c == longest:
#                     lcs_set.add(x[i-c+1:i+1])

#     return lcs_set
def long_com_substr(a, b):
    x = ' '.join(str(e) for e in a)
    y = ' '.join(str(e) for e in b)
    m = len(x)
    n = len(y)
    counter = [[0]*(n+1) for x in range(m+1)]
    longest = 0
    lcs_set = []
    for i in range(m):
        for j in range(n):
            if x[i] == y[j]:
                c = counter[i][j] + 1
                counter[i+1][j+1] = c
                if c > longest:
                    lcs_set = []
                    longest = c
                    lcs_set.append(x[i-c+1:i+1])
                elif c == longest:
                    lcs_set.append(x[i-c+1:i+1])

    return lcs_set

# def search_lcs(a, b):
     

#     x = ' '.join(str(e) for e in a)
#     y = ' '.join(str(e) for e in b)
#     flag = True
#     while flag:
#         if (long_com_substr == []): flag = False
#         else:
#             kk = long_com_substr(x, y)
#             k = ''.join(str(e) for e in kk)
#             print(k)
#             yy = y.replace(k, "")
#             print(yy)
#     print(yy)
    


VALUE = 20
array_a = [randint(0, 10) for item in range(VALUE)]
array_b = [randint(0, 10) for item in range(VALUE)]
print("*** Array A ***")
print(array_a)
print("\n\n*** Array B ***")
print(array_b)
print("\n_______________________________________________\n*** Sorted array A ***")
array_a.sort()
print(array_a)
print("\n_______________________________________________\n*** Sorted array B ***")
array_b.sort()
print(array_b)
line_search(array_a, array_b)
binary_search(array_a, array_b)
print("\n\nThe biggest coincidence:\t")
print(*long_com_substr(array_a, array_b))
