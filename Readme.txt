************************************************************************
* OpenSimWatcher - Project-Start 2011-11
*
* (c)Pixel Tomsen (Christian Kurzhals) pixel.tomsen[at]gridnet.info
* https://github.com/PixelTomsen/OpenSimWatch
* 
This program monitors opensim region server and restarts (windows-host's).

current methods:
- Test of the process to be present
- Test using http-check, if this fails, the process terminates

Note:
- In regions with lots of prims and scripts http the interval is not set too low, because it takes some time until the region
  is online!
 
  
***************************************************************************************************************************** 
German:
  
dieses programm überwacht opensim region-server und startet sie neu (windows-host's).

derzeitige methoden : 
- test auf vorhanden sein des prozesses
- test mittels http-check, wenn dieser fehlschlägt, wird der prozess beendet

Hinweis:
- bei regionen mit vielen prims und scripts das http-intervall nicht zu niedrig setzen, denn es dauert einige zeit, bis die region
 online ist!