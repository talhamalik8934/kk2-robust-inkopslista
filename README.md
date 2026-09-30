# Fel rapport 

## Första Felet
(ShoppingList.cs)
Förklaring: 
När jag startade programmet och den kördes load metoden för att läsa in det sparade värdet då kraschade programmet ("IndexOutOfRangeException"). 
Detta beror på att textfilen alltid sparades med en tom rad längst ner p.g.a (split(\n)). När programmet försökte läsa den tomma raden för att hitta namn och pris fanns det inget där och programmet kraschade.

Lösning:
Jag tog bort File.ReadAllText() och Split(\n). Istället använder jag bara File.ReadAllLines.
Dens funktion är att den delar automatisk raderna och hoppar över tomma rader. 


