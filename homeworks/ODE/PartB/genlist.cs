using static System.Console;

public class genlist<T>{
	public T[] data;
	public int size=0, capacity=10;
	public genlist(){data=new T[capacity];}
	public void push(T item){
		if(size==capacity){
			T[] newdata=new T[capacity*=2];
			for(int i=0;i<size;i++)newdata[i]=data[i];
			data=newdata;
		}	
		data[size]=item;
		size++;	
		}
	public void remove(int i){
		for(int j=0; j<size; j++){
			if(j==i){
				data[j]=data[j+1];
				size--;
			}
		}
	}
	public void print(){
		for(int i=0; i<size; i++){Write($"{data[i]}");
		Write("\n");}
	}
}
