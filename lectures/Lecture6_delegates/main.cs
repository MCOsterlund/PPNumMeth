using System;
using static System.Console;

class main{

	public delegate double fun_of_3_doubles(double x, double y, double z);

	public static void Main(){
		System.Func<double> fun = delegate(){return 7;}; //Delegates are functions. 
		Func<double,double> square = delegate(double x){return x*x;};
		Action hello = delegate(){WriteLine("hello");};
		fun_of_3_doubles f3=delegate(double x, double y, double z){return 9;};
		hello();
		WriteLine($"fun()={fun()} should be equal to 7");
		WriteLine($"square(2)={square(2)} should be equal 4");
		WriteLine($"f3(1,2,3)={f3(1,2,3)} should be equal 9");

		double a=0;
		Action fa=delegate(){a++;};
		fa();
		WriteLine($"a={a} should be 0 or 1<");
	}


}
