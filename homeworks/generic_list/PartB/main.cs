using System;
using static System.Console;
using static System.Math;
public class main{

public static void Main(){
	var list = new genlist<int>();
	
	//Adding numbers to the list.
	list.push(4);
	list.push(76);
	list.push(8983);
	WriteLine("Printed list of numbers");
	list.print();
	
	list.remove(1);
	WriteLine("The second element has been removed. The new list is");
	list.print();
	list.push(77);
	list.push(88);
	list.print();
	list.remove(list.size-2);
	list.print();
		}
}

