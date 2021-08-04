class Node:
    """Клас вершини дерева"""
    def __init__(self, data):
        self.left = None
        self.right = None
        self.data = data

    def insert(self, data):
        """Вставка в дерево"""
        if self.data:
            if data < self.data:
                if self.left is None:
                    self.left = Node(data)
                else:
                    self.left.insert(data)
            elif data > self.data:
                if self.right is None:
                    self.right = Node(data)
                else:
                    self.right.insert(data)
        else:
            self.data = data

    def findval(self, lkpval):
        """Пошук в дереві"""
        if lkpval < self.data:
            if self.left is None:
                return str(lkpval)+" Not Found"
            return self.left.findval(lkpval)
        elif lkpval > self.data:
            if self.right is None:
                return str(lkpval)+" Not Found"
            return self.right.findval(lkpval)
        else:
            print(str(self.data) + ' is found')

    def erase(self, lkpval):
        """Видалення з дерева"""
        if self is None:
            return None

        if lkpval < self.data:
            self.left = self.left.erase(lkpval)
            return self
        elif lkpval > self.data:
            self.right = self.right.erase(lkpval)
            return self

        if self.left is None:
            return self.right
        elif self.right is None:
            return self.left
        else:
            min_data = self.right.find_min().data
            self.data = min_data
            self.right = self.right.erase(min_data)
            return self

    def find_min(self):
        """Пошук вершини з найменшим клучем"""
        if self.left is not None:
            return self.left.find_min()
        else:
            return self

    def print_tree(self):
        """Друк дерева"""
        if self.left:
            self.left.print_tree()
        print(self.data)
        if self.right:
            self.right.print_tree()

if __name__ == '__main__':
    #створення дерева
    root = Node('0_Menu')
    root.insert('1_File')
    root.insert('1_File open')
    root.insert('1_File close')
    root.insert('1_File create')
    root.insert('2_Table create')
    root.insert('2_Table change')
    print(root.findval('1_File'))
    print(root.findval('Table'))
    print("\n___________________________________\n")
    root.print_tree()
    root.erase('1_File create')
    print("\n___________________________________\n")
    root.print_tree()