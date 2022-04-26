using System;
using static System.Console;
using static System.Math;

class main{
    public static double Fe(double e, double r, double rmin=1e-3){
        if(r<rmin) return r-r*r;

        Func<double,vector,vector> swave=(x,y)=> new vector(y[1],2*(-1/x +-e)*y[0]);

        vector yrmin=new vector(rmin-rmin*rmin, 1-2*rmin);
        var xs=new genlist<double>();
        var ys=new genlist<vector>();

        vector yrmax=ODE.driver(swave,rmin,yrmin,r,xs,ys);
        return yrmax[0];
    }
    
    public static void Main(string[] args){
        double rmax=8;
        if(args.Length>0) rmax=double.Parse(args[0]);

        Func<vector,vector> master=(vector v)=>{
            double e=v[0];
            double frmax=Fe(e,rmax);
            return new vector(frmax);
        };
        vector vstart=new vector(-1.0);
        vector vroot=rootfinder.newton(master,vstart,eps:1e-4);
        double energy=vroot[0];

	    Write("# r, Fe(e,r), exact\n");
	        for(double r=0; r<=rmax; r+=rmax/64){
		        Write("{0} {1} {2}\n",r,Fe(energy,r),r*Exp(-r));
            }
    }//Main
}//main