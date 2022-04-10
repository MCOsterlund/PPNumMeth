using System;
using static System.Console;
using static System.Math;
using System.IO;

class main{

    public static (matrix,vector,double) H_calc(int npoints){
        double dr=0.2; //Stepsize
        vector r=new vector(npoints);
        matrix H=new matrix(npoints,npoints);
        for(int i=0;i<npoints; i++){r[i]=dr*(i+1);}
        for(int i=0;i<npoints-1; i++){
            matrix.set(H,i,i,-2);
            matrix.set(H,i,i+1,1);
            matrix.set(H,i+1,i,1);
        }
    matrix.set(H,npoints-1,npoints-1,-2); //Assigning final value on diagonal to -2.
    H*=-0.5/dr/dr; //Definition of K
    for(int i=0;i<npoints;i++){H[i,i]+=-1/r[i];} //Making the final H matrix.
    return(H,r,dr);
    }

    public static void nconvergence(){ 
        int nstart=10; //Starting number of n's.
        int nmax=200; //Maximally, we use 200 points
        var nconvergence=new StreamWriter("nconvergence.txt");
        for(int i=nstart; i<=nmax; i+=5){
            (matrix H, vector r, double dr)=H_calc(i);
            (matrix e, matrix V)=jacobi.jacobi_cyclic(H);
            nconvergence.WriteLine($"{i} {e[0,0]} {e[1,1]} {e[2,2]} {-0.4998} {-0.1341} {-0.05952}");
        }
        nconvergence.Close();
    }

    public static void rconvergence(){
        int rmax=20;
        double dr=0.2;
        var rconvergence=new StreamWriter("rconvergence.txt");
        for(double r=1; r<rmax; r+=0.5){
            int npoints=(int)(r/dr)-1;
            (matrix H, vector r_vals, double dr_h)=H_calc(npoints);
            (matrix e, matrix V)=jacobi.jacobi_cyclic(H);
            rconvergence.WriteLine($"{r} {e[0,0]} {e[1,1]} {e[2,2]} {-0.4998} {-0.1341} {-0.05952}");
        }
        rconvergence.Close();
    }

    public static void Main(){

    nconvergence();
    rconvergence();

    int npoints=200;
    (matrix H, vector r, double dr)=H_calc(npoints);

    //Jacobi diagonalization
    (matrix e, matrix V)=jacobi.jacobi_cyclic(H);
    //e.print("e=");
    //V.print("V=");

    double[] realvals0=new double[npoints];
    double[] numvals0=new double[npoints];
    double[] realvals1=new double[npoints];
    double[] numvals1=new double[npoints];
    double[] realvals2=new double[npoints];
    double[] numvals2=new double[npoints];

    for(int i=0; i<npoints; i++){
        realvals0[i]=2*r[i]*Exp(-r[i]);
        realvals1[i]=r[i]*1.0/Sqrt(2)*(1-r[i]/2)*Exp(-r[i]/2);
        realvals2[i]=r[i]*2/(3*Sqrt(3))*(1-2*r[i]/3 + 2*Pow(r[i],2)/27)*Exp(-r[i]/3);
        numvals0[i]=V[i,0]/Sqrt(dr);
        numvals1[i]=-V[i,1]/Sqrt(dr);
        numvals2[i]=-V[i,2]/Sqrt(dr);
    }

    //Collecting numerical and tabulated results in out.txt along with r values.

    var wfplot=new StreamWriter("wfplot.txt");
    for(int i=0;i<npoints; i++){
    wfplot.WriteLine($"{r[i]} {realvals0[i]} {numvals0[i]} {realvals1[i]} {numvals1[i]} {realvals2[i]} {numvals2[i]}");
    }
    wfplot.Close();

    }//Main
}//main