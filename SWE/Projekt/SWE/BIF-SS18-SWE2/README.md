BIF/SWE 2 PicDB
===============

C# Template für das Übungsbeispiel "PicDB". Damit die Übung erfolgreich abgegeben werden kann müssen folgende Kriterien erfüllt sein:

* Die Solution muss BIF-SWE2.sln heißen
* JEDE/R in der Gruppe muss in SEIN Repository hochladen (git push)

Benutzen Sie bitte die Vorlage. Sie ist so vorbereitet, dass sie am Jenkins verwendet werden kann.

Diese Vorlage wurde für Visual Studio 2013 erstellt. Sie können aber jede andere Entwicklungsumgebung benutzen, solange BIF-SWE1.sln am Jenkins kompilierbar bleibt.

Repository
----------
https://inf-swe-git.technikum-wien.at/

Das Repository ist selbst anzulegen: 

* my dashboard 
* owned 
* new repository 
* if00x000/BIF-SS??-SWE2

Das Repository hat die URL: https://if00x000@inf-swe-git.technikum-wien.at/?r=~if00x000/BIF-SS??-SWE2.git

* if00x000 ist durch Ihre uid-Nummer zu ersetzen
* BIF-SS??-SWE2 durch das Jahr (SS 2015 -> BIF-SS15-SWE2)

Setup des Projektes
-------------------
https://inf-swe-git.technikum-wien.at/summary/?r=BIF/SWE2-CS.git

Clonen Sie das Template in ein Verzeichnis Ihrer Wahl und ändern Sie anschließend den remote/origin auf Ihr Repository
	
	git clone https://inf-swe-git.technikum-wien.at/r/BIF/SWE2-CS.git
	cd SWE2-CS
	git remote set-url origin https://if00x000@inf-swe-git.technikum-wien.at/r/~if00x000/BIF-SS??-SWE2.git
    git push origin master

Ihr KollegeInn klonen dann Ihr Repository.

Implementierung
---------------
Im Verzeichnis "Übungen" finden Sie für jede Abgabe eine Implementierung des jeweiligen Übungsinterface. Die Dokumentation finden Sie an dem Interface selbst.

Es spielt keine Rolle, wie die Abgabe-Klassen heisen oder in welchem Namespace sie liegen. Die Unit-Tests suchen nach genau einer Klasse, die das jeweilige Übungsinterface implementiert.

Ihre eigenen Klassen, die Sie im Rahmen der Übung implementieren, müssen ebenfalls bestimmte Interfaces implementieren. Diese leiten sich von den Übungsinterfaces bzw. den Unit-Tests ab.

Unit-Tests
----------
https://inf-swe-git.technikum-wien.at/tree/?f=BIF-SWE1/CS&r=SYSTEM/unit-tests.git&h=master

Am Jenkins wird Ihre Abgabe mit diesen Unit-Tests getestet. Diese Tests stehen Ihnen zur Verfügung. Sie können daher lokal, vorab überprüfen, ob Sie die Unit-Tests bestehen oder nicht.

In diesem Projekt ist auch dokumentiert, welche Interfaces Ihre Klassen implementieren müssen um die Unit-Tests zu bestehen.

## Setup der Tests in Visual Studio

Die Tests müssen im `deploy` Ordner ausgeführt werden. Um den Visual Studio Test Runner zu konfigurieren, muss eine Datei `.runsettings` (z.B. `my.runsettings`) zum eigenen Projekt hinzugefügt werden (nicht zum Unit Test Projekt!):

    <?xml version="1.0" encoding="utf-8" ?>
    <RunSettings>
      <TestRunParameters>
        <Parameter name="targetpath" value="path\to\your\deploy\folder" />
      </TestRunParameters>
    </RunSettings>

In Visual Studio wird dann diese Datei als "Test Settings" ausgewählt.


Jenkins
-------
https://inf-swe-jenkins.technikum-wien.at/view/BIF-SWE2/

Am Jenkins können Sie dann das Ergebnis Ihrer Abgabe sehen.

* Build aus dem Build-Verlauf auswählen
* Testergebnisse
* Konsolenausgabe

Sie dürfen so oft Sie möchten abgeben. Zu einem definierten Zeitpunkt (siehe Moodle) werden die Ergebnisse eingesammelt und ausgewertet. 
Am Ende der LV müssen alle Unit-Tests erfolgreich sein, mind. jedoch 50%. Zwischenergebnisse zählen nicht mehr. Die Anzahl der erfolgreich bestandenen Unit-Tests fließt in die Bewertung der Übung ein.