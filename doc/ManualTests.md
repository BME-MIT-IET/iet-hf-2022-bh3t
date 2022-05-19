# Manuális tesztek megtervezése, végrehajtása és dokumentálása
Manuális tesztjeinkben olyan helyzeteket vettünk sorra, melyek felmerülhetnek az RDFSharp API használata közben, tehát a megközelítés felhasználófelöli.

A négy réteg közül egyet választottunk ki, és azt igyekeztünk minél jobban körbejárni és átnézni, ez az RDFSharp.Model volt. A példaalkalmazásunkban így ennek az egy layernak a minél szétterjedőbb vizsgálatát valósítottuk meg a dokumentációra és az alapvető felhasználói elgépelésekre, tévedésekre alapozva.

## A példaéalkalmazás használatáról
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