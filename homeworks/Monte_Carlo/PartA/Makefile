all: Out.txt
	cat Out.txt

Out.txt: main.exe
	mono main.exe > Out.txt

main.exe: main.cs MCsolve.dll
	mcs -target:exe -out:$@ $< -reference:MCsolve.dll

MCsolve.dll: MCsolve.cs matrix.cs vector.cs
	mcs -target:library -out:$@ $^

clean:
		rm -rf *.txt *.dll *.exe