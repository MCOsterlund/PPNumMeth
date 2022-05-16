using System;
using static System.Console;
using static System.Math;

class main{
static Func<double,double> f=(x)=> x*Exp(-x*x); //Activation function, Gaussian wavepacket
static Func<double,double> dfdx=(x)=> Exp(-x*x)*(1-2*x*x);
static Func<double,double> f_int=(x)=> -Exp(-x*x)/2;
static Func<double,double> g=(x)=> Cos(5*x-1)*Exp(-x*x); //Trial function
static Func<double,double> dgdx=(x)=> Exp(-x*x)*(-5*Sin(5*x-1) - 2*x*Cos(5*x-1));
    public static void Main(){
        int n=3;
        var net=new ann(n,f,dfdx,f_int);
        double a=-1, b=1; //Start points and end points.
        int N=20; //Number of points
        double[] xs=new double[N];
        double[] ys=new double[N];
        double[] ys_df=new double[N];
        for(int i=0; i<N; i++){
            xs[i]=a+(b-a)*i/(N-1);
            ys[i]=g(xs[i]);
            ys_df[i]=dgdx(xs[i]);
            WriteLine($"{xs[i]} {ys[i]} {ys_df[i]}");
        }
        WriteLine("\n\n");
        for(int i=0; i<net.n; i++){
            net.p[3*i+0]=a+(b-a)*i/(net.n-1);
            net.p[3*i+1]=1;
            net.p[3*i+2]=1;
        }
        net.train(xs,ys);
        for(double z=a; z<=b; z+=1.0/64){
            WriteLine($"{z} {net.response(z)} {net.responsedf(z)} {net.responseint(z)}");
        }
        WriteLine("\n\n");
        net.p.print("Final parameters");
    }
}