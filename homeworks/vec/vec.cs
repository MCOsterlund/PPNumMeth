using static System.Console;
using static System.Math;

public class vec{
	public double x=0, y=0, z=0;
	//constructors:
	public vec(){x=y=z=0;}
	public vec(double a, double b, double c){x=a; y=b; z=c;}
	//Print method for debugging
	public void print(string s){Write(s);WriteLine($"{x} {y} {z}");}
	public void print(){this.print("");}
	public static void print(vec v){v.print("static method");}

	//Simple operators}
	public static vec operator*(vec u, double c){return new vec(c*u.x,c*u.y,c*u.z);}
	public static vec operator*(double c, vec u){
		return u*c; //This is an equivalent method of implementation.
	}

	public static vec operator+(vec u, vec v){
		return new vec(u.x+v.x, u.y+v.y, u.z+v.z);
	}

	public static vec operator+(vec u){return u;}
	public static vec operator-(vec u){return -1*u;}
	public static vec operator-(vec u, vec v){return new vec(u.x-v.x,u.y-v.y,u.z-v.z);}

	//In order to tell the program how to represent our vectors when we write them out, we use override Tostring
	
	public override string ToString(){
		return "["+ x +","+y+","+z+"]\n";
	}

	//Defining more complicated vector operators.
	public static double dot(vec v, vec w){return v.x*w.x + v.y*w.y + v.z*w.z;}
	public static vec cross(vec v, vec w){return new vec
	       (v.y*w.z-v.z*w.y,
		-1*(v.x*w.z-v.z*w.x),
		v.x*w.y - v.y*w.x);		
	}
	public static double norm(vec v){return Sqrt(v.x*v.x + v.y*v.y + v.z*v.z);}
	
	//Approximation method
	
	static bool approx(double a, double b, double tau=1e-9, double epsilon=1e-9){
		if(Abs(a-b)<tau) return true;
		if(Abs(a-b)/(Abs(a)+Abs(b))<epsilon)return true;
		return false;
	}
	public bool approx(vec other){
		if(!approx(this.x,other.x))return false;
		if(!approx(this.y,other.y))return false;
		if(!approx(this.z,other.z))return false;
		return true;
	}
	public static bool approx(vec u, vec v){return u.approx(v);}

}	

