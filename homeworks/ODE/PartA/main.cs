using System;
using static System.Console;
using static System.Math;
using System.IO;

class main{
    public static void Main(){
        double a=0;

        //Definining functions
        Func<double,vector,vector> dudtdt=delegate(double t, vector y){
            double u0=y[1]; //Contains y2, that is, u'.
            double u1=-y[0]; //Contains u'', that is, -u.
            vector usol=new vector(u0,u1); 
            return usol;
        };

        Func<double,vector,vector> py_comp=delegate(double t, vector y){
            double b=0.25;
            double c=5.0;
            double omega=y[1];
            double theta=y[0];
            vector py_sol=new vector(omega,-b*omega - c*Sin(theta));
            return py_sol;
        };

        //Debug example
        vector yinit=new vector(0,-1); //initial values.
        var debug=new StreamWriter("debug.txt");
        for(int i=0; i<=100; i++){
            double t=i/(2*PI);
            vector sol=ODE.driver(dudtdt,a,yinit,t);
            debug.WriteLine($"{t} {sol[0]} {sol[1]} {-Cos(t)}");
        }
        debug.Close();

        //Scipy example
        vector y0=new vector(PI-0.1,0.0);
        var py_write=new StreamWriter("py_comp.txt");
        for(int i=0; i<=100; i++){
            double t=i*1.0/10;
            vector sol=ODE.driver(py_comp,a,y0,t);
            py_write.WriteLine($"{t} {sol[0]} {sol[1]}");
        }
        py_write.Close();
    }//Main
}//main