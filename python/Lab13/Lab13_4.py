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

def correct_float(string):
    while True:
        try:
            point = float(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            if(point != 0):
                return point

def show_tuple(tuple):
    print(f"\nStreet {tuple[0]} :\n\nLenght : {tuple[1]}\nNum of buildings : {tuple[2]}\nLocation : {tuple[3]}\n")

n = correct_int("Enter amount of streets in your city : ")
city = []
for i in range(n):
    name = input("Street name : ")
    lenght = correct_float("Street len : ")
    num_of_building = correct_int("Num of building : ")
    location = input("Street location : ")
    city.append((name, lenght, num_of_building, location))

avarage = 0.0
print("\n\n-------------------CITY STREETS-------------------")
for i in city:
    show_tuple(i)
    avarage += i[1]
avarage /= n

counter = 0
for i in city:
    if i[1] > avarage:
        print(f"Street {i[0]} need double water")
        counter += 1
print("\nAmount of streets, which need double water : ", counter)