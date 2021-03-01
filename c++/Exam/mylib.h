#include "mylib.cpp"
#ifndef MYLIB_H
#define MYLIB_H

int** creatingMatrix(int numOfRows, int numOfColumns);

void initialize(int** matrix, int numOfRows, int numOfColumns);

int sumOfVect(int Vect[], int amountOfElements);

int* setVectA(int** Matrix, int numOfRows, int numOfColumns);

int* setVectB(int** Matrix, int numOfRows, int numOfColmns);

void setVect(int** Matrix, int amountOfElements);

#endif