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

    public static double corput(int n, int bas){
        double q=0, bk=1.0/bas;
        while(n>0){ q+=(n%bas)*bk; n/=bas; bk/=bas; }
        return q;
    }//corput

    public static vector halton(int n, int d, vector y, int sec=0){
    int[] bas={2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67};
    if(bas.Length<d)throw new Exception("halton: bas.Length<=d");
    for(int i=0; i<d; i++){y[i]=corput(n,bas[(i+sec)%bas.Length]);}
    return y;
    }

    public static (double,double) MCquasi(Func<vector,double> f, vector a, vector b, int N){
        int dim=a.size; double V=1.0; for(int i=0;i<dim;i++)V*=b[i]-a[i];
        double sum=0, sum2=0;
        vector x=new vector(dim);
        vector x2=new vector(dim);

        int offset=0;
        for(int i=0; i<N; i++){
            vector quas=halton(i+offset,dim,x);
            vector quas2=halton(i+offset,dim,x2,4);
            for(int k=0; k<dim; k++){
                x[k]=a[k]+quas[k]*(b[k]-a[k]);
                x2[k]=a[k]+quas2[k]*(b[k]-a[k]);
            }
            double fx=f(x); 
            double fx2=f(x2);
            if(double.IsNaN(fx)||double.IsInfinity(fx)||double.IsNaN(fx2)||double.IsInfinity(fx2)){
                --i; ++offset;
            } 
            else{
                sum+=fx;
                sum2+=fx2;
            }
        }
        double mean=sum/N, mean2=sum2/N;
        var result=(mean*V,Abs(mean*V-mean2*V));
        return result;
    }

}//MCsolve