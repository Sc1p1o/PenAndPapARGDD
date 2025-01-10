# Protokoll vom 10.01.2025

## Formalia:
**Protokollant:** Martin

**Start:** 13:30

**Ende:** 16:30

**Wo ist die HoloLens?:** Martin

### Anwesenheit:
Anwesenheit, bzw entschuldigte nicht Anwesenheit:
* [x]  Jannis
* [x]  Martin
* [ ]  Nana, entschuldigt
* [x]  Salem

### Festlegung des nächsten Meetings
Ort: Z524/TRL304

Datum: 13.01.2025

Zeit: 13:45

* [ ] Raum gebucht?
  * nicht möglich

Abmeldungen für nächstes Meeting:
*  keine Abmeldung

## Stand der Aufgaben von letztem Meeting

### Jannis:
* [x] How To Unity

### Martin:
* [x] Templates erstellen
  * [x] Protokoll Template
  * [x] Tops-Template
  * [x] Issue Template

### Nana:
* [x] beginn Umsetzung Design Thinking

### Salem:
* [x] MR Template
  * Muss noch ins deutsche Übersetzt werden, ansonsten fertig

## TOPS

* Was ist mit Einstellungen gemeint
  * Einstellungen waren, spiel setting options, e.g: zählt Gold mit rein

### Design Thinking
 - Nana arbeitet dran
   - Jannis meinte sieht bisher gut aus
   - wir warten gespannt auf Montag (Kein Druck)

### Vorstellung Templates
* TOPS haben 2 Vorschlag Templates,
  * Jannis präferiert Template 2, weil Martin dann nicht so böse auf ihn ist
  * Template 2 ist angenommen, einstimmig
  
#### Issue Templates
* bug und feature template sind erstellt
  * Martin schreibt bestehende Issues um (bis Montag)
  
#### Contribution Guidelines
* Branch Naming: [username]_[issue_nr]_[function]
* commit messages in english und verständlich
* MR erst senden wenn fertig, wenn vorher gezeigt, [DRAFT] davor schreiben
* Name Conventions:
  * Klassen: PascalCase
  * Funktionen: PascalCase
  * Variablen: camelCase
* Zeilenumbrüche:


    function(){
      doSomething();
    }

* Zeichenlänge pro Zeile: 80
* maximal 3 Einrückungen
* Modularität von Funktionen → möglichst wenig Abhängigkeiten
* Trennung zwischen Nebenläufigen und nicht nebenläufigen Funktionen/Klassen
* nur das in Klassen packen, was nur zur Klasse gehört
* Code sollte getestet werden

_Meeting pausiert von 14:23 bis 14:42_

### Unity How To
* Jannis hat mehrere Tutorials eingesendet und ein paar Übungsaufgaben für den Einstieg erstellt
* Ordnerstruktur:
  * einzelne Ordner für Scene, Scripts, Animation, Material etc
  * Beispiel Struktur Vogel:


    Scenes/    
      Assets/
        Bird/
          Scripts/
          Animation/
          Material/
          Prefabs/
          Audio/
          .../

#### Unity Hausaufgaben
* erstellt eine PLatte und eine Kugel (bis 17.01)
  * Kugel soll auf Platte bouncen
  * Platte bewegt sich mit Mauszeiger
  * Theoretisch nur 1-2 Skripts


#### Clean Code Guidelines
* simple as possible
* sollte gut lesbar sein
* Vermeidung unnötiger Kommentare
* einfach modifizierbarer
* sollte möglichst Bug frei sein
  * "wir haben keine Bugs, wir haben surprise Features" - Martin
* Naming sollte logisch Funktion sein 
* Vermeidung von Resonanzen
* Abfangen von Errors

### weitere Themen

#### Meeting Issue, als Zeitnachweis
* Martin meint, nicht notwendig, da Anwesenheit im Protokoll vermerkt ist

#### Inhalte der README.md
* Contributors
* Contribution Guidelines
* Code Standard
* Verlinkung zum GDD
* How To Start Up
* Goal

## Konklusion

### Aufgaben bis nächstes Meeting
Folgende Aufgaben sind zu erledigen bis zur Nächsten Sitzung

#### Jannis
* neue Issues erstellen
  * Hausaufgaben issue
  * README

#### Martin
* Issue Template auf Deutsch Übersetzen
* MR Discord Channel erstellen
* beginn README erstellen
* alte Issues an Template umschreiben
* neues TOPS und Protokoll vorbereiten

#### Nana
* Fertigstellung Design Thinking vorschläge [13.01.2025]

#### Salem
* MR Template auf Deutsch Übersetzen


### Weitere Aufgaben:
Folgende Aufgaben sind zu machen bis zu einem anderen Datum als dem nächsten Meeting.

Struktur:
* Aufgabe (Co-Worker) [Due-Date]

#### Jannis:
* Player Menü (mit Martin)

#### Martin:
* Player Menü (mit Jannis)
* GDD aktuell halten
* Hausaufgaben [bis 17.01]

#### Nana:
* Inventar
* Hausaufgaben [bis 17.01]

#### Salem:
* Fast Item Bar
* Notes
* Hausaufgaben [bis 17.01]

#### Nicht zugewiesen
* Einstellungen
* Actions HUD