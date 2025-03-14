USE GestionaleMunicipale;

INSERT INTO Anagrafiche (IdAnagrafica, Cognome, Nome, Indirizzo, Citta, CAP, CF) VALUES
(NEWID(), 'Rossi', 'Mario', 'Via Roma 10', 'Milano', '20121', 'RSSMRA80A01F205Z'),
(NEWID(), 'Bianchi', 'Luca', 'Via Milano 20', 'Roma', '00100', 'BNCGLC85T20H501D'),
(NEWID(), 'Verdi', 'Anna', 'Corso Italia 15', 'Napoli', '80100', 'VRDNNA75A41L833D'),
(NEWID(), 'Gialli', 'Elena', 'Piazza Duomo 1', 'Firenze', '50122', 'GLLLNE88E45H501G'),
(NEWID(), 'Neri', 'Paolo', 'Viale dei Mille 5', 'Torino', '10100', 'NRIPLA78R11F205T'),
(NEWID(), 'Esposito', 'Giuseppe', 'Via Stazione 3', 'Bologna', '40121', 'ESPGLS80T10L833E'),
(NEWID(), 'Ricci', 'Marco', 'Piazza San Marco 7', 'Venezia', '30100', 'RCCMRC85A11H501C'),
(NEWID(), 'Ferrari', 'Chiara', 'Via Verdi 12', 'Genova', '16100', 'FRRCHR90T30L833V'),
(NEWID(), 'Conti', 'Roberto', 'Via Garibaldi 22', 'Bari', '70100', 'CNTMRC92T20F205R'),
(NEWID(), 'Colombo', 'Serena', 'Piazza della Repubblica 5', 'Palermo', '90100', 'CLBSRN88A10H501P'),
(NEWID(), 'Marini', 'Andrea', 'Via Vittorio Veneto 18', 'Catania', '95100', 'MRNADR85A11L833C'),
(NEWID(), 'Mancini', 'Silvia', 'Corso Garibaldi 25', 'Verona', '37100', 'MNCSLV77R30F205T'),
(NEWID(), 'Moretti', 'Davide', 'Via Dante Alighieri 6', 'Messina', '98100', 'MRTDVD83T10H501M'),
(NEWID(), 'Barbieri', 'Laura', 'Via Napoli 4', 'Trieste', '34100', 'BRBLRA92A30L833B'),
(NEWID(), 'Rizzo', 'Simone', 'Piazza San Giovanni 10', 'Reggio Calabria', '89100', 'RZZSMN87T20F205R'),
(NEWID(), 'Lombardi', 'Francesca', 'Via Sicilia 9', 'Ancona', '60100', 'LMBFNC81A11H501L'),
(NEWID(), 'Costa', 'Alessandro', 'Via delle Rose 3', 'Perugia', '06100', 'CSTALS78T10L833A'),
(NEWID(), 'Giordano', 'Martina', 'Corso Umberto 2', 'Aosta', '11100', 'GRDMTN88R30F205G'),
(NEWID(), 'Fontana', 'Stefano', 'Viale Trento 8', 'Potenza', '85100', 'FNTSTF85A11L833F'),
(NEWID(), 'Caruso', 'Valeria', 'Via Palermo 15', 'Campobasso', '86100', 'CRSVLR80T10H501C');

INSERT INTO TipiViolazioni (IdViolazione, Descrizione) VALUES
(NEWID(), 'Eccesso di velocità'),
(NEWID(), 'Passaggio con il rosso'),
(NEWID(), 'Sosta vietata'),
(NEWID(), 'Guida senza cintura'),
(NEWID(), 'Utilizzo del cellulare alla guida'),
(NEWID(), 'Mancato rispetto precedenza'),
(NEWID(), 'Sorpasso vietato'),
(NEWID(), 'Guida in stato di ebbrezza'),
(NEWID(), 'Mancata revisione del veicolo'),
(NEWID(), 'Guida senza patente'),
(NEWID(), 'Fermata non consentita'),
(NEWID(), 'Mancata assicurazione RC'),
(NEWID(), 'Mancato uso casco'),
(NEWID(), 'Mancata segnalazione svolta'),
(NEWID(), 'Veicolo in divieto di circolazione'),
(NEWID(), 'Mancato rispetto distanza di sicurezza'),
(NEWID(), 'Trasporto carico non conforme'),
(NEWID(), 'Guida pericolosa'),
(NEWID(), 'Eccesso di rumorosità'),
(NEWID(), 'Emissioni inquinanti oltre i limiti');

--Aiutato con ChatGPT, volevo che gli elementi dentro la tabella fossero il più omogenei e casuali possibili e che non fossero troppi

INSERT INTO Verbali (IdVerbale, IdAnagrafica, DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo)
SELECT
    NEWID(),
    IdAnagrafica,
    DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 30, '2025-03-01'),
    'Via ' + LEFT(NEWID(), 8),
    'Agente ' + LEFT(NEWID(), 6),
    DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 5, '2025-03-02'),
    100 + (ABS(CHECKSUM(NEWID())) % 500)
FROM Anagrafiche
ORDER BY NEWID()
OFFSET 0 ROWS FETCH NEXT 20 ROWS ONLY;

WITH RankedData AS (
    SELECT 
        v.IdVerbale, 
        tv.IdViolazione, 
        1 + (ABS(CHECKSUM(NEWID())) % 10) AS DecurtamentoPunti,
        ROW_NUMBER() OVER (ORDER BY NEWID()) AS RowNum
    FROM 
        (SELECT TOP 20 IdVerbale FROM Verbali ORDER BY NEWID()) v
    JOIN 
        (SELECT TOP 20 IdViolazione FROM TipiViolazioni ORDER BY NEWID()) tv
    ON v.IdVerbale = v.IdVerbale
)
INSERT INTO VerbaliViolazioni (IdVerbale, IdViolazione, DecurtamentoPunti)
SELECT IdVerbale, IdViolazione, DecurtamentoPunti
FROM RankedData
WHERE RowNum <= 20;


