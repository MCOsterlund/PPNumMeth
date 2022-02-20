all: Out.txt
	cat $<

Out.txt: main.exe
	mono main.exe > Out.txt

main.exe: main.cs maketable.dll
	mcs -target:exe -out:main.exe main.cs -reference:maketable.dll

maketable.dll: maketable.cs
	mcs -target:library -out:maketable.dll maketable.cs

clean:
	rm -rf *.dll *.exe *.txt
