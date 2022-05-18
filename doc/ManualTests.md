# Manuális tesztek megtervezése, végrehajtása és dokumentálása
Manuális tesztjeinkben olyan helyzeteket vettünk sorra, melyek felmerülhetnek az RDFSharp API használata közben, tehát a megközelítés felhasználófelöli.

A négy réteg közül egyet választottunk ki, és azt igyekeztünk minél jobban körbejárni és átnézni, ez az RDFSharp.Model volt.

## Create resources tesztek

### Create resource with uri-string
Elvárás: Sikeres létrehozás
Kimenet: Sikeres létrehozás

### Create resource with blank string
Elvárás: Sikeresen létrehoz egy üres resourcet
Kimenet: Kivételt dob

### Create resource with not uri string
Elvárás: Kivételt dob
Kimenet: Kivételt dob

### Create resource without string
Elvárás: Sikeresen létrehoz egy üres resourcet
Kimenet: Sikeresen létrehoz egy üres resourcete

## Create literals tesztek

### Create plainliteral with string
Elvárás: Sikeresen létrehoz egy literalt
Kimenet: Sikeresen létrehoz egy literalt

### Create plainliteral with blank string
Elvárás: Sikeresen létrehoz egy literalt üres stringgel
Kimenet: Sikeresen létrehoz egy literalt üres stringgel

### Create plainliteral with string and language tag
Elvárás: Sikeresen létrehoz egy literalt
Kimenet: Sikeresen létrehoz egy literalt

### Create plainliteral with string and blank language tag
Elvárás: Sikeresen létrehoz egy literalt üres language taggel
Kimenet: Sikeresen létrehoz egy literalt üres language taggel

### Create plainliteral with blank string and language tag
Elvárás: Sikeresen létrehoz egy literalt üres stringgel
Kimenet: Sikeresen létrehoz egy literalt üres stringgel

### Create plainliteral with blank string and blank language tag
Elvárás: Sikeresen létrehoz egy literalt üres stringgel és egy üres language taggel
Kimenet: Sikeresen létrehoz egy literalt üres stringgel és egy üres language taggel

### Create typedliteral with correct value
Elvárás: Sikeresen létrehoz egy literalt
Kimenet: Sikeresen létrehoz egy literalt

### Create typedliteral with blank value
Elvárás: Kivételt dob
Kimenet: Kivételt dob

### Create typedliteral with not matching values
Elvárás: Kivételt dob
Kimenet: Kivételt dob

## Create triples tesztek

### Create triple with correct values
Elvárás: Sikeresen létrehoz egy triplet
Kimenet: Sikeresen létrehoz egy triplet

### Create triple with blank values
Elvárás: Kivételt dob
Kimenet: Kivételt dob

## Create graph

### Create empty graph
Elvárás: Sikeresen létrehoz egy üres gráfot
Kimenet: Sikeresen létrehoz egy üres gráfot

### Create graph with triples
Elvárás: Sikeresen létrehoz egy gráfot
Kimenet: Sikeresen létrehoz egy gráfot

### Create graph with uri string
Elvárás: Sikeresen létrehoz egy gráfot
Kimenet: Sikeresen létrehoz egy gráfot

### Create graph from datatable
Elvárás: Sikeresen létrehoz egy gráfot
Kimenet: Sikeresen létrehoz egy gráfot

### Create graph from uri
Elvárás: Sikeresen létrehoz egy gráfot
Kimenet: Sikeresen létrehoz egy gráfot

## Manipulate graph