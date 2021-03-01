//Задано масиви цілих: упорядкований за незростанням(a >= b >= c) чисел A(n+m), неупорядкований – B(m), n<=300, m<=200.
//Розробити програму, яка елементи масиву B вставляє в масив A так, щоб A залишився впорядкованим. 
//Для впорядкування використати метод вставки. 

#include <iostream>
#include <ctime>

using namespace std;

int main()
{
    int n;
    int m;
    cin >> n;
    cin >> m;
    int count = 0;
    n += m;
    int A[n];

    cout << "\t***The array A is:***\t" << endl;
    for(int i = 0; i < n; i++){
        A[i] = rand() % 100 + 1;
    }
    for(int i = 1; i < n; i++){
        int value = A[i];
        for(int j = i - 1; j >=0 && A[j] > value; j--)
           swap(A[j], A[j+1]); 
    }
    for(int i = 0; i < n; i++){
        cout << A[i] << " | ";
    }

    int B[n];
    cout << endl << endl << "\t***The array B is:***\t" << endl;
    for(int i = 0; i < m; i++){
        B[i] = rand() % 50 -25;
        cout << B[i] << " | ";
    }
    cout << endl << endl;

    int temp1, temp2, num;
  
    for(int i = 0; i < m; i++){ 
        for(int j = 0; j < n; j++)
            if(B[i] > A[j] && B[i] < A[j+1]){
                temp1 = A[j+1];
                num = A[j+2];
                A[j+1] = B[i];
                n++;
            }
        for(int j = num; j < n + m; j++){
            temp2 = A[j];
            A[j] = temp1;
            temp1 = temp2;
        }
    }
    for(int i = 0; i < n+m; i++){
        cout << A[i] << " | ";
    }

    return 0;
}