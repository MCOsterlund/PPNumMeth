using System;
using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		double[] x={0,1,2,3,4,5,6};
		double[] y={0,1,4,9,16,25,36};
		


		for(double n=0; n<=x[x.Length-1]; n+=0.1)
			{	
			double bin=linspline.binsearch(x,n);
			double spline=linspline.linterp(x,y,n);
			double integ=linspline.linterpInteg(x,y,n);
			WriteLine($"{n} {bin} {spline} {integ}");
			}
	}
}
