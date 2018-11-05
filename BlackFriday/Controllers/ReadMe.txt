1.  Neue Funktion in PaymentmethodsContrller erstellt.
2.  die IEGEasyCreditCardService ist 3 mal Publiziert.
3.  Retrylogic mit Fallback Methoden von Polly aufgerufen.

4.  Tests die erfolgreich sein müssen (Fiddler):
	im Code zuerst wird die 2 erste Url falsch gegeben dann funktioniert nur das 3. man kann mehr mals änderen und testen.
    http://localhost:55983/api/PaymentMethods     --> liefert die Paymentmethods wenn das Service erreichbar ist.
    http://localhost:55983/api/PaymentMethods   --> liefert die Rückmeldung für später noch ein Mal versuchen wenn das Service nicht erreichbar ist.
	sieht man in Fiddler http Code 502 für erste 2 Services
	und 200 für das letzte service
    