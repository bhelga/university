//Задано масиви цілих: упорядкований за незростанням чисел A(n+m), неупорядкований – B(m), n<=300, m<=200.
//Розробити програму, яка елементи масиву B вставляє в масив A так, щоб A залишився впорядкованим. 
//Для впорядкування використати метод вставки. 

#include <iostream>
#include <ctime>

using namespace std;

int main()
{
    const int n = 10;
    const int m = 5;
    int count = 0;
    int A[n+m], B[m];

    cout << "\t***The array A is:***\t" << endl;
    for(int i = 0; i < n; i++){
        A[i] = rand() % 100 + 1;
    }
    for(int i = 1; i < n; i++){
        for(int j = i; j >=0 && A[j] > A[j+1]; j--)
           swap(A[j], A[j+1]); 
    }
    for(int i = 0; i < n; i++){
        cout << A[i] << " | ";
    }

    cout << endl << endl << "\t***The array B is:***\t" << endl;
    for(int i = 0; i < m; i++){
        B[i] = rand() % 100 + 1;
        cout << B[i] << " | ";
    }
    cout << endl << endl;
  
    for(int i = n - 1; i < n + m; i++){
        A[i + 1] = B[count];
        for(int j = i; j >=0 && A[j] < A[j-1]; j--)
           swap(A[j], A[j-1]); 
        count++;
    }
    for(int i = 0; i < n+m; i++){
        cout << A[i] << " | ";
    }

    return 0;
}