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

### Test cases
#### Meerdere servers op dezelfde port
De applicatie moet afvangen dat er meerdere servers worden gemaakt op hetzelfde IPAddress met dezelfde port. De applicatie moet een melding naar de gebruiker doen wanneer dit voordoet.

#### Verbinden naar een server die niet bestaat
De applicatie moet voorkomen dat een gebruiker naar een server verbind die niet bestaat. De applicatie moet een melding naar de gebruiker doen wanneer dit voordoet.

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
Als alternatief kan je boxing/unboxing gebruiken in c#. Dit is alleen duurder in de performance van je applicatie, omdat de variabele moet worden "geboxed" en dan worden "ge-unboxed". Daarom is het ook te adviseren om _generics_ te gebruiken daar waar het kan.

###Authentieke en gezaghebbende bronnen
Vrat Agarwal, V. (2013, March 5). Using Generics With C#. Retrieved February 23, 2016, from http://www.c-sharpcorner.com/UploadFile/84c85b/using-generics-with-C-Sharp/  
Strahl, R. (2012, October 23). Dynamic Code for type casting Generic Types 'generically' in C#. Retrieved February 23, 2016, from http://weblog.west-wind.com/posts/2012/Oct/23/Dynamic-Code-for-type-casting-Generic-Types-generically-in-C

##Boxing & Unboxing

###Beschrijving van concept in eigen woorden
Door middel van gebruik te maken van _boxing_ kan iedere "value-type" worden veranderd naar een "value-type" object. _Unboxing_ is het tegenovergestelde van _boxing_. Hier wordt de "object box" terug veranderd is zijn originele "value-type".

###Code voorbeeld van je eigen code
```cs
// Translate data bytes to a ASCII string.
data = Encoding.ASCII.GetString(byteArray);
```
###Alternatieven & adviezen
>Since the introduction of C# 2.0, generics have provided an alternative solution in these cases, which leads to better static type safety and performance. Boxing/unboxing necessarily demands a small performance overhead, because it means copying values, dealing with indirection, and allocating memory on the heap. (Joseph Albahari, 2010)

###Authentieke en gezaghebbende bronnen
Ganesh, A. (2002, May 1). Boxing and unboxing in C#. Retrieved February 23, 2016, from http://www.codeproject.com/Articles/2225/Boxing-and-unboxing-in-C  
Hejlsberg, A. (2010, November 10). The C# Programming Language: Types. Retrieved February 23, 2016, from http://www.informit.com/articles/article.aspx?p=1648574

##Delegates & Invoke

###Beschrijving van concept in eigen woorden
Een _delegate_ is een type wat een referentie van een methode onthoudt in een object. Het wordt ook wel benoemt als een "type safe function pointer".  
Wat een delegate voor gebruikt kan worden is het doorgeven van een methode (De delegate) als argument van een andere methode. Zo kan je dus een "callback" maken zoals dit bijvoorbeeld ook in een taal als javascript makkelijk kan.

###Code voorbeeld van je eigen code
```cs
public delegate void PrintTextDelegate(string input);
private readonly PrintTextDelegate _printTextDelegate;
private readonly TcpClient _client;

public DataStream(TcpClient client, PrintTextDelegate printTextDelegate)
  {
    this._client = client;
    this._printTextDelegate = printTextDelegate;

    ReceiveData();
  }

public void ReceiveData()
  {
    var byteArray = new byte[256];
    string data;
    var t = new Thread(delegate ()
      {
        var stream = _client.GetStream();
        _printTextDelegate("Connected!");
      }
  }
```
###Alternatieven & adviezen
Er is de mogelijkheid om een single-method interface te gebruiken inplaats van een delegate. Veel komt overeen met beide aanpakken.  
Er wordt toch aangeraden om een delegate te gebruiken, omdat delegates hiervoor bedoelt zijn. Je hoeft in ieder geval geen aparte interface te declareren.  
De volgende punten kunnen ook worden gebruikt bij een delegate en niet bij een interface:
>* There is support built into the CLR for them
* There's support in the framework for them, including multi-cast abilities and asynchronous invocation
* There's additional C#/VB language support in the form of method group conversions, lambda expressions, anonymous methods
* They're mandated for events (i.e. events and delegates are a sort of matching pair)
* They mean you don't need to implement an interface in a separate class for each delegate instance you want to create.

###Authentieke en gezaghebbende bronnen
Nayagam, A. (2015, September 16). Understanding Delegates in C#. Retrieved February 23, 2016, from http://www.codeproject.com/Articles/11657/Understanding-Delegates-in-C

##Threading & Async

###Beschrijving van concept in eigen woorden

###Code voorbeeld van je eigen code

###Alternatieven & adviezen

###Authentieke en gezaghebbende bronnen
