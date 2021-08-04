class Stack:
     def __init__(self):
         self.items = []

     def isEmpty(self):
         return len(self.items) == 0

     def push(self, item):
         self.items.append(item)

     def pop(self):
         return self.items.pop()

     def peek(self):
         return self.items[len(self.items)-1]

     def size(self):
         return len(self.items)


stack = Stack()
sequence = "(a-3)*(a+3)/(a-1)"
result = ""
for i in range(len(sequence)):
    if (sequence[i] == '('):
        stack.push(sequence[i])
        print(f"({i}, ", end="")
    if (sequence[i] == ')'):
        if (not stack.isEmpty()):
            stack.pop()
            print(f"{i}) ")
        else:
            result = "Incorrect sequence!"

if stack.isEmpty() and result == "":
    result = "Correct sequence"
else:
    result = "Incorrect sequence"
print(result)