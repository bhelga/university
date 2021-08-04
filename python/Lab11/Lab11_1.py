import math
import json
import sys
import types

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
    def __init__(self, x = None, y = None, color = None, radius1 = None, radius2 = None) -> None:
        self.x = x
        self.y = y
        self.color = color
        self.radius1 = radius1
        if radius2 == None:
            self.radius2 = None
            self.type = "round"
        else:
            self.radius2 = radius2
            self.type = "ellipse"
        
    @property
    def _list(self):
        return [self.x, self.y, self.radius1, self.radius2, self.color]    
        
    def __getitem__(self, key):
        return self._list[key]
    
    def __iter__(self):
        return iter(self._list)

    def __iadd__(self, other):
        self.x += 1
        self.y += 1
        return self
    
    def __isub__(self, other):
        self.x -= 1
        self.y -= 1
        return self
    
    def __bool__(self, other):
        if self.type == "ellipse":
            return True
        else: return False

    
    def __mull__(self, num):
        self.x *= num
        self.y *= num
        return self

    def __str__(self):
        json = ''
        if (self.type == "round"):
            json = "{\"radius1\" : " + str(self.radius1) + ", \"x\" : " + str(self.x) + ", \"y\" : " + str(self.y) + ", \"color\" : " + str(self.color) + ", \"type\" : \"" + str(self.type) + "\"}"
        else:
            json = "{\"radius1\":" + str(self.radius1) + "\"radius2\":" + str(self.radius2) +  ", \"x\":" + str(self.x) + ", \"y\":" + str(self.y) + ", \"color\":" + str(self.color) + ", \"type\":\"" + str(self.type) + "\"}"
        #stri = "{\"Radius\":" + str(self.radius1) + ", \"X\":" + str(self.x) + ", \"Y\":" + str(self.y) + ", \"Type\":\"" + str(self.type) + "\"}"
        return json

    def to_obj(self, string):
        data = json.loads(string)
        if data['type'] == "round":
            self.__init__(data['x'], data['y'], data['color'], data['radius1'])
        else:
            self.__init__(data["x"], data["y"], data["color"], data["radius1"], data["radius2"])

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
            print(f"Diameter : {self.radius1 * 2}\nCoordinates : ({self.x}, {self.y})")
        else:
            print(f"Diameter1 : {self.radius1 * 2}\nDiameter2 : {self.radius2 * 2}\nCoordinates : ({self.x}, {self.y})")


circle1 = Circle(0, 0, 255, 15.3)
#circle1.set_coord
# print("First circle's coord: ")
# print(circle1.get_coord)
S1 = circle1.get_area()
P1 = circle1.get_circumfence()
type1 = circle1.get_type
print("Object[0] : ", circle1[0])
circle2 = Circle(0, 0, 315, 12, 12)
S2 = circle2.get_area()
P2 = circle2.get_circumfence()
type2 = circle2.get_type

print("//////////////////")
string1 = circle1.__str__()
print("Object to string -> " + string1)
new_circle = Circle()
new_circle.to_obj(string1)

print(f"\nCircle1 -> ({circle1[0]},{circle1[1]})\tCircle1 -> ({circle2[0]},{circle2[1]})")
circle1 += circle1
circle2 -= circle2
print(f"\nCircle1 -> ({circle1[0]},{circle1[1]})\tCircle1 -> ({circle2[0]},{circle2[1]})")

print("First circle : ")
circle1.get_info()
print(f"\nArea : {S1}\nCircumference : {P1}\nType : {type1}")
print("\n\nSecond circle : ")
circle2.get_info()
print(f"\nArea : {S2}\nCircumference : {P2}\nType : {type2}")
print("\n\nString to object : \n")
new_circle.get_info()
