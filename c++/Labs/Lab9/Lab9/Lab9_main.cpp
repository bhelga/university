//Задана матриця X[n][n], n<=15.
//Розробити програму, яка будує вектори: A[i] – сума елементів  i-го рядка, B[j] – сума елементів j-го стовпчика заданої матриці, i,j=1,2...n.
//Написати підпрограму для побудови вектора та підпрограму для обчислення суми елементів вектора
//і використати її для обчислення сум елементів рядків і стовпців. Вивести  отримані вектори.

#include <iostream>
#include "mylib.h"

using namespace std;

int main()
{
    int amountOfElements;
    do{
        cout << "Enter the dimension(< 15) of the square matrix:\t";
        cin >> amountOfElements;
    }while(amountOfElements > 15);

    int* vectA = new int[amountOfElements];
    int* vectB = new int[amountOfElements];
    int **matrixX;

    matrixX = creatingMatrix(amountOfElements, amountOfElements);
    initialize(matrixX, amountOfElements, amountOfElements);

    cout << endl << endl << "*** Create vectors with Functions which returns Values ***" << endl << endl;
    vectA = setVectA(matrixX, amountOfElements, amountOfElements);
    cout << "Vector A is:\t";
    for(int i = 0; i < amountOfElements; i++){
        cout.width(3);
        cout << vectA[i] << " | ";
    }
    vectB = setVectB(matrixX, amountOfElements, amountOfElements);
    cout << endl << "Vector B is:\t";
    for(int i = 0; i < amountOfElements; i++){
        cout.width(3);
        cout << vectB[i] << " | ";
    }

    cout << endl << endl << "*** Create vectors using void function ***" << endl << endl;
    setVect(matrixX, amountOfElements);

    return 0;
}