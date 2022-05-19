# Manuális tesztek megtervezése, végrehajtása és dokumentálása
Manuális tesztjeinkben olyan helyzeteket vettünk sorra, melyek felmerülhetnek az RDFSharp API használata közben, tehát a megközelítés felhasználófelöli.

A négy réteg közül egyet választottunk ki, és azt igyekeztünk minél jobban körbejárni és átnézni, ez az RDFSharp.Model volt. A példaalkalmazásunkban így ennek az egy layernak a minél szétterjedőbb vizsgálatát valósítottuk meg a dokumentációra és az alapvető felhasználói elgépelésekre, tévedésekre alapozva.

## A példaalkalmazás használatáról
Ha futtatjuk a példaalkalmazást, egy menüsorral találjuk szembe magunkat. Itt szűkíthetjük a tesztek típusát, azaz kiválaszthatjuk, hogy milyen sub-testekhez szeretnénk eljutni. Ha ezt kiválasztottuk, a sub-test menüjébe kerülünk, ahol már a tényleges teszteket érjük el. Ezeket sorrend és más megkötések nélkül futtathatjuk, vagy visszaléphetünk az első általános menübe. Ha a futtatás mellett döntünk, a teszt lefutása végén láthatjuk a teszt elvárt és valós kimenetét.

## Create resources tesztek

### Create resource with uri-string
*Resource létrehozása uri stringgel*  
Elvárás: Sikeres létrehozás  
Kimenet: Sikeres létrehozás

### Create resource with blank string
*Resourse létrehozása üres stringgel*  
Elvárás: Sikeresen létrehoz egy üres resourcet  
Kimenet: Kivételt dob

### Create resource with not uri string
*Resource létrehozása nem uri stringgel*  
Elvárás: Kivételt dob  
Kimenet: Kivételt dob

### Create resource without string
*Resource létrehozása paraméter nélkül*  
Elvárás: Sikeresen létrehoz egy üres resourcet  
Kimenet: Sikeresen létrehoz egy üres resourcete

## Create literals tesztek

### Create plainliteral with string
*Plainliteral létrehozása stringgel*  
Elvárás: Sikeresen létrehoz egy literalt  
Kimenet: Sikeresen létrehoz egy literalt

### Create plainliteral with blank string
*Plainliteral létrehozása üres stringgel*  
Elvárás: Sikeresen létrehoz egy literalt üres stringgel  
Kimenet: Sikeresen létrehoz egy literalt üres stringgel

### Create plainliteral with string and language tag
*Plainliteral létrehozása stringgel és language taggel*  
Elvárás: Sikeresen létrehoz egy literalt  
Kimenet: Sikeresen létrehoz egy literalt

### Create plainliteral with string and blank language tag
*Plainliteral létrehozása stringgel és üres language taggel*  
Elvárás: Sikeresen létrehoz egy literalt üres language taggel  
Kimenet: Sikeresen létrehoz egy literalt üres language taggel

### Create plainliteral with blank string and language tag
*Plainliteral létrehozása üres stringgel és language taggel*  
Elvárás: Kivételt dob   
Kimenet: Sikeresen létrehoz egy literalt üres stringgel

### Create plainliteral with blank string and blank language tag
*Plainliteral létrehozása üres stringgel és üres language taggel*   
Elvárás: Kivételt dob   
Kimenet: Sikeresen létrehoz egy literalt üres stringgel és egy üres language taggel

### Create typedliteral with correct value
*Typedliteral létrehozása a megfeleő értékekkel*  
Elvárás: Sikeresen létrehoz egy literalt  
Kimenet: Sikeresen létrehoz egy literalt

### Create typedliteral with blank value
*Typedliteral létrehozása üres értékkel*  
Elvárás: Kivételt dob  
Kimenet: Kivételt dob

### Create typedliteral with not matching values
*Typedliteral létrehozása nem egyező értékekkel*  
Elvárás: Kivételt dob  
Kimenet: Kivételt dob

## Create triples tesztek

