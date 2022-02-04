MCS = mcs -optimize+ -platform:arm

all: out.txt
	cat out.txt #Shows the contents of out.txt. cat is used to create single or multiple files, view content of a file, concatenate (sammekæde) files and redirects output in terminal or files.

out.txt: hello.exe  #out.txt depends on hello.exe
	mono hello.exe > out.txt #run hello.exe, send output to out.txt

hello.exe: hello.cs #hello.exe depends on hello.cs
	$(MCS) hello.cs -target:exe -out:hello.exe # compile hello.cs into hello.exe

.PHONEY: clean #A phoney target with no dependencies
clean:
	rm -rf Out.txt hello.exe #Removes secondary files

test:
	echo $(MCS) #Displays $(MCS) as a line of text. Essentially it prints "hello"
