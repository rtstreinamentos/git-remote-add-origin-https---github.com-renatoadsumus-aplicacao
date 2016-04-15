CREATE TABLE  Orcamento (
  `Cd_Orcamento` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Cd_Fornecedor` int(10) unsigned NOT NULL,
  `Cd_Pedido_Orcamento` int(10) unsigned NOT NULL,
  `Dt_Cadastro` datetime NOT NULL,
  `Observacao` varchar(1000) DEFAULT NULL,
  `Valor` double NOT NULL,
  `Validade` datetime NOT NULL,
  PRIMARY KEY (`Cd_Orcamento`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

ALTER TABLE Orcamento ADD 
      CONSTRAINT FK_Orcamento_PedidoOrcamento
      FOREIGN    KEY (Cd_Pedido_Orcamento)
      REFERENCES Pedido_Orcamento(Cd_Pedido_Orcamento);
	  
ALTER TABLE Orcamento ADD 
      CONSTRAINT FK_Orcamento_Fornecedor
      FOREIGN    KEY (Cd_Fornecedor)
      REFERENCES Fornecedor(Cd_Pessoa);	  
