using System;
using static System.Console;
using static System.Math;

class main{
    public static void Main(){
        Func<vector,double> f1= delegate(vector x) {return Pow(1-x[0],2)+100*Pow(x[1]-x[0]*x[0],2);}; //Rosenbrock
        vector x1=new vector(2);
        for(int i=0; i<x1.size; i++)x1[i]=0;

        (vector xmin1,int steps1)=minimize.qnewton(f1,x1);

        WriteLine($"Testing minima of the Rosenbrock function.\n");

        WriteLine($"The calculated minima are x={xmin1[0]} y={xmin1[1]}. The minima were found in {steps1} steps. The actual minima are supposed to be x=1 and y=1\n");
    
        Func<vector,double> f2=delegate(vector x) {return Pow(x[0]*x[0] + x[1] - 11,2) + Pow(x[0] + x[1]*x[1] -7,2);};
        vector x2=new vector(2);
        x2[0]=2.5;
        x2[1]=2.5;

        (vector xmin2, int steps2)=minimize.qnewton(f2,x2);

        WriteLine($"Testing minima of the Himmelblau function.\n");

        WriteLine($"The calculated minima are x={xmin2[0]} y={xmin2[1]}. The minima were found in {steps2} steps. The actual minima are supposed to be x=3 and y=2\n");

    }//Main
}//main