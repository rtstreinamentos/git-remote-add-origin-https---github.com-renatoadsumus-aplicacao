CREATE TABLE  Fornecedor_Categoria (
  `Cd_Categoria` int(10) unsigned NOT NULL,
  `Cd_Pessoa` int(10) unsigned NOT NULL,
  PRIMARY KEY (`Cd_Categoria`,`Cd_Pessoa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE Fornecedor_Categoria ADD 
      CONSTRAINT FK_FornecedorCategoria_Categoria
      FOREIGN    KEY (Cd_Categoria)
      REFERENCES Categoria(Cd_Categoria);

ALTER TABLE Fornecedor_Categoria ADD 
      CONSTRAINT FK_FornecedorCategoria_Fornecedor
      FOREIGN    KEY (Cd_Pessoa)
      REFERENCES Fornecedor(Cd_Pessoa);