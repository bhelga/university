//Задана дійсна матриця A[n][n], n <= 20.
//Розробити програму, яка будує вектор X[n] 
//за правилом: X[i] дорівнює половині суми модулів 
//максимального і мінімального елементів i-го рядка. 

#include <iostream> 
#include <math.h>

using namespace std;

int main()
{
    int const n = 5;
    double matrixA[n][n], vectX[n];
    double everyMin, everyMax;

    for (int i = 0; i < n; i++){
        for (int j = 0; j < n; j++){
            matrixA[i][j] = rand() % 10 + 1;
            cout.width(3);
            cout << matrixA[i][j] << " | ";
        }
        cout << endl;
    }

    for (int i = 0; i < n; i++){
        everyMin = matrixA[i][0];
        everyMax = matrixA[i][0];
        for (int j = 0; j < n; j++){
            if (matrixA[i][j] < everyMin)
                everyMin = matrixA[i][j];
            if (matrixA[i][j] > everyMax)
                everyMax = matrixA[i][j];
        }
        cout << "Min is:\t" << everyMin << endl << "Max is:\t" << everyMax <<endl;
        vectX[i] = (abs(everyMin) + abs(everyMax)) / 2;
    }

    cout << "Vector X is:\t";
    for (int i = 0; i < n; i++)
        cout << vectX[i] << " | ";

    return 0;
}