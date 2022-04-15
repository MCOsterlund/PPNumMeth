using System;
using static System.Console;
using static System.Math;

public class ODE{

    public static (vector, vector) rk12step(Func <double,vector,vector> f, double x, vector y, double h){
        vector k0=f(x,y);
        vector k1=f(x+h/2,y+k0*(h/2));
        vector yh=y+k1*h;
        vector er=(k1-k0)*h;
        return(yh,er);
    }//rk12step

    public static vector driver(Func <double,vector,vector> F, double a, vector ya, double b, double h=0.01, double acc=0.01, double eps=0.01){
        if(a>b) throw new Exception("driver: a>b");
        double x=a; vector y=ya;
        do{
            if(x>=b) return y;
            if(x+h>b) h=b-x;
            var (yh,erv)=rk12step(F,x,y,h);
            double tol=Max(acc,yh.norm()*eps)*Sqrt(h/(b-a));
            double err=erv.norm();
            if(err<=tol){x+=h; y=yh;}
            h*=Min( Pow(tol/err,0.25)*0.95 , 2);
        }while(true);
    }//driver
}//ODE