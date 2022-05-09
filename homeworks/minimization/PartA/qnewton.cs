using System;
using static System.Console;
using static System.Math;

public class minimize{

    public static readonly double DELTA=Pow(2,-26);

    public static vector gradient(Func<vector,double> f, vector x){
        vector grad=new vector(x.size);
        double fx=f(x);
        for(int i=0; i<x.size; i++){
            double dx=Abs(x[i])*DELTA;
            if(Abs(x[i])<DELTA)dx=DELTA;
            x[i]+=dx;
            grad[i]=(f(x)-fx)/dx;
            x[i]-=dx;
        }
        return grad;
    }

    public static (vector,int) qnewton(Func<vector,double> f, vector x, double acc=1e-3){
        double fx=f(x);
        vector gx=gradient(f,x);
        matrix B=matrix.id(x.size);
        int step=0;
        while(step<10000){
            step++;
            vector dx=-B*gx;
            if(dx.norm()<DELTA*x.norm()){
                Error.WriteLine($"SR1: Error, |dx|<DELTA*|x|");
                break;
            }
            if(gx.norm()<acc){
                Error.WriteLine($"SR1: Minima has been found (|gx|<acc)");
                break;
            }
            vector z;
            double fz, l=1;
            while(true){
                z=x+dx*l;
                fz=f(z);
                if(fz<fx){
                    break;
                }
                if(l<DELTA){
                    B.setid();
                    break;
                }
                l/=2;
            }
            vector s=z-x;
            vector gz=gradient(f,z);
            vector y=gz-gx;
            vector u=s-B*y;
            double udoty=u.dot(y);
            if(Abs(udoty)>1e-6){
                B.update(u,u,udoty);
            }
            x=z;
            gx=gz;
            fx=fz;
        }
    return (x,step);
    }//qnewton
}//minimize