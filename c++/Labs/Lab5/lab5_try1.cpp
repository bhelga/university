#include <iostream>
#include <vector>

using namespace std;

int main()
{
    int n;
    double sum = 0, average = 0;
    cout << "Enter value of Array:\t";
    cin >> n;

    double **A = new double*[n];    // виділяємо рядки
    for (int i = 0; i < n; i++)
        A[i] = new double [n];      // виділяємо стовпці

    vector<double> B;

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
        B.insert(B.end(), average);
        cout << B[i] << " | ";
    }


    delete[] A;
    return 0;
}