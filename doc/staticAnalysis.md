
# Statikus analízis és manuális kódátvizsgálás

## Összefoglaló

A feladat során a forráskód átvizsgálására kerül sor mind manuálisan, mind pedig satikus analízis eszközökkel. A talált érdekességeket és hibákat utána megpróbálom megvizsgálni, értelmezni, valamint ezeknek egy részét ténylegesen javítani a kódban.

## Eredmények és tanulságok

A forráskód alapvetően nem tartalmazott általam talált nagyobb hibákat (néhány esettől eltekintve, lásd lejjebb), logikailag helyesen van felépítve.

A statikus analízis során felmerült hibákat mind megnéztem, és ugyan voltak esetek, amikor nem voltak ténylegesen hibásak az adott kódrészetek, többségében valós problémákra derült fény így, mégha komolyabb bugokkal nem is találkoztam.. Esetenként másképp (például manuális átvizsgálással) nehezen észrevehető bugok és hibák kerültek javításra.

Ezek alapján a statikus analízist egy nagyon hasznos fejlesztési, ellenőrzési lépésnek tartom, bármely projektnél hasznos lehet egy ilyen eszköz használata.

A következőkben található egy részletesebb leírás a statikus analízis valamint manuális kódátvizsgálás során felmerült hibákról.

## Statikus analízis

A statikus analízis során számos Warning került felfedezésre a projektben (számszerint összesen 905), azonban ezek nagyrészt ismétlődő hibák vagy stílusbeli problémák voltak, így az egyes hiba típusokat egyszer mutatom csak be, valamint a szükséges javítást sem eszközölöm minden előfordulási helyen.

Statikus analízis eszköznek a SonarLintet valamint a SonarCloudot használtam, így a továbbiakban pusholt változtatások által okozott hibák könnyedén ellenőrizhetők lesznek majd SonarCloudon keresztül.

Az alábbi hibák merültek fel az analízis során:

- ### S101  Types should be named in PascalCase

    Egy konkrét példa: Rename class 'RDFDataSource' to match pascal case naming rules, consider using 'RdfDataSource'.

    Nem javítottam ezt a hibát, de valóban szembemegy a PascalCase konvenciónak, így nem szerencsés ilyen nevek használata.

- ### S1066 Collapsible "if" statements should be merged. Merge this if statement with the enclosing one.

    Ez a gyakorlatban a következőt jelenti:
    ```
    if (condition1)
    {
        if (condition2)
        {
            // ...
        }
    }
    ```
    helyett a következő javasolt:
    ```
    if (condition1 && condition2)
    {
        // ...
    }
    ```
    Ezt a hibát sem javítottuk, mivel egyrészt sok helyen előfordul, másrészt csak szokásbeli különbséget jelent, valamint esetenként kifejezőbbek és átláthatóbbak az if statementek így.

- ### S1075 URIs should not be hardcoded. Refactor your code not to use hardcoded absolute paths or URIs.

    Kódba égetett URI-k használata nem szerencsés például tesztelhetőségi szempontból.

    Pl.: 
    ```
    public static readonly string BASE_URI = "http://www.w3.org/2003/06/sw-vocab-status/ns#";
    ```
- ### S1104 Fields should not have public accessibility. Make this field 'private' and encapsulate it in a 'public' property.

    Osztályok publikus adattagjai clean code elveket sértenek, helyettük jobb publikus property-k használata (Encapsulation).

- ### S112  General exceptions should never be thrown. 'System.Exception' should not be thrown by user code.

    A hibák dobásánál minden esetben `System.Exception` típusú hibák kerülnek dobásra, és csak egy string jelzi a hibák valós okát. Ehelyett általában sokkal célravezetőbb lenne konkrét hibaosztályok használata, például `ArgumentNullException`, azonban esetünkben nincsenek olyan beépített `Exception` leszármazottak, amik pontosan illenének a problémákra.

- ### S1125 Boolean literals should not be redundant. Remove the unnecessary Boolean literal(s).

    Bool literálisok (true, false) felesleges használata történik, ami ugyan általában a tömörség rovására mehet, a jelzett esetekben mégis egyszerűsíti a kód megértését:
    ```
    bool disjointSubject = this.Pattern.Subject is RDFVariable ? !row.Table.Columns.Contains(subjectString) : true;
    ```
    Ez a kifejezés persze kifejezhető lenne a ?: operator használata nélkül is valahogy így:
    ```
    bool disjointSubject = !(this.Pattern.Subject is RDFVariable) || !row.Table.Columns.Contains(subjectString);
    ```
    Azonban látható, hogy az utóbbi lényegesen nehezebben értelmezhető, így ezeknek a hibáknak a javítását nem tartom célszerűnek, a bool literálisok redundáns használata jelen esetben kifejezetten hasznos.

