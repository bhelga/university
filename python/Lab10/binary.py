class Binary():
    def __init__(self, number = None) -> None:
        if number != None:
            try:
                for i in number:
                    if i != "1" and i != "0":
                        raise ValueError("Input string is not a sequence of digits.")
                self.binary_number = int(number, 2)
                self.convert_status = "Successfully converted"
            except ValueError:
                print("Input string is not a sequence of digits.")
                self.convert_status = "Error! String isn't a binary digit!"
            except OverflowError:
                print("The number cannot fit in an bin.")
                self.convert_status = "Error! Cannot fit in format!"
        else: self.convert_status = None
        self.binary_status = None
        
    
    @property
    def get_binary_status(self):
        return self.binary_status 
    @property
    def get_convert_status(self):
        return self.convert_status 

    def input_binary(self):
        while(True):
            try:
                number = input("Input binary number : ")
                for i in number:
                    if i != "1" and i != "0":
                        raise ValueError("Input string is not a sequence of digits.")
                self.binary_number = int(number, 2)
                self.convert_status = "Successfully converted"
            except ValueError:
                print("Input string is not a sequence of digits.")
                self.convert_status = "Error! String isn't digit!"
            except OverflowError:
                print("The number cannot fit in an bin.")
                self.convert_status = "Error! Cannot fit in format!"
            else: break
    
    def logic_multiplication(self, number):
        result = -48753975
        if self.convert_status == "Successfully converted":
            result = self.binary_number & number.binary_number
            self.binary_status = "The number is logically multiplied"
            return result
        else:
            print("Error! The number is not in correct format!")
    
    def logic_addition(self, number):
        result = -48753975
        if self.convert_status == "Successfully converted":
            result = self.binary_number | number.binary_number
            self.binary_status = "The number is logically added"
            return result
        else:
            print("Error! The number is not in correct format!")
    
    def XOR(self, key):
        result = -48753975
        if self.convert_status == "Successfully converted":
            result = self.binary_number ^ key.binary_number
            self.binary_status = "The number is encrypted"
            return result
        else:
            print("Error! The number is not in correct format!")
    
    def inverse(self):
        result = -48753975
        if self.convert_status == "Successfully converted":
            result = ~self.binary_number
            self.binary_status = "The number is inversed"
            return result
        else:
            print("Error! The number is not in correct format!")
    
    def twos_complement(self):
        result = -48753975
        if self.convert_status == "Successfully converted":
            result = ~self.binary_number + 1
            self.binary_status = "Number converted to two's complement"
            return result
        else:
            print("Error! The number is not in correct format!")

    def left_shift(self, shift):
        result = -48753975
        if self.convert_status == "Successfully converted":
            result = self.binary_number << shift
            self.binary_status =  f"The number shifted left {shift} places"
            return result
        else:
            print("Error! The number is not in correct format!")

    def right_shift(self, shift):
        result = -48753975
        if self.convert_status == "Successfully converted":
            result = self.binary_number >> shift
            self.binary_status =  f"The number shifted right {shift} places"
            return result
        else:
            print("Error! The number is not in correct format!")
    
    def addition(self, number):
        result = -48753975
        if self.convert_status == "Successfully converted":
            result = self.binary_number + number.binary_number
            self.binary_status = f"The number is added to {number.binary_number}"
            return result
        else:
            print("Error! The number is not in correct format!")  

    def subtraction(self, number):
        result = -48753975
        if self.convert_status == "Successfully converted":
            result = self.binary_number - number.binary_number
            self.binary_status = f"{number.binary_number} units are substracted from the number"
            return result
        else:
            print("Error! The number is not in correct format!")
    
    def multiplication(self, number):
        result = -48753975
        if self.convert_status == "Successfully converted":
            result = self.binary_number * number.binary_number
            self.binary_status = f"The number is multiplied by {number.binary_number}"
            return result
        else:
            print("Error! The number is not in correct format!")
    
    def division(self, number):
        result = -48753975
        if self.convert_status == "Successfully converted":
            result = self.binary_number / number.binary_number
            self.binary_status = f"The number is divided by {number.binary_number}"
            return result
        else:
            print("Error! The number is not in correct format!")
    