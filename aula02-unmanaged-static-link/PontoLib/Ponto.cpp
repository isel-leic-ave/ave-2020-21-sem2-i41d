// Ponto.cpp : Defines the exported functions by Ponto.obj
//

#include "Ponto.h"
#include <math.h>
#include <iostream>

/*
 * This is the constructor of a class that has been exported.
 * see aula01_Ponto.h for the class definition
 */
Ponto::Ponto(int x, int y)
{
	this->_x = x;
	this->_y = y;
}

double Ponto::getModule() {	 
	return sqrt((double)_x*_x + _y*_y);
}

void Ponto::print(){
	printf("Point (x = %d, y = %d)\n", this->_x, this->_y);
}
