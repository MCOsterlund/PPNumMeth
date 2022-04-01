using System;
using static System.Console;
using static System.Math;
using System.IO;

class main{
    
    public static void Main(string[] args){
        var fs=new Func<double,double>[] {z => 1.0, z =>-z}; //The terms in {} are two functions. The first is because we want to multiply or coefficient by one (we want just the coefficient). In the second, we want it to scale linearly.
        var options=StringSplitOptions.RemoveEmptyEntries;
        var instream=new System.IO.StreamReader("input.txt");
        var outstream=new System.IO.StreamWriter("Out.txt");
        //Keeping and formating just the numbers in the data file.
        for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
            string[] bits=line.Split(' ',',',':');
            double number;
            int n_numbers=0;
            int Index=0;
            foreach (string str in bits){
                if(Double.TryParse(str,out number)){
                n_numbers++;
                }
            }
            double[] Data_convert=new double[n_numbers];
            foreach (string str in bits){
                if(Double.TryParse(str,out number)){
                Data_convert[Index]=Double.Parse(str);
                Index++;
                }
            }
            for(int i=0; i<Data_convert.Length; i++){
                outstream.Write($"{Data_convert[i]} ");
            }
            outstream.WriteLine();
        }
        outstream.Close();
        instream.Close();
        //Finding the ammount of numbers in a given string.
        var string_length=new StreamReader("Out.txt");
        string line0=string_length.ReadLine();
        string[] nos=line0.Split(' ','\n',options);
        string_length.Close();
        //Array of the data
        double[,] Data_array=new double[3,nos.Length];
        using(var sr=new StreamReader("Out.txt"))
            for(int i=0; i<Data_array.GetLength(0); i++){
            string line=sr.ReadLine();
            string[] numbers1=line.Split(' ',options);
            for(int j=0; j<Data_array.GetLength(1); j++){
                Data_array[i,j]=Double.Parse(numbers1[j]);
            }
        }

        //Formatting the given data such that data is given in columns, not rows. Can be ommited.
        var Out_format=new StreamWriter("Out_format.txt");

        //Least squares stuff.
        vector xvals=new vector(nos.Length);
        vector yvals=new vector(nos.Length);
        vector dy=new vector(nos.Length);
        for(int i=0; i<nos.Length; i++){
            xvals[i]=Data_array[0,i];
            yvals[i]=Log(Data_array[1,i]);
            dy[i]=Data_array[2,i]/Data_array[1,i];
            Out_format.WriteLine($"{xvals[i]} {yvals[i]} {dy[i]}");
        }
        Out_format.Close();
    vector c=leastsquares.lsfit(fs,xvals,yvals,dy);
    c.print("c=");
    //Txt file with fit data.
    var fit=new StreamWriter("fit.txt");
    for(double x=1; x<=15; x+=0.1){
        fit.WriteLine($"{x} {c[0] - x*c[1]}");
    }
    fit.Close();
    }//Main
}//main