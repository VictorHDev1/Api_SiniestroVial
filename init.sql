CREATE DATABASE SiniestrosVialesBD;
GO

USE SiniestrosVialesBD;
GO

CREATE TABLE dbo.Siniestros (
    Id BIGINT IDENTITY(1,1) PRIMARY KEY,
    FechaHora DATETIME2 NOT NULL,
    Departamento NVARCHAR(100),
    Ciudad NVARCHAR(100),
    Tipo INT,
    NumeroVictimas INT,
    Descripcion NVARCHAR(500)
);
GO

CREATE NONCLUSTERED INDEX IX_Siniestros_Departamento_FechaHora
ON dbo.Siniestros (Departamento, FechaHora)
INCLUDE (Ciudad, Tipo, NumeroVictimas, Descripcion);
GO

CREATE TABLE dbo.Vehiculos (
    Id BIGINT IDENTITY(1,1) PRIMARY KEY,
    SiniestroId BIGINT FOREIGN KEY REFERENCES Siniestros(Id),
    Tipo NVARCHAR(50),
    Placa NVARCHAR(20)
);
GO
