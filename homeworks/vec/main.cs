using static System.Console;
using static System.Math;

class main{
	static void Main(){
	WriteLine("Testing of vector program.");
	int return_code=0;
	bool test;

	//Define test vectors
	vec x=new vec(1,0,0);
	vec y=new vec(0,1,0);
	vec z=new vec(0,0,1);
	
	WriteLine("---TESTING BASIC VECTOR OPERATORS---");

	WriteLine("Testing x=x...");
	test=x==x;
	if(test) WriteLine("...Passed\n");
	else{WriteLine("...Failed\n"); return_code +=1;}
	
	WriteLine("Testing x!=y...");
	test= x!=y;
	if(test) WriteLine("...Passed\n");
	else{WriteLine("...Failed\n"); return_code +=1;}

	WriteLine("Testing x!=z...");
	test=x!=z;
	if(test) WriteLine("...Passed\n");
	else{WriteLine("...Failed\n"); return_code +=1;}

	WriteLine("Testing y!=z...");
	test=y!=z;
	if(test) WriteLine("...Passed\n");
	else{WriteLine("...Failed\n"); return_code +=1;}
	
	WriteLine("---TESTING BASIC VECTOR OPERATORS---"); 
	
	WriteLine("Testing 1*x=x...");
	test=vec.approx(x,1*x);
	if(test) WriteLine("...Passed\n");
	else{WriteLine("...Failed\n"); return_code +=1;}
	
	WriteLine("Testing 1*y=y...");
	test=vec.approx(y,1*y);
	if(test) WriteLine("...Passed\n");
	else{WriteLine("...Failed\n"); return_code +=1;}
	
	WriteLine("Testing 1*z=z...");
	test=vec.approx(z,1*z);
	if(test) WriteLine("...Passed\n");
	else{WriteLine("...Failed\n"); return_code +=1;}
	
	WriteLine("Testing x+y+z...");
	test=vec.approx(x+y+z,new vec(1,1,1));
	if(test) WriteLine("...Passed\n");
	else{WriteLine("...Failed\n"); return_code +=1;}

	WriteLine("Testing x-y-z...");
	test=vec.approx(x-y-z,new vec(1,-1,-1));
	if(test) WriteLine("...Passed\n");
	else{WriteLine("...Failed\n"); return_code +=1;}
	
	WriteLine("Testing x-x...");
	test=vec.approx(x-x,new vec(0,0,0));
	if(test) WriteLine("...Passed\n");
	else{WriteLine("...Failed\n"); return_code +=1;}

	WriteLine("---TESTING COMPLICATED VECTOR OPERATORS---");
	
	WriteLine("Testing dot(x,x)...");
	test=vec.dot(x,x)==1;	
	if(test) WriteLine("...Passed\n");
	else{WriteLine("...Failed\n"); return_code +=1;}

	WriteLine("Testing dot(x,y)...");
	test=vec.dot(x,y)==0;
	if(test) WriteLine("...Passed\n");
	else{WriteLine("...Failed\n"); return_code +=1;}
	
	WriteLine("Testing norm(x)...");
	test=vec.norm(x)==1;
	if(test) WriteLine("...Passed\n");
	else{WriteLine("...Failed\n"); return_code +=1;}

	WriteLine("Testing cross(x,x)...");
	test=vec.approx(vec.cross(x,x),new vec(0,0,0));
	if(test) WriteLine("...Passed\n");
	else{WriteLine("...Failed\n"); return_code +=1;}

	WriteLine("Testing cross(x,y)=z...");
	test=vec.approx(vec.cross(x,y),z);
	if(test) WriteLine("...Passed\n");
	else{WriteLine("...Failed\n"); return_code +=1;}
	
	if(return_code==0);
		Write("All tests passed\n");
	else{Write("Tests failed\n",return_code); return return_code;}
			
	}	
}
