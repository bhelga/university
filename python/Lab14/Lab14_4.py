from linked import LinkedList
my_list = LinkedList()
f = open(r'D:\\helga\\university\\programming\\university\\c#\\Lab14\\list.txt', 'r')
for i in f.read().split("\n"):
    my_list.append(int(i))
f.close()
print(*my_list)
element = int(input("Enter your element : "))
min_index = 0
max_index = 0


for i in range(my_list.length):
    if (my_list[i].data == element):
        min_index = i
        break
for j in range(my_list.length - 1, 0, -1):
    if (my_list[j].data == element):
        max_index = j
        break
my_list = my_list[0:min_index+1] + my_list[min_index+1:max_index][::-1] + my_list[max_index:]
#reverse(my_list.head)
#reverseBetween(my_list.head, min_index, max_index)
print(min_index, " | ", max_index)
print("New linked list : ")
print(*my_list)
list_str = ""
for i in range(len(my_list)):
    list_str += str(my_list[i].data)
    if ((i + 1) % 6 == 0):
        list_str += "\n"

f = open("D:\\helga\\university\\programming\\university\\c#\\Lab14\\new_list_py.txt", 'w')
f.write(list_str)