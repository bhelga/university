#include <iostream>
#include <cmath>

using namespace std;

int main()
{
	double b, x, a, z;
	cout << "Input b:\t";
	cin >> b;
	cout << "Input x:\t";
	cin >> x;
	cout << "Input a:\t";
	cin >> a;
	cout << "Input z:\t";
	cin >> z;

	double rTop = pow(cos(b * pow(x, 5)), 7) - (sin(a * a) + cos(pow(x, 3) + pow(z, 5) - a * a));
	double rBottom = asin(a * a) + acos(pow(x, 7) - a * a);
	if (rBottom != 0) {
		double res = rTop / rBottom;
		cout << "Result:\t" << res << endl;
	}
	else cout << "There are no solution!" << endl;

	system("pause");
	return 0;
}