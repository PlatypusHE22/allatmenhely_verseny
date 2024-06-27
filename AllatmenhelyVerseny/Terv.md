# Állat menhely verseny program

## Leírás
Az állatmenhely-alapítvány kisállatversenyt rendez. Mindegyik állat regisztrálásakor meg kell adni az állat nevét és születési évét. Ezek a verseny során nyilván nem változhatnak. Mindegyikőjüket pontozzák, pontot kapnak a szépségükre és a viselkedésükre is.


A pontszám meghatározásakor figyelembe veszik a korukat is (csak év): egy egységesen érvényes maximális kor fölött 0 pontot kapnak, alatta pedig az életkor arányában veszik figyelembe a szépségre és a viselkedésre adott pontokat. Minél fiatalabb, annál inkább a szépsége számít, és minél idősebb, annál inkább a viselkedése. (Ha pl. 10 év a maximális kor, akkor egy 2 éves állat pontszáma: (10 – 2) a szépségére adott pontok + 2 a viselkedésé-re kapott pontok.)


Az állatok adatainak kiíratásához írjuk meg az állat nevét és pontszámát tartalmazó ToString() metódust.


Adja meg az aktuális évet és a versenyzők korhatárát (maximális kor), majd kezdje verse-nyeztetni az állatokat. Ez a következőt jelenti: egy állatnak regisztrálnia kell, majd azonnal kap egy-egy véletlenül generált pontszámot a szépségére is és a viselkedésére is. A pontozás után azonnal írja ki az állat adatait. Mindezt addig ismételje, amíg van versenyző állat. Ha már nincs, akkor írassa ki azt, hogy hány állat versenyzett, mekkora volt az átlag-pontszámuk és mekkora volt a legnagyobb pontszám.

## Kód
### Adatfájl szerkezete
Egy sorban: típus(macska = m, kutya = k);név;születési év;oltási igazolvány száma;van e hordozódobozuk(i/n, kutyaák esetén mindig n)
~~~
m;Cirmi;2012;185639;i
k;Kefír;2017;489264;n
~~~

### Mainloop
~~~
function main() do
    input maximumKor
    Állat.maximumKor = maximumKor

    állatok: Állat[]
   
    file = open_file(allatok.txt)
    while(file) do
        line: String[] = file.read_line()
        if(line[0] == 'k')
            állatok.add(Kutya(line))
        else
            állatok.add(Macska(line))
        end
        
    end
    
    foreach(állat in állatok) do
        out állat
    end
    
    out állatok.Size()
    out állatok.Average()
    out állatok.Max()
end
~~~

### Állat osztály
~~~
abstract class Állat
    const név: String
    const kor: Egész
    
    const oltásiIgazolás: Egész
    rajtszám: Egész
    
    viselkedésPont: Egész
    szépségPont: Egész
    összPont: Egész
    
    static const maximumÉletkor: Egész
    
    fucntion ToString() do
        return "Név" + név + "Pontszám" + osszPont
    end

    constructor Állat(név, kor) do
        this.név = név
        this.kor = kor
        
        if(kor > maximumÉletkor)
            viselkedéspont = 0
            szépségPont = 0
            összPont = 0
            return
        end
        
        viselkedésPont = random() + kor
        szépségPont = random() - kor
        
        összPont = viselkedésPont + szépségPont
    end
    
end
~~~

### Kutya osztály
~~~
class Kutya inherits Állat
    viszonypont: Egész

    constructor Kutya(név, kor, oltási_igazolás) do
        Allat(név, kor, oltási_igazolás)
        viszonypont = random()
        
        if viszonypont <= 0 do
            szépségpot = 0
            viselkedéspont = 0
        end
    end
end
~~~

### Macska osztály
~~~
class Macska inherits Állat
    van_doboz: Bool
    
    constructor Macska(név, kor, oltási_igazolás, van_doboz) do
        Állat(név, kor, oltási_igazolás)
        this.van_doboz = van_doboz
        
        if !van_doboz do 
            szépségpont = 0
            viselkedéspont = 0
        end
    end

end
~~~