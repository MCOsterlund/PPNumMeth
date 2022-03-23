using System;
using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		char[] delimiters={' ', '\t', '\n'}; //How things should be separated
		var options = StringSplitOptions.RemoveEmptyEntries; //Removes empty entries
		for(string line = ReadLine(); line !=null; line=ReadLine() ){
			var words = line.Split(delimiters,options);
			foreach(var word in words){
				double x=double.Parse(word);
				WriteLine($"{x} {Sin(x)} {Cos(x)}\n");

		}
	}
} //Main
} //main
