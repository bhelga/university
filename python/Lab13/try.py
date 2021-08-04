from collections import namedtuple
import random

def good_insurers(insurers):
    avarage = 0.0
    for i in insurers:
        avarage += i.number_of_agreements
    avarage /= 7
    ary = []
    print("Страховики", end=" ")
    for i in insurers:
        if i.number_of_agreements > avarage:
            ary.append(i)
            print(i.last_name, end=", ")
    print(" в цьому місяці найкращі!")

    

Insurer = namedtuple('Insurer', 'last_name mobile_phone address number_of_agreements')
insurer1 = Insurer("Melnuk", "0685453956", "6 Beatty Rise", 15)
insurer2 = Insurer("Shevchencko", "0539563407", "Fuglsangshaven 19, 1. sal. th.", 20)
insurer3 = Insurer("Voiko", "0995674967", "Kjeldsen Vej 55", 13)
insurer4 = Insurer("Kovalenko", "0675754965", "Kaivolakaarto 7", 18)
insurer5 = Insurer("Bondarenko", "0985354956", "12454 Dwight Keys", 10)
insurer6 = Insurer("Tkachenko", "0976754978", "696 Pete Avenue Apt. 151", 17)
insurer7 = Insurer("Oliynuk", "0986768967", "18572 Wunsch Keys", 9)


insurers = (insurer1, insurer2, insurer3, insurer4, insurer5, insurer6, insurer7)
good_insurers(insurers)
insurers = list(insurers)
for i in range(len(insurers)):
    insurers[i] = insurers[i]._replace(number_of_agreements=random.randint(1, 30))
    print(*insurers[i], sep="\n", end="\n\n")
insurers = tuple(insurers)
#print(*insurers)
good_insurers(insurers)