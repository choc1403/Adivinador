INSERT INTO PreguntasPredeterminadas(idPregunta, pregunta,nodoPadre, nodoIzquierdo, nodoDerecho) 
    VALUES(1,'ES UNA AVE?',0,2,3),
          (2,'ES UN ACUATICO?',1,4,5),
          (4,'ES UN MAMIFERO?',2,6,7),
          (6,'ES UN REPTIL?',4,8,9),
          (8,'ES UN ANFIBIO',6,0,10);

INSERT INTO PreguntasPredeterminadas(idPregunta, pregunta, nodoPadre,nodoDerecho)
    VALUES(5,'TIENE TENTACULOS?',2,11);

INSERT INTO Acuaticos(idPregunta, nombre)
    VALUES(5,'PULPO');

INSERT INTO PreguntasPredeterminadas(idPregunta, pregunta,nodoPadre,nodoDerecho)
    VALUES(7,'Su animal es el personaje principal de la serie animada de Bojack Horseman?',4,12);

INSERT INTO Mamiferos(idPregunta, nombre)
    VALUES(7,'CABALLO');

INSERT INTO PreguntasPredeterminadas(idPregunta, pregunta,nodoPadre,nodoDerecho)
    VALUES(3,'PUEDE HABLAR?',1,13);

INSERT INTO Aves(idPregunta, nombre)
    VALUES(3, 'LORO');

INSERT INTO PreguntasPredeterminadas(idPregunta, pregunta, nodoPadre, nodoDerecho)
    VALUES(9,'Posee un caparazon',6,14);

INSERT INTO Reptiles(idPregunta, nombre)
    VALUES(9,'TORTUGA');

INSERT INTO PreguntasPredeterminadas(idPregunta,pregunta,nodoPadre,nodoDerecho)
    VALUES(10,'En una pelicula, su animal fue besado por una princesa?',8,15);

INSERT INTO Anfibios(idPregunta, nombre)
    VALUES(10, 'RANA');

SELECT * FROM PreguntasPredeterminadas;
SELECT * FROM Acuaticos;
SELECT * FROM Mamiferos;
SELECT * FROM Aves;
SELECT * FROM Reptiles;
SELECT * FROM Anfibios;