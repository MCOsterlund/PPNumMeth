erf.gnuplot.png: erf.pyxplot.png
	cat log.gpi | sed 's/pyxplot/gnuplot/' | tee log.gnu.gpi | gnuplot #Changes to gnuplot

erf.pyxplot.png: erf.data.txt erf.tab.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set title 'error function' \n\
	set key left top \n\
	plot '$<' index 0 using 1:2 with lines title 'erf',\
	'erf.tab.txt' using 1:2 with points pointtype 2 title 'tab' \n\
	"| tee log.gpi | pyxplot

erf.data.txt: main.exe
	mono $< > $@

%.exe: %.cs
	mcs $<
