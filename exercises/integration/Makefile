all: Out.txt erf.data.txt erf.pyxplot.png 
	cat $<

erf.pyxplot.png: erf.data.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set title 'Error function' \n\
	set key left top \n\
	plot 'erf.data.txt' index 0 using 1:2 with lines title 'erf' \n\
	"| tee log.gpi | pyxplot

Out.txt erf.data.txt: main.exe
	mono $< 1> Out.txt 2>erf.data.txt

main.exe: main.cs integrate.dll
	mcs -target:exe -reference:integrate.dll -out:main.exe main.cs  

integrate.dll: integrate.cs
	mcs -target:library -out:integrate.dll integrate.cs 

clean:
	rm -rf *.dll *.exe *.txt *.gpi *.png
