all: Out.txt
	cat $<

Out.txt: main.exe
	mono main.exe > Out.txt

main.exe: main.cs linspline.dll
	mcs -target:exe -out:$@ $< -reference:linspline.dll

linspline.dll: linspline.cs
	mcs -target:library -out:$@ $<

clean:
	rm -rf *.dll *.exe *.txt
