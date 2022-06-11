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

    public static vector driver(Func <double,vector,vector> F, double a, vector ya, double b, genlist<double> xs=null, genlist<vector> ys=null, double h=0.01, double acc=0.01, double eps=0.01){
        if(a>b) throw new Exception("driver: a>b");
        double x=a; vector y=ya;
        do{
            if(x>=b) return y;
            if(x+h>b) h=b-x;

            var (yh,erv)=rk12step(F,x,y,h);
            vector tol=new vector(y.size);
            for(int i=0;i<tol.size;i++){
                tol[i]=Max(acc,yh[i]*eps)*Sqrt(h/(b-a));
            }
            bool ok=true;
            for(int i=0; i<tol.size;i++){
                ok=(ok && erv[i]<tol[i]);
            }

            if(ok) {
                x+=h; 
                y=yh; 
                xs.push(x);
                ys.push(y);
            }
            double factor=tol[0]/Abs(erv[0]);
            for(int i=1;i<tol.size;i++){
                 factor=Min(factor,tol[i]/Abs(erv[i]));
            }
            h*=Min( Pow(factor,0.25)*0.95 , 2);
        }while(true);
    }//driver
}//ODE