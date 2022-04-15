using System;
using static System.Console;
using static System.Math;
using System.IO;

class main{
    public static void Main(){
        double a=0;

        Func<double,vector,vector> py_comp=delegate(double t, vector y){
            double b=0.25;
            double c=5.0;
            double omega=y[1];
            double theta=y[0];
            vector py_sol=new vector(omega,-b*omega - c*Sin(theta));
            return py_sol;
        };

        //Scipy example
        vector y0=new vector(PI-0.1,0.0);
        var py_write=new StreamWriter("py_comp.txt");
        var xs=new genlist<double>();
        var ys=new genlist<vector>();
        double b_end=10;
        vector sol=ODE.driver(py_comp,a,y0,b_end,xs,ys);
        for(int i=0; i<xs.size; i++){
        py_write.WriteLine($"{xs.data[i]} {ys.data[i][0]} {ys.data[i][1]}");
        }
        py_write.Close();
    }//Main
}//main