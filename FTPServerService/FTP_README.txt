1. FileZilla Server herunterladen: https://filezilla-project.org/ => mit Port 14147 installieren
	Host: localhost
	port: 14147
		=> connect
		
2. FileZilla Server -> Edit -> Users:
	General -> Add:
		- Add user account: "ieg1"
		- password: "ieg1"
	Shared folders: einen Lokalen Ordner erstellen => unter Files alle Berechtigungen anhaken

3. Mit FileZilla Client die Verbindung testen: 
	Host: localhost
	Username: ieg1
	Password: ieg1
	Port: 21 (FTP-Port)
	
4. In den lokalen Ordner das JSON-File (productlist_json.json) kopieren 

5. In Fiddle GET: http://localhost:7826/api/FTPReadout/