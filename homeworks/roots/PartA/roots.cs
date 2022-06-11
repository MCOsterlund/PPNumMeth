using System;
using static System.Math;
using static System.Console;

public class rootfinder{
    public static matrix jacobi(Func<vector,vector> f, vector x0){
        int n=f(x0).size;
        int m=x0.size;
        matrix J=new matrix(n,m);
        vector deltax=new vector(x0.size);
        for(int i=0; i<deltax.size; i++){
            deltax[i]=x0[i]*Pow(2,-26);
        }
        for(int j=0; j<n; j++){
            for(int k=0; k<m; k++){
                vector xshift=new vector(deltax.size);
                xshift[k]=deltax[k];
                vector xprime=x0+xshift;
                vector df=f(xprime)-f(x0);
                J[j,k]=df[j]/deltax[k];
            }
        }
        return J;
    }

    public static vector newton(Func<vector,vector> f, vector x0, double eps=1e-6){
        do{
            matrix J=jacobi(f,x0);
            QRGS J_qr=new QRGS(J);
            vector Deltax=J_qr.QRGSsolve(-f(x0));
            double l=1.0;
            do{
                l/=2;
            }while(f(x0+l*Deltax).norm()>(1-l/2)*f(x0).norm() && l>1.0/32);
            x0+=l*Deltax;
        }while(f(x0).norm()>eps);
        return x0;
    }
}