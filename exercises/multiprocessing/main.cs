using System;
using System.Threading;
using static System.Console;

class main{

public class data {public int a,b;public double sum;}

public static void harm(object obj){
	data d=(data)obj;
	WriteLine($"harm: Summing from {d.a} to {d.b}");
	d.sum=0; for(int i=d.a;i<d.b;i++)d.sum+=1.0/i; //The C# way: From 0 to N-1.
	WriteLine($"harm: sum={d.sum}");
	
}
	public static void Main(string[] args){
		int N=(int)1e8;
		if(args.Length>0) N = (int)double.Parse(args[0]);
		WriteLine($"N={(float)N}");
		data x=new data();
		x.a=1; x.b=N/2;
		data y=new data();
		y.a=N/2; y.b=N+1;
		Thread t1= new Thread(harm); //Preparing a thread
		Thread t2= new Thread(harm);
		t1.Start(x); //Running the thread
		t2.Start(y);
		t1.Join(); //Joining the forked threads.
		t2.Join();
		WriteLine($"harmonic sum from {1} to {N} is equal to {x.sum+y.sum}");
	}
}
