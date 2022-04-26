swave.png rmaxconv.png rminconv.png: swave.txt rmax.txt rmin.txt Makefile
	echo "\
	set terminal png \n\
	set output 'swave.png' \n\
	set xlabel 'r' \n\
	set ylabel 'Wavefunction' \n\
	set title 'S-Wave comparison' \n\
	set key top right \n\
	plot 'swave.txt' index 0 using 1:3 with lines title 'Exact',\ \n\
	'swave.txt' index 0 using 1:2 with lines linetype 2 title 'Differential equation' \n\
	"| tee logswave.gpi| pyxplot
	echo "\
	set terminal png \n\
	set output 'rmaxconv.png' \n\
	set xlabel 'rmax' \n\
	set ylabel 'Energy' \n\
	set yrange [-2:2.5] \n\
	set title 'Energy convergence rmax' \n\
	set key top right \n\
	plot 'rmax.txt' index 0 using 1:3 with lines title 'Exact',\ \n\
	'rmax.txt' index 0 using 1:2 with points pointtype 17 title 'Energy solver' \n\
	"| tee logrmax.gpi| pyxplot
	echo "\
	set terminal png \n\
	set output 'rminconv.png' \n\
	set xlabel 'rmin' \n\
	set ylabel 'Energy' \n\
	set yrange [-1:0] \n\
	set xrange [0.1:1] \n\
	set title 'Energy convergence rmin' \n\
	set key bottom right \n\
	plot 'rmin.txt' index 0 using 1:3 with lines title 'Exact',\ \n\
	'rmin.txt' index 0 using 1:2 with points pointtype 17 title 'Energy solver' \n\
	"| tee logrmin.gpi| pyxplot

swave.txt rmax.txt rmin.txt: main.exe
	mono $< > $@

main.exe: main.cs roots.dll
	mcs -target:exe -out:$@ $< -reference:roots.dll

roots.dll: roots.cs QRGS.cs matrix.cs vector.cs ode.cs genlist.cs
	mcs -target:library -out:$@ $^

clean:
	rm -rf *.exe *.txt *.dll *.gpi *.png