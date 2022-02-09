using System;
using static System.Console;

public static class test{ 
	public static int n=7; 
	public static double pi=3.1415927;
	public static double e=2.71828;
}

public static class main{
	static string s="main\n";
	static void hello(){
		string s="hello\n";
		Write("hello\n");
	}
	static int Main() {
		double x,y;
		x=test.pi;
		y=test.e;
		Write("x={0} y={1}\n",x,y);
		Write($"x={x} y={y}\n");
		math.test();
	return 0;
	}
}

//using System: Starts out with looking through System, then afterwards System.Console
//Everything in C-sharp must be in a class. In this case, we use public static
//static int n=7; prints out n=7
//static double defines, in this case, e and pi. Defines variables (I think...)
//Function in C-sharp can only return a single value
//Using commands such as "static", "void", "main", etc. is for optimisation purposes, so code runs faster.
//public static class main: double x,y defines the variables we use, then define their value, then use Write to print.
//The second Write function is the more modern and neater way to Write.
//Functions can decalre own variables, which are deleted once the function exits.
//However, "block shadowing" is forbidden. Cannot define a variable in a function if it is already defined.
