#include <iostream>
#include <cmath>

using namespace std;

/*
double factorial(int n) {
	if (n < 0) return 0;					
	else if (n == 0) return 1;				
	else return n * (factorial(n - 1));		
}
*/


// ������� ������� �������� ���������
// ��� ����� n
int factorialForN(int n) {				
	if (n < 0) return 0;
	else if (n == 0) return 1;
	else {
		int result = 1;

		for (int i = 1; i <= n; i++) {
			result *= i;
		}

		return result;
	}
}

int main()
{
	double x, a, eps, numBottom;
	double sum = 0, num = 1;	// num � ���� ����, sum � ���� ����� ����� � ������� �������
	int k;
	cout << "Enster x and a:\t ";
	if (!(cin >> x >> a) || (a == 0) || (x == 0)) {
		cout << "Error!" << endl;
		return -1;
	}
	cout << "Enter precision e:\t ";
	if (!(cin >> eps) || eps <= 0) {
		cout << "Error!" << endl;
		return -1;
	}

	for (k = 1; fabs(num) >= eps; k++){
		if ((numBottom = (pow(a, 2 * k) + factorialForN(2 * k))) == 0) {
			cout << "Error!" << endl;
			return -1;
		}
		else {
			num = sin(pow(x, k)) / numBottom;
			sum += num;
		}
    }

	cout << "Result:\t" << sum << endl;
	cout << "The number of iterations:\t" << (k) << endl;

	system("pause");
	return 0;
}