- ### S1168  Empty arrays and collections should be returned instead of null. Return an empty collection instead of null.

    A null visszatérési érték a hívó függvényben további null ellenőrzéseket okozhat, azonban a projektben ez az alábbi módon fordul elő:
    ```
    public RDFShape SelectShape(string shapeName)
    {
        if (shapeName != null)
        {
            long shapeID = RDFModelUtilities.CreateHash(shapeName);
            if (this.Shapes.ContainsKey(shapeID))
                return this.Shapes[shapeID];
        }
        return null;
    }
    ```
    Tehát null bemeneti érték esetében adódik csak vissza null, ehelyett talán jobb lenne egyből itt egy `ArgumentNullException()` dobása.
    
    Ennek a hibának a javítása igazán nehézkes, mivel a hivó függvények logikájában is változásokat okoz a visszatérési érték változása.
    
- ### S1172	Unused method parameters should be removed.
    
    Nem használt függvényparaméterek használata.

    Lokálisan használt függvények esetén könnyen belátható, hogy a jelölt paraméterek feleslegesek.
    Javítás: https://github.com/BME-MIT-IET/iet-hf-2022-bh3t/commit/9490181e3ef6c27a755deb14b95af827b197a450

    A projekt több helyen tartalmaz még hasonlóan felesleges paramétereket.

- ### S125	Sections of code should not be commented out. Remove this commented out code.

    A forráskód kikommentezett kódot tartalmaz, ez nyilvánvalóan felesleges mindegyik előfordulási esetben, nem segítették a kód megoldását, törlésre kerültek:
    https://github.com/BME-MIT-IET/iet-hf-2022-bh3t/commit/678f877869e99a819a5aaf79a06572bcb4d767f9

- ### S1854	Unused assignments should be removed. Remove this useless assignment to local variable 'bufChar'.
    
    A kódban egy változónak értéket adunk, majd még azelőtt felülírjuk ezt egy újabb értékadással, hogy a változót máshol használnánk, így az első értékadás felesleges. Javítás: https://github.com/BME-MIT-IET/iet-hf-2022-bh3t/commit/366ee37074d11d9a8f176edfb7b75a49a08dd0b4
    
- ### S1905	Redundant casts should not be used. Remove this unnecessary cast to 'RDFResource'.

    A kódban felesleges castolás történt, olyan típussra castoltunk, amilyen az adott változó típusa, így ez teljes mértékben felesleges. Javítás:
    https://github.com/BME-MIT-IET/iet-hf-2022-bh3t/commit/10e04d79ae0068f940da500b74336bb36895375e

- ### S2223	Change the visibility of 'SystemString' or make it 'const' or 'readonly'.

    A változók lehetnek readonly-k, így ezeket javítottam a kódban: https://github.com/BME-MIT-IET/iet-hf-2022-bh3t/commit/b073c7b67dcf9a14c80c1ead54992c540df4c305

- ### S2234	Parameters should be passed in the correct order. Parameters to 'CheckIsTransitiveAssertionOf' have the same names but not the same order as the method arguments.

    A függvény deklarációja a következő:
    ```
    public static bool CheckIsTransitiveAssertionOf(this RDFOntologyData data, RDFOntologyFact aFact, RDFOntologyObjectProperty transProp, RDFOntologyFact bFact)
    {
        //...
    }
    ```
    Valamint a következő módon kerül meghívásra:
    ```
    ontologyData.CheckIsTransitiveAssertionOf(bFact, objProperty, aFact)
    ```
    Egyrészt látszik, hogy a függvény paramátereinek nevei nem elég kifejezőek, másrészt az ilyen nevű paramétereket felcserélve kapja meg a függvény (aFact és bFact), aminek okát nem sikerült megértenem.

