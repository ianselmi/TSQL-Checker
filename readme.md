Progetto liberamente preso da :https://github.com/davebally/TSQL-Smells
<br>
con l'aggiunta dei seguenti controlli:<br>
* RaiseErrorProcessor

Path di installazione:<br>
* **VS2017** - %ProgramFiles(x86)%\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\Extensions\Microsoft\SQLDB\DAC<br>
  * *SQL2016* -> cartella 150

 <br>Debugging
Utilizzare due istanze di vs una che contiene il dbproject e l'altra il codice. Quella con il dbproject andrà chiusa e riaperta ad ogni compilazione.<br>
Per debuggare "Attach to process" sul processo che contiene il dbproject, poi in questo progetto tasto destro sul progetto e premere la voce **Run code analysis**