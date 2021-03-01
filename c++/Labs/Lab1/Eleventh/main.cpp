#include <iostream>
#include <cmath>

using std::cin;
using std::cout;

int main()
{
	int b, x, a;
	cout << "Input b:\t";
	cin >> b;
	cout << "Input x:\t";
	cin >> x;
	cout << "Input a:\t";
	cin >> a;

	double res = (a / (x - a)) + ((pow(b, x) + pow(cos(x), 3)) / (pow(log(a), 3) + 4.5));
	cout << "Result:\t" << res;

	_getwch();
	return 0;
}