#include <cmath>
#include <iostream>

using std::cin;
using std::cout;

int main()
{
	int x, y, z, c;

	cout << "Input x:\t";
	cin >> x;
	cout << "Input y:\t";
	cin >> y;
	cout << "Input z:\t";
	cin >> z;
	cout << "Input c:\t";
	cin >> c;

	double res = (tan(pow(x, 4) - 6) - pow(cos(z + (pow(x, 3) * y)), 3 * x)) / (pow(cos(pow(x, 3) * pow(c, 2)), 2));
	cout << "Result:\t" << res;

	_getwch();
	return 0;

}
