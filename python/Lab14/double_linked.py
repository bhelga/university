class Node:
    def __init__(self, data=None, next_node=None, prev_node=None):
        self.next_node = next_node
        self.prev_node = next_node
        self.data = data

    def __repr__(self):
        return str(self.data)


class DoubleListIterator:
    def __init__(self, head: Node):
        self.current = head

    def __iter__(self):
        return self

    def __next__(self):
        if not self.current:
            raise StopIteration
        else:
            item = self.current
            self.current = self.current.next_node
            return item


class DoubleList:
    def __init__(self):
        self.head = None
        self.tail = None
        self.length = 0
        
    @property
    def len(self):
        return len(list(iter(self)))

    def append(self, item):
        item = Node(item)
        if self.tail is None:  # length == 0
            self.head = item
            self.tail = self.head
            self.length += 1
        else:
            self.tail.next_node = item
            item.prev_node = self.tail
            self.tail = item
            self.length += 1

    def appstart(self, item):
        item = Node(item, self.head)
        self.head.prev_node = item
        self.head = item

    def insert(self, item, index):
        if index == 0:
            return self.appstart(item)
        elif index == self.len:
            return self.append(item)
        elif index in range(1, self.len):
            temp1, temp2 = self[index - 1], self[index]
            temp1.next_node = Node(item, temp2)
            temp1.next_node.prev_node = temp1
            self.length += 1

    def remove_at_index(self, position):
        start = self.head
        previous = self.head
        position = int(position)
        pos = 0
        while pos != position:
            previous = start
            start = start.next_node
            pos += 1
        try:
            start.next_node.prev_node = previous
            previous.next_node = start.next_node
        except :
            previous.next_node = None

        return previous.data
    
    def removePosition(self, position):
        if position==0 and self.len==1:
            self.head = None
            self.tail = None
            
        elif position==0:
            self.head = self.head.next_node
        if position not in range(len(list(iter(self)))):
            return "Not in range"
        data = self.remove_at_index(position)
        # self.remove(data)
        if data:
            self.length-=1
        return data

    def find(self, value):
        return value in [i.data for i in list(iter(self))]

    def replace_all(self, find, replace):
        for i in iter(self):
            if i.data == find:
                i.data = replace       

    def delete_by_value(self, value):
        for i in iter(self):
            if i.data == value:
                self.removePosition([x.data for x in iter(self)].index(value))
                return True
        return False

    def delete_all_by_value(self, value):
        state = self.delete_by_value(value)
        while state:
            state = self.delete_by_value(value)

    def delete_all(self):
        self.head = None
        self.tail = None
        self.length = 0

    def _new(self, data_list):
        self.delete_all()
        for i in data_list:
            self.append(i)
    
    def sort(self):
        self._new(sorted([x.data for x in list(iter(self))]))
        
    def write_file(self, filename):
        with open(filename, "w") as f:
            for i in list(iter(self)):
                f.write(f"{i}\n")
    def load_file(self, filename):
        with open(filename, "r") as f:
            self._new(f.read().split("\n"))

    def __len__(self):
        return self.length

    def __iter__(self):
        return iter(DoubleListIterator(self.head))

    def __getitem__(self, index):
        if index > self.length:
            return None
        if isinstance(index, int):
            if index in range(self.length):
                return list(self.__iter__())[index]
        elif isinstance(index, slice):
            return [list(self.__iter__())[i] for i in range(len(self))[index]]
        else:
            raise ValueError(f'Wrong value type: {type(index)}')