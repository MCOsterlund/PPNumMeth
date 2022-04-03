using System;
using static System.Console;
using static System.Math;

public class leastsquares{
    public static (vector,matrix) lsfit(Func<double,double>[] fs, vector x, vector y, vector dy){
        int n=x.size; int m=fs.Length;
        var A=new matrix(n,m);
        var b=new vector(n);
        for(int i=0; i<n; i++){
            b[i]=y[i]/dy[i];
            for(int k=0; k<m; k++){A[i,k]=fs[k](x[i])/dy[i];}
        }
        var qra=new QRGS(A);
        vector c=qra.QRGSsolve(b,true);
        matrix B=qra.R.T*qra.R;
        QRGS qrb=new QRGS(B);
        matrix S=qrb.inverse();        
        return (c,S);
    }//lsfit
}//leastsquares