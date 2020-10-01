-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Erstellungszeit: 01. Okt 2020 um 10:42
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
(24, 137886, 'Stürmer', 43, 3, 4, 5, 3),
(25, 173494, 'Stürmer', 425, 5, 999, 1, 420),
(26, 203549, 'Torwart', 0, 3, 999, 1, 420);

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
(1337, 'TestMan', 'Fussball', 1, 0, 0, 0, 0, 0),
(7167, 'Kickers', 'Fussball', 1, 2, 3, 2, 76, 21),
(47521, 'KickersOld', 'Fussball', 1, 4, 2, 0, 17, 15),
(156033, 'FCBayern', 'Fussball', 1, 1, 0, 5, 15, 69),
(171524, 'Schalke04', 'Fussball', 1, 1, 3, 1, 22, 25),
(171568, 'Green Donkeys', 'Handball', 1, 0, 0, 0, 0, 0),
(171569, 'Considerate Horses', 'Fussball', 1, 0, 0, 0, 0, 0),
(171570, 'Considerate Dodgers', 'Tennis', 1, 0, 0, 0, 0, 0),
(171571, 'Canada Pink Legs', 'Handball', 1, 0, 0, 0, 0, 0),
(171572, 'Splendid Mice', 'Handball', 1, 0, 0, 0, 0, 0),
(171573, 'Malicious Goldfish', 'Tennis', 1, 0, 0, 0, 0, 0),
(171574, 'Canada Pink Legs', 'Fussball', 1, 0, 0, 0, 0, 0),
(171575, 'Splendid Mice', 'Tennis', 1, 0, 1, 1, 6, 8),
(171576, 'Malicious Goldfish', 'Handball', 1, 0, 2, 1, 12, 8),
(171577, 'Remarkable Angels', 'Handball', 1, 0, 2, 0, 17, 4),
(171578, 'London Toads', 'Fussball', 1, 1, 0, 2, 6, 14),
(171579, 'Understanding Lizards', 'Handball', 1, 1, 2, 1, 7, 9),
(171580, 'Modest Foxes', 'Fussball', 1, 0, 1, 2, 13, 19),
(171581, 'Considerate Horses', 'Tennis', 1, 0, 0, 2, 3, 5),
(171582, 'Considerate Dodgers', 'Tennis', 1, 0, 2, 1, 11, 8);

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
(10155, 'Janson', 'TennisGuy', '2020-09-17', NULL, 1),
(11411, '2', '2', '2020-08-02', NULL, 1),
(38768, 'mom', 'dad', '2020-09-04', 156033, 1),
(44195, '6', '67435', '2020-08-06', 156033, 1),
(71697, 'DerTennisspieler', 'Tobi', '2020-09-10', NULL, 1),
(116778, '53', '553', '2020-08-05', NULL, 1),
(117397, '3', '3', '2020-03-03', NULL, 1),
(120738, 'da', 'dwasd', '2020-09-10', NULL, 1),
(137886, 'Derfussballer', 'Frencis', '2020-09-03', 171524, 1),
(161130, 'taylor', 'tom', '2020-09-09', NULL, 1),
(164851, 'wdas', 'dasd', '2020-09-19', 171524, 1),
(169101, 'awdasd', 'dwasd', '2020-09-09', NULL, 1),
(173494, 'VonDenKickers', 'Gregor', '2020-09-03', 7167, 1),
(203549, 'TheTorhüter', 'Mario', '2020-09-01', 47521, 1),
(206550, 'dawsd', 'per', '2020-09-17', NULL, 1),
(206551, 'Klaus', 'NachName', '2020-09-09', NULL, 1);

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
(18, 171524, 156033, 5, 4, 145031),
(21, 156033, 7167, 1, 11, 145031),
(22, 7167, 171524, 11, 2, 145031),
(23, 7167, 47521, 5, 5, 145031),
(24, 171524, 47521, 5, 5, 145031),
(25, 7167, 171524, 1, 5, 145031),
(26, 7167, 156033, 45, 4, 145031),
(27, 171524, 156033, 5, 4, 145031),
(28, 47521, 156033, 2, 1, 145031),
(29, 47521, 7167, 3, 2, 145031),
(30, 47521, 156033, 1, 1, 145031),
(31, 47521, 7167, 1, 1, 145031),
(32, 171575, 171576, 4, 2, 121187),
(33, 171577, 171580, 12, 1, 121187),
(34, 171582, 171581, 3, 2, 121187),
(35, 171578, 171577, 3, 5, 121187),
(36, 171579, 171578, 1, 1, 121187),
(37, 171582, 171579, 2, 4, 121187),
(38, 171582, 171575, 6, 2, 121187),
(39, 171576, 171580, 5, 4, 121187),
(40, 171579, 171581, 2, 1, 121187),
(41, 171578, 171580, 2, 8, 121187),
(42, 171576, 171579, 5, 0, 121187);

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
(14, 'ddad', 0, 2),
(121187, 'SummerSlam2034', 0, 1),
(145031, 'RoyalCup01', 0, 1);

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
(7, 156033, 145031),
(8, 171524, 145031),
(9, 7167, 145031),
(10, 47521, 145031),
(11, 171575, 121187),
(12, 171576, 121187),
(13, 171577, 121187),
(14, 171578, 121187),
(15, 171579, 121187),
(16, 171580, 121187),
(17, 171581, 121187),
(18, 171582, 121187);

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT für Tabelle `handballspieler`
--
ALTER TABLE `handballspieler`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT für Tabelle `mannschaft`
--
ALTER TABLE `mannschaft`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=171583;

--
-- AUTO_INCREMENT für Tabelle `person`
--
ALTER TABLE `person`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=206552;

--
-- AUTO_INCREMENT für Tabelle `physiotherapeut`
--
ALTER TABLE `physiotherapeut`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT für Tabelle `spiel`
--
ALTER TABLE `spiel`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=43;

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=145032;

--
-- AUTO_INCREMENT für Tabelle `turnier_mannschaften`
--
ALTER TABLE `turnier_mannschaften`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

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
