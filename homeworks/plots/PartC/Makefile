gamma.complex.png: gamma.complex.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'Re(z)' \n\
	set ylabel 'Im(z)' \n\
	set zlabel 'Abs(z)' \n\
	set xtics -5,1,5 \n\
	set ytics -5,1,5 \n\
	set size 8 square \n\
	set grid \n\
	set view -30,30 \n\
	set title 'Complex Gamma function' \n\
	set key below \n\
	plot 3d [-4:4] [-4:4] '$<' index 0 using 1:2:3 with surface col black fillcol blue title 'Complex Gamma' \n\
	" |tee log.gpi |pyxplot

gamma.complex.txt: main.exe
	mono $< 1> $@ 2>log

main.exe: main.cs cmath.dll
	mcs $< -target:exe -reference:cmath.dll main.cs -out:$@

cmath.dll: cmath.cs complex.cs
	mcs $^ -target:library -out:$@

clean:
	rm -rf *.exe *.dll *.txt *.gpi *.png

