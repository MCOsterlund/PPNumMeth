all: exp.pdf

exp.pdf: exp.tex
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