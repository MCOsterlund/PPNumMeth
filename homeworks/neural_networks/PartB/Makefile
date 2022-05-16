plot.png: out.txt Makefile
	echo "\
	set terminal png \n\
	set output 'plot.png' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set yrange [-3.5:5.5] \n\
	set xrange [-1:1] \n\
	set title 'Neural network test' \n\
	set key top right \n\
	plot 'out.txt' index 0 using 1:2 with points pointtype 17 title 'data' ,\ \n\
	'out.txt' index 0 using 1:3 with points pointtype 17 title 'derivative data',\ \n\
	'out.txt' index 1 using 1:2 with lines title 'fit',\ \n\
	'out.txt' index 1 using 1:3 with lines title 'derivative fit',\ \n\
	'out.txt' index 1 using 1:4 with lines title 'integral' \n\
	"| tee log.gpi| pyxplot

out.txt: main.exe
	mono main.exe > out.txt

main.exe: main.cs ann.dll
	mcs -target:exe -out:$@ $< -reference:ann.dll

ann.dll: ann.cs matrix.cs vector.cs qnewton.cs
	mcs -target:library -out:$@ $^

clean:
		rm -rf *.exe *.txt *.dll *.png *.gpi