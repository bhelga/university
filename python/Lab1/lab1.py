import math

print("First task\n\n")

side = float(input("Type the length of a side:\t"))\
    
perimeter = side * 4
area = side * side

print("The square perimeter is {0} and the area of square is {1}".format(perimeter, area))
    
print("\n__________________________________\n")
print("Second task\n\n")

x1 = float(input("Enter x1:\t"))
x2 = float(input("Enter x2:\t"))

result1 = (6 - math.cos(3 + x1)) / (34 - 9 * math.pow(x2, 3) + x2)

print("The result is: {0}".format(result1))

print("\n__________________________________\n")
print("Second task\n\n")

alpha = float(input("Enter alpha:\t")) * math.pi / 180
result2 = 1 - 0.25 * math.pow(math.sin(2 * alpha), 2) + math.cos(2 * alpha)
result3 = math.pow(math.cos(alpha), 2) + math.pow(math.cos(alpha), 4)

print("The first answer is {0};\nThe second answer is {1}".format(result2, result3))