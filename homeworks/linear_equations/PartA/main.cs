using System;
using static System.Console;
using static System.Math;

class main{
    public static void Main(){
        Random rnd=new Random();
        int m=rnd.Next(2,6);
        int n=rnd.Next(m,m*2); //Matrix dimensions
        var A=new matrix(n,m);
        var A_square=new matrix(n,n); //Square matrix for solving vector b.
        var b=new vector(n);
        for(int i=0; i<n; i++){
            b[i]=rnd.Next(1,11);
            for(int j=0; j<m; j++){
                matrix.set(A,i,j,rnd.Next(1,11));
            }
        } //Filling of a random matrix
        for(int i=0; i<n; i++){
            
            for(int j=0; j<n; j++){
                matrix.set(A_square,i,j,rnd.Next(1,11));
            }
        }//Filling square matrix and vector b.
        WriteLine("-----BEFORE QRGS-----");
        A.print("A=");
        WriteLine("-----AFTER QRGS-----");
        QRGS A_qr=new QRGS(A);
        matrix Q=A_qr.Q;
        matrix R=A_qr.R;
        Q.print("Q=");
        R.print("R=");
        WriteLine("-----CHECKING IF QRGS IS PERFORMED CORRECTLY-----");
        WriteLine($"Testing if Q^T*Q=Id: {(Q.T*Q).approx(matrix.id(A.size2))}\n ");
        WriteLine($"Testing if Q*R=A: {(Q*R).approx(A)}\n ");

        WriteLine("-----IN PLACE BACK SUBSTITUTION-----");
        QRGS A_qr_sq=new QRGS(A_square);
        matrix Q_sq=A_qr_sq.Q;
        matrix R_sq=A_qr_sq.R;
        vector x_sol=A_qr_sq.QRGSsolve(b);
        b.print("b=");
        x_sol.print("x=");
        vector prod=A_square*x_sol;
        prod.print("A*x=");
        WriteLine("-----CHECKING IF VECTOR x IS THE CORRECT SOLUTION-----");
        WriteLine($"Testing if A*x=b: {(A_square*x_sol).approx(b)}");


    }
}