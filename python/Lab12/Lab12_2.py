class Computer():
    def __init__(self, CPU_frequency=0.0, number_of_cores=0, memory=0, hard_disk_capacity=0.0) -> None:
        self.CPU_frequency = CPU_frequency
        self.number_of_cores = number_of_cores
        self.memory = memory
        self.hard_disk_capacity = hard_disk_capacity
    
    def get_device_cost(self):
        return ((self.CPU_frequency * self.number_of_cores) / 100 + (self.memory / 80) + (self.hard_disk_capacity / 20))

    def get_device_suitability(self):
        return self.CPU_frequency >= 2000 and self.number_of_cores >= 2 and self.memory >= 2048 and self.hard_disk_capacity >= 320
    
    def get_info(self):
        print(f"COMPUTER\n\nCPU Frequency : {self.CPU_frequency} MHz\nNumber Of Cores : {self.number_of_cores}\nMemory : {self.memory} MB\nHard Disk Capaity : {self.hard_disk_capacity} GB\nCost : ${self.get_device_cost()}\nSituability : {self.get_device_suitability()}\n")

class Laptop(Computer):
    def __init__(self, CPU_frequency=0.0, number_of_cores=0, memory=0, hard_disk_capacity=0.0, battery_duration=0) -> None:
        super().__init__(CPU_frequency, number_of_cores, memory, hard_disk_capacity)
        self.battery_duration = battery_duration

    def get_device_cost(self):
        return (super().get_device_cost() + self.battery_duration) / 10
    
    def get_device_suitability(self):
        return super().get_device_suitability() and self.battery_duration >= 60
    
    def get_info(self):
        print(f"LAPTOP\n\nCPU Frequency : {self.CPU_frequency} MHz\nNumber Of Cores : {self.number_of_cores}\nMemory : {self.memory} MB\nHard Disk Capaity : {self.hard_disk_capacity} GB\nCost : ${self.get_device_cost()}\nBattery Duration : {self.battery_duration} min\nSituability : {self.get_device_suitability()}\n")

class Tablet(Computer):
    def __init__(self, CPU_frequency=0.0, number_of_cores=0, memory=0, hard_disk_capacity=0.0, weight=0.0) -> None:
        super().__init__(CPU_frequency=CPU_frequency, number_of_cores=number_of_cores, memory=memory, hard_disk_capacity=hard_disk_capacity)
        self.weight = weight
    
    def get_device_cost(self):
        return super().get_device_cost() / 10
    
    def get_info(self):
        print(f"TABLET\n\nCPU Frequency : {self.CPU_frequency} MHz\nNumber Of Cores : {self.number_of_cores}\nMemory : {self.memory} MB\nHard Disk Capaity : {self.hard_disk_capacity} GB\nCost : ${self.get_device_cost()}\nWeight : {self.weight} kg\nSituability : {self.get_device_suitability()}\n")
    

def correct_int(string):
    while True:
        try:
            point = int(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            if point > 0:
                return point
            print("Range error! Try again!\n")

def correct_float(string):
    while True:
        try:
            point = float(input("{}".format(string)))
        except ValueError:
            print("Value error! Try again!\n")
        else:
            if point > 0:
                return point
            print("Range error! Try again!\n")

print("YOUR COMPUTER")
cpu1 = correct_float("Enter CPU Frequency (in MHz) : ")
num_of_cores1 = correct_int("Input number of cores : ")
memory1 = correct_int("Input memory (in MB) : ")
hard_disk1 = correct_float("Input Hard Disk Capacity (in GB) : ")
device1 = Computer(cpu1, num_of_cores1, memory1, hard_disk1)

print("\nYOUR LAPTOP")
cpu2 = correct_float("Enter CPU Frequency (in MHz) : ")
num_of_cores2 = correct_int("Input number of cores : ")
memory2 = correct_int("Input memory (in MB) : ")
hard_disk2 = correct_float("Input Hard Disk Capacity (in GB) : ")
battery_duration = correct_int("Input battery duration (in min) : ")
device2 = Laptop(cpu2, num_of_cores2, memory2, hard_disk2, battery_duration)

print("\nYOUR TABLET")
cpu3 = correct_float("Enter CPU Frequency (in MHz) : ")
num_of_cores3 = correct_int("Input number of cores : ")
memory3 = correct_int("Input memory (in MB) : ")
hard_disk3 = correct_float("Input Hard Disk Capacity (in GB) : ")
weight = correct_float("Inout weight (in kg) : ")
device3 = Tablet(cpu3, num_of_cores3, memory3, hard_disk3, weight)

print("\n______________________________________________________\n")

device1.get_info()
device2.get_info()
device3.get_info()
