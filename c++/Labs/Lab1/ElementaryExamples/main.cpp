#include <cmath>
#include <iostream>

using std::cout;
using std::cin;

int main()
{
	char q, w, e;
	cout << "Input x:\t";
	cin >> q;
	cout << "Input a:\t";
	cin >> w;
	cout << "Input c:\t";
	cin >> e;

	int x, a, c;
	x = (int)q;
	a = (int)w;
	c = (int)e;

	double res = ((sqrt(exp(x) - pow(cos((pow(x, 2) * pow(a, 5))), 4) + pow(atan(a - pow(x, 5)), 4))) / (sqrt(abs(a + (x * (pow(c, 4)))))));
	
	cout << "Result:\t" << res << "\n";
	

	_getwch();

	return 0;

}