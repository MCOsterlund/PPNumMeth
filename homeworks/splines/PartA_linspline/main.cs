using System;
using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		double[] x={0, 4, 5, 6};
		double[] y={5, 4, 7, 5};
		
		double dx=1.0/16, shift=dx/2;
		for(double n=0+shift; n<=x[x.Length-1]; n+=dx)
			{	
			double spline=linspline.linterp(x,y,n);
			WriteLine($" {spline} ");
			}
	}
}
