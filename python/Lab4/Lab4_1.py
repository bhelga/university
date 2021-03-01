import math

def volume_of_cylinder(height, diameter):
    return math.pi * ((diameter / 2) ** 2) * height

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

height = correct_int("Enter height:\t")
diameter = correct_int("Enter diameter:\t")
print("The volume of the cylinder is:\t", volume_of_cylinder(height, diameter))