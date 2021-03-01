from lab2 import Superhero, Film, correct_input

while True:
    first_evil = input("Введiть розмiр першого зла:\t")
    second_evil = input("Введiть розмiр другого зла:\t")
    if first_evil.isdigit() and second_evil.isdigit():
        break

string = "Оцiнiть вiд 1 до 10:\t"


if (float(first_evil) < float(second_evil)):
    s_first = Superhero(input("\nВведiть iм'я супергероя:\t"), input("Опишiть його силу:\t"), correct_input(1, 10, string))
    s_second = Superhero(input("\n\nВведiть iм'я супергероя:\t"), input("Опишiть його силу:\t"), correct_input(1, 10, string))
    s_third = Superhero(input("\n\nВведiть iм'я супергероя:\t"), input("Опишiть його силу:\t"), correct_input(1, 10, string))

    print("Вашi супергерої:\n\n")
    s_first.display_info()
    s_second.display_info()
    s_third.display_info()
else:
    f_first = Film(input("Назва фільму:\t"), input("Опис:\t"), input("Головні актори:\t"), correct_input(1, 10, string))
    f_second = Film(input("\n\nНазва фільму:\t"), input("Опис:\t"), input("Головні актори:\t"), correct_input(1, 10, string))
    f_third = Film(input("\n\nНазва фільму:\t"), input("Опис:\t"), input("Головні актори:\t"), correct_input(1, 10, string))
   
    print("Вашi фiльми:\n")
    f_first.display_info()
    f_second.display_info()
    f_second.display_info()