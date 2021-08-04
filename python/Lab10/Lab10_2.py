from binary import *

# Перший спосіб задання
number1 = Binary("100")
print("Status : " + number1.convert_status)

# Другий спосіб задання
number2 = Binary()
number2.input_binary()
print("Status : " + number2.convert_status)

shift = 1
print("\nLogic block : \n")
print(f"{number1.binary_number} & {number2.binary_number} = ", number1.logic_multiplication(number2), "\nNumber status : ", number1.binary_status)
print(f"\n{number1.binary_number} | {number2.binary_number} = " , number1.logic_addition(number2) , "\nNumber status : " , number1.binary_status)
print(f"\n{number1.binary_number} ^ {number2.binary_number} = " , number1.XOR(number2) , "\nNumber status : " , number1.binary_status)
print(f"\n~{number1.binary_number} = " , number1.inverse() , "\nNumber status : " , number1.binary_status)
print(f"\n~{number1.binary_number} + 1 = " , number1.twos_complement() , "\nNumber status : " , number1.binary_status)
print(f"\n{number1.binary_number} << {shift} = " , number1.left_shift(shift) , "\nNumber status : " , number1.binary_status)
print(f"\n{number1.binary_number} >> {shift} = " , number1.right_shift(shift) , "\nNumber status : " , number1.binary_status)

print("\n\nArithmetic Block\n")
print(f"\n{number1.binary_number} + {number2.binary_number} = " , number1.addition(number2) , "\nNumber status : " , number1.binary_status)
print(f"\n{number1.binary_number} - {number2.binary_number} = " , number1.subtraction(number2) , "\nNumber status : " , number1.binary_status)
print(f"\n{number1.binary_number} * {number2.binary_number} = " , number1.multiplication(number2) , "\nNumber status : " , number1.binary_status)
print(f"\n{number1.binary_number} / {number2.binary_number} = " , number1.division(number2) , "\nNumber status : " , number1.binary_status)