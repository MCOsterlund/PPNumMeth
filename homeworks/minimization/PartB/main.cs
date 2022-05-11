using System;
using static System.Math;
using static System.Console;
using System.IO;

class main{
    public static void Main(){
        //Reading the lines from the datafile and converting them to vectors.
        string[] lines=File.ReadAllLines("higgsdata.txt");
        char[] delimiters={' ', '\t', '\n'};
        var options=StringSplitOptions.RemoveEmptyEntries;
        int len=lines.Length-1;
        vector E=new vector(len);
        vector cross=E.copy();
        vector err=E.copy();
        for(int i=1; i<=len; i++){
            string line=lines[i];
            var words=line.Split(delimiters,options);
            E[i-1]=double.Parse(words[0]);
            cross[i-1]=double.Parse(words[1]);
            err[i-1]=double.Parse(words[2]);
        }

    Func<vector,double,double> BW=delegate(vector x, double e){
        double m=x[0];
        double Lambda=x[1];
        double A=x[2];
        double F=A/(Pow(e-m,2)+Lambda*Lambda/4);
        return F;
    };

    Func<vector,double> deviation=delegate(vector x){
        double sum=0;
        for(int n=0; n<E.size; n++){
            double F=BW(x,E[n]);
            double dev=Pow((F-cross[n])/err[n],2);
            sum+=dev;
        }
        return sum;
    };

    vector x0=new vector(120,3,3);

    (vector xmin, int steps)=minimize.qnewton(deviation,x0);

    var higgsfit=new StreamWriter("higgsfit.txt");

    int k=200;
    vector energies=new vector(k);

    double splits=(E[E.size-1]-E[0])/k;

    energies[0]=E[0];
    for(int j=1; j<k; j++){
        energies[j]+=energies[j-1]+splits;
    }

    for(int i=0; i<k; i++){
        higgsfit.WriteLine($"{energies[i]} {BW(xmin,energies[i])}");
    }
    higgsfit.Close();
    }
}