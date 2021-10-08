DROP DATABASE IF EXISTS bdAdivinador;

CREATE DATABASE IF NOT EXISTS bdAdivinador;

USE bdAdivinador;

CREATE TABLE IF NOT EXISTS PreguntasPredeterminadas(
    idPregunta INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
    pregunta TEXT NOT NULL,
    nodoPadre INT UNSIGNED,
    nodoIzquierdo INT UNSIGNED,
    nodoDerecho INT UNSIGNED,
    fecha_creacion DATETIME DEFAULT CURRENT_TIMESTAMP

);

CREATE TABLE IF NOT EXISTS Aves(
    idAve INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
    idPregunta INT UNSIGNED NOT NULL,
    nombre VARCHAR(50) NOT NULL UNIQUE,

    FOREIGN KEY (idPregunta) REFERENCES PreguntasPredeterminadas(idPregunta) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Acuaticos(
    idAcuatico INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
    idPregunta INT UNSIGNED NOT NULL,
    nombre VARCHAR(50) NOT NULL UNIQUE,

    FOREIGN KEY (idPregunta) REFERENCES PreguntasPredeterminadas(idPregunta) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Mamiferos(
    idMamifero INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
    idPregunta INT UNSIGNED NOT NULL,
    nombre VARCHAR(50) NOT NULL UNIQUE,

    FOREIGN KEY (idPregunta) REFERENCES PreguntasPredeterminadas(idPregunta) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Reptiles(
    idReptil INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
    idPregunta INT UNSIGNED NOT NULL,
    nombre VARCHAR(50) NOT NULL UNIQUE,

    FOREIGN KEY (idPregunta) REFERENCES PreguntasPredeterminadas(idPregunta) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Anfibios(
    idAnfibio INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
    idPregunta INT UNSIGNED NOT NULL,
    nombre VARCHAR(50) NOT NULL UNIQUE,

    FOREIGN KEY (idPregunta) REFERENCES PreguntasPredeterminadas(idPregunta) ON DELETE CASCADE
);


DESC PreguntasPredeterminadas;
DESC Aves;
DESC Acuaticos;
DESC Mamiferos;
DESC Reptiles;
DESC Anfibios;

