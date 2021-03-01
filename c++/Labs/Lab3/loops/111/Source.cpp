#include <iostream>

using namespace std;


int factorialForN(int n) {				// функція визначає факторіал
	if (n < 0) return 0;
	else if (n == 0) return 1;
	else {
		int result = 1;

		for (int i = 1; i <= n; i++) {
			result *= i;
		}

		return result;
	}
}

int main() {
	int result = 1;

	for (int i = 1; i <= 5; i++) {
		result *= i;
		cout << result << endl;
	}
	
	return 0;
}
