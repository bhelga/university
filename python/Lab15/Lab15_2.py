class Deque:
 
    def __init__(self):
        self.deque = []
 
    def push_front(self, key):
        self.deque.insert(0, key)
 
    def push_back(self, key):
        self.deque.append(key)
        
    def pop_front(self):
        if self.deque == []:
            print("Error!")
        else:
            return self.deque.pop(0)

    def pop_back(self):
        if self.deque == []:
            print("Error!")
        else:
            return self.deque.pop()
 
    def front(self):
        if self.deque == []:
            print("Error!")
        else:
            return self.deque[0]
 
    def back(self):
        if self.deque == []:
            print("Error!")
        else:
            return self.deque[len(self.deque) - 1]
 
    def clear(self):
        self.deque = []
        return self.deque
 
    def size(self):
        return len(self.deque)
    
    def print_deque(self):
        print(*self.deque)

deque = Deque()
size = 10

for i in range(size//2):
    deque.push_back(i)
    deque.push_front(i + size)

print("Our deque : ")
deque.print_deque()
print(f"\n\nDeque front : {deque.front()}\nDeque back : {deque.back()}")
for i in range(size//2):
    print("\n\nPop back : ")
    deque.pop_back()
    deque.print_deque()
    print("Pop front : ")
    deque.pop_front()
    deque.print_deque()

deque.pop_back()

deque.push_back(100)
deque.push_front(99)
print("Deque to clear : ")
deque.print_deque()
print(f"\n\nDeque count : {deque.size()}\n\nDeleting...")
deque.clear()
print(f"\n\nDeque count : {deque.size()}")
