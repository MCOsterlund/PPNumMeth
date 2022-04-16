using System;
using static System.Console;
using static System.Math;
using System.IO;

class main{
    public static void Main(){
        double a=0, b=1;
        int i=0, j=0;
        Func<double,double> fs1=delegate(double x){i++; return 1/Sqrt(x);};
        Func<double,double> fs2=delegate(double x){j++; return Log(x)/Sqrt(x);};

        //Calculating the integrals
        double Q1=integrate.quad(fs1,a,b);
        double Q2=integrate.quad(fs2,a,b);

        WriteLine("-----REGULAR QUADRATURES----- \n");
        WriteLine($"The integral of 1/Sqrt(x)={Q1}. Should be 2. Number of steps: {i}");
        WriteLine($"The integral of Log(x)/Sqrt(x)={Q2}. Should be -4. Number of steps: {j}\n");

        i=0; j=0;
        //Clenshaw-Curtis quadratures
        double Q1_CC=integrate.CC_quad(fs1,a,b);
        double Q2_CC=integrate.CC_quad(fs2,a,b);

        WriteLine("-----CLENSHAW-CURTIS TRANSFORMATION-----\n");
        WriteLine($"The integral of 1/Sqrt(x)={Q1_CC}. Should be 2. Number of steps: {i}");
        WriteLine($"The integral of Log(x)/Sqrt(x)={Q2_CC}. Should be -4. Number of steps: {j}\n");

    }//Main
}//main