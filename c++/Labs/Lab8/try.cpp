//Задано текст, слова в якому розділені пробілами і розділовими знаками.
//Розробити програму, яка вилучає в кожному слові цього тексту всі попередні входження останньої літери. 

#include <iostream>
#include <cctype>

using namespace std;

int main()
{   
    int n = 256;
    char str1[n] = "";
    char lastLetter;

    cout << "Enter your string:\t";
    cin.getline(str1, n);

    for(int i = 1; i < n; i++){
        cout << str1[i-1];
        if(str1[i-1] != '\0' && isalpha(str1[i-1]))
            lastLetter = str1[i-1];
    }
    cout << lastLetter << endl;

    return 0;
}