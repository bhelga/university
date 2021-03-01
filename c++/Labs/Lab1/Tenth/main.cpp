#include <iostream>
#include <cmath>

using std::cin;
using std::cout;

int main()
{
	int y, x, a;
	cout << "Input y:\t";
	cin >> y;
	cout << "Input x:\t";
	cin >> x;
	cout << "Input a:\t";
	cin >> a;

	double res = (pow(cos(abs(y + x)), 3) - (x + y)) / (pow(atan(x + a), 4) * pow(a, 5));
	cout << "Result:\t" << res;

	_getwch();
	return 0;
}