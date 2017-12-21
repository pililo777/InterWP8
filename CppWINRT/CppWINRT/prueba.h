#pragma once
#include "pch.h"
#include <string>
#include "stdio.h"
#include <iostream>
#include <stdlib.h>
 

using namespace Windows;
using Platform::String;

namespace CppWINRT  // test
{
 
#include "nodo.h"

 class ast   
	{
	public:
 
		ast(void);
		~ast(void);
		ast *nodo1;
		ast *nodo2;
		ast *nodo3;
		ast *nodo4;
		ast *nodo5;
		tiponodo tipo;
		double num;
		int    nrolinea1;
		int    nrolinea2;

	};

}