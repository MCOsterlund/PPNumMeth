using System;
using static System.Math;
using static System.Console;

public class MCsolve{
    public static (double,double) plainmc(Func<vector,double> f, vector a, vector b, int N){ 
        int dim=a.size; double V=1; for(int i=0; i<dim; i++)V*=b[i]-a[i];
        double sum=0 , sum2=0;
        var x=new vector(dim);
        Random rand01=new Random();
        for(int i=0; i<N; i++){
            for(int k=0;k<dim;k++)x[k]=a[k]+rand01.NextDouble()*(b[k]-a[k]);
            double fx=f(x); sum+=fx; sum2+=fx*fx;
        }
    double mean=sum/N, sigma=Sqrt(sum2/N - mean*mean);
    var result=(mean*V,sigma*V/Sqrt(N)); //Returns Weights and error.
    return result;
    }//plainmc
}//MCsolve