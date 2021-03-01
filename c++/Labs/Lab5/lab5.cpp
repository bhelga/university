//Задано дійсну матрицю A[n][n], n <= 20. Розробити програму, яка будує вектор B[n] за правилом: координати вектора B є
//середніми арифметичними значеннями елементів рядків матриці A.

#include <iostream>

using namespace std;

int main()
{
    const int n = 10;
    double sum = 0, average = 0;
    double A[n][n], B[n];

    for(int i = 0; i < n; i++){
        for(int j = 0; j < n; j++){
            A[i][j] = rand() % 10;
            cout << A[i][j] << " | ";
        }
        cout << endl;
    }
    cout << endl << endl;
    
    for(int i = 0; i < n; i++){
        for(int j = 0; j < n; j++)
            sum += A[i][j];
        average = sum / n;
        B[i] = average;
        cout << B[i] << " | ";
    }
    return 0;
}