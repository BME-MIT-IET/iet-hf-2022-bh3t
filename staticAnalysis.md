@@ -0,0 +1,143 @@
# Statikus analízis és manuális kódátvizsgálás

## Statikus analízis

A feladat részeként egy statikus analízis eszközt kellett futtatni a projekten, és a jelzett hibák átnézézsét követően ezeknek egy részét javítani.

A statikus analízis eszközként a SonarLint-re esett a választásom, részben azért is, mivel a gyakorlatok egyike érintette a használatát.

Ez az eszköz számos Warningot talált a projektben (számszerint összesen 905-öt), azonban ezek nagyrészt ismétlődő hibák voltak, így az egyes hiba típusokat egyszer mutatom csak be, valamint a szükséges javítást sem eszközölöm minden előfordulási helyen, és csak a nem triviális hibák kerülnek javításra.



Az alábbi Warningokat jelezte a SonarLint:

- S101: Types should be named in PascalCase

    Egyonkrét példa: Rename class 'RDFDataSource' to match pascal case naming rules, consider using 'RdfDataSource'.

    (Ez a warning 281-szer jelent meg különböző osztályoknál, néhany kivételtől eltekintve akkor, ha az adott osztály neve tartalmazza az 'RDF' kulcsszót; ezt a továbbiakban nem jelzem külön, hiszen szinte minden esetben fennáll, hogy ugyanaz a warning többször is előfordult ugyanarra a hibára.)

- S1066	Collapsible "if" statements should be merged. Merge this if statement with the enclosing one.

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

- S1075	URIs should not be hardcoded. Refactor your code not to use hardcoded absolute paths or URIs.

    Kódba égetett URI-k használata nem szerencsés például tesztelhetőségi szempontból.


- S1104	Fields should not have public accessibility. Make this field 'private' and encapsulate it in a 'public' property.

    Osztályok publikus adattagjai clean code elveket sértenek, helyettük jobb publikus property-k használata (Encapsulation).


- S1116	Empty statements should be removed. Remove this empty statement.

    Triviális hiba, az alábbi helyen fordult elő:
    ```
    void BuildSemanticReification(bool isAxiomAnn, RDFOntologyTaxonomyEntry te, RDFTriple asnTriple,
                RDFResource type, RDFResource subjProp, RDFResource predProp, RDFResource objProp, RDFResource litProp)
    {
        // ...
    };
    ```
    A probléma itt a kapcsoszárójel utáni, valószínűleg véletlenül kiírt pontosvessző. Javítás:

    

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

    - `SWRLB` : W3C Semantic Web Rule Language - BuiltIns vocabulary
    - `DOAP` : Description-of-a-Project vocabulary
    - stb.

    A csapat többi tagjára való tekintettel nem végeztem el a névmódosításokat, mivel párhuzamosan dolgoztunk a különböző feladatokon.