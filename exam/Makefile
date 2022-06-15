all: Out.txt
	cat Out.txt

Out.txt: main.exe
	mono main.exe > Out.txt 

main.exe: main.cs quad.dll
	mcs -target:exe -reference:quad.dll -out:main.exe main.cs 

quad.dll: quad.cs
	mcs -target:library -out:$@ $< 

clean:
		rm -rf Out.txt *.dll *.exe *.png *.gpi