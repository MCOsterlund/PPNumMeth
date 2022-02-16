MCS = mcs -optimize+ -platform:arm

all: out-stdin.txt
	cat out-stding.txt

out-stdin.txt: stdin.exe input.txt
	mono stdin.exe > out-stdin.txt

input.txt: Makefile
	echo this is out input line 

stdin.exe: stdin.cs 
	$(MCS) stdin.cs -target:exe -out:stdin.exe  

.PHONEY: clean 
clean:
	rm -rf stdin.exe 

test:
	echo $(MCS)
