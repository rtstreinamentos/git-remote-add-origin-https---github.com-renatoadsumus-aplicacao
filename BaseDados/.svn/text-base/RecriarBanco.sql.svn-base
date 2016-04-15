USE ORCAMENTONET;

/*******************************************************************************/

Call Sp_Excluir_Dados_Banco();

DROP TABLE IF EXISTS Orcamento;
DROP TABLE IF EXISTS Pedido_Orcamento;
DROP TABLE IF EXISTS Comprador;
DROP TABLE IF EXISTS Fornecedor_Cidade;
DROP TABLE IF EXISTS Fornecedor_Categoria;
DROP TABLE IF EXISTS Fornecedor;
DROP TABLE IF EXISTS Pessoa;

/*******************************************************************************/
CREATE TABLE  Pessoa (
  `Cd_Pessoa` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Nm_Pessoa` varchar(100) NOT NULL,
  `Dt_Alteracao` datetime DEFAULT NULL,
  `Dt_Cadastro` datetime DEFAULT NULL,
  `CPF_CNPJ` varchar(14) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Telefone` varchar(15) NOT NULL,
  `Cd_Tipo_Pessoa` int(10) unsigned NOT NULL,
  `Cd_Cidade` int(10) unsigned NOT NULL,
  `Senha` varchar(45) NOT NULL,
  `Cd_Status` int(10) unsigned NOT NULL,
  `Endereco` varchar(100) NULL,
  `Bairro` varchar(30) NULL,
  `WebSite` varchar(100) NULL,
  `Dt_Ultimo_Acesso` datetime NULL,
  PRIMARY KEY (`Cd_Pessoa`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

CREATE UNIQUE INDEX IX_Pessoa_Email ON Pessoa (Email ASC);
/*******************************************************************************/

CREATE TABLE  Fornecedor (
  `Cd_Pessoa` int(10) unsigned NOT NULL DEFAULT '0',
  `Credito` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`Cd_Pessoa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE Fornecedor ADD 
      CONSTRAINT FK_FornecedorPessoa
      FOREIGN    KEY (Cd_Pessoa)
      REFERENCES Pessoa (Cd_Pessoa);

/*******************************************************************************/

CREATE TABLE  Comprador (
  `Cd_Pessoa` int(10) unsigned NOT NULL DEFAULT '0',
  `Chave` varchar(45) NOT NULL,   
  PRIMARY KEY (`Cd_Pessoa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE Comprador ADD 
      CONSTRAINT FK_CompradorPessoa
      FOREIGN    KEY (Cd_Pessoa)
      REFERENCES Pessoa (Cd_Pessoa);
	  
/*******************************************************************************/

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

/*******************************************************************************/

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
	  
/*******************************************************************************/

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
	  
/*******************************************************************************/

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
	  
/*******************************************************************************/