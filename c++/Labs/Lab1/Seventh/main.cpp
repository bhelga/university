#include <iostream>
#include <cmath>

using std::cin;
using std::cout;

int main()
{
	int x, z, b, a;

	cout << "Input x:\t";
	cin >> x;
	cout << "Input z:\t";
	cin >> z;
	cout << "Input b:\t";
	cin >> b;
	cout << "Input a:\t";
	cin >> a;

	double res = sqrt(abs(x) + pow(cos(x), 3) + pow(z, 4)) / (log(x) - asin((b * x) - a));
	cout << "Result:\t" << res;


	_getwch();
	return 0;
}