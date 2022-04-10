swaveplot.png nconvergence.png rconvergence.png: wfplot.txt nconvergence.txt rconvergence.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'Distance' \n\
	set ylabel 'Wavefunction' \n\
	set title 'S-wave comparison' \n\
	set key right top \n\
	plot 'wfplot.txt' index 0 using 1:2 with lines title '1s Tab',\ \n\
	'wfplot.txt' index 0 using 1:3 with lines linetype 5 title '1s Numerical',\ \n\
	'wfplot.txt' index 0 using 1:4 with lines title '2s Tab',\ \n\
	'wfplot.txt' index 0 using 1:5 with lines linetype 5 title '2s Numerical',\ \n\
	'wfplot.txt' index 0 using 1:6 with lines title '3s Tab',\ \n\
	'wfplot.txt' index 0 using 1:7 with lines linetype 5 title '3s Numerical' \n\
	" |tee log.gpi |pyxplot
	echo "\
	set terminal png \n\
	set output 'nconvergence.png' \n\
	set xlabel 'Number of points' \n\
	set ylabel 'Energies' \n\
	set title 'Convergence of as a function of points' \n\
	set yrange [-0.6:2.4] \n\
	set xrange [0:200] \n\
	set key right top \n\
	plot 'nconvergence.txt' using 1:5 with lines linetype 5 title 'E1 Tab',\ \n\
	'nconvergence.txt' using 1:6 with lines linetype 5 title 'E2 Tab',\ \n\
	'nconvergence.txt' using 1:7 with lines linetype 5 title 'E3 Tab' ,\ \n\
	'nconvergence.txt' using 1:2 with points pointtype 17 title 'E1 Numerical',\ \n\
	'nconvergence.txt' using 1:3 with points pointtype 17 title 'E2 Numerical',\ \n\
	'nconvergence.txt' using 1:4 with points pointtype 17 title 'E3 Numerical' \n\
	" |tee log_n.gpi |pyxplot
	echo "\
	set terminal png \n\
	set output 'rconvergence.png' \n\
	set xlabel 'Different rmax values' \n\
	set ylabel 'Energies' \n\
	set title 'Convergence of as a function of rmax' \n\
	set xrange [0:20] \n\
	set yrange [-0.6:2] \n\
	set key right top \n\
	plot 'rconvergence.txt' using 1:5 with lines linetype 5 title 'E1 Tab',\ \n\
	'rconvergence.txt' using 1:6 with lines linetype 5 title 'E2 Tab',\ \n\
	'rconvergence.txt' using 1:7 with lines linetype 5 title 'E3 Tab' ,\ \n\
	'rconvergence.txt' using 1:2 with points pointtype 17 title 'E1 Numerical',\ \n\
	'rconvergence.txt' using 1:3 with points pointtype 17 title 'E2 Numerical',\ \n\
	'rconvergence.txt' using 1:4 with points pointtype 17 title 'E3 Numerical' \n\
	" |tee log_r.gpi |pyxplot


wfplot.txt nconvergence.txt rconvergence.txt: main.exe
	mono main.exe > $@

main.exe: main.cs jacobi.dll
	mcs -target:exe -out:$@ $< -reference:jacobi.dll 

jacobi.dll: jacobi.cs matrix.cs vector.cs
	mcs -target:library -out:$@ $^

clean:
	rm -rf *.dll *.exe *.txt *.png *.gpi