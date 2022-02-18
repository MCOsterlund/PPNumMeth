public class genlist<T>{ //T is the variable/parameter. Signifies typer of operator to be put into the list.
	public T[] data;
	public genlist(){ data = new T[0];} //Constructor
	public void push(T item){ //Adds an item to the list
	int n=data.Length;
	T[] newdata=new T[n+1]; //This is somewhat ineffective but it saves more memory
	for (int i=0;i<n;i++)newdata[i]=data[i];
	data=newdata; //Garbage collector. Prevents memory leaks.
	data[n]=item;
	}
}
