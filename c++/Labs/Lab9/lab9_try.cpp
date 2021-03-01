//Задана матриця X[n][n], n<=15.
//Розробити програму, яка будує вектори: A[i] – сума елементів  i-го рядка, B[j] – сума елементів j-го стовпчика заданої матриці, i,j=1,2...n.
//Написати підпрограму для побудови вектора та підпрограму для обчислення суми елементів вектора
//і використати її для обчислення сум елементів рядків і стовпців. Вивести  отримані вектори.

#include <iostream>

using namespace std;

int sumOfVect(int Vect[], int amountOfElements){
    int sumOfVect = 0;
    for(int i = 0; i < amountOfElements; i++){
        sumOfVect += Vect[i];
    }
    return sumOfVect;
}
void setVect(int** Matrix, int amountOfElements)
{
    int *vectA = new int[amountOfElements];
    int *vectB = new int[amountOfElements];
    for(int i = 0; i < amountOfElements; i++){
        int sumOfVectA = 0;
        int sumOfVectB = 0;
        int vectOne[amountOfElements], vectTwo[amountOfElements];
        for(int j = 0; j < amountOfElements; j++){
            vectOne[j] = Matrix[i][j];
            vectTwo[j] = Matrix[j][i];
        }
        sumOfVectA = sumOfVect(vectOne, amountOfElements);
        vectA[i] = sumOfVectA;
        sumOfVectB = sumOfVect(vectTwo, amountOfElements);
        vectB[i] = sumOfVectB;
        cout << vectA[i] << " | ";
        cout << vectB[i] << endl;
    }
}

int main()
{
    const int n = 3;
    int A[n], B[n];
    int **X;
    X = new int *[n];
    for (int i = 0; i < n; i++) {
       X[i] = new int [n];
    }
    for(int i = 0; i < n; i++){
        for(int j = 0; j < n; j++){
            X[i][j] = rand() % 10 + 1;
            cout.width(3);
            cout << X[i][j] << " | ";
            }
        cout << endl;
    }
    setVect(X, n);
}