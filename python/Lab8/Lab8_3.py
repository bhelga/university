import re

pattern = r"\b[аеиiоуяюєїАЕИІОУЯЮЄЇ]\w*"
text = input("Enter your text:\t")
temp = re.split(r"\W+", text)
temp = list(filter(None, temp))
print("\n\nChecking...")
i = 0
while i < len(temp):
    if re.fullmatch(pattern, temp[i]):
        print(temp[i])
        temp.remove(temp[i])
    else:
        i += 1
text = ' '.join(temp)
print("\n\nYour checked text:\t" + text)