### Create triple with correct values
*Triple létrehozása a megfelelő értékekkel*  
Elvárás: Sikeresen létrehoz egy triplet  
Kimenet: Sikeresen létrehoz egy triplet

### Create triple with blank values
*Triple létrehozása üres értékekkel*  
Elvárás: Kivételt dob  
Kimenet: Kivételt dob

## Create graph

### Create empty graph
*Üres graph létrehozása*  
Elvárás: Sikeresen létrehoz egy üres gráfot  
Kimenet: Sikeresen létrehoz egy üres gráfot

### Create graph with triples
*Graph létrehozása létező triple-ökkel*  
Elvárás: Sikeresen létrehoz egy gráfot  
Kimenet: Sikeresen létrehoz egy gráfot

### Create graph with uri string
*Graph létrehozása uri stringgel*  
Elvárás: Sikeresen létrehoz egy gráfot  
Kimenet: Sikeresen létrehoz egy gráfot

### Create graph from datatable
*Graph létrehozása datatable-ből*  
Elvárás: Sikeresen létrehoz egy gráfot  
Kimenet: Sikeresen létrehoz egy gráfot

## Manipulate graph

### Add triple to graph
*Triple hozzáadása graphhoz*  
Elvárás: Hozzáad egy triple-t a graphhoz  
Kimenet: Hozzáad egy triple-t a graphhoz

### Delete triples from graph
*Triple törlése graphból*   
Elvárás: Töröl egy triple-t a graphból  
Kimenet: Töröl egy triple-t a graphból

### Delete triples by subject from graph
*Triple törlése graphból alany alapján*   
Elvárás: Töröl egy triple-t a graphból alany alapján  
Kimenet: Töröl egy triple-t a graphból alany alapján

### Delete triples by non existing predicate from graph
*Triple törlése graphból állítmány alapján*   
Elvárás: Töröl egy triple-t a graphból állítmány alapján  
Kimenet: Töröl egy triple-t a graphból állítmány alapján

### Delete triples by object from graph
*Triple törlése graphból tárgy alapján*   
Elvárás: Töröl egy triple-t a graphból tárgy alapján  
Kimenet: Töröl egy triple-t a graphból tárgy alapján

### Delete triples by non existing literal from graph
*Triple törlése graphból literal alapján*   
Elvárás: Töröl egy triple-t a graphból literal alapján  
Kimenet: Töröl egy triple-t a graphból literal alapján

### Clear triples from graph
*Összes triple törlése a graphból*   
Elvárás: Törli az összes triple-t a graphból   
Kimenet: Törli az összes triple-t a graphból

### Check if given triple exists
*Triple létezik-e a graphban*   
Elvárás: Visszaadja, hogy az adott triple létezik-e a graphban  
Kimenet: Visszaadja, hogy az adott triple létezik-e a graphban

### Select triples by subject
*Tripleök kiválasztása alany alapján*   
Elvárás: Visszaadja adott alanyú tripleök gráfját  
Kimenet: Visszaadja adott alanyú tripleök gráfját

### Select triples by predicate
*Tripleök kiválasztása állítmány alapján*   
Elvárás: Visszaadja adott állítmányú tripleök gráfját  
Kimenet: Visszaadja adott állítmányú tripleök gráfját

### Select triples by object
*Tripleök kiválasztása tárgy alapján*   
Elvárás: Visszaadja adott tárgyú tripleök gráfját  
Kimenet: Visszaadja adott tárgyú tripleök gráfját

### Select triples by literal
*Tripleök kiválasztása literál alapján*   
Elvárás: Visszaadja adott literálú tripleök gráfját  
Kimenet: Visszaadja adott literálú tripleök gráfját

### Graph intersect
*Két graph metszetének képzése*   
Elvárás: Visszaadja a két gráf metszetét  
Kimenet: Visszaadja a két gráf metszetét

### Graph union
*Két graph uniójának képzése*   
Elvárás: Visszaadja a két gráf unióját  
Kimenet: Visszaadja a két gráf unióját

### Graph difference
*Két graph különbségének képzése*   
Elvárás: Visszaadja a két gráf különbségét  
Kimenet: Visszaadja a két gráf különbségét