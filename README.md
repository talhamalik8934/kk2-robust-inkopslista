# Fel rapport 

## Första Fel
(ShoppingList.cs)
Förklaring: 
När jag startade programmet och den kördes load metoden för att läsa in det sparade värdet då kraschade programmet ("IndexOutOfRangeException"). 
Detta beror på att textfilen alltid sparades med en tom rad längst ner p.g.a (split(\n)). När programmet försökte läsa den tomma raden för att hitta namn och pris fanns det inget där och programmet kraschade.

Lösning:
Jag tog bort File.ReadAllText() och Split(\n). Istället använder jag bara File.ReadAllLines.
Dens funktion är att den delar automatisk raderna och hoppar över tomma rader. 


## Andra Fel
(Program.cs)

Förklaring:
När programmet bad om en siffra från menyn och använderen skrev bokstäver kraschade programmet ("FormatException"). Man kunde dessutom skriva in siffror som inte fanns i menyn (till exempel 9 eller -1)

Lösning:
Jag byte ut int.Parse med int.TryParse och lade in det i en while-loop. TryParse testar om inmatning är en siffra (utan att krascha), Loopen kontrollerar samtidigt om inmattning är mellan 1 och 5. 

## Tredje fel
(Program.cs) (Choice = 1)

Förklaring:
När användaren skulle lägga till en ny vara och skrev in bokstäver istället för heltal då kraschade programmet ("FormatException"). Det var också möjligt att skriva in negativ tal vilket inte är logiskt.

Lösning:
Jag lade i en while-loop tillsammans med int.TryParse när priset anges. Koden testar nu att inmatming är en siffra utan att krascha och jag lade till ett vilkor som kontrollerar om talet är positiv. Om användaren gör fel tvingas de att försöka igen.

## Fjärde fel
(Program.cs)
(ShoppingList.cs)

Förklaring:
När jag skulle ta bort en vara (menyval 2) och skrev in text eller en siffra som inte fanns i listan då kraschade programmet ("System.ArgumentOutOfRangeException").

Lösning:
Jag löste problemet i två steg.
1. Jag lade till en egenskap(Count. get) i ShoppingList- klassen. Det gör att programmet kan läsa exakt hur många varor som finns i listan. 
2. Sedan lade jag till en while loop i program.cs med TryParse. Det kontrollerar tre saker att inmatning är ett heltal, siffran är minst 1 och siffran inte är större än antal varor i listan.

## Femte fel
(ShoppingList.cs)

Förklaring: 
När programmet räknade ut total priset stämde inte resultat med summan. Det kraschade inte med resultat var fel. Felet var i loop i metoden Total() började på i=1 eftersom listor börjar med index(0) så hoppade loopen altid över den första varan i inköpslistan.

Lösning:
Ändrade loopens start värde från i=1 till i=0.

## Sjätte fel
(ShoppingList.cs)

Förklaring:
När programmet frågade efter varans namn och om man matade in en lowercase istället för en uppercase då tog den inte fram den varan. Felet var i metoden Find i ShoppingList.cs.

Lösning: 
Jag har lagt till ToLower() på både sidor (item.Name == name). Nu kan man mata in lower eller uppdercase och det kommer komma fram till varan.

## Sjunde fel
(ShoppingList.cs)

Förklaring:
När programmet startade försökte den direkt läsa in filen med den sparade listan. Så t.ex om filen inte fanns, eller man råkade byta namn på filen (vilket jag gjorde) då kraschade programmet (System.IO.FileNotFoundException) eftersom det letade efter något som inte fanns.

Lösning:
Jag löste problemmet genom att lägga till en if stats i början av load metoden. If (!file.Exists(Path)) Den kollar först om filen existerar. Om filen inte finns avbryts inläsningen med return. Detta gör att programmet inte kraschar och istället kör med en tom inköpslista. 

## Åttonde fel
(ShoppingList.cs)

Förklaring:
I ShoppingList.cs så fanns det en tom catch-sats i Save metoden. Detta är ett dölt fel. Om något gick fel när filen skulle sparas fångades kraschen upp men eftersom catch var tom så hände igenting och programmet gick vidare och skrev ut "Listan är sparad".

Lösning:
Jag ändrade den tomma catch till catch (IOException) för att fånga fel som handlar om filer. Jag flytade också in "Listan är sparad" i try-blocket och nu när det inte finns något fel så skriver det ut "Listan är sparad" annars "Fel:Kunde inte sparas".