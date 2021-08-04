def correct_int(string):
    while True:
        try:
            point = int(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            return point

class VectorLong:
    num_vec = 0
    def __init__(self, size = 1, param = 0) -> None:
        VectorLong.count()
        self.size = abs(size)
        self.LongArray = [param for i in range(size)]
        self.__code_error = 0
        
    def __del__(self):
        print("Object is deleted!")
    
    def input_elements(self):
        for i in range(self.size):
            self.LongArray[i] = correct_int("Enter your element : ")
    
    def get_elements(self):
        print(self.LongArray)
    
    def set_param(self, param):
        self.LongArray = [param for i in range(self.size)]
    
    def count():
        VectorLong.num_vec += 1
    
    def show_count():
        print("Number of vectors : " + VectorLong.num_vec)
    
    @property
    def _size(self):
        return self.size
    
    @property
    def code_error(self):
        return self.__code_error
    
    @code_error.setter
    def code_error(self, value):
        self.__code_error = value  
        
    def __getitem__(self, key):
        if 0 <= key < self.size:
            self.__code_error = 0
            return self.LongArray[key]
        else:
            self.__code_error = -1
            return "Error!"
    
    def __iadd__(self):
        for i in range(self.size):
            self.LongArray[i] += self.LongArray[i]
        return self
    
    def __isub__(self):
        for i in range(self.size):
            self.LongArray[i] -= self.LongArray[i]
        return self
    
    def __bool__(self):
        if self.size == 0 and 0 not in self.LongArray:
            return True
        else: return False
    def __invert__(self):
        for i in range(self.size):
            self.LongArray[i] = ~self.LongArray[i]
        return self
    
    # Арифметичні бінарні операції
    def __add__(self, other):
        if (type(other) == type(0)):
            for i in range(self.size):
                self.LongArray[i] += other
        elif type(other) == type(VectorLong()):
            if self.size == other.size:
                for i in range(self.size):
                    self.LongArray[i] += other.LongArray[i]
            else:
                return "Error!"
        return self.LongArray

    def __sub__(self, other):
        if (type(other) == type(0)):
            for i in range(self.size):
                self.LongArray[i] -= other
        elif type(other) == type(VectorLong()):
            if self.size == other.size:
                for i in range(self.size):
                    self.LongArray[i] -= other.LongArray[i]
            else:
                return "Error!"
        return self.LongArray

    def __mul__(self, other):
        if (type(other) == type(0)):
            for i in range(self.size):
                self.LongArray[i] *= other
        elif type(other) == type(VectorLong()):
            if self.size == other.size:
                for i in range(self.size):
                    self.LongArray[i] *= other.LongArray[i]
            else:
                return "Error!"
        return self.LongArray
    
    def __truediv__(self, other):
        if (type(other) == type(0)):
            for i in range(self.size):
                self.LongArray[i] /= other
        elif type(other) == type(VectorLong()):
            if self.size == other.size:
                for i in range(self.size):
                    self.LongArray[i] /= other.LongArray[i]
            else:
                return "Error!"
        return self.LongArray
    
    def __mod__(self, other):
        if (type(other) == type(0)):
            for i in range(self.size):
                self.LongArray[i] %= other
        elif type(other) == type(VectorLong()):
            if self.size == other.size:
                for i in range(self.size):
                    self.LongArray[i] %= other.LongArray[i]
            else:
                return "Error!"
        return self.LongArray
    
    # Побітові бінарні операції
    def __or__(self, other):
        if (type(other) == type(0)):
            for i in range(self.size):
                self.LongArray[i] |= other
        elif type(other) == type(VectorLong()):
            if self.size == other.size:
                for i in range(self.size):
                    self.LongArray[i] |= other.LongArray[i]
            else:
                return "Error!"
        return self.LongArray
    
    def __and__(self, other):
        if (type(other) == type(0)):
            for i in range(self.size):
                self.LongArray[i] &= other
        elif type(other) == type(VectorLong()):
            if self.size == other.size:
                for i in range(self.size):
                    self.LongArray[i] &= other.LongArray[i]
            else:
                return "Error!"
        return self.LongArray
    
    def __xor__(self, other):
        if (type(other) == type(0)):
            for i in range(self.size):
                self.LongArray[i] ^= other
        elif type(other) == type(VectorLong()):
            if self.size == other.size:
                for i in range(self.size):
                    self.LongArray[i] ^= other.LongArray[i]
            else:
                return "Error!"
        return self.LongArray
    
    def __lshift__(self, other):
        for i in range(self.size):
            self.LongArray[i] = self.LongArray[i] << other
        return self.LongArray
    
    def __rshift__(self, other):
        for i in range(self.size):
            self.LongArray[i] = self.LongArray[i] >> other
        return self.LongArray

    # Операції рівності та порівняння
    def __eq__(self, other):
        if self.size != other.size: return False
        for i in range(self.size):
            if self.LongArray[i] != other.LongArray[i]: return False
        return True
    
    def __ne__(self, other):
        if self.size != other.size: return True
        for i in range(self.size):
            if self.LongArray[i] != other.LongArray[i]: return True
        return False
    
    def __lt__(self, other):
        if self.size != other.size: return "Error!"
        for i in range(self.size):
            if self.LongArray[i] >= other.LongArray[i]: return False
        return True
    def __le__(self, other):
        if self.size != other.size: return "Error!"
        for i in range(self.size):
            if self.LongArray[i] > other.LongArray[i]: return False
        return True
    
    def __gt__(self, other):
        if self.size != other.size: return "Error!"
        for i in range(self.size):
            if self.LongArray[i] <= other.LongArray[i]: return False
        return True
    def __ge__(self, other):
        if self.size != other.size: return "Error!"
        for i in range(self.size):
            if self.LongArray[i] < other.LongArray[i]: return False
        return True
        
vector1 = VectorLong(4)
print("First vector is : ")
vector1.get_elements()
vector1.input_elements()
print("\nAfter : ")
vector1.get_elements()

vector2 = VectorLong(4, 2)
print("\n\nSecond vector is : ")
vector2.get_elements()
vector2.set_param(5)
print("\nAfter : ")
vector2.get_elements()
print("Vector1  + 4 = ", vector1 + 4)

