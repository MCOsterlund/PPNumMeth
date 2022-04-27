using System;
using static System.Console;
using static System.Math;

class main{
    public static void Main(){
        //Volume definitions
        vector a=new vector(3);
        vector b=new vector(3);

        a[0]=0; a[1]=0; a[2]=0;
        b[0]=1; b[1]=PI; b[2]=2*PI;

        //Function definition
        Func<vector,double> f_sphere=delegate(vector v){return v[0]*v[0]*Sin(v[1]);};

        int N=1000000;
        (double result,double err)=MCsolve.plainmc(f_sphere,a,b,N);

        WriteLine("DEBUGGING EXAMPLE: Calculating the volume of a sphere of radius 1.\n");
        WriteLine($"The integrated result is: {result}, should be {4.0*PI/3.0}. Estimated error from is {err}. Deviation from actual result is {Abs(result-4.0*PI/3.0)}.\n");
        
        WriteLine("Testing the singular example from the exercise.\n");

        vector a1=new vector(3);
        vector b1=new vector(3);

        for(int i=0; i<a1.size; i++){
            a1[i]=0;
            b1[i]=PI;
        }

        Func<vector,double> f_ex=delegate(vector v){return 1.0/(Pow(PI,3))*1.0/(1.0-Cos(v[0])*Cos(v[1])*Cos(v[2]));};

        (double result1,double err1)=MCsolve.plainmc(f_ex,a1,b1,N);

        WriteLine($"Integrated result is: {result1}, should be {1.3932039296856768591842462603255}. Error is {err1}. Deviation from actual result is {Abs(result1-1.3932039296856768591842462603255)}\n");

        WriteLine("Debugging of Quasi-random sampling.\n");    

        (double result2,double err2)=MCsolve.MCquasi(f_sphere,a,b,N);

        WriteLine($"The integrated result is: {result2}, should be {4.0*PI/3.0}. Error is {err2}. Deviation from actual result is {Abs(result2-4.0*PI/3.0)}.\n");

        WriteLine("Testing the singular example from the exercise.");

        (double result3, double err3)=MCsolve.MCquasi(f_ex,a1,b1,N);

        WriteLine($"Integrated result is: {result3}, should be {1.3932039296856768591842462603255}. Error is {err3}. Deviation from the actual result is {Abs(result3-1.3932039296856768591842462603255)}\n");       
    }
}