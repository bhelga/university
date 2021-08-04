import math

def correct_float(string):
    while True:
        try:
            point = float(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            if point >= 0:
                return point
            print("Range error! Try again!\n")

class Circle(object):    
    def __init__(self, x = None, y = None, radius1 = None, radius2 = None) -> None:
        self.coord = (x, y)
        self.radius1 = radius1
        if radius2 == None:
            self.type = "round"
        else:
            self.radius2 = radius2
            self.type = "ellipse"
    
    @property
    def set_coord(self):
        x = correct_float("Input x : ")
        y = correct_float("Input y : ")
        self.coord = (x, y)
    @property
    def get_coord(self):
        return self.coord
    @property
    def get_type(self):
        return self.type
    
    
    
    def get_area(self):
        area = 0.0
        if self.type == "round":
            area = math.pi * (self.radius1 ** 2)
        else:
            area = math.pi * self.radius1 * self.radius2
        return area
    
    def get_circumfence(self):
        circumfence = 0.0
        if self.type == "round":
            circumfence = 2 * math.pi * self.radius1
        else:
            circumfence = math.pi * (self.radius1 + self.radius2)
        return circumfence
    
    def get_info(self):
        if self.type == "round":
            print(f"Diameter : {self.radius1 * 2}\nCoordinates : {self.coord}")
        else:
            print(f"Diameter1 : {self.radius1 * 2}\nDiameter2 : {self.radius2 * 2}\nCoordinates : {self.coord}")
