linspline.png: Out.txt tabvals.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set title 'Linear Spline' \n\
	set key left top \n\
	plot '$<' index 0 using 1:3 with lines linetype 1 title 'Linear spline',\ \n\
	'$<' using 1:4 with lines linetype 2 title 'Integral',\ \n\
	'tabvals.txt' using 1:2 with points pointtype 2 title 'Tab' \n\
	"| tee log.gpi| pyxplot

Out.txt: main.exe
	mono main.exe > Out.txt

main.exe: main.cs linspline.dll
	mcs -target:exe -out:$@ $< -reference:linspline.dll

linspline.dll: linspline.cs
	mcs -target:library -out:$@ $<

clean:
	rm -rf *.dll *.exe Out.txt *.png *.gpi
