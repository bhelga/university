#include <iostream>

using namespace std;

int main(){
    int n, sum = 0, product = 1;
    bool flag;
    cout << "Enter value of array(<=300):\t";
    cin >> n;
    int* arrayA = new int[n];


    for (int i = 0; i < n; i++){
        cout << "Enter element " << i + 1 << ":\t";
        cin >> arrayA[i];
    }

    cout << endl << "Array is:\t";
    for (int i = 0; i < n; i++){
        cout << arrayA[i] << " | ";
    }

    for (int i = 0; i < n - 1; i++){
        flag = false;
        if(arrayA[i] <= arrayA[i+1]){
            flag = true;
        }else break;
    }

    for (int i = 0; i < n; i++){
        if(flag){
            product *= arrayA[i];
        }else sum += arrayA[i];
    }

    if(flag){
            cout << "Product is:\t" << product << endl << endl;
        }else cout << "Sum is:\t" << sum << endl << endl;

    return 0;
}