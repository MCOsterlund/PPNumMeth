using System;
using static System.Math;
using static System.Console;

class main{
    public static void Main(){
        WriteLine("This is a comparison of the regular quadrature algorithm from the homeworks, which performed two subdivisions, with our new algorithm, which performs 3 subdivisions\n");

        double a=0, b=1;
        int i=0, j=0, k=0, l=0;

        WriteLine("Trial functions: f1(x)=Sqrt(x), f2=1/Sqrt(x), f3=4*Sqrt(1-x^2) and f4(x)=Log(x)/Sqrt(x).\n");

        Func<double,double> fs1=delegate(double x){i++; return Sqrt(x);};
        Func<double,double> fs2=delegate(double x){j++; return 1/Sqrt(x);};
        Func<double,double> fs3=delegate(double x){k++; return 4*Sqrt(1-x*x);};
        Func<double,double> fs4=delegate(double x){l++; return Log(x)/Sqrt(x);};

        double Q1=integrate.quad(fs1,a,b);
        double Q2=integrate.quad(fs2,a,b);
        double Q3=integrate.quad(fs3,a,b);
        double Q4=integrate.quad(fs4,a,b);

        int i1=i, j1=j, k1=k, l1=l;

        i=0; j=0; k=0; l=0;

        //double Q3=integrate.threequad(fs1,a,b);
        double Q5=integrate.threequad(fs1,a,b);
        double Q6=integrate.threequad(fs2,a,b);
        double Q7=integrate.threequad(fs3,a,b);
        double Q8=integrate.threequad(fs4,a,b);    

        int i2=i, j2=j, k2=k, l2=l;

        WriteLine("-------COMPARISONS-------\n");

        WriteLine($"The integral of Sqrt(x). Using 2 subdivision routine we get {Q1} in {i1} steps. Using 3 subdivisions we get {Q5} in {i2} steps. Actual result is {0.667}.\n");
        WriteLine($"The integral of 1/Sqrt(x). Using 2 subdivision routine we get {Q2} in {j1} steps. Using 3 subdivisions we get {Q6} in {j2} steps. Actual result is {2}.\n");
        WriteLine($"The integral of 4*Sqrt(1-x^2). Using 2 subdivision routine we get {Q3} in {k1} steps. Using 3 subdivisions we get {Q7} in {k2} steps. Actual result is {PI}.\n");
        WriteLine($"The integral of Log(x)/Sqrt(x). Using 2 subdivision routine we get {Q4} in {l1} steps. Using 3 subdivisions we get {Q8} in {l2} steps. Actual result is {-4}.\n");

        WriteLine("In conclusion: The three subdivision routine is generally much faster than the two subdivision routine.");

    }
}