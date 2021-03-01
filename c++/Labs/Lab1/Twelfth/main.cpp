#include <cmath>
#include <conio.h>
#include <iostream>

using std::cin;
using std::cout;

int main()
{
	int n, m;
	cout << "Input n:\t";
	cin >> n;
	cout << "Input m:\t";
	cin >> m;

	double res = ((n + 1) * (m - 4) + pow(sin(n * m), 2) - pow(n, 4) + pow(m, 3)) / log(pow((m + 2), 2));
	cout << "Result:\t" << res;

	_getwch();
	return 0;
}