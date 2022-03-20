using System;
using static System.Console;
using static System.Math;

class main{

	static double gamma(double x){
		if(x<0)return PI/Sin(PI*x)/gamma(1-x);
		if(x<9)return gamma(x+1)/x;
		double lngamma=x*Log(x+1/(12*x - 1/x/10)) - x+Log(2*PI/x)/2;
		return Exp(lngamma);
	}

	static double log_gamma(double x){
		return x*Log(x+1/(12*x - 1/x/10)) - x+Log(2*PI/x)/2;
	}

	static public void Main(){
		double dx=1.0/64, shift=dx/2;
		for(double x=-5+shift; x<=5; x+=dx)
			if(Double.IsNaN(log_gamma(x))){
				WriteLine($"{x} {gamma(x)} {0}"); //Writing zeroes for negative values of the gamma function
			}
			else{
			WriteLine($"{x} {gamma(x)} {log_gamma(x)}");
			}
	}

}
