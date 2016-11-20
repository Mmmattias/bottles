Detta projekt löser följande problem:

---
You have two unmarked bottles that can hold 3 liters and 5 liters respectively, and a bathtub with unlimited water. You are allowed to either fill a bottle, empty a bottle or pour one bottle into the other until either the source bottle is empty or the target bottle is full.

- how can 1 liter be measured?
- how can 4 liters be measured?

---

Lösningen är skriven i C# (portad från Rust, se nedan) och är en enkel konsol-applikation.

Klona repo:t och bygg i Visual Studio eller MonoDevelop / Xamarin Studio.

När jag studerade problemet märkte jag snabbt att det var ett enkelt grafproblem eftersom man vid varje givet state alltid har ett antal (max 6) states man kan ta sig till.

Av en slump hade jag i somras byggt en labyrint-lösare till ett spel jag hade som hobbyprojekt (skrivet i Rust med SDL för grafik och input-hantering) och jag insåg att jag enkelt kunde modifiera min A*-algoritm till att lösa problemet.

Det enda som krävdes var att jag byggde om min datastruktur som hanterar kartor till att istället hantera grafen med state för flaskorna.

Istället för att ha en metod som ger tillgängliga vägar att gå i labyrinten givet en position får man här istället en lista med tillgängliga state som man kan nå från given mängd i varje flaska.

Jag tog bort heurestiken och fick då någon slags variant av Dijkstras algoritm (om jag minns rätt från skolan) som löser problemet.
