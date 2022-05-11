# Statikus analízis és manuális kódátvizsgálás

## Statikus analízis

A feladat részeként egy statikus analízis eszközt kellett futtatni a projekten, és a jelzett hibák átnézézsét követően ezeknek egy részét javítani.

A statikus analízis eszközként a SonarLint-re esett a választásom, részben azért is, mivel a gyakorlatok egyike érintette a használatát.

Ez az eszköz számos Warningot talált a projektben (számszerint összesen 905-öt), azonban ezek nagyrészt ismétlődő hibák voltak, így az egyes hiba típusokat egyszer mutatom csak be, valamint a szükséges javítást sem eszközölöm minden előfordulási helyen.



Az alábbi Warningokat jelezte a SonarLint:

- S101: Rename class 'RDFDataSource' to match pascal case naming rules, consider using 'RdfDataSource'.

    (Ez a warning 281-szer jelent meg, néhany kivételtől eltekintve akkor, ha az adott osztály neve tartalmazza az 'RDF' kulcsszót; ezt a továbbiakban nem jelzem külön, hiszen szinte minden esetben fennáll, hogy ugyanaz a warning többször is előfordult ugyanarra a hibára.)

    Ebben az esetben az RDF kulcsszókaval kezdődő osztályneveket nem refaktoráltam, mivel ez elfogadható konvencióként, azonban a többi esetben végrehajtottam az ajánlott változtatásokat, mivel ezek döntő többsége nem általánosan ismert rövidítés volt.

    Pl.: `public static class FOAF` helyett `public static class Foaf`



- S1066	Merge this if statement with the enclosing one.


S1075	Refactor your code not to use hardcoded absolute paths or URIs.



S1104	Make this field 'private' and encapsulate it in a 'public' property.


S1116	Remove this empty statement.


S112	'System.Exception' should not be thrown by user code.


S1125	Remove the unnecessary Boolean literal(s).


S1168	Return an empty collection instead of null.



S1172	Remove this unused method parameter 'ontGraph'.


S125	Remove this commented out code.


S1481	Remove the unused local variable 'predUriQName'.


S1854	Remove this useless assignment to local variable 'bufChar'.


S1905	Remove this unnecessary cast to 'RDFResource'.


S2223	Change the visibility of 'SystemString' or make it 'const' or 'readonly'.


S2234	Parameters to 'CheckIsTransitiveAssertionOf' have the same names but not the same order as the method arguments.


S2259	'subjNode' is null on at least one execution path.



S2589	Change this condition so that it does not always evaluate to 'true'.


S2755	Disable access to external entities in XML parsing.


S2971	Drop this useless call to 'ToList' or replace it by 'AsEnumerable' if you are using LINQ to Entities.


S3060	Offload the code that's conditional on this type test to the appropriate subclass and remove the condition.


S3218	Rename this field to not shadow the outer class' member with the same name.


S3247	Replace this type-check-and-cast sequence with an 'as' and a null check.


S3267	Loops should be simplified with "LINQ" expressions


S3358	Extract this nested ternary operation into an independent statement.


S3442	Change the visibility of this constructor to 'private protected'.


S3457	Remove this formatting call and simply use the input string.


S3626	Remove this redundant jump.


S3897	Implement 'IEquatable<RDFMemoryStore>'.


S3973	Use curly braces or indentation to denote the code conditionally executed by this 'if'


S4019	Remove or rename that method because it hides 'RDFSharp.Query.RDFQuery.AddModifier<T>(RDFSharp.Query.RDFDistinctModifier)'.


S4035	Seal class 'RDFGraph' or implement 'IEqualityComparer<T>' instead.


S4136	All 'ToSparqlXmlResult' method overloads should be adjacent.


S4143	Verify this is the index/key that was intended; a value has already been set for it.


S4201	Remove this unnecessary null check; 'is' returns false for nulls.


S927	Rename parameter 'table' to 'tableToFilter' to match the base class declaration.




## Manuális kódátvizsgálás:

A projekt manuális átvizsgálása során az alábbi code-smellekre, hibákra lettem figyelmes:

- Sok osztálynév nem triviális rövidítésekből, mozaikszavakból állnak, mint pl.:

    - `FOAF` : Friend-of-a-Friend vocabulary
    - `SWRLB` : W3C Semantic Web Rule Language - BuiltIns vocabulary
    - `DOAP` : Description-of-a-Project vocabulary
    - stb.

    Azokban az esetekben végeztem névváltoztatás kifejezőbb, hosszabb nevekre, ahol csak egy szűk körben ismert rövidítés volt (így például az `XML`, `OWL`, stb. osztályok maradhattak ilyen néven)