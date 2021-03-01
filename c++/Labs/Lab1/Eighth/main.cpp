#include <iostream>
#include <cmath>

using std::cin;
using std::cout;

int main()
{
	int x, y, a;
	cout << "Input x:\t";
	cin >> x;
	cout << "Inpit y:\t";
	cin >> y;
	cout << "input a:\t";
	cin >> a;

	double res = (cos(pow(x, 3) + 6) - sin(y - a)) / (log(pow(x, 4)) - 2 * pow(sin(x), 5));
	cout << "Result:\t" << res;

	_getwch();
	return 0;
}