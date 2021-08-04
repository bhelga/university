from enum import Enum

class Car(Enum):
    FUEL = 1
    INTERFACE = 2
    LIGHTING = 3
    WEIGHT = 4
    SEATING = 5
    BODY_STYLE = 6
    SAFETY = 7
    COSTS = 8
    BENEFITS = 9
    ENVIRONMENTAL_IMPACT = 10

def print_enum(element):
    print(f"Name : {element.name}\nValue : {element.value}")

fuel = Car(1)
interface = Car.INTERFACE
costs = Car['COSTS']

print_enum(fuel)
print("Costs value : ", costs.value)
print("Interface name : ", interface.name)
