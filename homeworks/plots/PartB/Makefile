gamma.pyxplot.png: gamma.data.txt gamma.tab.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set title 'Gamma function' \n\
	set key left top \n\
	plot [0:4] [0:7] '$<' index 0 using 1:2 with lines title 'Gamma',\ \n\
	'gamma.tab.txt' using 1:2 with points pointtype 2 title 'tab' \n\
	"| tee log.gpi | pyxplot

gamma.data.txt: main.exe
	mono $< > $@

%.exe: %.cs
	mcs $<
