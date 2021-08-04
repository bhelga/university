from circle import *

circle1 = Circle(0, 0, 15.3)
circle1.set_coord
print("First circle's coord: ")
print(circle1.get_coord)
S1 = circle1.get_area()
P1 = circle1.get_circumfence()
type1 = circle1.get_type

circle2 = Circle(0, 0, 12, 12)
S2 = circle2.get_area()
P2 = circle2.get_circumfence()
type2 = circle2.get_type

print("First circle : ")
circle1.get_info()
print(f"\nArea : {S1}\nCircumference : {P1}\nType : {type1}")
print("\n\nSecond circle : ")
circle2.get_info()
print(f"\nArea : {S2}\nCircumference : {P2}\nType : {type2}")




