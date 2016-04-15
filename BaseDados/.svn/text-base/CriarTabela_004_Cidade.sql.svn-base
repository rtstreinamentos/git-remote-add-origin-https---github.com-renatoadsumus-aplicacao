CREATE TABLE  Cidade (
	`Cd_Cidade` int(10) unsigned NOT NULL AUTO_INCREMENT,
	`Cd_Estado` int(10) unsigned NOT NULL,
	`Nm_Cidade` varchar(45) NOT NULL,
  PRIMARY KEY (`Cd_Cidade`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

ALTER TABLE Cidade ADD 
      CONSTRAINT FK_Estado
      FOREIGN    KEY (Cd_Estado)
      REFERENCES Estado(Cd_Estado);
