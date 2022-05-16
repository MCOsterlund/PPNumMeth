using System;
using static System.Console;
using static System.Math;

static class main{

	static void minmax(){
			WriteLine("Maximum/minimum representable integers.");
			int i=1;
			while(i+1>i){i++;}
			WriteLine($"my max int={i}");

			while(i-1<i){i++;}
			WriteLine($"my min int={i}\n");

		}

	static void epsilon(){
		WriteLine("Machine epsilon");
		double x=1;
       		while(1+x!=1){x/=2;}
       		x*=2;

		float y=1F;
		while((float)(1F+y) !=1F){y/=2F;}
       		y*=2F;	

		Console.WriteLine($"double precision: {x}.Pow(2,-52)={System.Math.Pow(2,-52)}");
		Console.WriteLine($"float precision: {x}.Pow(2,-23)={System.Math.Pow(2,-23)}\n");
		}
	static void tiny(){
		WriteLine($"Comparing '1-tiny' and 'tiny-1'.");
		int n=(int) 1e6;
		double epsilon = Pow(2,-52);
		double tiny=epsilon/2;
		double sumA=0,sumB=0;

		sumA+=1;
	       	for(int i=0;i<n;i++){sumA+=tiny;}
		WriteLine($"sumA-1={sumA-1:e} should be {n*tiny:e}");

		for(int i=0; i<n; i++){sumB+=tiny;} 
		sumB+=1;
		WriteLine($"sumB-1={sumB-1:e} should be {n*tiny:e}\n");
	}
	static bool approx(double a, double b, double tau=1e-9, double epsilon=1e-9){
		return (Abs(a-b)<tau || Abs(a-b)/(Abs(a)+Abs(b))<epsilon);
	}

	static void approxtest(){
		WriteLine("Test of the approximation method");
		WriteLine($"Checking a=1, b=1: {approx(1,1)}");
		WriteLine($"Checking a=1, b=2: {approx(1,2)}");
		WriteLine($"Checking a=1, b=1+Pow(2,-52): {approx(1,1+Pow(2,-52))}");
	}

	static int Main(){
	minmax();
	epsilon();
	tiny();
	approxtest();
	return 0;
	}	
}
