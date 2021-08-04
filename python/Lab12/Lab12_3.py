from abc import ABC, abstractmethod

class Organization(ABC):
    def __init__(self, name="", num_of_employees=0, type_of_activity=[], total_income=0.0) -> None:
        self.name = name
        self.num_of_employees = num_of_employees
        self.type_of_activity = type_of_activity
        self.total_income = total_income


    @abstractmethod
    def get_info(self):
        print(f"ORGANIZATION {self.name.upper()}\n\nNumber of employees : {self.num_of_employees}\nType of activities : {self.type_of_activity}\nTotal income : {self.total_income}\nPayment for taxes : {self.get_payment_for_taxes()}\nProfit : {self.get_profit()}")

    @abstractmethod
    def get_payment_for_taxes(self):
        return 1
    
    @abstractmethod
    def get_profit(self):
        return 1

class Factory(Organization):
    def __init__(self, name, num_of_employees, type_of_activity, total_income, num_of_machines=0) -> None:
        super().__init__(name=name, num_of_employees=num_of_employees, type_of_activity=type_of_activity, total_income=total_income)
        self.num_of_machines = num_of_machines
    
    def get_info(self):
        print(f"ORGANIZATION {self.name.upper()}\n\nNumber of employees : {self.num_of_employees}\nType of activities : {self.type_of_activity}\nTotal income : {self.total_income}\nPayment for taxes : {self.get_payment_for_taxes()}\nProfit : {self.get_profit()}\nNumber of machines : {self.num_of_machines}")

    def get_payment_for_taxes(self):
        return self.num_of_employees * 6000 * 0.22

    def get_profit(self):
        return self.total_income - self.get_payment_for_taxes() - 6000 * self.num_of_employees - self.num_of_machines * 1500
    
    def get_amount_of_production(self):
        return self.num_of_machines * 1000 - self.num_of_employees * 100

class InsuranceCompany(Organization):
    def __init__(self, name, num_of_employees, type_of_activity, total_income, num_of_gen_manader=0) -> None:
        super().__init__(name=name, num_of_employees=num_of_employees, type_of_activity=type_of_activity, total_income=total_income)
        self.number_of_general_manager = num_of_gen_manader
        self.__num_of_order = 0
    
    def get_info(self): 
        print(f"ORGANIZATION {self.name.upper()}\n\nNumber of employees : {self.num_of_employees}\nType of activities : {self.type_of_activity}\nTotal income : {self.total_income}\nPayment for taxes : {self.get_payment_for_taxes()}\nProfit : {self.get_profit()}\nNumber of general managers : {self.number_of_general_manager}\nNumber of order : {self.number_of_order}")

    @property
    def number_of_order(self):
        return self.__num_of_order

    def get_payment_for_taxes(self):
        return self.total_income * 0.18

    def get_profit(self):
        return self.total_income - self.get_payment_for_taxes() - 6000 * self.num_of_employees - 2000 * self.number_of_general_manager

    def order(self, type_of_order):
        for i in self.type_of_activity:
            if type_of_order == i:
                self.__num_of_order += 1


organization1 = Factory("Volkswagen", 55600, ["виготовлення автомобілей"], 100000, 1000)
organization2 = Factory("МАМАЛИГІВСЬКИЙ ГІПСОВИЙ ЗАВОД", 1000, ["гіпсова штукатурка", "фінішна гіпсова шпаклівка", "щебінь гіпсового каменю", "гіпс будівельний"], 50000, 100)
organization3 = InsuranceCompany("Guardian", 500, ["страхування будівель", "страхування авто"], 10000, 25)
organization4 = InsuranceCompany("Oranta", 15000, ["страхування будівель", "страхування авто", "страхування життя"], 1000000, 1000)

organizations = [organization1, organization2, organization3, organization4]

print("ORGANIZATION INFO")
for i in organizations:
    i.get_info()

while(True):
    find = []
    type_of_activities = input("Ви хочете знайти організацію з ... ")
    for i in organizations:
        for j in i.type_of_activity:
            if j == type_of_activities:
                    find.append(i)
    if (len(find) > 0):
        print("Організції, які ви шукали : ")
        for i in find:
            print(i.name)
    else:
        print ("\nУпс... Щось пішло не так! В базі немає організацій з цією спеціалізацією або введені дані некоректні!\n")
        continue
    
    opr = input("\nХочете продовжити пошук? (1 якщо так, будь-що якщо ні)")
    if opr != "1":
        break

