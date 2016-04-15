CREATE TABLE  Fornecedor_Cidade (
  `Cd_Pessoa` int(10) unsigned NOT NULL,
  `Cd_Cidade` int(10) unsigned NOT NULL,
  PRIMARY KEY (`Cd_Pessoa`,`Cd_Cidade`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE Fornecedor_Cidade ADD 
      CONSTRAINT FK_FornecedorCidade_Cidade
      FOREIGN    KEY (Cd_Cidade)
      REFERENCES Cidade(Cd_Cidade);

ALTER TABLE Fornecedor_Cidade ADD 
      CONSTRAINT FK_FornecedorCidade_Fornecedor
      FOREIGN    KEY (Cd_Pessoa)
      REFERENCES Fornecedor(Cd_Pessoa);