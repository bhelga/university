#include <iostream>
#include <cmath>

using std::cin;
using std::cout;

int main()
{
	int x, a, b, y;
	cout << "Input x:\t";
	cin >> x;
	cout << "Input a:\t";
	cin >> a;
	cout << "Input b:\t";
	cin >> b;
	cout << "Input y:\t";
	cin >> y;

	double res = (cos(pow(x, 3)) - a * sqrt(6) - cos(3 * a * b)) / pow(sin(a * asin(x) + log(y)), 2);
	cout << "Result:\t" << res; 

	_getwch();
	return 0;
}