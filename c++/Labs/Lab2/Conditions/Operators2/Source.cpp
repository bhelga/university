#include <iostream>
#include <cmath>

using namespace std;

int main() {
	int k;
	double x, y, z, res;

	cout << "Input x, y, z: ";
	cin >> x >> y >> z;
	cout << "Input k: ";
	cin >> k;

	switch (k) {
	case 1: res = min(x, max(y, z)); break;
	case 3: res = min(fabs(x), max(y, z)); break;
	case 2: 
	case 4:
	case 5: res = min(x * x, max(y * y, z * z)); break;
	default: res = (x * x + y * y + z * z) * (x * x + y * y + z * z);
	}
	cout << "Result: " << res << endl;
	system("pause");
	return 0;
}