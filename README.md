# Pen&PapAR

Das Projekt Pen&PapAR wird in Unity programmiert. Das ganze Projekt ist in zwei Repos geteilt.
Dieses Repo enthält das GDD und die organisatorischen Dinge.
Die Implementierung der Datenbank und des Backends mit DjangoDB findet sich [hier](https://github.com/Sc1p1o/PenAndPapARDB)

---

## Inhaltsverzeichnis

1. [Mitarbeiter](#mitarbeiter)
2. [Projektziele](#projektziele)
3. [Technologien](#technologien)
4. [How To Start Up](#how-to-start-up)
5. [Verwendung](#how-to-start-up)
6. [Contribution Guidelines](#contribution-guidelines)
7. [Code Standards](#code-standards)
8. [Game Design Document](#game-design-document)

---

## Mitarbeiter

* Jannis Kerz (Deschnische Leidung)
* Martin Miller (Teamleidung, Issues)
* Nana Lenk (Design Leidung)
* Salem Zin (Deschnische Leidung, Merge Requests)

## Projektziele

Das Hauptziel von Pen&PapAR ist es, die traditionelle Nutzung von Papier-Charakterbögen in DND-Sessions durch digitale Lösungen zu ersetzen. Die spezifischen Ziele sind:

* Entwicklung einer AR-Anwendung zur Echtzeit-Anzeige und Bearbeitung von Charakterbögen.
* Integration von VR-Elementen für eine immersive Spielerfahrung.
* Bereitstellung einer benutzerfreundlichen Schnittstelle für schnelle und einfache Änderungen.

---

## Technologien

Das Projekt wurde mit folgenden Technologien entwickelt:

* **Unity3D**: Für die Entwicklung der VR- und AR-Umgebung.
* **ARKit und ARCore**: Für die AR-Funktionalität.
* **Blender**: Für die Erstellung von 3D-Modellen.
* **JSON**: Für die Datenverarbeitung von Charakterbögen.
* **GitHub**: Für die Versionskontrolle und Zusammenarbeit.
* **LaTeX**: Für die Dokumentation.

---

## How To Start Up

Mit der folgenden Anleitung unten startet man das Projekt auf der HoloLens und den Local Host auf einem PC.

[coming soon]

## Contribution Guidelines

Um das Zurechtfinden in den beiden Gits (GitHub und UVC) sicherzustellen, sind hier festgeschrieben, nach welchen
Bedingungen Contributor etwas beitragen können. Dazu gehören Commit Messages, Branch Namen und im weitesten Sinne auch
die im folgenden Punkt erklärten Coding Standards.

Bei Nichteinhaltung dieser Standards wird eine dringende Änderung erbeten und der Merge mit anderen Branches untersagt.

* Branch Namen sollten dem Muster `contributor_issue-number_feature` oder wenn mehrere am Branch arbeiten
  `contributor1_contributor2_issue-number_feature`, folgen
* Commits sind auf Englisch zu Verfassen
  * Commits sollen verständlich und nachvollziehbar sein
* MRs sind auf Deutsch zu verfassen
* Keine Commits und Pushes direkt auf den `master` Branch
  * Ausnahme: Protokolle, TOPS, Doku
* MRs erst Stellen, wenn Feature fertig zum mergen
* MRs sind stets von mindestens einer Person zu approven, die nicht an dem Branch gearbeitet hat

## Code Standards

Zusätzlich zu den eben besprochenen Contribution Guidelines ist es auch wichtig den Code einheitlich zu gestalten und
gewisse Standards und Conventions einzuhalten. Dazu sind hier jene besagten Standards und Conventions nochmals
niedergeschrieben.
Diese Coding Standards sind dringend einzuhalten und nur unter absoluten Ausnahmen zu brechen, wenn es nicht anders
geht.

Bei Nichteinhaltung wird eine Erklärung gefordert, sollte diese nicht ausreichend aufweisen, dass es notwendig war,
diese Standards zu ignorieren, wird die Merge Request abgelehnt bis die Standards wieder eingehalten werden.

### Unity Standards

| Objekt              | Schreibweise | Anmerkung                                                                                                |
| ------------------- | ------------ | -------------------------------------------------------------------------------------------------------- |
| lokale Varaiblen    | camelCase    | - Normal: Substantiv<br /> -Bool: Substantiv mit Verb als Präfix                                      |
| globale Variablen   | PascalCase   | - Normal: Substantiv<br /> - Bool: Substantiv mit Verb als PräfixVerb                                 |
| public Variablen    | PascalCase   | - Normal: Substantiv<br /> - Bool: Substantiv mit Verb als Präfix                                     |
| private Variablen   | _camelCase   | - Notation mit "_" als Präfix,<br />Normal mit Substantiv<br />- Bool: Substantiv mit Verb als Präfix  |
| protected Varaiblen | _camelCase   | - Notation mit "_" als Präfix,<br />Normal mit Substantiv<br />-Bool: Substantiv mit Verb als Präfix  |
| Enums               | PascalCase   | - Normal: Singular Substantiv<br />- Bitweise: Plural Substantiv                                       |
| Klassen             | PascalCase   |                                                                                                          |
| Interfaces          | IPascalCase  | - "I" als markierendes Präfix                                                                           |
| Methoden            | PascalCase   | - Beginnt mit einem Verb<br />- Bool Methoden als Frage                                                  |
| Zeilenumbruch       | Allmann      | - Standard zum setzen von Klammern bei Funktionen, Klassen, Interfaces, Enums, etc                      |

### Weitere Coding Standards

* Maximal 3 Einrückungen
* Maximal 50 Zeilen pro Funktion
* Trennung zwischen Nebenläufigen und nicht nebenläufigen Funktionen/Klassen
* Klassen nicht mit allgemeinen Methoden füllen
* Code möglichst Modular halten
* simple as possible
* Funktions und Variablen Namen sollten erklärend sein
  * Namen wie `d`, `i` und Abkürzungen sind mathematischen Funktionen und Loops vorenthalten
* Vermeidung von Resonanzen
* Abfangen von Errors
* auf Lesbarkeit achten

### Bsp Code

```C#
public float GlobalVaraible;
public bool IsBoolean = true;

public class ExampleClass : MonoBehavior
{
    public bool IsFirstTry = False;
    public string SleepState = "Nein";
  
    private bool _isOnline;
    private int _yawnCounter = 100;
  
    public void DoSomething()
    {
        bool isLocaleVaraible = true;
        float Something = 3.41;
    }
}

public enum NormalEnum
{
    EnumType1,
    EnumType2
}

public enum BitwiseEnum
{
    None = 0,
    Action = 1,
    AnotherAction = 2,
    DifferentAction = 4,
  
    ActionAndDifferentAction = Action | DifferentAction // = 3
}

public interface ISleepless
{
    void Sleep();
}
```

## Game Design Document

Das vollständige Game Design Document (GDD) für Pen&PapAR kann [hier](out\PenAndPapAR.pdf) eingesehen werden.