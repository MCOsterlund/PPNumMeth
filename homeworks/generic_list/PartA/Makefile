all: Out.txt
	cat $<

Out.txt: main.exe input.data
	> $@
	echo 'Exercise "genlist" part A: simple generic list' >> $@
	echo '\ninput: irregular table:' >>$@
	cat input.data >> $@
	echo '\noutput: regular table:' >> $@
	mono main.exe < input.data >> $@

input.data: Makefile
	>$@
	echo -1.23 '	' 23.4 '\t  \t' 456.7 >> $@
	echo '  \t  ' 0.07' \t\t\t ' -7.4e8 '\t' 6.72 >> $@
	echo 0.53 23.4 4.5 >> $@

main.exe: main.cs genlist.dll
	mcs -target:exe -out:$@ $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

genlist.dll: genlist.cs
	mcs -target:library -out:$@ $<

clean:
	rm -rf *.dll *.exe *.data
