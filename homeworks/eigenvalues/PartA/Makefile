all: Out.txt
	cat Out.txt

Out.txt: main.exe
	mono main.exe > Out.txt

main.exe: main.cs jacobi.dll
	mcs -target:exe -out:$@ $< -reference:jacobi.dll 

jacobi.dll: jacobi.cs matrix.cs vector.cs
	mcs -target:library -out:$@ $^

clean:
	rm -rf *.dll *.exe *.txt