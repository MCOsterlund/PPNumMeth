using System;
using static System.Console;
using static System.Math;
using System.IO;

class main{
    public static double Fe(double e, double r, double rmin){
        if(r<rmin) return r-r*r;

        Func<double,vector,vector> swave=(x,y)=> new vector(y[1],2*(-1.0/x -e)*y[0]);

        vector yrmin=new vector(rmin-rmin*rmin, 1-2*rmin);
        var xs=new genlist<double>();
        var ys=new genlist<vector>();
        vector yrmax=ODE.driver(swave,rmin,yrmin,r,xs,ys);
        return yrmax[0];
    }
    
    public static double E_sol(double rmin, double rmax){
        Func<vector,vector> master=(vector v)=>{
            double e=v[0];
            double frmax=Fe(e,rmax,rmin);
            return new vector(frmax);
        };
        vector vstart=new vector(-1.0);
        vector vroot=rootfinder.newton(master,vstart,eps:1e-4);
        double energy=vroot[0];
        return energy;
    }


    public static void Main(){
        double rmax=8;
        double rmin=1e-3;

        double energy=E_sol(rmin,rmax);

        var swavecomp=new StreamWriter("swave.txt");
	        for(double r=0; r<=rmax; r+=rmax/64){
		        swavecomp.WriteLine($"{r} {Fe(energy,r,rmin)} {r*Exp(-r)}");
            }
        swavecomp.Close();

        var rmaxconv=new StreamWriter("rmax.txt");
            for(double rmax2=1; rmax2<=8; rmax2+=0.5){
                rmaxconv.WriteLine($"{rmax2} {E_sol(rmin,rmax2)} {-0.5}");
            }
        rmaxconv.Close(); 

        var rminconv=new StreamWriter("rmin.txt");
            for(double rmin3=1; rmin3>=1e-3; rmin3-=0.1){
                rminconv.WriteLine($"{rmin3} {E_sol(rmin3,rmax)} {-0.5}");
            }
        rminconv.Close();
    }//Main
}//main