- ### S2259	Null pointers should not be dereferenced. 'subjNode' is null on at least one execution path.

    A hiba által talált hiba a valóságban sosem fordulhat elő vélemémyem szerint, minden ágon inicializálva lesz a kérdéses változó. Elméletileg ugyen előfordulhatnak ágak, amikben ez nem történne meg (ezeket találta meg a statikus analízis), de ezek lehetetlen feltételsorozat következtében fordulnának csak elő. 
    
    https://github.com/BME-MIT-IET/iet-hf-2022-bh3t/blob/SonarCloud/RDFSharp/Model/Serializers/RDFXml.cs

- ### S2755	XML parsers should not be vulnerable to XXE attacks. Disable access to external entities in XML parsing.

    Az XML szerializáció kódban történő ahasználata sérülékenységekhez vezethet. A problémát az alábbi utolsó sor okozza:
    ```
    using (XmlTextReader trixReader = new XmlTextReader(streamReader))
        {
            trixReader.DtdProcessing = DtdProcessing.Parse;
    ```
    Az XmlReader biztonságos "by default", azonban a `DtdProcessing = Parse` következtében nem lesz biztonságos.

    Javítva: https://github.com/BME-MIT-IET/iet-hf-2022-bh3t/commit/6572551fad57396dd4ddb0e6fb4c90259222654e

- ### S2971	"IEnumerable" LINQs should be simplified. Drop this useless call to 'ToList' or replace it by 'AsEnumerable' if you are using LINQ to Entities.

    Felesleges a ToList() meghívása egy IEnumerable objektumon, ha utána Any()-t is hívunk. Javitva:
    https://github.com/BME-MIT-IET/iet-hf-2022-bh3t/commit/0d97c6247499a7c9a117218fe2afb5bff9cf840c

- ### S3060 "is" should not be used with "this". Offload the code that's conditional on this type test to the appropriate subclass and remove the condition.

    A kódban az alábbihoz hasonló esetekkel találkozhatunk:
    ```
    internal bool IsGraph() => this is RDFGraph;
    ```
    A `this` és az `is` együttes használata szinte minden esetben alapvető objektumorientáltsági problémákra utal, ugyanis a típus kódba égetett tesztelése rugalmatlanná teszi a kódot, későbbi módosítás esetén hibák keletkezhetnek, több helyen kell módosítani a kódot, így ennel használata nem ajánlott. Helyette például polimorfizmust lehetne használni ennek elkerülésére.

- ### S3218	Inner class members should not shadow outer class "static" or type members. Rename this field to not shadow the outer class' member with the same name.
    ```
     public static class DC
        {
            public static readonly string PREFIX = "dc";
            /* ... */
            public static class DCAM
            {
                public static readonly string PREFIX = "dcam";
                /* ...
    ```
    A fenti példához hasonló esetekkel találkozhatunk, a belső osztály attribútumai ugyanolyan nevet kaptak, mint a befoglaló osztályé. Ez jelen esetben nem okoz hibákat, azonban valóban célszerűbb lenne ezeknek más nevet adni, például `PrefixDcam`.

- ### S3247	 Duplicate casts should not be made. Replace this type-check-and-cast sequence with an 'as' and a null check.

    Hatékonyabb a kódunk, ha csak 1 castolást végzünk 2 helyett, például a következő esetben:
    ```
    if (tObject is RDFResource)
    {
        this.AddTriple(new RDFTriple((RDFResource)tSubject, (RDFResource)tPredicate, (RDFResource)tObject));
    ```
    helyett:
    ```
    var to = tObject as RDFResource;
    if (to != null)
    {
        this.AddTriple(new RDFTriple((RDFResource)tSubject, (RDFResource)tPredicate, to));
    ```
- ### S3267	Loops should be simplified with "LINQ" expressions.

    Ha egy foreach ciklusban if feltétel is van, lehet, hogy a kettő összevonható egy LINQ kifejezéssel. Ez nem hiba, csupán a kód tömörségét segíti.

- ### S3358	Extract this nested ternary operation into an independent statement.

    ?: operátorok (ternary operator) egymásba ágyazása történik, ami szintén nem jelent hibát, azonban nagyban megnehezíti a kód értelmezését.

- S3442	"abstract" classes should not have "public" constructors. Change the visibility of this constructor to 'private protected'.

    Mivel egy abstract osztály nem példányosítható, nincs értelme `public` vagy `internal` construktoroknak, helyette `private` vagy `protected` kéne, hogy legyen.

- ### S3457	Composite format strings should be used correctly. Remove this formatting call and simply use the input string.

    ```
    string.Format("text");
    ```
    Ehhez hasonló esetekben felesleges a string.Format hívása, javítva: https://github.com/BME-MIT-IET/iet-hf-2022-bh3t/commit/8c8681cc6db16b4aa249a91af54051d94f708e8d

