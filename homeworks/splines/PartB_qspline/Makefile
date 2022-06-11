qsplinesq.png qspline1.png qsplinex.png: Out.txt xones.txt yx.txt tabvals.txt Makefile
	echo "\
	set terminal png \n\
	set output 'qsplinesq.png' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set xrange [1:5] \n\
	set yrange [1:45] \n\
	set xtics 1,1,5 \n\
	set title 'Quadratic Spline: x squared' \n\
	set key left top \n\
	plot 'Out.txt' index 0 using 1:2 with lines linetype 1 title 'Quadratic spline',\ \n\
	'Out.txt' using 1:3 with lines linetype 2 title 'Integral',\ \n\
	'Out.txt' using 1:4 with lines linetype 3 title 'Derivative',\ \n\
	'tabvals.txt' using 1:2 with points pointtype 2 title 'Tab' \n\
	"| tee logsq.gpi| pyxplot
	echo "\
	set terminal png \n\
	set output 'qspline1.png' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set yrange [-1:5] \n\
	set xrange [1:5] \n\
	set xtics 1,1,5 \n\
	set ytics -1,1,5 \n\
	set title 'Quadratic Spline: y equals 1' \n\
	set key left top \n\
	plot 'xones.txt' index 0 using 1:2 with lines linetype 1 title 'Quadratic spline',\ \n\
	'xones.txt' using 1:3 with lines linetype 2 title 'Integral',\ \n\
	'xones.txt' using 1:4 with lines linetype 3 title 'Derivative',\ \n\
	'tabvals.txt' using 1:3 with points pointtype 2 title 'Tab' \n\
	"| tee log1.gpi| pyxplot
	echo "\
	set terminal png \n\
	set output 'qsplinex.png' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set xrange [1:5] \n\
	set yrange [0:15] \n\
	set xtics 1,1,5 \n\
	set ytics 0,2,15 \n\
	set title 'Quadratic Spline: y equals x' \n\
	set key left top \n\
	plot 'yx.txt' index 0 using 1:2 with lines linetype 1 title 'Quadratic spline',\ \n\
	'yx.txt' using 1:3 with lines linetype 2 title 'Integral',\ \n\
	'yx.txt' using 1:4 with lines linetype 3 title 'Derivative',\ \n\
	'tabvals.txt' using 1:4 with points pointtype 2 title 'Tab' \n\
	"| tee logx.gpi| pyxplot

Out.txt: main.exe
	mono main.exe > Out.txt

main.exe: main.cs qspline.dll
	mcs -target:exe -out:$@ $< -reference:qspline.dll

qspline.dll: qspline.cs
	mcs -target:library -out:$@ $<

clean:
	rm -rf *.dll *.exe Out.txt *.png *.gpi
