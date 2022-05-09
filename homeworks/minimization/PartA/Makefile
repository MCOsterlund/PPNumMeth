all: Out.txt
	cat Out.txt

Out.txt: main.exe
	mono main.exe > Out.txt

main.exe: main.cs qnewton.dll
	mcs -target:exe -out:$@ $< -reference:qnewton.dll

qnewton.dll: qnewton.cs matrix.cs vector.cs
	mcs -target:library -out:$@ $^

clean:
	rm -rf *.exe *.txt *.dll