#include <iostream>
#include <cmath>

using namespace std;

int main()
{
    double x, y, z, a, b, c, d, res;
    cout << "Input x, y, z, a, b, c, d: ";
    cin >> x >> y >> z >> a >> b >> c >> d;

    if (c > d) swap(c, d);
    if (a > b) swap(a, b);

    cout << "a = " << a << "\nb = " << b << "\nc = " << c << "\nd = " << d << endl;

    if ((x > c && x < d) && (y > c && y < d) && z != 0)
        res = (fabs(x) + fabs(y)) / fabs(z);
    else if ((x > c && x < d) && (y > c && y < d) && z == 0)
        res = min(x, y) + sqrt(x * x + y * y);
    else
        res = max(max(fabs(x), fabs(y)), fabs(z));
    cout << "Result: " << res << endl;

    system("pause");
    return 0;
}