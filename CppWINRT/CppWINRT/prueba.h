#pragma once
#include "pch.h"
#include <string>
#include "stdio.h"
#include <iostream>
#include <stdlib.h>
 #include "nodo.h"

using namespace Windows;
using namespace System;
using Platform::String;

namespace CppWINRT  // test
{
 


 public ref  class ast   sealed   
	{

		int tipo;
		double num;
		int    nrolinea1;
		int    nrolinea2;
		int    subnodos;
		ast    ^nodo1;
		ast    ^nodo2;
		ast    ^nodo3;
		ast    ^nodo4;
		ast    ^nodo5;

 
public:
		ast(void);
		virtual ~ast(void);

	void	setast1(int t, ast ^a, double n);
	void	setast2(int t, ast ^a, ast ^b, double n);
	void	setast3(int t, ast ^a, ast ^b, ast ^c, double n);
	void	setast4(int t, ast ^a, ast ^b, ast ^c, ast ^d, double n);
	void	setast5(int t, ast ^a, ast ^b, ast ^c, ast ^d, ast ^e, double n);

	int     getsubnodos(); 



	 property int Subnodos
       {
           int get() { return subnodos; }
           void set(int value)
           {
               if (value <= 0) 
               { 
                   throw ref new Platform::InvalidArgumentException(); 
               }
               subnodos = value;
           }
       }

	  property int Tipo
       {
           int get() { return tipo; }
           void set(int value)
           {
               if (value <= 0) 
               { 
                   throw ref new Platform::InvalidArgumentException(); 
               }
               tipo = value;
           }
       }

	   property double Numero
       {
           double get() { return num; }
           void set(double value)
           {
                num = value;
           }
       }


	    property ast ^Nodo1
       {
           ast^ get() { return  nodo1; }
           void set(ast ^a)
           {
                nodo1 = a;
           }
       }

		 property ast ^Nodo2
       {
           ast^ get() { return  nodo2; }
           void set(ast ^a)
           {
                nodo2 = a;
           }
       }

		  property ast ^Nodo3
       {
           ast^ get() { return  nodo3; }
           void set(ast ^a)
           {
                nodo3 = a;
           }
       }

		   property ast ^Nodo4
       {
           ast^ get() { return  nodo4; }
           void set(ast ^a)
           {
                nodo4 = a;
           }
       }



	};
 
}