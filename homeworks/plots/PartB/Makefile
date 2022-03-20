gamma.pyxplot.png lngamma.pyxplot.png: gamma.data.txt gamma.tab.txt Makefile
	echo "\
	set terminal png \n\
	set output 'gamma.pyxplot.png' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set title 'Gamma function' \n\
	set key right bottom \n\
	plot [-5:5] [-5:5] '$<' index 0 using 1:2 with lines title 'Gamma',\ \n\
	'gamma.tab.txt' using 1:2 with points pointtype 2 title 'tab' \n\
	" |tee log.gpi |pyxplot
	echo "\
	set terminal png \n\
	set output 'lngamma.pyxplot.png' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set title 'Log of Gamma' \n\
	set key left top \n\
	plot '$<' index 0 using 1:3 with lines title 'Log of Gamma' \n\
	" |tee logln.gpi |pyxplot

gamma.data.txt: main.exe
	mono $< > $@

main.exe: main.cs
	mcs $<

clean:
	rm -rf gamma.data.txt *.png *.gpi *.exe
