using System;
using static System.Console;
using static System.Math;
using System.IO;

class main{
    public static void Main(){
        double a=0, b=1;
        Func<double,double> fs1=delegate(double x){return Sqrt(x);};
        Func<double,double> fs2=delegate(double x){return 1.0/Sqrt(x);};
        Func<double,double> fs3=delegate(double x){return 4*Sqrt(1-x*x);};
        Func<double,double> fs4=delegate(double x){return Log(x)/Sqrt(x);};

        //Calculating the integrals
        double Q1=integrate.quad(fs1,a,b);
        double Q2=integrate.quad(fs2,a,b);
        double Q3=integrate.quad(fs3,a,b);
        double Q4=integrate.quad(fs4,a,b);

        WriteLine("Intgrals from 0 to 1 of various functions: \n");
        WriteLine($"Sqrt(x)={Q1}. Should be {0.667}. \n");
        WriteLine($"1/Sqrt(x)={Q2}. Should be {2}. \n");
        WriteLine($"4*Sqrt(1-x^2)={Q3}. Should be {PI}. \n");
        WriteLine($"Log(x)/Sqrt(x)={Q4}. Should be {-4}. \n");

        //Error function. Included in the quad routine.
        var erfnum=new StreamWriter("erf_calc.txt");
        for(double z=0; z<=3.5; z+=0.1){
            double erf_quad=integrate.erf(z);
            erfnum.WriteLine($"{z} {erf_quad}");
        }
        erfnum.Close();


    }//Main
}//main