erf.png: erf_calc.txt erf_tab.txt Out.txt Makefile
	echo "\
	set terminal png \n\
	set output 'erf.png' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set title 'error function' \n\
	set key left top \n\
	plot 'erf_calc.txt' index 0 using 1:2 with lines title 'erf',\ \n\
	'erf_tab.txt' using 1:2 with points pointtype 2 title 'tab' \n\
	"| tee log.gpi | pyxplot
	cat Out.txt

Out.txt erf_calc.txt: main.exe
	mono main.exe > Out.txt erf_calc.txt

main.exe: main.cs quad.dll
	mcs -target:exe -reference:quad.dll -out:main.exe main.cs 

quad.dll: quad.cs
	mcs -target:library -out:$@ $< 

clean:
		rm -rf *.txt *.dll *.exe *.png *.gpi