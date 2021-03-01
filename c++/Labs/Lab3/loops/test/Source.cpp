//������ ������� X[n][n], n<=15.
//��������� ��������, ��� ���� �������: A[i] � ���� ��������  i-�� �����, B[j] � ���� �������� j-�� ��������� ������ �������, i,j=1,2...n.
//�������� ���������� ��� �������� ������� �� ���������� ��� ���������� ���� �������� �������
//� ����������� �� ��� ���������� ��� �������� ����� � ��������. �������  ������� �������.

#include <iostream>
#include <ctime>

using namespace std;

//������� ������� ���������� ��������� ����� �� ����� ���������
int** creatingMatrix(int numOfRows, int numOfColumns) {
    int** matrix;
    matrix = new int* [numOfRows];
    for (int i = 0; i < numOfRows; i++) {
        matrix[i] = new int[numOfColumns];
    }
    return matrix;
}

//������� �������� �������� �� �������� �� ����� ���������� �����
void initialize(int** matrix, int numOfRows, int numOfColumns)
{
    srand(time(0));
    cout << endl;
    for (int i = 0; i < numOfRows; i++) {
        for (int j = 0; j < numOfColumns; j++) {
            matrix[i][j] = rand() % 10 + 1;
            cout.width(3);
            cout << matrix[i][j] << " | ";
        }
        cout << endl;
    }
}

//������� ���� ���� �������� �������
int sumOfVect(int Vect[], int amountOfElements) {
    int sumOfVect = 0;
    for (int i = 0; i < amountOfElements; i++) {
        sumOfVect += Vect[i];
    }
    return sumOfVect;
}

//������� ������� ������, �������� ����� � ���� ����� �������
int* setVectA(int** Matrix, int numOfRows, int numOfColumns)
{
    int* vectA = new int[numOfRows];
    for (int i = 0; i < numOfRows; i++) {
        int sumOfVectA = 0;
        int* vectOne = new int[numOfRows];
        for (int j = 0; j < numOfColumns; j++) {
            vectOne[j] = Matrix[i][j];
        }
        sumOfVectA = sumOfVect(vectOne, numOfRows);
        vectA[i] = sumOfVectA;
    }
    return vectA;
}

//������� ������� ������, �������� ����� � ���� �������� �������
int* setVectB(int** Matrix, int numOfRows, int numOfColmns)
{
    int* vectB = new int[numOfColmns];
    for (int i = 0; i < numOfColmns; i++) {
        int sumOfVectB = 0;
        int* vectTwo = new int[numOfColmns];
        for (int j = 0; j < numOfRows; j++) {
            vectTwo[j] = Matrix[j][i];
        }
        sumOfVectB = sumOfVect(vectTwo, numOfColmns);
        vectB[i] = sumOfVectB;
    }
    return vectB;
}
//������� �������� ������� � �� �,
//���������� ���� � ���� �����(������ �) �� ���� ��������(������ �) ��������� �������
void setVect(int** Matrix, int amountOfElements)
{
    int* vectA = new int[amountOfElements];
    int* vectB = new int[amountOfElements];
    for (int i = 0; i < amountOfElements; i++) {
        int sumOfVectA = 0;
        int sumOfVectB = 0;
        int* vectOne = new int[amountOfElements];
        int *vectTwo = new int[amountOfElements];
        for (int j = 0; j < amountOfElements; j++) {
            vectOne[j] = Matrix[i][j];
            vectTwo[j] = Matrix[j][i];
        }
        sumOfVectA = sumOfVect(vectOne, amountOfElements);
        vectA[i] = sumOfVectA;
        sumOfVectB = sumOfVect(vectTwo, amountOfElements);
        vectB[i] = sumOfVectB;
    }
    cout << "Vector A is:\t";
    for (int i = 0; i < amountOfElements; i++) {
        cout.width(3);
        cout << vectA[i] << " | ";
    }
    cout << endl << "Vector B is:\t";
    for (int i = 0; i < amountOfElements; i++) {
        cout.width(3);
        cout << vectB[i] << " | ";
    }
}


int main()
{
    int amountOfElements;
    do {
        cin.clear();
        cout << "Enter the dimension(< 15) of the square matrix:\t";
        cin >> amountOfElements;
    } while (amountOfElements > 15);

    int* vectA = new int[amountOfElements];
    int* vectB = new int[amountOfElements];
    int** matrixX;

    matrixX = creatingMatrix(amountOfElements, amountOfElements);
    initialize(matrixX, amountOfElements, amountOfElements);

    cout << endl << endl << "*** Create vectors with Functions which returns Values ***" << endl << endl;
    vectA = setVectA(matrixX, amountOfElements, amountOfElements);
    cout << "Vector A is:\t";
    for (int i = 0; i < amountOfElements; i++) {
        cout.width(3);
        cout << vectA[i] << " | ";
    }
    vectB = setVectB(matrixX, amountOfElements, amountOfElements);
    cout << endl << "Vector B is:\t";
    for (int i = 0; i < amountOfElements; i++) {
        cout.width(3);
        cout << vectB[i] << " | ";
    }

    cout << endl << endl << "*** Create vectors using void function ***" << endl << endl;
    setVect(matrixX, amountOfElements);

    return 0;
}