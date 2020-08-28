-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Erstellungszeit: 28. Aug 2020 um 08:13
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
(20, 109282, '1', 1, 1, 1, 1, 1),
(21, 44195, '6', 6, 6, 6, 6, 6);

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
(79428, 'h1', 'Handball', 1, 0, 0, 0, 0, 0),
(156102, 't1', 'Tennis', 1, 0, 0, 0, 0, 0),
(214516, 'f1', 'Fussball', 1, 0, 0, 0, 0, 0);

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
(11411, '2', '2', '2020-08-02', 79428, 1),
(39599, '4', '4', '2020-08-04', NULL, 1),
(44195, '6', '6', '2020-08-06', NULL, 1),
(109282, '1', '1', '2020-08-01', 214516, 1),
(116778, '5', '5', '2020-08-05', NULL, 1),
(117397, '3', '3', '2020-03-03', 156102, 1);

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
(14, 116778, 'nothing');

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
(13, 117397, 3, 3, '3', 3, 3, 3);

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
(13, 39599, 4);

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
(10, 'Spring Slam Series', 1, 1);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `login` text NOT NULL,
  `password` text NOT NULL,
  `role` text NOT NULL,
  `session` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `user`
--

INSERT INTO `user` (`id`, `login`, `password`, `role`, `session`) VALUES
(1, 'admin', 'admin', 'ADMIN', 'admin'),
(2, 'user', 'user', 'USER', 'user');

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT für Tabelle `handballspieler`
--
ALTER TABLE `handballspieler`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT für Tabelle `mannschaft`
--
ALTER TABLE `mannschaft`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=214517;

--
-- AUTO_INCREMENT für Tabelle `person`
--
ALTER TABLE `person`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=201050;

--
-- AUTO_INCREMENT für Tabelle `physiotherapeut`
--
ALTER TABLE `physiotherapeut`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT für Tabelle `spiel`
--
ALTER TABLE `spiel`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT für Tabelle `tennisspieler`
--
ALTER TABLE `tennisspieler`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT für Tabelle `trainer`
--
ALTER TABLE `trainer`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT für Tabelle `turnier`
--
ALTER TABLE `turnier`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

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
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
