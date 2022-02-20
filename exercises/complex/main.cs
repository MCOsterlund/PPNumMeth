using System;
using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		complex x1=cmath.sqrt(-1);
		WriteLine($"Sqrt(-1) = {x1}\n, should be i");	
		complex x2=cmath.sqrt(cmath.I);
		WriteLine($"sqrt(i)={x2}\n, should be 0.707+0.707i");
		complex x3=cmath.exp(cmath.I);
		WriteLine($"exp(i)={x3}\n, should be 0.540+0.841i");
		complex x4=cmath.exp(cmath.I*Math.PI);
		WriteLine($"exp(i*pi)={x4}\n, should be -1");
		complex x5=cmath.pow(cmath.I,cmath.I);
		WriteLine($"i^i={x5}\n, should be 0.208");
		complex x6=cmath.log(cmath.I);
		WriteLine($"ln(i)={x6}\n, should be 1.571i");
		complex x7=cmath.sin(cmath.I*Math.PI);
		WriteLine($"sin(pi*i)={x7}\n, should be 11.549i");		
	}

}

