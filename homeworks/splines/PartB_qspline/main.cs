using System;
using static System.Console;
using static System.Math;
using System.IO;

class main{
	public static void Main(){
		double[] x={1,2,3,4,5};
		double[] ysq={1,4,9,16,25};
		double[] y1={1,1,1,1,1};
		double[] yx={1,2,3,4,5};
		qspline splinesq= new qspline(x,ysq);
		qspline spline1=new qspline(x,y1);
		qspline splinex=new qspline(x,yx);

		//y equals x squared
		for(double n=1; n<=x[x.Length-1]; n+=0.1){	
			double qterpsq=splinesq.qterp(n);
			double qintsq=splinesq.qint(n);
			double qderivsq=splinesq.qderiv(n);
			WriteLine($"{n} {qterpsq} {qintsq} {qderivsq}");
			}

		//y equals 1
		var xones=new StreamWriter("xones.txt");
		for(double n=1; n<=x[x.Length-1]; n+=0.1){
			double qterp1=spline1.qterp(n);
			double qint1=spline1.qint(n);
			double qderiv1=spline1.qderiv(n);
			xones.WriteLine($"{n} {qterp1} {qint1} {qderiv1}");
		}
		xones.Close();
		//y equals x
		var yequalsx=new StreamWriter("yx.txt");
		for(double n=1; n<=x[x.Length-1]; n+=0.1){
			double qterpx=splinex.qterp(n);
			double qintx=splinex.qint(n);
			double qderivx=splinex.qderiv(n);
			yequalsx.WriteLine($"{n} {qterpx} {qintx} {qderivx}");
		}
		yequalsx.Close();
	}//Main
}//main
