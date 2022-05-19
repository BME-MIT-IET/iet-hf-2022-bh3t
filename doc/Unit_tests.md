# Egységtesztek kiegészítése és tesztek kódlefedettségének mérése

A feladatot a codecov kódfedettseg mérő beüzemelésével kezdtem.
Az eszközt Github Actionbe is bekötöttem, így minden push után a main branchbe
friss információt kapunk az aktuális kódfedettségről, a következő linken:

https://app.codecov.io/gh/BME-MIT-IET/iet-hf-2022-bh3t/

Kódfedettség a feladat végrehajtása előtt:

![Kódfedettség a feladat végrehajtása előtt](coverage_1.png)

Az `RDFSelectQuery` és `RDFConstructQuery` osztályokat teszteltem.
A tesztek során a projektben korábban használt framewörköt alkalmaztam. (MSTest és WireMockServer)

A következő teszteseteket hoztam létre:
- `ShouldCreateConstructQuery`: Inicializált RDFConstructQuery vizsgálata.
- `ShouldCreateConstructQueryWithQueryMembers`: RDFConstructQuery helyes SPARQL reprezentációjának vizsgálata.
- `ShouldApplyConstructQueryToSPARQLEndpoint`: SPARQL végponttól construct queryre kapott válasz helyes szerializációjának vizsgálata. Ehhez mock szerver objektumot hoztam létre.
- `ShouldCreateSelectQuery`: Inicializált RDFSelectQuery vizsgálata.
- `ShouldCreateSelectQueryWithQueryMembers`: RDFSelectQuery helyes SPARQL reprezentációjának vizsgálata.
- `ShouldApplySelectQueryToSPARQLEndpoint`: SPARQL végponttól select queryre kapott válasz helyes szerializációjának vizsgálata. Ehhez mock szerver objektumot hoztam létre.

A `ShouldCreateSelectQueryWithQueryMembers` teszt elbukott. A hibát felvettem egy issueba.
A coverage láthatósága miatt a tesztet kikommenteztem átmenetileg.
