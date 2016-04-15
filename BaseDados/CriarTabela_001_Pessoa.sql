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
  `Bairro` varchar(100) NULL,
  `WebSite` varchar(100) NULL,
  `Dt_Ultimo_Acesso` datetime NULL,
  PRIMARY KEY (`Cd_Pessoa`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

CREATE UNIQUE INDEX IX_Pessoa_Email ON Pessoa (Email ASC);