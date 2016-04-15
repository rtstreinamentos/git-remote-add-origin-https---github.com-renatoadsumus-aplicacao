CREATE TABLE  Fornecedor (
  `Cd_Pessoa` int(10) unsigned NOT NULL DEFAULT '0',
  `Credito` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`Cd_Pessoa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE Fornecedor ADD 
      CONSTRAINT FK_FornecedorPessoa
      FOREIGN    KEY (Cd_Pessoa)
      REFERENCES Pessoa (Cd_Pessoa);
