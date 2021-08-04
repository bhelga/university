from random import randint
class Node:
    def __init__(self, data=None, next_node=None):
        self.position = 0
        self.next_node = next_node
        self.data = data

class LinkedListIterator:
    def __init__(self, head: Node):
        self.current = head

    def __iter__(self):
        return self

    def __next__(self):
        if not self.current:
            raise StopIteration
        else:
            item = self.current.data
            self.current = self.current.next_node
            return item

class LinkedList: # abc.Sequence
    def __init__(self):
        self.head = None
        self.tail = None
        self.length = 0
    
    def append(self, item):
        item = Node(item)
        if self.tail is None:  # length == 0
            self.head = item
            self.tail = self.head
            self.tail.next_node = self.head
        else:
            self.tail.next_node = item 
            self.tail = item
            self.tail.next_node = self.head
        item.position = self.length
        self.length += 1
     
    def __len__(self):
        return self.length
    
    def __iter__(self):
        return LinkedListIterator(self.head)
    
    def __getitem__(self, index):
        if isinstance(index, int):
            if index in range(self.length):
                return self.__iter__()[index]
        else:
            raise ValueError(f'Linked list cannot be indexed with values of type {type(index)}')

team1 = LinkedList()
team2 = LinkedList()

for i in range(10):
    team1.append(f"Team 1 : Player {i}")
    team2.append(f"Team 2 : Player {i}")

head1 = team1.head
head2 = team2.head
count = 10
m = randint(1, 9)
n = randint(1, 9)
if (m % 2 == 0 and n %2 == 0): count = 5
schedule = ""
num1 = 0
num2 = 0
print(m, " | ", n)
for i in range(count):
    num1 += m
    num2 += n
    if num1 >= 10: num1 -= 10
    if num2 >= 10: num2 -= 10
    while (head1.position != num1): 
        head1 = head1.next_node
    while (head2.position != num2): 
        head2 = head2.next_node
    schedule += "Play {0} : {1:20} | {2:20}".format(i, head1.data, head2.data)
    schedule += "\n"
print(schedule)

