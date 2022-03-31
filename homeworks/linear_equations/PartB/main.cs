using System;
using static System.Console;
using static System.Math;

class main{
    public static void Main(){
        Random rnd=new Random();
        int m=rnd.Next(2,6);
        int n=rnd.Next(m,m*2); //Matrix dimensions
        var A_square=new matrix(n,n); //Square matrix for solving vector b.
        for(int i=0; i<n; i++){
            for(int j=0; j<n; j++){
                matrix.set(A_square,i,j,rnd.Next(1,11));
            }
        }//Filling square matrix and vector b.
        WriteLine("-----MATRIX A-----");
        A_square.print("A=");
        WriteLine("-----CALCULATING THE INVERSE OF A, B-----");
        QRGS A_qr=new QRGS(A_square);   
        matrix B=A_qr.inverse();
        B.print("B=");
        WriteLine($"Testing if A*B=Id: {(A_square*B).approx(matrix.id(A_square.size2))}");
    }
}