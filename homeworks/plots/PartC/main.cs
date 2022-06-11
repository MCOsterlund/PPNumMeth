using System;
using static System.Console;
using static System.Math;

class main{

	static complex gamma(complex z){
		if(cmath.abs(z)<0){return PI/cmath.sin(PI*z)/gamma(1-z);}
		if(cmath.abs(z)<9){return gamma(z+1)/z;}
		complex lngamma=z*cmath.log(z+1/(12*z - 1/z/10)) -z + cmath.log(2*PI/z)/2;
		return cmath.exp(lngamma);
	}

	static public void Main(){
		double dx=1.0/16, shift=dx/2;
		for(double R=-4+shift; R<4; R+=dx){
		for(double Ima=-4+shift; Ima<=4; Ima+=dx){
			complex z=new complex(R,Ima);
				WriteLine($"{R} {Ima} {cmath.abs(gamma(z))}");
		}	
		}


	}
}
