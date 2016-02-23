Studentnaam: Joeri Smits

Studentnummer: 524292

‐‐‐

#Algemene beschrijving applicatie
Dit is een chat applicatie die is gebouwd op het client/server principe. Door middel van deze applicatie kunnen meerdere gebruikers met elkaar verbinden via een TCP connectie. De verbinding wordt momenteel gebruikt om gebruikers te laten praten met elkaar door middel van een windows form.

Het programma bestaat uit vier gedefineerde classes. 
* De classe "**Client**" is een client die kan verbinden met een server.
* De classe "**Server**" is een server waar andere clients mee kunnen verbinden.
* De classe "**DataStream**" is de classe die tussen de client en de server ligt. De classe zorgt ervoor dat elke client een bericht krijgt als een andere client een bericht stuurt.
* In de classe "**ChatApp**" staan alle event listeners van het window form. In deze classe worden dan ook de bovenstaande classe geinitialiseerd om het programma te laten werken.

De server kan met de volgende code worden gestart:
```cs
Server server = new Server(int port);
server.Start();
```

##Generics
###Beschrijving van concept in eigen woorden
_Generics_ stellen je in staat om code te gebruiken of te schrijven die "type-safe" is. Bijvoorbeeld als je een List<string> gebruikt dat is dat altijd een lijst van strings.  
Wanneer je _generics_ toepast dan zorg je ervoor dat de compiler checks kan doen tijdens "compile-time". Bijvoorbeeld wanneer je een int in een List<string> probeert te stoppen. Als je geen _generics_ toepast en bijvoorbeeld een ArrayList gebruikt dan kan het vorige voorbeeld een run-time error opleveren de minder duidelijk kan zijn als de compile fout.  
Het toepassen van _generics_ is ook nog eens sneller, omdat je niet te maken hebt met boxing/unboxing.

###Code voorbeeld van je eigen code
```cs
public partial class ChatApp : Form {}
```

###Alternatieven & adviezen

###Authentieke en gezaghebbende bronnen
Vrat Agarwal, V. (2013, March 5). Using Generics With C#. Retrieved February 23, 2016, from http://www.c-sharpcorner.com/UploadFile/84c85b/using-generics-with-C-Sharp/  
Strahl, R. (2012, October 23). Dynamic Code for type casting Generic Types 'generically' in C#. Retrieved February 23, 2016, from http://weblog.west-wind.com/posts/2012/Oct/23/Dynamic-Code-for-type-casting-Generic-Types-generically-in-C

##Boxing & Unboxing

###Beschrijving van concept in eigen woorden

###Code voorbeeld van je eigen code

###Alternatieven & adviezen

###Authentieke en gezaghebbende bronnen

##Delegates & Invoke

###Beschrijving van concept in eigen woorden

###Code voorbeeld van je eigen code

###Alternatieven & adviezen

###Authentieke en gezaghebbende bronnen

##Threading & Async

###Beschrijving van concept in eigen woorden

###Code voorbeeld van je eigen code

###Alternatieven & adviezen

###Authentieke en gezaghebbende bronnen
