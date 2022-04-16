using System;
using static System.Console;
using static System.Math;

public class integrate{
    public static double quad(
        Func<double,double> f, 
        double a,
        double b,
        double delt=0.001,
        double eps=0.001,
        double f2=double.NaN,
        double f3=double.NaN
    ){
        double h=b-a;
        if(double.IsNaN(f2)){f2=f(a+2*h/6); f3=f(a+4*h/6);} //First function call
        double f1=f(a+h/6), f4=f(a+5*h/6);
        double Q= (2*f1+f2+f3+2*f4)/6*(b-a); //Higer order rule
        double q= (f1+f2+f3+f4)/4*(b-a); //Lower order rule
        double err=Abs(Q-q);
        if(err<= delt+eps*Abs(Q)) return Q;
        else return quad(f,a,(a+b)/2,delt/Sqrt(2),eps,f1,f2)+
                    quad(f,(a+b)/2,b,delt/Sqrt(2),eps,f3,f4);
    }//quad

    public static double erf(double z){
        Func<double,double> f_erf=delegate(double x){return 2/Sqrt(PI)*Exp(-x*x);};
        double erf_int=quad(f_erf,0,z);
        return erf_int;
    }//erf

    public static double CC_quad(
        Func<double,double> f,
        double a,
        double b
    ){
        Func<double,double> ftrans= (theta => f((a+b/2 + (b-a)/2*Cos(theta)))*Sin(theta)*(b-a)/2);
        return quad(ftrans,0,PI);
    }
}//integrate