# Állat menhely verseny program

## Leírás
Az állatmenhely-alapítvány kisállatversenyt rendez. Mindegyik állat regisztrálásakor meg kell adni az állat nevét és születési évét. Ezek a verseny során nyilván nem változhatnak. Mindegyikőjüket pontozzák, pontot kapnak a szépségükre és a viselkedésükre is.


A pontszám meghatározásakor figyelembe veszik a korukat is (csak év): egy egységesen érvényes maximális kor fölött 0 pontot kapnak, alatta pedig az életkor arányában veszik figyelembe a szépségre és a viselkedésre adott pontokat. Minél fiatalabb, annál inkább a szépsége számít, és minél idősebb, annál inkább a viselkedése. (Ha pl. 10 év a maximális kor, akkor egy 2 éves állat pontszáma: (10 – 2) a szépségére adott pontok + 2 a viselkedésé-re kapott pontok.)


Az állatok adatainak kiíratásához írjuk meg az állat nevét és pontszámát tartalmazó ToString() metódust.


Adja meg az aktuális évet és a versenyzők korhatárát (maximális kor), majd kezdje verse-nyeztetni az állatokat. Ez a következőt jelenti: egy állatnak regisztrálnia kell, majd azonnal kap egy-egy véletlenül generált pontszámot a szépségére is és a viselkedésére is. A pontozás után azonnal írja ki az állat adatait. Mindezt addig ismételje, amíg van versenyző állat. Ha már nincs, akkor írassa ki azt, hogy hány állat versenyzett, mekkora volt az átlag-pontszámuk és mekkora volt a legnagyobb pontszám.

## Kód
### Mainloop
~~~
function main() do
    input maximumKor
    Állat.maximumKor = maximumKor

    állatok: Állat[]
   
    while(true) do 
        input név, kor
        állatok.Add(Állat(név, kor))
        
        out "További állat hozzáadása? [I]gen vagy [N]em
        if(input N) do
            break
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
class Állat
    const név: String
    const kor: Egész
    
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