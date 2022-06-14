all: Out.txt
	cat Out.txt

Out.txt: epsilon.exe
	mono epsilon.exe > Out.txt

epsilon.exe: epsilon.cs
	mcs -target:exe -out:epsilon.exe epsilon.cs

clean:
	rm -rf *.txt *.exe
