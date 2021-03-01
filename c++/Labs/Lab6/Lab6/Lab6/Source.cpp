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
    const int k = n + m;
    int count = 0;
    int A[k + m], B[m];

    cout << "\t***The array A is:***\t" << endl;
    for (int i = 0; i < k; i++) {
        A[i] = rand() % 100 + 1;
        if (i > 0 && A[i] > A[i - 1]) swap(A[i], A[i - 1]);
        cout << A[i] << " | ";
    }
    cout << endl << endl << "\t***The array B is:***\t" << endl;
    for (int i = 0; i < m; i++) {
        B[i] = rand() % 100 + 1;
        cout << B[i] << " | ";
    }
    cout << endl << endl;

    for (int i = k; i < k + m; i++) {
        A[i] = B[count];
        count++;
    }
    for (int i = 0; i < k + m; i++) {
        cout << A[i] << " | ";
    }

    return 0;
}