all: Out.txt
	cat $<

Out.txt: cmdline.exe
	mono cmdline.exe 1 2 3 4 5 > Out.txt

cmdline.exe: cmdline.cs
	mcs -target:exe -out:$@ $<

clean:
	rm -rf *.txt *.exe *.dll
