CREATE TABLE  Comprador (
  `Cd_Pessoa` int(10) unsigned NOT NULL DEFAULT '0',
  `Chave` varchar(45) NOT NULL,  
  PRIMARY KEY (`Cd_Pessoa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE Comprador ADD 
      CONSTRAINT FK_CompradorPessoa
      FOREIGN    KEY (Cd_Pessoa)
      REFERENCES Pessoa (Cd_Pessoa);
