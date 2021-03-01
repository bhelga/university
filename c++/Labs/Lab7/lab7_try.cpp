//Задано масив дійсних чисел A[n], n <= 500.
//Розробити програму, яка обчислює суму всіх чисел, які повторюються,  і добуток всіх чисел, які не повторюються.
//Якщо чисел що повторюються або не повторюються немає, то виводить відповідне повідомлення.

#include <iostream>

using namespace std;

int main()
{
    int n;
    double sumOfRepeating = 0, productOfNonRepeating = 1;
    int count = 0;
    bool flag;

    cout << "Enter the number(<= 500) of items:\t";
    cin >> n;
    double *arrayA = new double[n];
    for(int i = 0; i < n; i++){
        cout << "Enter item [" << i << "]:\t";
        cin >> arrayA[i];
    } 

    for(int i = 0; i < n; i++){
        cout << arrayA[i] << ' ';
    } 
    cout << endl << endl;

    for(int i = 0; i < n; i++){
        flag = true;
        for(int j = 0; j < n; j++)
            if(arrayA[i] == arrayA[j] && i != j){
                sumOfRepeating += arrayA[i];
                flag = false;
                count += 1;
                break;
            }
        if(flag)
            productOfNonRepeating *= arrayA[i];
    }

    if(count == 0){
        cout << "There are no repeting items!" << endl;
        cout << "Product of Non-Repeating Items:\t" << productOfNonRepeating << endl;
    }else if(count == n){
        cout << "All items are repeating!" << endl;
        cout << "Sum of Repeating Items:\t" << sumOfRepeating << endl;
    }else{
        cout << "Product of Non-Repeating Items:\t" << productOfNonRepeating << endl;
         cout << "Sum of Repeating Items:\t" << sumOfRepeating << endl;
    }

    delete [] arrayA;

    return 0;
}