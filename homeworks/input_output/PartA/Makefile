all: Out.txt
	cat $<

Out.txt: main.exe
	echo 1 2 3 4 5 > input.txt
	mono main.exe < input.txt > Out.txt

main.exe: main.cs
	mcs -target:exe -out:$@ $<

clean:
	rm -rf *.txt *.exe *.dll
