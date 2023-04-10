Primov Algoritam VVeljovic
Na pocetku se korisnik pita da unese koliki broj cvorova zeli da se generise(ispisano na konzoli),
Zatim se korisnik pita da li zeli da se realizuje slucaj 1 ili 2 (slucajevi definisani na timsu),
Nakon toga se korisnik pita da unese K pa ce biti generisano K*N cvorova,
Izvrsava se Primov algoritam,
Ispisuje se vreme izvrsenja,minimalno sprezno stablo je napisano u fajlu ispis.txt, i ispisana je na konzoli ukupna tezina grafa pre izvrsenja algoritma i kada je formirano MST.
**Kratko pojasnjenje
U zadatku sam koristio Dictionary za cvorove i potege,radi efikasnijeg pristupa svim cvorovima i potezima koje imam u grafu.
Naime kada se generise veliki broj potega nema potrebe da proveravam i da prolazim kroz celu listu potega da bih utvrdio da li neki poteg vec postoji,
koristim zato dictionary gde ne sme da postoje 2 elementa sa istim kljucem,i ukoliko granu dodam u dictionary uspesno,dodam je i u graf(za DaisyChain i FirstCase mogu i odmah u graf jer svakako ne postoje prethodno).
Kljuc za dictionary za potezima je string tj. ukoliko spajam cvorove 3 i 5 kljuc je "35".
Pokusao sam sto vise da priblizim kako sam realizovao zadatak i nadam se da sam u tome uspeo.

