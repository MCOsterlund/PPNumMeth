using System;
using static System.Math;
using static System.Console;

public class ann{
    public readonly int n;
    public Func<double,double> f;
    public Func<double,double> dfdx;
    public Func<double,double> f_int;
    public vector p;
    public ann(int n, Func<double,double> f, Func<double,double> dfdx, Func<double,double> f_int){
        this.n=n;
        this.dfdx=dfdx;
        this.f_int=f_int;
        this.f=f;
        this.p=new vector(3*n);
    }//ann

    public double response(double x){
        double sum=0;
        for(int i=0; i<n; i++){
            double a=p[3*i+0];
            double b=p[3*i+1];
            double w=p[3*i+2];
            sum+=f((x-a)/b)*w;
        }
        return sum;
    }//response

    public double responsedf(double x){
        double sum=0;
        for(int i=0; i<n; i++){
            double a=p[3*i+0];
            double b=p[3*i+1];
            double w=p[3*i+2];
            sum+=dfdx((x-a)/b)*w/b;
        }
        return sum;
    }

    public double responseint(double x){
        double sum=0;
        for(int i=0; i<n; i++){
            double a=p[3*i+0];
            double b=p[3*i+1];
            double w=p[3*i+2];
            sum+=f_int((x-a)/b)*w*b;
        }
        return sum;
    }

    public void train(vector xs, vector ys){
        Func<vector,double> cost=(u) =>{
            double sum=0;
            p=u;
            for(int k=0; k<xs.size; k++)sum+=Pow(response(xs[k])-ys[k],2);
            return sum/xs.size;
        };
        var (result,nsteps)=minimize.qnewton(cost,p,1e-3);
        p=result;
    }//train

}//class