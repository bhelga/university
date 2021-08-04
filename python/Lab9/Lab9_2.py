import re

path1 = "D:\\helga\\university\\programming\\university\\python\\lab9\\file_1.txt"
path2 = "D:\\helga\\university\\programming\\university\\python\\lab9\\file_2.txt"
file1 = open(path1, 'r', encoding="utf8")
line = file1.read()
result = re.sub(r'(?i)\b[а-я]\b', "", line)
file2 = open(path2, 'w+', encoding="utf8")
file2.write(result)
file1.close()
file2.close()