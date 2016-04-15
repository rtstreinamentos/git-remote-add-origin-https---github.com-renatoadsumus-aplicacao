CREATE TABLE  Pedido_Orcamento (
  `Cd_Pedido_Orcamento` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Cd_Pessoa` int(10) unsigned NOT NULL,
  `Observacao` varchar(1000) DEFAULT NULL,
  `Dt_Cadastro` datetime DEFAULT NULL,
  `Status` int(10) unsigned NOT NULL,
  `Cd_Categoria` int(10) unsigned NOT NULL,
  `Titulo` varchar(100) DEFAULT NULL,
  `Cd_Cidade` int(10) unsigned NOT NULL,
  PRIMARY KEY (`Cd_Pedido_Orcamento`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

ALTER TABLE Pedido_Orcamento ADD 
      CONSTRAINT FK_PedidoOrcamento_Categoria
      FOREIGN    KEY (Cd_Categoria)
      REFERENCES Categoria(Cd_Categoria);

ALTER TABLE Pedido_Orcamento ADD 
      CONSTRAINT FK_PedidoOrcamento_Cidade
      FOREIGN    KEY (Cd_Cidade)
      REFERENCES Cidade(Cd_Cidade);