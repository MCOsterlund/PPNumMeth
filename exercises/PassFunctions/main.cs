using System;
using static System.Console;
using static System.Math;

class main{



	public static void Main(){
		//Making the function
		double k=1; //Initially, k=1.
		Func<double,double> f_sin =delegate(double x){return Math.Sin(k*x);}; //Note to self: In "<...>", we write all the variables the function may depend on, in this case two for x and k.
		WriteLine("---Table for k=1---");
		table.make_table(f_sin,0,Math.PI,0.1); 
		k=2; //k=2 now.
		WriteLine("---Table for k=2---");
		table.make_table(f_sin,0,Math.PI,0.1);
		k=3; //k=3 now.
		WriteLine("---Table for k=3---");
		table.make_table(f_sin,0,Math.PI,0.1);	
	}
}
