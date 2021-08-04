# 8.1.1
name = input("Введiть назву роману та натиснiть Enter:\t")
author = input("Введiть iм'я автора роману та натиснiть Enter:\t")
print(f"Письменник – автор роману:\t{author} – автор роману {name}")

# 8.1.2
first = input("Введіть перший рядок:\t")
second = input("Введіть другий рядок:\t")
if len(first) < 3 or len(second) < 2:
    print("Error!")
else:
    third = first[1] + first[2] + second[len(second) - 2]
    print("Third is: " + third)

# 8.1.3
word = "голова"
print("Our word:\t" + word)
word += word[4]
word += word[1:4]
word += word[0]
word += word[5]
word = word[6:12]
print("Our final word:\t" + word)

# 8.1.4
user_str = input("Введіть ваш рядок:\t")
user_str = user_str.replace("ах", "ух")
print("Finished:\t" + user_str)