import datetime
def correct_float(string):
    while True:
        try:
            point = float(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            if point >= 0:
                return point
            print("Range error! Try again!\n")

class City(object):
    
    def __init__(self, name = None, mayor = None, year_of_founding = None, history = None, geography = None, population = None, culture = []) -> None:
        self.name = name
        self.mayor = mayor
        self.year_of_founding = year_of_founding
        self.history = history
        self.geography = geography
        self.population = population
        self.culture_area = culture
    
    @property
    def get_name(self):
        return self.name
    @property
    def get_mayor(self):
        return self.mayor
    @property
    def get_year_of_founding(self):
        return self.year_of_founding
    @property
    def get_history(self):
        return self.history
    @property
    def get_geography(self):
        return self.geography
    @property
    def get_population(self):
        return self.population
    @property
    def get_culture(self):
        return self.culture_area

    @property
    def set_name(self, value):
        self.name = value
    @property
    def set_mayor(self, value):
        self.mayor = value
    @property
    def set_year_of_founding(self, value):
        self.year_of_founding = value
    @property
    def set_history(self, value):
        self.history = value
    @property
    def set_geography(self, value):
        self.geography = value
    @property
    def set_population(self, value):
        self.population = value
    @property
    def set_culture(self, value):
        self.culture_area = value

    def input_info(self):
        self.name = input("Input city name : ")
        self.mayor = input("Input city mayor : ")
        while True:
            try:
                self.year_of_founding = int(input("Input year of founding : "))
            except ValueError:
                print("Value error! Change your data!")
            else:
                if (self.year_of_founding >= 0): break
                else:
                    print("Range error! Change your data!")
        self.history = input("Input city history : ")
        self.geography = input("Input city location : ")
        while True:
            try:
                self.population = int(input("Input total population : "))
            except ValueError:
                print("Value error! Change your data!")
            else:
                if (self.population >= 0): break
                else:
                    print("Range error! Change your data!")
        print("Input culture (type \"exit\" to break)")
        while True:
            data = input()
            if data == "exit": break
            self.culture_area.append(data)

    
    def get_info(self):
        print(f"City : {self.name}\nMayor : {self.mayor}\nYear of founding : {self.year_of_founding}\nCity history : {self.history}\nCity location : {self.geography}\nThe total population : {self.population}\nSome culture of city :\n")
        i = 1
        for item in self.culture_area:
            print(f"{i}. {item}")
        print("\n")

    def city_age(self):
        now = datetime.datetime.today().year
        age = now - self.year_of_founding
        return age
    
    def get_city_status(self):
        status = ""
        if self.population < 50000:
                status = "small"
        elif self.population < 100000:
            status = "medium"
        elif self.population < 500000:
            status = "large"
        elif self.population < 1000000:
            status = "very large"
        else:
            status = "millionaire"
        print(f"City {self.name} is {status} city")
    
    def get_oldest_city(cities):
        min_age = cities[0].year_of_founding
        k = 0
        for i in range(len(cities)):
            if cities[i].year_of_founding < min_age:
                min_age = cities[i].year_of_founding
                k = i
        city_age = cities[k].city_age()
        print(f"The oldest city is {cities[k].name}. Its age is : {city_age}")
