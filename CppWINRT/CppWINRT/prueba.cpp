#include "pch.h"
#include "prueba.h"
#include <string>
extern   elnodo * pila_programas[32]; 



using namespace Windows;

namespace CppWINRT  // test
{
 

ast::ast(void)
{
	num = 0;
	tipo = secuencia;
	nrolinea1 = 0;
	nrolinea2 = 0;
}


ast::~ast(void)
{
}


  void	ast::setast1(int t, ast ^a, double n) {
	nodo1 = a;
	tipo = t;
	subnodos = 1;
	num = n;
}

  void	ast::setast2(int t, ast ^a, ast ^b, double n) {
	nodo1 = a;
	nodo2 = b;
	tipo = t;
	subnodos = 2;
	num = n;
}

   void	ast::setast3(int t, ast ^a, ast ^b, ast ^c, double n) {
	nodo1 = a;
	nodo2 = b;
	nodo3 = c;
	tipo = t;
	subnodos = 3;
	num = n;
}

   void	ast::setast4(int t, ast ^a, ast ^b, ast ^c, ast ^d, double n) {
	nodo1 = a;
	nodo2 = b;
	nodo3 = c;
	nodo4 = d;
	tipo = t;
	subnodos = 4;
	num = n;
}

   void	ast::setast5(int t, ast ^a, ast ^b, ast ^c, ast ^d, ast ^e, double n) {
	nodo1 = a;
	nodo2 = b;
	nodo3 = c;
	nodo4 = d;
	nodo4 = e;
	tipo = t;
	subnodos = 5;
	num = n;
}

  	int     ast::getsubnodos() { return subnodos ;}

	
}
