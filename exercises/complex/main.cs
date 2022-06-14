using System;
using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		complex neg_one=new complex(-1,0);

		complex x1=cmath.sqrt(neg_one);
		WriteLine($"Sqrt(-1) = {x1}, should be i \n");	
		complex x2=cmath.sqrt(cmath.I);
		WriteLine($"sqrt(i)={x2}, should be 0.707+0.707i\n");
		complex x3=cmath.exp(cmath.I);
		WriteLine($"exp(i)={x3}, should be 0.540+0.841i\n");
		complex x4=cmath.exp(cmath.I*Math.PI);
		WriteLine($"exp(i*pi)={x4}, should be -1\n");
		complex x5=cmath.pow(cmath.I,cmath.I);
		WriteLine($"i^i={x5}, should be 0.208\n");
		complex x6=cmath.log(cmath.I);
		WriteLine($"ln(i)={x6}, should be 1.571i\n");
		complex x7=cmath.sin(cmath.I*Math.PI);
		WriteLine($"sin(pi*i)={x7}, should be 11.549i\n");		
	}

}

