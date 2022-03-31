all: Out.txt
	cat $<

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs QRGS.dll
	mcs -target:exe -out:$@ $< -reference:QRGS.dll

QRGS.dll: QRGS.cs matrix.cs vector.cs
	mcs -target:library -out:$@ $^

clean:
	rm -rf *.exe *.txt *.dll