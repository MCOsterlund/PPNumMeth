using System;
using static System.Console;
using static System.Math;

class main{
    public static void Main(){
        WriteLine("Debugging some simple functions. First we check roots of f(x,y)=[x^2*y,5*x+cos(y)]\n");
        Func<vector,vector> f1=delegate(vector x){
            vector sol=new vector(x[0]*x[0]*x[1], 5*x[0] + Cos(x[1]));
            return sol; 
        };

    vector x0=new vector(1,1);
    vector x1=rootfinder.newton(f1,x0);
    WriteLine($"Roots are: {x1[0]} and {x1[1]}. Evaluating the roots at this point yields: {f1(x1)[0]} and {f1(x1)[1]}\n");
    WriteLine($"Next function: f(x,y,z)=[x,5*z,4*y^2-2*z,z*sin(x)]\n");
        Func<vector,vector> f2=delegate(vector x){
            vector sol=new vector(x[0], 5*x[2], 4*x[1]*x[1]-2*x[2],x[2]*Sin(x[0]));
            return sol;
        };
    vector x02=new vector(1,1,1);
    vector x2=rootfinder.newton(f2,x02);
    WriteLine($"Roots are: {x2[0]}, {x2[1]} and {x2[2]}. Evaluating the roots at this point yields: {f2(x2)[0]}, {f2(x2)[1]} and {f2(x2)[2]}\n");

    WriteLine("Investigating minima of Rosenbrock's Valley function: f(x,y)=(2-x)^2 + 100*(y-x^2)^2\n");

        Func<vector,vector> df=delegate(vector x){
            vector sol=new vector(2*(200*x[0]*x[0]*x[0] - 200 *x[0]*x[1]+ x[0] -2),200*(x[1]-x[0]*x[0]));
            return sol;
        };

    vector x03=new vector(1.5,4.1);
    vector x3=rootfinder.newton(df,x03);
    WriteLine($"Roots are: {x3[0]} and {x3[1]}. Should be 2 and 4.");

    }//Main
}//main