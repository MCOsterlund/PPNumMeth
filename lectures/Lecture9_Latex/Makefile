all:ms.pdf

out.gamma.txt:main.exe
	mono $< > $@

ms.pdf:ms.tex gamma_pyx.pdf gamma_gnu.pdf
	pdflatex $<
	pdflatex $<
#	bibtex $<
#	pdflatex <$

gamma_pyx.pdf: fig-pyxplot.gpi out.gamma.txt tab.gamma.txt
	pyxplot $<

gamma_gnu.pdf: fig-gnuplot.gpi out.gamma.txt tab.gamma.txt
	gnuplot $<

main.exe:main.cs sfuns.dll

%.exe: %.cs
	mcs -t:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

%.dll: %.cs
	mcs -t:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	rm -rf *.exe *.dll *.pdf *.aux *.log
