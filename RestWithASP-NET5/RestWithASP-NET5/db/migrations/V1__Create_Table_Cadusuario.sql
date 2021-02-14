CREATE TABLE IF NOT EXISTS `cadusuario` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) NOT NULL,
  `SobreNome` varchar(50) NOT NULL,
  `Endereco` varchar(50) DEFAULT NULL,
  `Genero` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;