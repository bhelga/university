class Employee:
    def __init__(self, name="", salary=0, experience=0, hours=0) -> None:
        self.__name = name
        self.__salary = salary
        self.__experience = experience
        self.__hours = hours

    @property
    def name(self):
        return self.__name
    
    @name.setter
    def name(self, name):
        self.__name = name
    
    @property
    def salary(self):
        return self.__salary
    
    @salary.setter
    def salary(self, salary):
        if salary > 0:
            self.__salary = salary
        else:
            print("Value error")
    
    @property
    def experience(self):
        return self.__experience
    
    @experience.setter
    def experience(self, experience):
        if experience > 0:
            self.__experience = experience
        else:
            print("Value error")

    @property
    def hours(self):
        return self.__hours
    
    @hours.setter
    def hours(self, hours):
        if hours > 0:
            self.__hours = hours
        else:
            print("Value error")
    
    def __del__(self):
        print("\nObject ", self.__name,"is deleted")
    
    def show_info(self):
        print(f"EMPLOYEE:\nName : {self.__name}\nSalary : ${self.__salary} per hour\nHours : {self.__hours}\nExperience : {self.__experience} years")

    def calculate_month_salary(self):
        return self.__salary * self.__hours

class Administration(Employee):
    def PRIZE(self):
        return 10
    def __init__(self,  name="", salary=0, experience=0, hours=0, post="", amount_of_assignment=0):
        Employee.__init__(self, name, salary, experience, hours)
        self.post = post
        self.__amount_of_assignment = amount_of_assignment
    
    @property
    def amount_of_assignment(self, amount_of_assignment):
        return self.__amount_of_assignment
    
    @amount_of_assignment.setter
    def amount_of_assignment(self, amount_of_assignment):
        if amount_of_assignment > 0:
            self.__amount_of_assignment = amount_of_assignment
        else:
            print("Value error")
    
    def __del__(self):
        print("\nObject ", self.name,"is deleted")

    def show_info(self):
        print(f"ADMINISTRATION EMPLOYEE:\nName : {self.name}\nPost : {self.post}\nSalary : ${self.salary} per hour\nHours : {self.hours}\nAmount of Assignment : {self.__amount_of_assignment}\nExperience : {self.experience} years")

    def calculate_month_salary(self):
        return self.salary * self.hours + (self.PRIZE() * self.__amount_of_assignment)

class Engineer(Employee):
    def __init__(self,  name="", salary=0, experience=0, hours=0, department_ID=0, post="", project_complexity=0):
        Employee.__init__(self, name, salary, experience, hours)
        self.department_ID = department_ID
        self.post = post
        if(project_complexity <= 5):
            self.project_complexity = project_complexity
            if(project_complexity == 0):
                self.__salary_bonus = 0.5
            elif(project_complexity == 1):
                self.__salary_bonus = 1
            elif(project_complexity == 2):
                self.__salary_bonus = 1.2
            elif(project_complexity == 3):
                self.__salary_bonus = 1.5
            elif(project_complexity == 4):
                self.__salary_bonus = 1.7
            elif(project_complexity == 5):
                self.__salary_bonus = 2
        else:
            raise Exception("Value error!")
        
    @property
    def salary_bonus(self):
        return self.__salary_bonus

    def __del__(self):
        print("\nObject ", self.name,"is deleted")
    
    def show_info(self):
        print(f"ENGINEER EMPLOYEE:\nName : {self.name}\nDepartment ID : {self.department_ID}\nPost : {self.post}\nSalary : ${self.salary} per hour\nHours : {self.hours}\nSalary bonus : {self.salary_bonus}\nExperience : {self.experience} years")
        
    def calculate_month_salary(self):
        return self.salary * self.hours * self.salary_bonus

class Employees:
    def __init__(self, project_name="", list_of_employees=[], director=None) -> None:
        self.project_name = project_name
        self.list_of_employees = list_of_employees
        self.director = director
        if (director == None and len(list_of_employees) != 0):
            self.director = list_of_employees[0]
    
    def __del__(self):
        print("\nProject ", self.project_name,"is deleted")
    
    def calculate_bugget(self):
        sum = 0.0
        for i in self.list_of_employees:
            sum += i.calculate_month_salary()
        return sum
    
    def show_info(self):
        print(f"{self.project_name.upper()}\n\nDirector : {self.director.name}\nEmployees :\n")
        for i in self.list_of_employees:
            print("\n")
            i.show_info()

employee1 = Engineer("Andew", 10000, 10, 168, 100500, "Senior Full Stack Software Engineer (.NET+JS)", 5)
employee2 = Engineer("Helga", 10, 0, 168, 100500, "Trainee .net Software Engineer", 0)
employee3 = Engineer("Stas", 100000, 12, 168, 1000, "Middle Full Stack Software Engineer", 5)
employee4 = Administration("Sveta", 3, 10, 4, "Helpdesk specialist", 2)
employee5 = Administration("Victor", 3, 10, 4, "Director", 2)
employee_list = [employee1, employee2, employee3, employee4, employee5]
project = Employees("MicroRaptor", employee_list, employee5)
project.show_info()
print("\n\nBudget : ", project.calculate_bugget())
    
    
