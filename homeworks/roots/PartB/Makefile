comp.png: Out.txt Makefile
	echo "\
	set terminal png \n\
	set output 'comp.png' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set title 'S-Wave comparison' \n\
	set key top right \n\
	plot 'Out.txt' index 0 using 1:3 with lines title 'Exact',\ \n\
	'Out.txt' index 0 using 1:2 with lines linetype 2 title 'Differential equation' \n\
	"| tee log.gpi| pyxplot

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs roots.dll
	mcs -target:exe -out:$@ $< -reference:roots.dll

roots.dll: roots.cs QRGS.cs matrix.cs vector.cs ode.cs genlist.cs
	mcs -target:library -out:$@ $^

clean:
	rm -rf *.exe *.txt *.dll *.gpi *.png