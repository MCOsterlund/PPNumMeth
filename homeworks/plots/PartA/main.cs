using System;
using static System.Console;
using static System.Math;

class main{
	public static double erf(double x){
		/// Single precision error function (Abramowitz and Stegun, from Wikipedia)
			 if(x<0) return -erf(-x);
			 double[] a={0.254829592,-0.284496736,1.421413741,-1.453152027,1.061405429};
			 double t=1/(1+0.3275911*x);
			 double sum=t*(a[0]+t*(a[1]+t*(a[2]+t*(a[3]+t*a[4]))));
			 return 1-sum*Exp(-x*x); 
	}
//pyxplot expects a table. We create this in our Main function
	public static void Main(){
		for(double x=0;x<=3.5; x+=1.0/8) 
			WriteLine($"{x} {erf(x)}");
	}	

}
