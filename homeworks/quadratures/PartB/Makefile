all: Out.txt
	cat Out.txt

Out.txt: main.exe
	mono main.exe > Out.txt 

main.exe: main.cs quad.dll py_comp.txt
	mcs -target:exe -reference:quad.dll -out:main.exe main.cs 

py_comp.txt: py_comp.py
	python3 $< > $@

quad.dll: quad.cs
	mcs -target:library -out:$@ $< 

clean:
		rm -rf *.txt *.dll *.exe *.png *.gpi