# BDD Tesztek

## BDD
A Behavior Driven Development olyan partikák és megközelítések gyűjteménye, amely hasonló a
TDD-hez (Test Driven Development), ami igyekszik áthidalni a kommunikációs szakadékot a
stakeholderek között. A BDD célja, hogy olyan követelmények jöjjenek létre, amelyek a teljes
csapat számára érthetőek azért, hogy elkerülhetőek legyenek a félreértések.

## Gherkin
A teszteléshez használt nyelv a Gherkin, ami szimpla angol szöveget használ egy teszteset
leírásához. Olyan módon vannak leírva a teszteseteink ezáltal, hogy azokat bárki megérthesse.
A Feature kulcsszóval kezdődnek a tesztszcenáriók, amelyet egy szöveg követ, amely a teszteset
leírása. Az előfeltételeinket a Given kulcsszó után adjuk meg. Ebből általában több is van, ezekben
készíjtük elő mindazt, amire a tesztünknek szüksége van. Ilyen például az, hogy a
Lifecyclermanager már fut, létre van hozva egy projekt egy eszközzel, esetlegesen valamilyen
konfigurációs XML-lel. Ezt követi a When kulcsszó, melybe már egy esemény kerül. Ezután jön
Then lépés, melybe az utófeltétel kerül. A tesztelésnél Scenario Outlinokat írunk azért, mert ezek
olyanok, mint egy template, és ezáltal könnyebben újrafelhasználhatóvá válnak.

## Specflow
A teszteléshez Specflowt használtunk, ugyanis ez a teszt keretrendszer támogatja a Behaviour
Driven Developmentet a .NET keretrendszereben. A specflow egy nyílt forráskódú keretrendszer,
mely elérhető GitHubon. Támogatja az ATDD (Acceptance Test Driver Development) használatát
.NET alkalmazások számára. Ezáltál definiálhatunk szcenáriókat egyszerűen angolul, felhasználva a
Gherkin nyelvet.

## Tesztscenáriók
### Az RDFSharp projektben különböző adatstruktúrák lettek tesztelve. Ezek az akábbiak:
- RDFVariable
- RDFPattern
- RDFTriple
- RDFGraph
- RDFGraph kovertálása DataTable objektummá

### Különböző lekérdezések tesztelése:
- top 3 érték megtalálása
- átlag számítás
- maximum érték meghatározása


## Eredmények, tanulságok
A tesztek sikeresen lefutottak, és mindegyik át is ment. A Gherkin nyelvet felhaználba bárki számára érthetőek, hogy pontosan mi is lett tesztelve, aminek az implementációját segítette a Specflow.
