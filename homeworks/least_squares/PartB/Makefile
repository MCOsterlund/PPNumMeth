fit.pyxplot.png: Out.txt input_clean.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'Times [days]' \n\
	set ylabel 'Activity [Logarithmic scale]' \n\
	set title 'Least sqaures fit' \n\
	set key bottom left \n\
	plot 'input_clean_format.txt' index 0 using 1:2:3 with yerrorbars title 'Data points',\ \n\
	'fit.txt' using 1:2 with lines title 'fit' \n\
	" |tee log.gpi |pyxplot

Out.txt input_clean.txt input_clean_format.txt: main.exe input.txt
	mono $< > Out.txt

main.exe: main.cs leastsquares.dll
	mcs -target:exe -out:$@ $< -reference:leastsquares.dll

leastsquares.dll:leastsquares.cs QRGS.cs matrix.cs vector.cs
	mcs -target:library -out:$@ $^

clean:
	rm -rf *.exe fit.txt input_clean.txt input_clean_format.txt Out.txt *.dll *.png *.gpi