from linked import LinkedList
from double_linked import DoubleList
import os

l = {"single": LinkedList, "double": DoubleList}[input("Оберіть тип (single/double)")]()

txt = "1) формування списку (згiдно варiанту);\n"\
        + "2)	перегляд елементiв списку;\n"\
        + "3)	визначення кiлькостi елементiв списку;\n"\
        + "4)	перевiрка списку на вiдсутнiсть елементiв;\n"\
        + "5)	вставка елементiв в список;\n"\
        + "6)	видалення елементiв iз списку;\n"\
        + "7)	редагування елементiв списку;\n"\
        + "8)	замiна всiх елементiв списку iз заданим значенням на нове значення введене користувачем програми;\n"\
        + "9)	пошук елементiв в списку за заданим полем;\n"\
        + "10) сортування елементiв списку;\n"\
        + "11) збереження списку у файл;\n"\
        + "12) читання(завантаження) списку iз файлу\n"

while True:
    print(txt)
    choice = input("Оберіть операцію: ") 
    if choice == "1":
        for i in range(int(input("Введіть кількість студентів"))):
            l.append(int(input(f"Введіть сереній бал успішності студента №{i}:\n\t")))
    elif choice == "2":
        print(*list(l))
    elif choice == "3":
        print(l.len)
    elif choice == "4":
        print("Елементи відсутні" if l.len==0 else "Елементи присутні")
    elif choice == "5":
        os.system('cls' if os.name == 'nt' else 'clear')
        print("""
1) на початок, 
2) в кінець,
3) у відповідну позицію
              """)
        ch2 = choice = input("Оберіть операцію: ") 
        if ch2 == "1":
            l.appstart(int(input("Введіть сереній бал успішності студента:\n\t")))
        elif ch2 == "2":
            l.append(int(input("Введіть сереній бал успішності студента:\n\t")))
        elif ch2 == "3":
            index = -1
            while index not in range(l.len+1):
                index = int(input("Введіть індекс:\n\t"))
            l.insert(int(input("Введіть сереній бал успішності студента:\n\t")), index) 
    elif choice == "6":
        os.system('cls' if os.name == 'nt' else 'clear')
        print("""
1) всіх елементів,
2) конкретного елементу, 
3) елементу із заданим значенням, 
4) елементів із заданим значенням
              """)
        ch2 = choice = input("Оберіть операцію: ") 
        if ch2 == "1":
            l.delete_all()
        elif ch2 == "2":
            index = -1
            while index not in range(l.len+1):
                index = int(input("Введіть індекс:\n\t"))
            l.removePosition(index)
        elif ch2 == "3":
            l.delete_by_value(input("Введіть значення: "))
        elif ch2 == "4":  
            l.delete_all_by_value(input("Введіть значення: "))
    elif choice == "7":
        index = -1
        while index not in range(l.len+1):
            index = int(input("Введіть індекс:\n\t"))
        l[index].data = int(input("Введіть нве значення:\n\t")) 
    elif choice == "8":
        l.replace_all(int(input("Старе значення:\n\t")), int(input("Нове значення:\n\t")))
    elif choice == "9":
        print("Знайдено!" if l.find(int(input("Введіть значення\n\t"))) else "Не знайдено")
    elif choice == "10":
        l.sort()
    elif choice == "11":
        l.write_file(input("Введіть шлях/назву файлу:\n\t"))
    elif choice == "12": 
        l.load_file(input("Введіть шлях/назву файлу:\n\t"))
    input("Для продовження натисніть enter")   
    # очистка екрану 
    os.system('cls' if os.name == 'nt' else 'clear')