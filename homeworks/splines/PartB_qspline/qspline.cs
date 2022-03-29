using System;
using static System.Console;
using static System.Math;
using System.Linq;

public class qspline{

	public double[] x,y,b,c;

	public static int binsearch(double[] x, double z)
	{/* Locates interval for z-bisection. How we should split our interval*/
		if(!(x[0]<=z && z<=x[x.Length - 1])) throw new Exception("binsearch: bad z");
		int i=0, j=x.Length-1;
		while(j-i>1){ //Checks when we are down to two points.
			int mid=(i+j)/2; //Locating the middle
			if(z>x[mid]) i=mid; else j=mid; 
		}
		return i;}//binsearch

	public qspline(double[] xs, double[] ys){
		int n=xs.Length;
		x=xs;
		y=ys;
		double[] dx=new double[n-1];
		double[] dy=new double[n-1];
		double[] p=new double[n-1];
		c=new double[n-1];
		b=new double[n-1];
		for(int i=0; i<n-1; i++){
			dx[i]=x[i+1] - x[i]; if(!(dx[i]>0)) throw new Exception("qterp: dx<1");
			dy[i]=y[i+1] - y[i];
			p[i]=dy[i]/dx[i];
			}
		for(int i=0; i<n-2; i++){
			c[i+1]=1/dx[i+1]*(p[i+1] - p[i] - c[i]*dx[i+1]);
		}
		//Running the backwards recursion on the above.
		c[n-2]/=2;
		for(int i=n-3; i>=0; i--){
			c[i]=1/dx[i]*(p[i+1] - p[i] - c[i+1]*dx[i+1]);
		}
		for(int i=0; i<n-1; i++){
			b[i]=p[i] - c[i]*dx[i];
		}
	}//qspline

	public double qterp(double z){
		int i=binsearch(x,z);
		return y[i] + b[i]*(z-x[i]) +c[i]*Pow((z-x[i]),2);
	}//qterp

	public double qderiv(double z){
		int i=binsearch(x,z);
		return b[i] + 2*c[i]*(z-x[i]);
	}//qderiv

	public double qint(double z){
		int i=binsearch(x,z);
		double[] IntCon = new double [x.Length-1];
		for(int m=0; m<i; m++){
			IntCon[m]= y[m]*(x[m+1]-x[m]) + 1.0/2 *b[m] *Pow(x[m+1]-x[m],2)+ 1.0/3 * c[m]*Pow(x[m+1]-x[m],3);
		}
		double IntConTot=IntCon.Sum();
		return IntConTot +y[i]*(z-x[i]) + 1.0/2 *b[i]* Pow(z-x[i],2)+ 1.0/3 *c[i]* Pow(z-x[i],3);
	}
}//qspline  
