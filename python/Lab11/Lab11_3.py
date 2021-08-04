def correct_int(string):
    while True:
        try:
            point = int(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            return point

class MatrixLong:
    num_vec = 0
    def __init__(self, n = 1, m = 1, param = 0) -> None:
        MatrixLong.count()
        self.m = abs(m)
        self.n = abs(n)
        self.LongArray = [[param for i in range(m)] for i in range(n)]
        self.code_error = 0
        
    def __del__(self):
        print("Object is deleted!")
    
    def input_elements(self):
        for i in range(self.n):
            for j in range(self.m):
                self.LongArray[i][j] = correct_int("Enter your element : ")
    
    def get_elements(self):
        for i in self.LongArray:
            print(i)
    
    def set_param(self, param):
        self.LongArray = [[param for i in range(self.m)] for i in range(self.n)]
    
    def count():
        MatrixLong.num_vec += 1
    
    def show_count():
        print("Number of vectors : " + MatrixLong.num_vec)
    
    @property
    def size(self):
        return self.n * self.n
    
    @property
    def _code_error(self):
        return self.code_error
    
    @_code_error.setter
    def _code_error(self, value):
        self.code_error = value  
        
    def __getitem__(self, i, j = -1):
        if j != -1:
            if 0 <= i < self.n and 0 <= j < self.m:
                self.code_error = 0
                return self.LongArray[i][j]
            else:
                self.code_error = -1
                return "Error!"
        else:
            if(i < self.n * self.m):
                self.code_error = 0
                return self.LongArray[i // self.n][i % self.m]
            else:
                self.code_error = -1
                return "Error!"
    
    def __iadd__(self):
        for i in range(self.n):
            for j in range(self.m):
                self.LongArray[i][j] += 1
        return self
    
    def __isub__(self):
        for i in range(self.n):
            for j in range(self.m):
                self.LongArray[i][j] -= 1
        return self
    
    def __bool__(self):
        if self.n * self.m == 0 and 0 not in self.LongArray:
            return True
        else: return False

    def __invert__(self):
        for i in range(self.n):
            for j in range(self.m):
                self.LongArray[i][j] = ~self.LongArray[i][j]
        return self
    
    # # Арифметичні бінарні операції
    def __add__(self, other):
        if (type(other) == type(0)):
            for i in range(self.n):
                for j in range(self.m):
                    self.LongArray[i][j] += other
        elif type(other) == type(MatrixLong()):
            if self.n * self.n == other.n * other.m:
                for i in range(self.n):
                    for j in range(self.m):
                        self.LongArray[i][j] += other.LongArray[i][j]
            else:
                return "Error!"
        return self.LongArray

    def __sub__(self, other):
        if (type(other) == type(0)):
            for i in range(self.n):
                for j in range(self.m):
                    self.LongArray[i][j] -= other
        elif type(other) == type(MatrixLong()):
            if self.n * self.n == other.n * other.m:
                for i in range(self.n):
                    for j in range(self.m):
                        self.LongArray[i][j] -= other.LongArray[i][j]
            else:
                return "Error!"
        return self.LongArray

    def __mul__(self, other):
        arr = [[0 for i in range(other.m)] for i in range(self.n)]
        if (type(other) == type(0)):
            for i in range(self.n):
                for j in range(self.m):
                    self.LongArray[i][j] *= other
            return self.LongArray
        elif type(other) == type(MatrixLong()):
            if self.m == other.n:
                for i in range(self.n):
                    for j in range(other.m):
                        arr[i][j] = 0
                        for k in range(self.m):
                            arr[i][j] += self.LongArray[i][k] * other.LongArray[k][j]  
            else:
                return "Error!"
        return arr
    
    def __truediv__(self, other):
        arr = [[0 for i in range(other.m)] for i in range(self.n)]
        if (type(other) == type(0)):
            for i in range(self.n):
                for j in range(self.m):
                    self.LongArray[i][j] /= other
            return self.LongArray
        elif type(other) == type(MatrixLong()):
            if self.m == other.n:
                for i in range(self.n):
                    for j in range(other.m):
                        arr[i][j] = 0
                        for k in range(self.m):
                            arr[i][j] += self.LongArray[i][k] / other.LongArray[k][j]  
            else:
                return "Error!"
        return arr
    
    def __mod__(self, other):
        arr = [[0 for i in range(other.m)] for i in range(self.n)]
        if (type(other) == type(0)):
            for i in range(self.n):
                for j in range(self.m):
                    self.LongArray[i][j] %= other
            return self.LongArray
        elif type(other) == type(MatrixLong()):
            if self.m == other.n:
                for i in range(self.n):
                    for j in range(other.m):
                        arr[i][j] = 0
                        for k in range(self.m):
                            arr[i][j] += self.LongArray[i][k] % other.LongArray[k][j]  
            else:
                return "Error!"
        return arr
    
    # # Побітові бінарні операції
    def __or__(self, other):
        if (type(other) == type(0)):
            for i in range(self.n):
                for j in range(self.m):
                    self.LongArray[i][j] |= other
        elif type(other) == type(MatrixLong()):
            if self.n * self.n == other.n * other.m:
                for i in range(self.n):
                    for j in range(self.m):
                        self.LongArray[i][j] |= other.LongArray[i][j]
            else:
                return "Error!"
        return self.LongArray
    
    def __and__(self, other):
        arr = [[0 for i in range(other.m)] for i in range(self.n)]
        if (type(other) == type(0)):
            for i in range(self.n):
                for j in range(self.m):
                    self.LongArray[i][j] &= other
            return self.LongArray
        elif type(other) == type(MatrixLong()):
            if self.m == other.n:
                for i in range(self.n):
                    for j in range(other.m):
                        arr[i][j] = 0
                        for k in range(self.m):
                            arr[i][j] += self.LongArray[i][k] & other.LongArray[k][j]  
            else:
                return "Error!"
        return arr
    
    def __xor__(self, other):
        arr = [[0 for i in range(other.m)] for i in range(self.n)]
        if (type(other) == type(0)):
            for i in range(self.n):
                for j in range(self.m):
                    self.LongArray[i][j] ^= other
            return self.LongArray
        elif type(other) == type(MatrixLong()):
            if self.m == other.n:
                for i in range(self.n):
                    for j in range(other.m):
                        arr[i][j] = 0
                        for k in range(self.m):
                            arr[i][j] += self.LongArray[i][k] ^ other.LongArray[k][j]  
            else:
                return "Error!"
        return arr
    
    def __lshift__(self, other):
        for i in range(self.n):
            for j in range(self.m):
                self.LongArray[i][j] = self.LongArray[i][j] << other
        return self.LongArray
    
    def __rshift__(self, other):
        for i in range(self.n):
            for j in range(self.m):
                self.LongArray[i][j] = self.LongArray[i][j] >> other
        return self.LongArray

    # # Операції рівності та порівняння
    def __eq__(self, other):
        if self.m != other.m or self.n != other.n: return False
        for i in range(self.size):
            for j in range(self.m):
                if self.LongArray[i][j] != other.LongArray[i][j]: return False
        return True
    
    def __ne__(self, other):
        if self.m != other.m or self.n != other.n: return True
        for i in range(self.size):
            for j in range(self.m):
                if self.LongArray[i][j] != other.LongArray[i][j]: return True
        return False
    
    def __lt__(self, other):
        if self.m != other.m or self.n != other.n: return "Error!"
        for i in range(self.n):
            for j in range(self.m):
                if self.LongArray[i][j] >= other.LongArray[i][j]: return False
        return True
    def __le__(self, other):
        if self.m != other.m or self.n != other.n: return "Error!"
        for i in range(self.n):
            for j in range(self.m):
                if self.LongArray[i][j] > other.LongArray[i][j]: return False
        return True
    
    def __gt__(self, other):
        if self.m != other.m or self.n != other.n: return "Error!"
        for i in range(self.n):
            for j in range(self.m):
                if self.LongArray[i][j] <= other.LongArray[i][j]: return False
        return True
    def __ge__(self, other):
        if self.m != other.m or self.n != other.n: return "Error!"
        for i in range(self.n):
            for j in range(self.m):
                if self.LongArray[i][j] < other.LongArray[i][j]: return False
        return True

matrix1 = MatrixLong(2, 2)
print("First matrix is : ")
matrix1.get_elements()
matrix1.input_elements()
print("\nAfter : ")
matrix1.get_elements()

matrix2 = MatrixLong(4, 4, 2)
print("\n\nSecond matrix is : ")
matrix2.get_elements()
matrix2.set_param(5)
print("\nAfter : ")
matrix2.get_elements()
print("Matrix1  + 4 = ", matrix1 + 4)

matrix3 = MatrixLong(4, 2, 3)
print("\n\nThird matrix is : ")
matrix3.get_elements()

temp = matrix2 * matrix3
print(temp)

