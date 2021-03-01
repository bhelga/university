print("Допомiжнi iнструкцiї:\n\n1 – пiка\n2 – трефа\n3 – бубна\n4 – чирва\n\n" +
                "6 – шiстка\n7 – сiмка\n8 – вiсiмка\n9 – дев'ятка\n10 – десятка\n11 – валет\n12 – дама\n13 – король\n14 – туз.\n\n" +
                "Натиснiть будь-яку клавiшу, щоб рухатися далi.")
i_suit = int(input("Введiть номер мастi: "))
i_rank = int(input("Введiть номер рангу: "))

s_suit = ""
s_rank = ""

if (i_suit == 1):
    s_suit = "Пiка"
elif (i_suit == 2):
    s_suit = "Трефа"
elif (i_suit == 3):
    s_suit = "Бубна"
elif (i_suit == 4):
    s_suit = "Чирва"
else:
    print("Введенi данi некоректнi!")

if (i_rank == 6):
    s_rank = "шiстка"
elif (i_rank == 7):
    s_rank = "сiмка"
elif (i_rank == 8):
    s_rank = "вiсiмка"
elif (i_rank == 9):
    s_rank = "дев'ятка"
elif (i_rank == 10):
    s_rank = "десятка"
elif (i_rank == 11):
    s_rank = "валет"
elif (i_rank == 12):
    s_rank = "дама"
elif (i_rank == 13):
    s_rank = "король"
elif (i_rank == 14):
    s_rank = "туз"
else:
    print("Введенi данi некоректнi!")

print("Ваша карта:\t{0} {1}".format(s_suit, s_rank))