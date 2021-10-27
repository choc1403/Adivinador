DROP DATABASE IF EXISTS bdAdivinador;

CREATE DATABASE IF NOT EXISTS bdAdivinador;

USE bdAdivinador;

CREATE TABLE IF NOT EXISTS PreguntasPredeterminadas(
    idPregunta INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
    pregunta TEXT,    
    nodoIzquierdo INT UNSIGNED,
    nodoDerecho INT UNSIGNED,
    fecha_creacion DATETIME DEFAULT CURRENT_TIMESTAMP

);

DESC PreguntasPredeterminadas;


