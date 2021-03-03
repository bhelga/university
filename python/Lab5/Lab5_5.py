def correct_int(string):
    while True:
        try:
            point = int(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            if point > 0:
                return point
            print("Range error! Try again!\n")

def correct_input(string):
    while True:
        try:
            point = int(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            return point
def correct_array(string):
    while True:
        counter = 0
        st = input("{}".format(string))
        array = []
        for x in st.split():
            try:
                item = int(x)
                #array = [int(x) for x in string.split()]
            except ValueError:
                print("Value error! Try again!\n")
                counter += 1
                #break
            else:
                array.append(item)
        if(counter == 0): break
    return array

value = correct_int("Введiть кiлькiсть рядкiв:\t")
array = [correct_array(f"Введiть елементи [{item+1}] рядка:\t") for item in range(value)]
for row in array:
    print(row)

number = correct_input("Введiть ваше число:\t")
vect = []
for i in range(value):
    counter = 0
    for j in range(len(array[i])):
        if array[i][j] > number:
            counter += 1
    vect.append(counter)
    print(f"Кiльксть бiльших чисел в {i + 1} рядку:\t{vect[i]}")