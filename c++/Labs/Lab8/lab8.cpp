//Задано текст, слова в якому розділені пробілами і розділовими знаками.
//Розробити програму, яка вилучає в кожному слові цього тексту всі попередні входження останньої літери. 

#include <iostream>
#include <cctype>
#include <cstring>

using namespace std;

int main()
{   
    const int n = 256;
    char str1[n] = "";
    char lastLetter;

    cout << "Enter your string:\t";
    cin.getline(str1, n);

    for(int i = 0; i < n; i++){
        if(str1[i-1] != '\0' && isalpha(str1[i-1]))
            lastLetter = str1[i-1];
    }
    cout << lastLetter << endl;
    for(int i = 0; i < n; i++){
        if(str1[i] == lastLetter){
            str1[i] = '\0';
            for(int j = i; j < n; j++){
                swap(str1[j], str1[j+1]);
            }
        }
            
    }
    cout << "Result is:\t" << str1 << endl;

    return 0;
}