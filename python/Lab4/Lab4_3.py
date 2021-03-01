def correct_float(string):
    while True:
        try:
            point = float(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            return point

def correct_int(string):
    while True:
        try:
            point = int(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            if point > 1:
                return point
            print("Range error! Try again!\n")

def is_parallel_lines(A1, B1, C1, A2, B2, C2):
    if A1 * B2 - A2 * B1 == 0 and C1 != C2:
        print("Лiнiї паралельнi")
        return True
    elif A1 * B2 - A2 * B1 == 0 and C1 == C2:
        print("Лiнiї збiгаються")
        return False
    else:
        print("Лiнiї не паралельнi")
        return False
   
n = correct_int("Введiть кiлькiсть прямих:\t")
flag = False
counter = 0
print("Ax + By + C = 0")
A = []
B = []
C = []

for i in range(0, n):
    print(f"Введiть коортинати {i + 1} прямої")
    A.append(correct_float("Введiть А:\t"))
    B.append(correct_float("Введiть B:\t"))
    C.append(correct_float("Введiть C:\t"))
for i in range(0, n - 1):
    for j in range(i + 1, n):
        print(f"{i + 1} та {j + 1} лiнiї:\t")
        flag = is_parallel_lines(A[i], B[i], C[i], A[j], B[j], C[j])
        if(flag):
            counter += 1

print(f"Серед вказаних n прямих {counter * 2} прямих взаємно паралельнi")