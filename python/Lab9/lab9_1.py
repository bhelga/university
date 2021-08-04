from random import randint
def gen_rand_str(alphabet, lenght):
    string = ""
    for i in range(lenght):
        position = randint(0, len(alphabet) - 1)
        string += alphabet[position]
    return string

temp = []
size = randint(1, 10)
i = 0
while i < size:
    temp.append(gen_rand_str("QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm", randint(1,25)))
    i += 1
    
path1 = "D:\\helga\\university\\programming\\university\\python\\lab9\\TF_1.txt"
path2 = "D:\\helga\\university\\programming\\university\\python\\lab9\\TF_2.txt"
sw = open(path1, 'w+', encoding="utf8")
sw2 = open(path2, 'a+', encoding="utf8")
for i in temp:
    sw.write(i + "\n")
sw.close()
sw = open(path1, 'w+', encoding="utf8")
print("*** TF_1 ***\n")
print(*temp, sep="\n")
border = 20
for i in range(size):
    if len(temp[i]) < border:
        stmp = '&'*(border - len(temp[i]))
        temp[i] = f"{temp[i]}{stmp}"
    elif len(temp[i]) > border:
        temp[i] = temp[i][0:border]
        sw2.write(temp[i] + "\n")
for i in temp:
    sw.write(i + "\n")
sw.close()
sw2.close()

print("\nTF_1:")
print(open(path1).read())
print("\nTF_2")
print(open(path2).read())

