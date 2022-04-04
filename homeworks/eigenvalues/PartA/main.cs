using System;
using static System.Math;
using static System.Console;

class main{
    public static void Main(){
        //Random symmetric matrix generation.
        Random rnd=new Random();
        int n=rnd.Next(2,10);
        matrix A=new matrix(n,n);
        for(int i=0; i<n; i++){
            for(int j=0; j<=i; j++){
                matrix.set(A,i,j,rnd.Next(0,11));
                matrix.set(A,j,i,A[i,j]);
            }
        }
        A.print("A=");
        WriteLine($"Checking if the matrix A is symmetric: {(A.T).approx(A)}");

        (matrix D,matrix V)=jacobi.jacobi_cyclic(A);
        A.print("Checking if A maintans value after function call.");
        D.print("D (eigenvalue matrix)=");
        V.print("V (eigenvector matrix)=");

        WriteLine("-----TESTING THE ALGORITHM-----");
        WriteLine($"Testing V^T*V: {(V.T*V).approx(matrix.id(A.size1))}");
        WriteLine($"Testing V*V^T: {(V*V.T).approx(matrix.id(A.size1))}");
        WriteLine($"Testing V^T*A*T=D: {(V.T*A*V).approx(D)}");
        WriteLine($"Testing V*D*V^T=A: {(V*D*V.T).approx(A)}");

    }//Main
}//main