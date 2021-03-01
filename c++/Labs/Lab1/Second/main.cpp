#include <cmath>
#include <iostream>

using std::cout;
using std::cin;

int main()
{
	int x, y;
	cout << "Input x:\t";
	cin >> x;
	cout << "Input y:\t";
	cin >> y;

	double res = (sqrt(pow((2 + y), 2)) + sqrt(sin(y + 5))) / (log(x + 1) - pow(y, 3));

	cout << "Result:\t" << res;

	_getwch();
	return 0;

}