CREATE DATABASE IF NOT EXISTS `inmobiliaria`;

USE `inmobiliaria`;

CREATE TABLE `Inquilinos` (
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `DNI` INT NOT NULL,
    `Nombre` VARCHAR(100) NOT NULL,
    `Apellido` VARCHAR(100) NOT NULL,
    `Email` VARCHAR(100) NOT NULL,
    `Telefono` BIGINT NOT NULL
);

CREATE TABLE `Propietarios` (
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `DNI` INT NOT NULL,
    `Nombre` VARCHAR(100) NOT NULL,
    `Apellido` VARCHAR(100) NOT NULL,
    `Email` VARCHAR(100) NOT NULL,
    `Telefono` BIGINT NOT NULL
);

CREATE TABLE `Users` (
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Username` VARCHAR(100) NOT NULL,
    `Password` VARCHAR(100) NOT NULL,
    `Rol` VARCHAR(50) NOT NULL
);

CREATE TABLE `Inmuebles` (
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `PropietarioId` INT NOT NULL,
    `Direccion` VARCHAR(255) NOT NULL,
    `Uso` INT NOT NULL,
    `Tipo` INT NOT NULL,
    `NoAmbientes` INT NOT NULL,
    `Latitud` DOUBLE NOT NULL,
    `Longitud` DOUBLE NOT NULL,
    `Precio` VARCHAR(50) NOT NULL,
    `Disponibilidad` INT NOT NULL,
    FOREIGN KEY (`PropietarioId`) REFERENCES `Propietarios` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Contratos` (
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Desde` DATE NOT NULL,
    `Hasta` DATE NOT NULL,
    `InquilinoId` INT NOT NULL,
    `InmuebleId` INT NOT NULL,
    FOREIGN KEY (`InmuebleId`) REFERENCES `Inmuebles` (`Id`) ON DELETE CASCADE,
    FOREIGN KEY (`InquilinoId`) REFERENCES `Inquilinos` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Pagos` (
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `NoPago` INT NOT NULL,
    `Fecha` DATE NOT NULL,
    `Importe` DECIMAL(10, 2) NOT NULL,
    `ContratoId` INT NOT NULL,
    `InquilinoId` INT NOT NULL,
    FOREIGN KEY (`ContratoId`) REFERENCES `Contratos` (`Id`) ON DELETE CASCADE,
    FOREIGN KEY (`InquilinoId`) REFERENCES `Inquilinos` (`Id`) ON DELETE CASCADE
);

CREATE INDEX `IX_Contratos_InmuebleId` ON `Contratos` (`InmuebleId`);

CREATE INDEX `IX_Contratos_InquilinoId` ON `Contratos` (`InquilinoId`);

CREATE INDEX `IX_Inmuebles_PropietarioId` ON `Inmuebles` (`PropietarioId`);

CREATE INDEX `IX_Pagos_ContratoId` ON `Pagos` (`ContratoId`);

CREATE INDEX `IX_Pagos_InquilinoId` ON `Pagos` (`InquilinoId`);


-- DROP DATABASE if EXISTS `inmobiliaria`;