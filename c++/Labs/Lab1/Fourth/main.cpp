#include <iostream>
#include <cmath>

using std::cin;
using std::cout;

int main()
{
	int a, x, y, c;
	cout << "Input a:\t";
	cin >> a;
	cout << "Input x:\t";
	cin >> x;
	cout << "Input y:\t";
	cin >> y;
	cout << "Input c:\t";
	cin >> c;

	double res = (pow(a, 5) + acos(a + pow(x, 3)) - pow(sin(y - c), 4)) / (pow(sin(x + y), 3) + abs(x - y));
	cout << "Result:\t" << res;

	_getwch();
	return 0;

}