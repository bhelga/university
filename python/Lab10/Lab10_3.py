from city import *

city1 = City("Kiev", "Vitaliy Klichko", 482, "bla bla", "Ukrain", 2963199, 
            ["Kyiv River Port", "Pivdennyi (Southern) Bridge", "National Taras Shevchenko University", "The monument to St. Volodymyr"])
city2 = City("Chernivtsi", "Roman Klychuk", 1875, "bla bla bla", "Ukrain", 267060, 
            ["Chernivtsi Regional Museum", "Chernivtsi Art Museum", "History and Culture Museum of Bukovinian Jews",
                "Chernivtsi Regional Museum of Folk Architecture and Life", "Yuriy Fedkovich Literary Memorial Museum"])
city3 = City()
city3.input_info()
city_array = [city1, city2, city3]
for city in city_array:
    city.get_info()
    city.get_city_status()
    print("\n\n")

City.get_oldest_city(city_array)

