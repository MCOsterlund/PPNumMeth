using System;
using static System.Console;
using static System.Math;
using System.IO;
using System.Linq;

//A NOTE ON THE .txt FILES IN THIS DOCUMENT:
//"input.txt" contains the input data
//"input_clean.txt" is the input.txt only cleaned of letters and other symbols. 
//"input_format.txT" is the input_clean.txt formatted for pyxplot. Data has also been converted to logarithmic values. 
//"fit.txt" contains the fitted parameters.
//"Out.txt" contains the variables concerning the fit. Covariance matrix, fit parameters, calculated half life:

class main{
    
    public static void Main(string[] args){
        var fs=new Func<double,double>[] {z => 1.0, z =>-z}; //The terms in {} are two functions. The first is because we want to multiply or coefficient by one (we want just the coefficient). In the second, we want it to scale linearly.
        var options=StringSplitOptions.RemoveEmptyEntries;
        var instream=new System.IO.StreamReader("input.txt");
        var outstream=new System.IO.StreamWriter("input_clean.txt");
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
        var string_length=new StreamReader("input_clean.txt");
        string line0=string_length.ReadLine();
        string[] nos=line0.Split(' ','\n',options);
        string_length.Close();
        //Array of the data
        double[,] Data_array=new double[3,nos.Length];
        using(var sr=new StreamReader("input_clean.txt"))
            for(int i=0; i<Data_array.GetLength(0); i++){
            string line=sr.ReadLine();
            string[] numbers1=line.Split(' ',options);
            for(int j=0; j<Data_array.GetLength(1); j++){
                Data_array[i,j]=Double.Parse(numbers1[j]);
            }
        }

        //Formatting the given data such that data is given in columns, not rows. Can be ommited.

        var input_format=new StreamWriter("input_clean_format.txt");
        //Least squares stuff.
        vector xvals=new vector(nos.Length);
        vector yvals=new vector(nos.Length);
        vector dy=new vector(nos.Length);
        for(int i=0; i<nos.Length; i++){
            xvals[i]=Data_array[0,i];
            yvals[i]=Log(Data_array[1,i]);
            dy[i]=Data_array[2,i]/Data_array[1,i];
            input_format.WriteLine($"{xvals[i]} {yvals[i]} {dy[i]}");
        }
        input_format.Close();
    (vector c,matrix S)=leastsquares.lsfit(fs,xvals,yvals,dy);
    S.print("Covariance matrix=");
    c.print("Fitting Parameters=");


    //Error propagation
    double[] S_diag=new double[S.size1];
    for(int i=0; i<S.size1; i++){
        S_diag[i]=Sqrt(S[i,i]);
    }

    //Txt file with fit data.
    var fit=new StreamWriter("fit.txt");
    for(double x=1; x<=15; x+=0.1){
        fit.WriteLine($"{x} {c[0] - x*c[1]}");
    }
    fit.Close();

    //Half life calculations and error propagation of half life.
    double hl=Log(2)/c[1];
    double err_hl=S_diag[1]*hl/c[1];
    WriteLine($"The fitted halflife is: t_(1/2)={hl} +/- {err_hl}");
    double hl_true=3.6;
    bool hl_bool=hl-err_hl<=hl_true && hl+err_hl>=hl_true;
    WriteLine($"The table half-life is given as: {hl_true}. The fitted halflife is within expected error: {hl_bool}");

    }//Main
}//main