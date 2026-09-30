# Fel rapport 

## Första Felet
(ShoppingList.cs)
Förklaring: 
När jag startade programmet och den kördes load metoden för att läsa in det sparade värdet då kraschade programmet ("IndexOutOfRangeException"). 
Detta beror på att textfilen alltid sparades med en tom rad längst ner p.g.a (split(\n)). När programmet försökte läsa den tomma raden för att hitta namn och pris fanns det inget där och programmet kraschade.

Lösning:
Jag tog bort File.ReadAllText() och Split(\n). Istället använder jag bara File.ReadAllLines.
Dens funktion är att den delar automatisk raderna och hoppar över tomma rader. 


## Andra Felet
(Program.cs)

Förklaring:
När programmet bad om en siffra från menyn och använderen skrev bokstäver kraschade programmet ("FormatException"). Man kunde dessutom skriva in siffror som inte fanns i menyn (till exempel 9 eller -1)

Lösning:
Jag byte ut int.Parse med int.TryParse och lade in det i en while-loop. TryParse testar om inmatning är en siffra (utan att krascha), Loopen kontrollerar samtidigt om inmattning är mellan 1 och 5. 

## Tredje felet
(Program.cs) (Choice = 1)

Förklaring:
När användaren skulle lägga till en ny vara och skrev in bokstäver istället för heltal då kraschade programmet ("FormatException"). Det var också möjligt att skriva in negativ tal vilket inte är logiskt.

Lösning:
Jag lade i en while-loop tillsammans med int.TryParse när priset anges. Koden testar nu att inmatming är en siffra utan att krascha och jag lade till ett vilkor som kontrollerar om talet är positiv. Om användaren gör fel tvingas de att försöka igen.