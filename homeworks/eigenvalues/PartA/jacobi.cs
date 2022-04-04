using System;
using static System.Console;
using static System.Math;

public class jacobi{
    public static void timesJ(matrix A, int p, int q, double theta){
        double c=Cos(theta), s=Sin(theta);
        for(int i=0; i<A.size1;i++){
            double aip=A[i,p], aiq=A[i,q];
            A[i,p]=c*aip-s*aiq;
            A[i,q]=s*aip+c*aiq;
        }
    }//timesJ

    public static void Jtimes(matrix A, int p, int q, double theta){
        double c=Cos(theta), s=Sin(theta);
        for(int j=0; j<A.size1;j++){
            double apj=A[p,j], aqj=A[q,j];
            A[p,j]=c*apj+s*aqj;
            A[q,j]=-s*apj+c*aqj;
        }
    }//Jtimes
    public static (matrix,matrix) jacobi_cyclic(matrix A){ 
        bool changed;
        matrix V=matrix.id(A.size1);
        matrix D=A.copy();
        int n=A.size1;
        do{
                changed=false;
                for(int p=0; p<n-1;p++){
                for(int q=p+1; q<n; q++){
                    double apq=matrix.get(D,p,q);
                    double app=matrix.get(D,p,p);
                    double aqq=matrix.get(D,q,q);
                    double theta=0.5*Atan2(2*apq,aqq-app);
                    double c=Cos(theta), s=Sin(theta);
                    double new_app=c*c*app-2*s*c*apq+s*s*aqq;
                    double new_aqq=s*s*app+2*s*c*apq+c*c*aqq;
                    if(new_app!=app || new_aqq!=aqq){ //If condition is true, do rotation
                        changed=true;
                        timesJ(D,p,q,theta);
                        Jtimes(D,p,q,-theta); //Jacobi rotation of A.
                        timesJ(V,p,q,theta); //Applying V=1*J_1*J_2...*J_n
                    } 
                }
            }
        }while(changed);
        return(D,V);
    }  //jacobi_cyclic
}//Jacobi