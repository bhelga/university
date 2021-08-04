import re

def create_text(first_text, second_text):
    key = " "
    final = []
    for i in range(len(first_text)):
        for j in range(len(second_text)):
            if first_text[i] == second_text[j]:
                break
            if j == len(second_text) - 1:
                if first_text[i] != key:
                    final.append(first_text[i])
                key = first_text[i]
    return final

first_text = input("Enter first text:\t")
second_text = input("\n\nEnter second text:\t")
first = re.split(r"\W+", first_text)
first = list(filter(None, first))
second = re.split(r"\W+", second_text)
second = list(filter(None, second))
final = create_text(first, second)
final_text = ' '.join(final)
print("\n\nFinal text is:\t" + final_text)