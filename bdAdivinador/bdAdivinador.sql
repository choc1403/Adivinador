DROP DATABASE IF EXISTS bdAdivinador;

CREATE DATABASE IF NOT EXISTS bdAdivinador;

USE bdAdivinador;

CREATE TABLE IF NOT EXISTS PreguntasPredeterminadas(
    idPregunta INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
    pregunta TEXT,    
    nodoIzquierdo VARCHAR(25)  DEFAULT 'izq',
    nodoDerecho VARCHAR(25)  DEFAULT 'der',
    fecha_creacion DATETIME DEFAULT CURRENT_TIMESTAMP

);

INSERT INTO PreguntasPredeterminadas(pregunta)
    VALUES('LADRA');

INSERT INTO PreguntasPredeterminadas(pregunta)
    VALUES('PERRO');

INSERT INTO PreguntasPredeterminadas(pregunta)
    VALUES('Dice miu');

INSERT INTO PreguntasPredeterminadas(pregunta)
    VALUES('Gato');


DESC PreguntasPredeterminadas;


