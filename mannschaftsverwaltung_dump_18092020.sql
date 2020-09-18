-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Erstellungszeit: 18. Sep 2020 um 12:14
-- Server-Version: 10.1.37-MariaDB
-- PHP-Version: 7.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `mannschaftsverwaltung`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `fussballspieler`
--

CREATE TABLE `fussballspieler` (
  `id` int(11) NOT NULL,
  `person_id` int(11) NOT NULL,
  `position` text NOT NULL,
  `tore` int(11) NOT NULL,
  `anzahlJahre` int(11) NOT NULL DEFAULT '0',
  `gewonneneSpiele` int(11) NOT NULL DEFAULT '0',
  `anzahlVereine` int(11) NOT NULL DEFAULT '0',
  `anzahlSpiele` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `fussballspieler`
--

INSERT INTO `fussballspieler` (`id`, `person_id`, `position`, `tore`, `anzahlJahre`, `gewonneneSpiele`, `anzahlVereine`, `anzahlSpiele`) VALUES
(21, 44195, '6', 6, 6, 6, 6, 6),
(22, 38768, '3', 2, 323, 23, 23, 232),
(23, 164851, 'dad', 23, 23, 23, 32, 32),
(24, 137886, 'Stürmer', 43, 3, 4, 5, 3);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `handballspieler`
--

CREATE TABLE `handballspieler` (
  `id` int(11) NOT NULL,
  `person_id` int(11) NOT NULL,
  `position` text NOT NULL,
  `tore` int(11) NOT NULL,
  `anzahlJahre` int(11) NOT NULL DEFAULT '0',
  `gewonneneSpiele` int(11) NOT NULL DEFAULT '0',
  `anzahlVereine` int(11) NOT NULL DEFAULT '0',
  `anzahlSpiele` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `handballspieler`
--

INSERT INTO `handballspieler` (`id`, `person_id`, `position`, `tore`, `anzahlJahre`, `gewonneneSpiele`, `anzahlVereine`, `anzahlSpiele`) VALUES
(12, 11411, '2', 2, 2, 2, 2, 2);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `mannschaft`
--

CREATE TABLE `mannschaft` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `sportart` text NOT NULL,
  `session_id` int(11) NOT NULL DEFAULT '1',
  `Unentschieden` int(11) NOT NULL DEFAULT '0',
  `GewSpiele` int(11) NOT NULL DEFAULT '0',
  `VerlSpiele` int(11) NOT NULL DEFAULT '0',
  `ErzielteTore` int(11) NOT NULL DEFAULT '0',
  `GegnerischeTore` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `mannschaft`
--

INSERT INTO `mannschaft` (`id`, `name`, `sportart`, `session_id`, `Unentschieden`, `GewSpiele`, `VerlSpiele`, `ErzielteTore`, `GegnerischeTore`) VALUES
(79428, 'h1', 'Handball', 1, 0, 4, 4, 159, 79),
(156102, 't1', 'Tennis', 1, 1, 0, 2, 53, 135),
(201119, 'tennis1', 'Tennis', 1, 1, 3, 1, 78, 76);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `person`
--

CREATE TABLE `person` (
  `id` int(11) NOT NULL,
  `vorname` text NOT NULL,
  `name` text NOT NULL,
  `geburtstag` date NOT NULL,
  `mannschaft_id` int(11) DEFAULT NULL,
  `session_id` int(11) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `person`
--

INSERT INTO `person` (`id`, `vorname`, `name`, `geburtstag`, `mannschaft_id`, `session_id`) VALUES
(7592, 'Thetrainer', 'Tom', '2020-09-03', NULL, 1),
(10155, 'Janson', 'TennisGuy', '2020-09-17', 201119, 1),
(11411, '2', '2', '2020-08-02', 79428, 1),
(38768, 'mom', 'dad', '2020-09-04', NULL, 1),
(44195, '6', '67', '2020-08-06', NULL, 1),
(71697, 'DerTennisspieler', 'Tobi', '2020-09-10', 201119, 1),
(116778, '53', '553', '2020-08-05', NULL, 1),
(117397, '3', '3', '2020-03-03', 156102, 1),
(120738, 'da', 'dwasd', '2020-09-10', NULL, 1),
(137886, 'Derfussballer', 'Frencis', '2020-09-03', NULL, 1),
(161130, 'taylor', 'tom', '2020-09-09', NULL, 1),
(164851, 'wdas', 'dasd', '2020-09-19', NULL, 1),
(169101, 'awdasd', 'dwasd', '2020-09-09', NULL, 1),
(206550, 'dawsd', 'per', '2020-09-17', NULL, 1);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `physiotherapeut`
--

CREATE TABLE `physiotherapeut` (
  `id` int(11) NOT NULL,
  `person_id` int(11) NOT NULL,
  `annerkennungen` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `physiotherapeut`
--

INSERT INTO `physiotherapeut` (`id`, `person_id`, `annerkennungen`) VALUES
(14, 116778, 'test'),
(15, 206550, 'nothing');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `spiel`
--

CREATE TABLE `spiel` (
  `id` int(11) NOT NULL,
  `team1ID` int(11) DEFAULT NULL,
  `team2ID` int(11) DEFAULT NULL,
  `team1Punkte` int(11) DEFAULT NULL,
  `team2Punkte` int(11) DEFAULT NULL,
  `turnierID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `spiel`
--

INSERT INTO `spiel` (`id`, `team1ID`, `team2ID`, `team1Punkte`, `team2Punkte`, `turnierID`) VALUES
(11, 79428, 201119, 4, 5, 7),
(13, 201119, 201119, 5, 57, 7),
(14, 201119, 156102, 5, 5, 9);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tennisspieler`
--

CREATE TABLE `tennisspieler` (
  `id` int(11) NOT NULL,
  `person_id` int(11) NOT NULL,
  `aufschlaggeschwindigkeit` int(11) NOT NULL,
  `gewonnenespiele` int(11) NOT NULL,
  `schlaeger` text NOT NULL,
  `anzahlJahre` int(11) NOT NULL,
  `anzahlVereine` int(11) NOT NULL,
  `anzahlSpiele` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `tennisspieler`
--

INSERT INTO `tennisspieler` (`id`, `person_id`, `aufschlaggeschwindigkeit`, `gewonnenespiele`, `schlaeger`, `anzahlJahre`, `anzahlVereine`, `anzahlSpiele`) VALUES
(13, 117397, 3, 3, '3', 3, 3, 3),
(14, 71697, 9000, 3, 'Turboschlägldad2343', 2, 4, 23),
(15, 169101, 23, 34, 'dawd', 34, 3234, 243),
(16, 10155, 54, 43, 'Jop', 3, 2, 23);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `trainer`
--

CREATE TABLE `trainer` (
  `id` int(11) NOT NULL,
  `person_id` int(11) NOT NULL,
  `erfahrung` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `trainer`
--

INSERT INTO `trainer` (`id`, `person_id`, `erfahrung`) VALUES
(14, 7592, 34),
(15, 120738, 3),
(16, 161130, 3);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `turnier`
--

CREATE TABLE `turnier` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `turnierstatus` int(11) NOT NULL DEFAULT '1',
  `session_id` int(11) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `turnier`
--

INSERT INTO `turnier` (`id`, `name`, `turnierstatus`, `session_id`) VALUES
(7, 'Royal Cup\r\n', 1, 1),
(9, 'Summerslam', 1, 1),
(14, 'ddad', 0, 2);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `turnier_mannschaften`
--

CREATE TABLE `turnier_mannschaften` (
  `id` int(11) NOT NULL,
  `teamID` int(11) NOT NULL,
  `turnierID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `turnier_mannschaften`
--

INSERT INTO `turnier_mannschaften` (`id`, `teamID`, `turnierID`) VALUES
(1, 79428, 7);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `login` text NOT NULL,
  `password` text NOT NULL,
  `role` text NOT NULL,
  `canreadsession` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `user`
--

INSERT INTO `user` (`id`, `login`, `password`, `role`, `canreadsession`) VALUES
(1, 'admin', 'admin', 'ADMIN', 1),
(2, 'user', 'user', 'USER', 1);

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `fussballspieler`
--
ALTER TABLE `fussballspieler`
  ADD PRIMARY KEY (`id`),
  ADD KEY `person_id` (`person_id`);

--
-- Indizes für die Tabelle `handballspieler`
--
ALTER TABLE `handballspieler`
  ADD PRIMARY KEY (`id`),
  ADD KEY `person_id` (`person_id`);

--
-- Indizes für die Tabelle `mannschaft`
--
ALTER TABLE `mannschaft`
  ADD PRIMARY KEY (`id`),
  ADD KEY `mannschaft_session` (`session_id`);

--
-- Indizes für die Tabelle `person`
--
ALTER TABLE `person`
  ADD PRIMARY KEY (`id`),
  ADD KEY `mannschaft_id` (`mannschaft_id`),
  ADD KEY `person_session` (`session_id`);

--
-- Indizes für die Tabelle `physiotherapeut`
--
ALTER TABLE `physiotherapeut`
  ADD PRIMARY KEY (`id`),
  ADD KEY `person_id` (`person_id`);

--
-- Indizes für die Tabelle `spiel`
--
ALTER TABLE `spiel`
  ADD PRIMARY KEY (`id`),
  ADD KEY `team1ID_mann` (`team1ID`),
  ADD KEY `team2ID_mann` (`team2ID`),
  ADD KEY `spiel_turnier` (`turnierID`);

--
-- Indizes für die Tabelle `tennisspieler`
--
ALTER TABLE `tennisspieler`
  ADD PRIMARY KEY (`id`),
  ADD KEY `person_id` (`person_id`);

--
-- Indizes für die Tabelle `trainer`
--
ALTER TABLE `trainer`
  ADD PRIMARY KEY (`id`),
  ADD KEY `person_id` (`person_id`);

--
-- Indizes für die Tabelle `turnier`
--
ALTER TABLE `turnier`
  ADD PRIMARY KEY (`id`),
  ADD KEY `turnier_session` (`session_id`);

--
-- Indizes für die Tabelle `turnier_mannschaften`
--
ALTER TABLE `turnier_mannschaften`
  ADD PRIMARY KEY (`id`),
  ADD KEY `team_turnier` (`teamID`),
  ADD KEY `turnier_team` (`turnierID`);

--
-- Indizes für die Tabelle `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `fussballspieler`
--
ALTER TABLE `fussballspieler`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT für Tabelle `handballspieler`
--
ALTER TABLE `handballspieler`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT für Tabelle `mannschaft`
--
ALTER TABLE `mannschaft`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=201120;

--
-- AUTO_INCREMENT für Tabelle `person`
--
ALTER TABLE `person`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=206551;

--
-- AUTO_INCREMENT für Tabelle `physiotherapeut`
--
ALTER TABLE `physiotherapeut`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT für Tabelle `spiel`
--
ALTER TABLE `spiel`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT für Tabelle `tennisspieler`
--
ALTER TABLE `tennisspieler`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT für Tabelle `trainer`
--
ALTER TABLE `trainer`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT für Tabelle `turnier`
--
ALTER TABLE `turnier`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=90030;

--
-- AUTO_INCREMENT für Tabelle `turnier_mannschaften`
--
ALTER TABLE `turnier_mannschaften`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT für Tabelle `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `fussballspieler`
--
ALTER TABLE `fussballspieler`
  ADD CONSTRAINT `fussballspieler_ibfk_1` FOREIGN KEY (`person_id`) REFERENCES `person` (`id`);

--
-- Constraints der Tabelle `handballspieler`
--
ALTER TABLE `handballspieler`
  ADD CONSTRAINT `handballspieler_ibfk_1` FOREIGN KEY (`person_id`) REFERENCES `person` (`id`);

--
-- Constraints der Tabelle `mannschaft`
--
ALTER TABLE `mannschaft`
  ADD CONSTRAINT `mannschaft_session` FOREIGN KEY (`session_id`) REFERENCES `user` (`id`);

--
-- Constraints der Tabelle `person`
--
ALTER TABLE `person`
  ADD CONSTRAINT `person_ibfk_1` FOREIGN KEY (`mannschaft_id`) REFERENCES `mannschaft` (`id`),
  ADD CONSTRAINT `person_session` FOREIGN KEY (`session_id`) REFERENCES `user` (`id`);

--
-- Constraints der Tabelle `physiotherapeut`
--
ALTER TABLE `physiotherapeut`
  ADD CONSTRAINT `physiotherapeut_ibfk_1` FOREIGN KEY (`person_id`) REFERENCES `person` (`id`);

--
-- Constraints der Tabelle `spiel`
--
ALTER TABLE `spiel`
  ADD CONSTRAINT `spiel_turnier` FOREIGN KEY (`turnierID`) REFERENCES `turnier` (`id`),
  ADD CONSTRAINT `team1ID_mann` FOREIGN KEY (`team1ID`) REFERENCES `mannschaft` (`id`),
  ADD CONSTRAINT `team2ID_mann` FOREIGN KEY (`team2ID`) REFERENCES `mannschaft` (`id`);

--
-- Constraints der Tabelle `tennisspieler`
--
ALTER TABLE `tennisspieler`
  ADD CONSTRAINT `tennisspieler_ibfk_1` FOREIGN KEY (`person_id`) REFERENCES `person` (`id`);

--
-- Constraints der Tabelle `trainer`
--
ALTER TABLE `trainer`
  ADD CONSTRAINT `trainer_ibfk_1` FOREIGN KEY (`person_id`) REFERENCES `person` (`id`);

--
-- Constraints der Tabelle `turnier`
--
ALTER TABLE `turnier`
  ADD CONSTRAINT `turnier_session` FOREIGN KEY (`session_id`) REFERENCES `user` (`id`);

--
-- Constraints der Tabelle `turnier_mannschaften`
--
ALTER TABLE `turnier_mannschaften`
  ADD CONSTRAINT `team_turnier` FOREIGN KEY (`teamID`) REFERENCES `mannschaft` (`id`),
  ADD CONSTRAINT `turnier_team` FOREIGN KEY (`turnierID`) REFERENCES `turnier` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
