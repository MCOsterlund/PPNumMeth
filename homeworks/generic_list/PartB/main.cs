using System;
using static System.Console;
using static System.Math;
public class main{

public static void Main(){
	var list = new genlist<double[]>();
	char[] delimiters = {' ','\t'}; //How things should be separated in the list
	var options = StringSplitOptions.RemoveEmptyEntries; //Specifies options for Split
	for(string line=ReadLine(); line!=null; line=ReadLine()){ //Reads the lines in the input
		var words = line.Split(delimiters,options); //Implementation of Split
		int n = words.Length; //Finds the length of each string and saves it in n.
		var numbers = new double[n];	
		for(int i=0;i<n;i++) numbers[i]=double.Parse(words[i]); //Parses a string to an integer
		list.push(numbers);
	}
	list.remove(3);
	for(int i=0;i<list.size;i++){
		var numbers=list.data[i];
		foreach(var number in numbers)WriteLine($"{number:e}");
		WriteLine();
	}
}
}
