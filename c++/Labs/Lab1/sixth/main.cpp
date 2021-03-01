#include <iostream>
#include <cmath>

using std::cin;
using std::cout;

int main()
{
	int x, y;
	cout << "Input x:\t";
	cin >> x;
	cout << "Input y:\t";
	cin >> y;

	double res = sin(x * y) + ((pow((x + y), 3) * (x - y))) / (pow(x, 2) + cos(pow(y, 2)));
	cout << "Resulr:\t" << res;

	_getwch();
	return 0;
}