- ### S3626	Remove this redundant jump.

    Felesleges a `continue` használata a jelzett esetben.
    https://github.com/BME-MIT-IET/iet-hf-2022-bh3t/blob/main/RDFSharp/Semantics/OWL/RDFSemanticsUtilities.cs#L1095

- ### S3897	Classes that provide `Equals(<T>)` should implement `IEquatable<T>`. Implement `IEquatable<RDFMemoryStore>`.
    
    Az `RDFMemoryStore` osztályunknak van `Equals(RDFMemoryStore other)` függvénye, azonban nem implementálja az `IEquatable<RDFMemoryStore>` interface-t.
     
- ### S3973	A conditionally executed single line should be denoted by indentation. Use curly braces or indentation to denote the code conditionally executed by this 'if'

    If után következő sor nem volt beljebb indentálva vagy kapcsos zárójelek közé téve, így ez hibás működést eredményezhetett. **Ez egy valós és kifejezetten jelentős hiba**, így ezt különsen szerencsés, hogy megtaláltuk a statikus analízis során. Javítva: https://github.com/BME-MIT-IET/iet-hf-2022-bh3t/commit/8d296cc5219cc24f85502561857ede599a33040e

- ### S4136	Method overloads should be grouped together. All 'ToSparqlXmlResult' method overloads should be adjacent. 

    Ugyanazon metódusokat felülíró metódusoknak egymás mellet célszerű lenniük az átláthatóság szempontjából, de egyébként nem okoz hibát a nehezebb megértésen kívül.

- ### S4143	Collection elements should not be replaced unconditionally. Verify this is the index/key that was intended; a value has already been set for it.

    https://github.com/BME-MIT-IET/iet-hf-2022-bh3t/blob/SonarCloud/RDFSharp/Model/Serializers/RDFNTriples.cs#L259-L266

    Ez a hibajelzés potenciálisan komoly hibákra deríthetne fényt, hiszen többször egymás után ugyanannak a tömbelemnek adunk értéket, azonban esetünkben minden helyesen történik szerintem, ugyanis az értékadásoknak mind van hatásuk a stringre (egy adott regexre illeszkedő rész kicserélése), és megállapítható, hogy ezek a hatások nem vesznek el a függvények megvizsgálását követően, így ezek nem hibásak. Kissé szerencsétlen a függvények iyen módon történő használata ebben az esetben, első ránézésre valóban nem egyértelmű, mi is történik valójában.

- ### S4201	Null checks should not be used with "is". Remove this unnecessary null check; 'is' returns false for nulls.

    ```
    if (this.FocusNode != null && this.FocusNode is RDFResource)
    ```
    A null checkelés felesleges, hiszen null esetén az `is` false eredményt ad, azonban ez nem okoz hibát, valamint expliciten jelzi, hogy nem lehet null a változó értéke, ami segítheti az egyértelműséget.

## Manuális kódátvizsgálás:

A projekt manuális átvizsgálása során nem találtam nagyobb problémákat, csak az alábbi kisebb code-smellekre lettem figyelmes:

- Sok osztálynév nem triviális rövidítésekből, mozaikszavakból állnak, mint pl.:
    - `SWRLB` : W3C Semantic Web Rule Language - BuiltIns vocabulary
    - `DOAP` : Description-of-a-Project vocabulary
    - stb.

    A csapat többi tagjára való tekintettel nem végeztem el a névmódosításokat, mivel párhuzamosan dolgoztunk a különböző feladatokon.

- A kód sok helyen tartalmaz nehezen érthető, nem elég kifejező változóneveket, függvényparamétereket, például:
    ```
    public static bool CheckIsTransitiveAssertionOf(this RDFOntologyData data, RDFOntologyFact aFact, RDFOntologyObjectProperty transProp, RDFOntologyFact bFact)
    {
        //...
    }
    ```
    Ezeket refatorálva a függvényhívásoknál sokkal magától értetődőbb lenne a paraméterezés.

- A kódban az osztályok, fieldek és paraméterek elnevezése sokszor nem követi a platform konvenciókat (pl. PascalCase)

- Általánosságban véve sok a nehezen érthető kódrészlet (egymásba ágyazott ternary operator-ok, bonyolult logikai kifejezések, stb.).