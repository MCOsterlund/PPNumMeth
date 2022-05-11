higgs.png: higgsfit.txt higgsdata.txt Makefile
	echo "\
	set terminal png \n\
	set output 'higgs.png' \n\
	set xlabel 'Energies' \n\
	set ylabel 'Cross sections' \n\
	set title 'Higgs plot' \n\
	set key top right \n\
	plot 'higgsdata.txt' index 0 using 1:2:3 with yerrorbars title 'Data' ,\ \n\
	'higgsfit.txt' index 0 using 1:2 with lines title 'Fit' \n\
	"| tee log.gpi|pyxplot

higgsfit.txt: main.exe
	mono main.exe > Out.txt

main.exe: main.cs qnewton.dll
	mcs -target:exe -out:$@ $< -reference:qnewton.dll

qnewton.dll: qnewton.cs matrix.cs vector.cs
	mcs -target:library -out:$@ $^

clean:
	rm -rf *.exe Out.txt higgsfit.txt *.dll *.png *.gpi