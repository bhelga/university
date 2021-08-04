import re

def correct_int(string):
    while True:
        try:
            point = int(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            if point == 0 or point == 1:
                return point
            print("Range error! Try again!\n")

string = ""
sr = open('D:\\helga\\university\\programming\\university\\test.txt', 'r', encoding="utf8")
string = sr.read()
temp = string.split()
print(*temp, sep="\n")

flag = correct_int("\n\nDo you wanna change something(1 for \"Yes\", 0 for \"No\")?\t")
if (flag == 1):
    flag = correct_int("\nDo you wanna replace or remove element(1 for \"Replace\", 0 for \"Remove\")?\t")
    if flag == 1:
        element1 = input("\nEnter the element you want to replace:\t")
        counter = -1
        for i in range(len(temp)):
            if element1 == temp[i]: 
                counter = i

        if counter != -1:
            element2 = input("\nEnter new element:\t")
            temp[counter] = element2
            print("New data:\n")
            print(*temp, sep="\n")
        else: print("Error! Can't find this element!")
    elif flag == 0:
        element = input("Enter the element you wanna remove:\t")
        counter = -1
        for i in range(len(temp)):
            if element == temp[i]: 
                counter = i
        if counter != -1:
            temp.remove(element)
            print("New data:\n")
            print(*temp, sep="\n")
        else: print("Error! Can't find this element!")
        
pattern = r"https?:\/\/[-a-zA-Z0-9@:%_\+.~#?&\/=]{2,256}\.com\b(\/[-a-zA-Z0-9@:%_\+.~#?&\/=]*)?"
counter = 0
print("\n\nChecking...")
i = 0
while i < len(temp):
    if re.fullmatch(pattern, temp[i]):
        counter += 1
        print(temp[i])
        i += 1
    else:
        temp.remove(temp[i])
print("\n\n_______________________________")
print(*temp, sep="\n")
sr.close()
sw = open('D:\\helga\\university\\programming\\university\\result.txt', 'w', encoding="utf8")
for i in temp:
    sw.write(i + "\n")
sw.close()
print("\n\nNumber of elements:\t", counter)