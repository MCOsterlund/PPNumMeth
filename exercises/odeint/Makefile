all: Out.txt
	cat $< $@

Out.txt: main.exe
	mono $< Out.txt

main.exe: main.cs ode.dll
	mcs -target:exe -reference:ode.dll -out:main.exe main.cs

ode.dll: ode.cs
	mcs -target:library -out:ode.dll ode.cs
