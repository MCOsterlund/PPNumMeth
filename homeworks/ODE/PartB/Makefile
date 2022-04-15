py_comp.png:Out.txt py_comp.txt Makefile
	echo "\
	set terminal png \n\
	set output 'py_comp.png' \n\
	set xlabel 't' \n\
	set ylabel 'Solution' \n\
	set title 'ODE solver: Python comparison' \n\
	set yrange[-4.5:3.5] \n\
	set key top right \n\
	plot 'py_comp.txt' index 0 using 1:2 with lines title 'Theta',\ \n\
	'py_comp.txt' index 0 using 1:3 with lines title 'Omega' \n\
	" |tee log_pycomp.gpi|pyxplot

Out.txt py_comp.txt: main.exe
	mono $< > $@

main.exe: main.cs ode.dll
	mcs -target:exe -reference:ode.dll -out:main.exe main.cs

ode.dll: ode.cs matrix.cs vector.cs genlist.cs
	mcs -target:library -out:$@ $^

clean:
		rm -rf *.dll *.exe *.txt *.gpi *.png