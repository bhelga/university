//Задана матриця X[n][n], n<=15.
//Розробити програму, яка будує вектори: A[i] – сума елементів  i-го рядка, B[j] – сума елементів j-го стовпчика заданої матриці, i,j=1,2...n.
//Написати підпрограму для побудови вектора та підпрограму для обчислення суми елементів вектора
//і використати її для обчислення сум елементів рядків і стовпців. Вивести  отримані вектори.

#include <iostream>

using namespace std;

//функція створює двовимірний динамічний масив як масив вказівників
int** creatingMatrix(int numOfRows, int numOfColumns){
    int **matrix;
    matrix = new int *[numOfRows];
    for (int i = 0; i < numOfRows; i++) {
       matrix[i] = new int [numOfColumns];
    }
    return matrix;
}

//функція рандомно заповнює та виводить на екран заповнений масив
void initialize(int** matrix, int numOfRows, int numOfColumns)
{
    srand(time(0));
    for(int i = 0; i < numOfRows; i++){
	    for(int j = 0;  j < numOfColumns;  j++){
		    A[i][j] = rand()%11 - 5 ;
		    cout << A[i][j] << " | ";
		}
    cout << endl;
	}
}

//функція рахує суму елементів вектора
int sumOfVect(int Vect[], int amountOfElements){
    int sumOfVect = 0;
    for(int i = 0; i < amountOfElements; i++){
        sumOfVect += Vect[i];
    }
    return sumOfVect;
}

//функція створює вектор, елементи якого – сума рядків матриці
int* setVectA(int** Matrix, int amountOfElements)
{
    int *vectA = new int[amountOfElements];
    for(int i = 0; i < amountOfElements; i++){
        int sumOfVectA = 0;
        int vectOne[amountOfElements];
        for(int j = 0; j < amountOfElements; j++){
            vectOne[j] = Matrix[i][j];
        }
        sumOfVectA = sumOfVect(vectOne, amountOfElements);
        vectA[i] = sumOfVectA;
    }
    return vectA;
}

//функція створює вектор, елементи якого – сума стовпців матриці
int* setVectB(int** Matrix, int amountOfElements)
{
    int *vectB = new int[amountOfElements];
    for(int i = 0; i < amountOfElements; i++){
        int sumOfVectB = 0;
        int vectTwo[amountOfElements];
        for(int j = 0; j < amountOfElements; j++){
            vectTwo[j] = Matrix[j][i];
        }
        sumOfVectB = sumOfVect(vectTwo, amountOfElements);
        vectB[i] = sumOfVectB;
    }
    return vectB;
}

int main()
{
    int amountOfElements;
    cout << "Enter the dimension of the square matrix:\t";
    cin >> amountOfElements;
    int* vectA = new int[amountOfElements];
    int* vectB = new int[amountOfElements];
    int **matrixX;
    matrixX = new int *[amountOfElements];
    for (int i = 0; i < amountOfElements; i++) {
       matrixX[i] = new int [amountOfElements];
    }
    for(int i = 0; i < amountOfElements; i++){
        for(int j = 0; j < amountOfElements; j++){
            matrixX[i][j] = rand() % 10 + 1;
            cout.width(3);
            cout << matrixX[i][j] << " | ";
            }
        cout << endl;
    }
    vectA = setVectA(matrixX, amountOfElements);
    cout << "Vector A is:\t";
    for(int i = 0; i < amountOfElements; i++){
        cout.width(3);
        cout << vectA[i] << " | ";
    }
    vectB = setVectB(matrixX, amountOfElements);
    cout << endl << "Vector B is:\t";
    for(int i = 0; i < amountOfElements; i++){
        cout.width(3);
        cout << vectB[i] << " | ";
    }
}

