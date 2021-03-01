#include <iostream>

using namespace std;

int main()
{
    const int n = 10, k = 2 * n;
    int X[n], Y[n], Z[k], ResultArray[k];
    int temp, index = 0, sum = 0;;
    unsigned long long product = 1;

    for (int i = 0; i < n; i++) {
        X[i] = rand() % 10 + 1;
        cout << X[i] << " | ";
    }
    cout << endl << endl;

    for (int i = 0; i < n; i++) {
        Y[i] = rand() % 40;
        cout << Y[i] << " | ";
    }
    cout << endl << endl;

    for (int i = 0; i < n; i++) {
        Z[i] = X[i];
        Z[i + n] = Y[i];
    }
    for (int i = 0; i < k - 1; i++) {
        for (int j = 0; j < (k - i - 1); j++) {
            if (Z[j] > Z[j + 1]) {
                temp = Z[j];
                Z[j] = Z[j + 1];
                Z[j + 1] = temp;
            }
        }
    }

    for (int i = 0; i < k; i++) cout << Z[i] << " | ";
    cout << endl << endl;

    for (int i = 0; i < k; i++) {
        bool flag = true;
        for (int j = 0; j < index; j++) {
            if (Z[i] == ResultArray[j]) {
                flag = false;
                break;
            }
        }
        if (flag) {
            ResultArray[index] = Z[i];
            sum += ResultArray[index];
            product *= ResultArray[index];
            index++;
        }
    }
    for (int i = 0; i < index; i++) cout << ResultArray[i] << " | ";
    cout << endl << endl;
    cout << "The sum of array is:\t" << sum << endl;
    cout << "The product of array is:\t" << product << endl;


    return 0;
}