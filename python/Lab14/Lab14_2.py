class Node:
    def __init__(self, data=None, next_node=None):
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
            self.length += 1
        else:
            self.tail.next_node = item 
            self.tail = item
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
    

def reverse(head):
 
    prev = None  
    curr = head
  
    while (curr):
        next = curr.next
        curr.next = prev
        prev = curr
        curr = next
     
    return prev
  
def reverseBetween(head, m, n):
 
    if (m == n):
        return head

    revs = None
    revs_prev = None
    revend = None
    revend_next = None
  
    i = 1
    curr = head
     
    while (curr and i <= n):
        if (i < m):
            revs_prev = curr
  
        if (i == m):
            revs = curr
  
        if (i == n):
            revend = curr
            revend_next = curr.next_node
  
        curr = curr.next_node
        i += 1
 
    revend.next_node = None

    revend = reverse(revs)

    if (revs_prev):
        revs_prev.next_node = revend

    else:
        head = revend
  
    revs.next_node = revend_next
    return head
 

my_list = LinkedList()
f = open(r'D:\\helga\\university\\programming\\university\\c#\\Lab14\\list.txt', 'r')
for i in f.read().split("\n"):
    my_list.append(int(i))
print(*my_list)
element = int(input("Enter your element : "))
min_index = my_list.length
max_index = 0
for i, j in zip(range(my_list.length), range(my_list.length - 1, 0, -1)):
    if (list(my_list)[i] == element):
        min_index = i
    if (list(my_list)[j] == element):
        max_index = j
reverse(my_list.head)
#reverseBetween(my_list.head, min_index, max_index)
print("New linked list : ")
print(*my_list)
