CREATE TABLE IF NOT EXISTS `livros` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Author` varchar(50) NOT NULL,
  `Data_Cadastro` datetime NOT NULL,
  `Preco` decimal(10,2) NOT NULL,
  `Titulo` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;