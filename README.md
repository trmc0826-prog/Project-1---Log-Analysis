# Analyse av hendelseslogg.

Prosjektet er utviklet for synteseprosjektet i C# Basic.

Programmet er en konsollapplikasjon som leser hendelselogger fra en tekstfil. Målet er å gjøre det enklest mulig å undersøke
loggoppføringer gjennom filtrering, søk, sortering og statistikk.

Arbeidet med klasser, lister, filbehandling og LINQ.

_litt av grunnen jeg valgte var å arbeide med akkurat dette, var for å banke inn noe jeg fant utfordrende i starten._

## Funksjonalitet

1. Show all logs (Oversikt over alle loggene i filen som leses.)
2. Filters logs. (Filtrere logger etter type eller kilde, og lar brukeren søke etter tekst i meldingene.)
3. Show statistics (Antall logger fordelt på kategorier. Opplyser også om det er feilmeldinger/error.)
4. Save report (Lagrer rapporten til fil)
5. Sort logs by Source (Sorterer loggene alfabetisk)
6. Quit (welp.. quits)

### Hvordan kjøre programmet

For å kjøre programmet trenger du .NET installert på PC-en.

Last ned prosjektet fra GitHub og åpne prosjektmappen i VS Code.

Åpne terminalen i prosjektmappen og skriv:

_dotnet run_

Programmet leser automatisk loggene fra events.txt når det starter.

Vi møter en meny med de forskjellige funksjonene. Skriv in tallet for det du ønsker å gjøre, og trykk Enter.

Mulig å teste med andre logger, endre innholdet i events.txt.

VIKTIG: Formatet må følges: LEVEL|SOURCE|MESSAGE

Rapporten lagres som report.txt når du velger alternativ 4 i menyen (save report).
