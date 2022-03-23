all: Out.txt
	cat $<

Out.txt: main.exe 
	mono main.exe -input:input.txt -output:Out.txt

main.exe: main.cs 
	mcs -target:exe main.cs # -out:$^ $@

clean:
	rm -rf *.txt *.exe *.dll
