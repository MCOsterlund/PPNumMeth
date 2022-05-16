all: exp.pdf

exp_pyxplot.pdf: exp.pyxplot.gpi out.txt
	pyxplot $<

exp.pdf: exp.tex exp_pyxplot.pdf
	pdflatex $<
	pdflatex $<
#	bibtex $<
#	pdflatex $<

out.txt: main.exe
	mono main.exe > out.txt

main.exe: main.cs
	mcs -target:exe -out:$@ $<

clean:
	rm -rf *.exe *.log *.aux *.pdf