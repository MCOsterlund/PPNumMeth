all: Out.txt
	cat $<

Out.txt: main.exe
	mono main.exe > Out.txt

CMATHDIR = ~/repos/PPNumMeth/exercises/complex
cmath.dll: $(CMATHDIR)/cmath.cs $(CMATHDIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^

main.exe: main.cs cmath.dll
	mcs -reference:cmath.dll main.cs
