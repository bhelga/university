#include <iostream>

using namespace std;

double factorial(int k) {
	if (k < 0) return 0;
	else if (k == 0) return 1;
	else return k * factorial(k - 1);
}

int main()
{
	int n,  recursion;
	cout << "Enter n for factorial: ";
	cin >> n;
	
	recursion = factorial(n);
	cout << "The recursion recult is: " << recursion << endl;
	
	
	return 0;
}