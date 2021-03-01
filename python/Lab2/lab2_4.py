from lab2 import correct_input
import math

def Queen(queeneX, queeneY, anotherX, anotherY):
    R1 = queeneY - queeneX
    R2 = queeneY + queeneX
    if (anotherY == anotherX + R1 or anotherY == -anotherX + R2 or anotherY == queeneY or anotherX == queeneX):
        return True
    else:
        return False

def King(kingX, kingY, anotherX, anotherY):
    if (math.fabs(anotherX - kingX) <=1 and math.fabs(anotherY - kingY) <= 1):
        return True
    else:
        return False

zahust = ""
stringx = "x:\t"
stringy = "y:\t"
print("Введiть координати фігур!\n\nБiлий ферзь:\n")
wqx = correct_input(1, 8, stringx)
wqy = correct_input(1, 8, stringy)
print("\nЧорний король:\n")
while True:
    bkx = correct_input(1, 8, stringx)
    bky = correct_input(1, 8, stringy)
    if((bkx == wqx and bky == wqy)):
        print("Error! This cell is full!\n")
    else: break
print("\nЧорний ферзь:\n")
while True:
    bqx = correct_input(1, 8, stringx)
    bqy = correct_input(1, 8, stringy)
    if((bqx == wqx and bqy == wqy) or (bqx == bkx and bqy == bky)):
        print("Error! This cell is full!\n")
    else: break

if Queen(bqx, bqy, bkx, bky):
        zahust += "\nЧорний ферзь захищає короля"
if King(bkx, bky, bqx, bqy):
        zahust += "\nЧорний король захищає ферзя"

if King(bkx, bky, wqx, wqy) and Queen(wqx, wqy, bqx, bqy):
    print("Бiлий ферзь може побити чорного ферзя i короля та навпаки залежно вiд ходу." + zahust)
elif Queen(wqx, wqy, bqx, bqy) and not King(bkx, bky, wqx, wqy) and not Queen(wqx, wqy, bkx, bky):
    print("Бiлий ферзь може побити чорного ферзя та навпаки залежно вiд ходу." + zahust)
elif Queen(wqx, wqy, bkx, bky) and Queen(wqx, wqy, bqx, bqy) and not King(bkx, bky, wqx, wqy):
    print("Бiлий ферзь може побити чорного ферзя та навпаки залежно вiд ходу i чорного короля." + zahust)
elif King(bkx, bky, wqx, wqy) and not Queen(wqx, wqy, bqx, bqy):
    print("Бiлий ферзь може побити чорного короля." + zahust)
else:
    print("Нiхто нiкого не б'є" + zahust)