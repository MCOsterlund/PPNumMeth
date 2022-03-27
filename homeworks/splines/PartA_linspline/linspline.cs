using System;
using static System.Console;
using static System.Math;
using System.Linq;

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
		double dx=x[i+1] - x[i]; if(!(dx>0)) throw new Exception("linterp: dx<1");
		double dy=y[i+1] - y[i];
		return y[i] + dy/dx*(z-x[i]);
	}//linterp

	public static double linterpInteg(double[] x, double[] y, double z){
		int i=binsearch(x,z);
		//Implementing a way to make the integrals continuous
		double[] IntCon = new double [x.Length-1];
		double dx=x[i+1] - x[i]; if(!(dx>0)) throw new Exception("linterpInteg: dx<1");
		double dy=y[i+1] - y[i];
		for(int m=0; m<i; m++){
			IntCon[m]= y[m]*(x[m+1]-x[m])+1.0/2* (x[m+1]-x[m])*(y[m+1]-y[m]);
		}
		double IntConTot=IntCon.Sum();
		//Error.WriteLine($"{IntConTot}");
		return IntConTot +y[i]*(z-x[i]) + 1.0/2*dy/dx * Pow(z-x[i],2);
		}//linterpInteg
}//lspline  
