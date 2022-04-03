using System;
using static System.Console;
using static System.Math;

public class QRGS{
    public matrix Q,R;

    public QRGS(matrix A){
        Q=A.copy(); R=new matrix(A.size2,A.size2);
        for(int i = 0; i<A.size2; i++){
            R[i,i]=Q[i].norm();
            Q[i]/=R[i,i];
            for(int j=i+1; j<A.size2; j++){
                R[i,j]=Q[i].dot(Q[j]);
                Q[j]-=Q[i]*R[i,j];
            }
        }
    }//QRGS method
    public vector QRGSsolve(vector b, bool useQ=true){
            vector x;
            if(useQ){
            x=Q.T*b;
            }
            else{x=b.copy();}
            for(int i=x.size-1; i>=0;i--){
                double sum=0;
                for(int k=i+1; k<x.size; k++){
                    sum+=R[i,k]*x[k];   
                }
                x[i]=(x[i]-sum)/R[i,i];
            }
            return x;
    }//solve

    public matrix inverse(){
        matrix A=Q*R;
        matrix B=new matrix(A.size1,A.size2);
        for(int j=1; j<=A.size1; j++){
            vector es=new vector(A.size1);
            es[j-1]=1;
            B[j-1]=QRGSsolve(es);
        }
        return B;
    }//inverse
    public matrix pinverse(){
        int m=R.size2;
        var B=new matrix(m,m);
        var e=new vector(m);
        for(int i=0;i<m;i++){
                e[i]=1;
                B[i]=QRGSsolve(e,useQ:false);
                e[i]=0;
                }
        return B*Q.T;
        }//pinverse
    
}//QRGS class