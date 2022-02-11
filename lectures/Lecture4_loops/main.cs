using System;
using static System.Console;
using static System.Math;

class main{
	static void Main(){
		int n=9;
		double[] a=new double[n];
		a[0]=7;
		WriteLine($"a[0]={a[0]}");
		for(int i=0; i<n;i++){a[i]=i;}
		for(int i=0; i<n;i++)WriteLine($"a[{i}]={a[i]}");
		
		int m=n;
		m=0;
		WriteLine($"m={m}, n=...{n}");

		double[] b=a;
		b[0]=999;
		WriteLine($"b[0]={b[0]}, a[0]=...{a[0]}");

		foreach(double ai in a)WriteLine($"ai={ai}");

		vec u=new vec();
		u.print("u=");
		vec v=new vec(1,2,3);
		v.print("v=");
		(u+v).print("u+v=");
		var w=3*u-v;
		w.print("w=");
		vec.print(w);	
	}
}

//Array type is a "double[]". Writing "double[] a;", the compiler links a to an array.
//new creates a new operator, in this case, a new array. All clases are reference types, all structs are value types.
//hibg and stack. Arrays are saved in hibg (the RAM), whereas stack is memory allocated by itsself.
//hibg is managed by the garbage collector.
//The first for loop 
//Remember for "for" loops: Block variables may not shadow
//Structs are not used for large things. 
