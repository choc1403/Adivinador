UPDATE PreguntasPredeterminadas 
    SET nodoDerecho = 2 
    WHERE idPregunta = 1;

UPDATE PreguntasPredeterminadas 
    SET nodoIzquierdo = 3 
    WHERE idPregunta = 1;

UPDATE PreguntasPredeterminadas 
    SET nodoDerecho = 4 
    WHERE idPregunta = 3;