using System;
using static System.Console;
using static System.Math;

public class linspline{
	public static int binsearch(double[] x, double z)
	{/* Locates interval for z-bisection. How we should split our interval*/
		if(!(x[0]<=z && z<=x[x.Length - 1])) throw new Exception("binsearch: bad z");
		int i=0, j=x.Length-1;
		while(j-i>1){ //Checks when we are down to two points.
			int mid=(i+j)/2; //Locating the middle
			if(z>x[mid]) i=mid; else j=mid; 
		}
		return i;}//binsearch

	public static double linterp(double[] x, double[] y, double z){
		int i=binsearch(x,z);
		double dx=x[i+1] - x[i]; if(!(dx>0)) throw new Exception("ERROR");
		double dy=y[i+1] - y[i];
		return y[i] + dy/dx*(z-x[i]);
	}//linterp
}//lspline  
