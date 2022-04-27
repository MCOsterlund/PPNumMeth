scipy_example.png: Out.txt Makefile
	echo "\
	set terminal png \n\
	set output 'scipy_example.png' \n\
	set xlabel 't' \n\
	set ylabel 'Solution' \n\
	set yrange[-4.5:3.5] \n\
	set key top right \n\
	plot 'Out.txt' index 0 using 1:2 with lines title 'Theta',\ \n\
	'Out.txt' index 0 using 1:3 with lines title 'Omega' \n\
	"| tee log.gpi|pyxplot

Out.txt: main.exe
	mono $< > Out.txt

main.exe: main.cs ode.dll
	mcs -target:exe -reference:ode.dll -out:main.exe main.cs

ode.dll: ode.cs vector.cs
	mcs -target:library -out:ode.dll ode.cs vector.cs

clean:
	rm -rf *.exe *.dll *.txt *.png *.gpi