class Superhero:
    superhero = ""
    power = ""
    point = 1

    def __init__(self, superhero, power, point):
        self.superhero = superhero
        self.power = power
        self.point = point

    def display_info(self):
        print("Супергерой:\t{0}\nОпис сили:\t{1}\nПотужність:\t{2}\n\n".format(self.superhero, self.power, self.point))

class Film:
    name = ""
    description = ""
    actors = ""
    fpoint = 10

    def __init__(self, name, description, actors, fpoint):
        self.name = name
        self.description = description
        self.actors = actors
        self.fpoint = fpoint

    def display_info(self):
        print("Назва фiльму:\t{0}\nОпис:\t{1}\nГоловнi актори:\t{2}\nОцiнка:\t{3}\n\n".format(self.name, self.description, self.actors, self.fpoint))

def correct_input(start, end, string):
    while True:
        try:
            point = int(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            if start <= point <= end:
                return point
            print("Range error! Try again!\n")
