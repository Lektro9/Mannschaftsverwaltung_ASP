-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 19. Aug 2020 um 16:11
-- Server-Version: 10.4.13-MariaDB
-- PHP-Version: 7.2.32

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
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
  `anzahlJahre` int(11) NOT NULL DEFAULT 0,
  `gewonneneSpiele` int(11) NOT NULL DEFAULT 0,
  `anzahlVereine` int(11) NOT NULL DEFAULT 0,
  `anzahlSpiele` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `fussballspieler`
--

INSERT INTO `fussballspieler` (`id`, `person_id`, `position`, `tore`, `anzahlJahre`, `gewonneneSpiele`, `anzahlVereine`, `anzahlSpiele`) VALUES
(1, 12, 'Stürmer', 34, 0, 0, 0, 0),
(11, 15, 'Stürmer', 10, 0, 0, 0, 0),
(12, 16, 'Außenmittelfeldspieler (Flügelspieler)', 15, 0, 0, 0, 0),
(14, 2, 'defensiver Mittelfeldspieler', 28, 0, 0, 0, 0),
(17, 13, 'Stürmer', 45, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `handballspieler`
--

CREATE TABLE `handballspieler` (
  `id` int(11) NOT NULL,
  `person_id` int(11) NOT NULL,
  `position` text NOT NULL,
  `tore` int(11) NOT NULL,
  `anzahlJahre` int(11) NOT NULL DEFAULT 0,
  `gewonneneSpiele` int(11) NOT NULL DEFAULT 0,
  `anzahlVereine` int(11) NOT NULL DEFAULT 0,
  `anzahlSpiele` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `handballspieler`
--

INSERT INTO `handballspieler` (`id`, `person_id`, `position`, `tore`, `anzahlJahre`, `gewonneneSpiele`, `anzahlVereine`, `anzahlSpiele`) VALUES
(2, 21, 'Angriff', 25, 0, 0, 0, 0),
(5, 17, 'Rückraumlinks', 12, 0, 0, 0, 0),
(6, 19, 'Rückraummitte', 4, 0, 0, 0, 0),
(8, 18, 'Rechtsaußen', 65, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `mannschaft`
--

CREATE TABLE `mannschaft` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `session_id` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `mannschaft`
--

INSERT INTO `mannschaft` (`id`, `name`, `session_id`) VALUES
(1, 'FrankfurtSV', 1),
(2, 'TestMannschaft', 1),
(6, 'Stuttgart', 1),
(7, 'Dortmund', 1),
(8, 'Berlin', 1),
(9, 'Köln', 1),
(10, 'Manchester City', 1),
(11, 'FC Liverpool', 1),
(12, 'Real Madrid', 1),
(13, 'FC Barcelona', 1);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `person`
--

CREATE TABLE `person` (
  `id` int(11) NOT NULL,
  `vorname` text NOT NULL,
  `name` text NOT NULL,
  `geburtstag` date NOT NULL,
  `mannschaft_id` int(11) NOT NULL,
  `turnier_id` int(11) NOT NULL,
  `session_id` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `person`
--

INSERT INTO `person` (`id`, `vorname`, `name`, `geburtstag`, `mannschaft_id`, `turnier_id`, `session_id`) VALUES
(1, 'Vergil', 'Redgrave', '2020-03-26', 2, 1, 1),
(2, 'Dante', 'Regdrave', '2002-03-26', 1, 2, 1),
(12, 'Dennis', 'grandle', '1993-03-26', 6, 2, 1),
(13, 'Klaus', 'Shidokiv', '1990-01-02', 6, 2, 1),
(14, 'Peter', 'Schmitt', '2000-03-13', 6, 2, 1),
(15, 'Lars', 'Banane', '2001-04-02', 7, 2, 1),
(16, 'Bern', 'Wunder', '1989-03-02', 7, 2, 1),
(17, 'Fernando', 'Brandez', '1998-03-11', 7, 2, 1),
(18, 'James', 'Peterson', '2003-03-20', 8, 2, 1),
(19, 'George', 'doubleyuu', '1970-12-26', 8, 2, 1),
(20, 'Michael', 'Stiefelmacher', '1999-01-14', 8, 2, 1),
(21, 'Chris', 'Redfield', '1980-03-30', 9, 2, 1),
(22, 'Randy', 'Shmot', '1993-02-21', 9, 2, 1),
(23, 'Gerry', 'sMod', '1995-07-26', 9, 2, 1),
(24, 'ExampleGuy', 'ExampleName', '2001-03-11', 8, 7, 1),
(34234, 'Trainer', 'Tom', '2020-05-05', 8, 2, 1),
(34235, 'Klemens', 'Bondie', '2020-05-02', 12, 1, 1);

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
(11, 34235, 'Medizinstudium abgeschlossen');

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
(1, 23, 86, 14, 'Wilson 9000', 0, 0, 0),
(10, 1, 250, 67, 'Wilson 9000', 0, 0, 0);

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
(11, 34234, 35),
(12, 24, 33);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `turnier`
--

CREATE TABLE `turnier` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `session_id` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `turnier`
--

INSERT INTO `turnier` (`id`, `name`, `session_id`) VALUES
(1, 'TestTurnier', 1),
(2, 'Bundesliga', 1),
(3, 'Stb. Open', 1),
(4, 'Madness Competition', 1),
(5, 'Spring Cup\r\n', 1),
(6, 'Speedy Cup\r\n', 1),
(7, 'Royal Cup\r\n', 1),
(8, 'Easter, Winter Trophy\r\n', 1),
(9, 'Summerslam', 1),
(10, 'Spring Slam Series', 1);

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
(1, 'admin', 'admin', 'ADMIN', 'admin');

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
  ADD KEY `turnier_id` (`turnier_id`),
  ADD KEY `person_session` (`session_id`);

--
-- Indizes für die Tabelle `physiotherapeut`
--
ALTER TABLE `physiotherapeut`
  ADD PRIMARY KEY (`id`),
  ADD KEY `person_id` (`person_id`);

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT für Tabelle `handballspieler`
--
ALTER TABLE `handballspieler`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT für Tabelle `mannschaft`
--
ALTER TABLE `mannschaft`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT für Tabelle `person`
--
ALTER TABLE `person`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34237;

--
-- AUTO_INCREMENT für Tabelle `physiotherapeut`
--
ALTER TABLE `physiotherapeut`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT für Tabelle `tennisspieler`
--
ALTER TABLE `tennisspieler`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT für Tabelle `trainer`
--
ALTER TABLE `trainer`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT für Tabelle `turnier`
--
ALTER TABLE `turnier`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT für Tabelle `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

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
  ADD CONSTRAINT `person_ibfk_2` FOREIGN KEY (`turnier_id`) REFERENCES `turnier` (`id`),
  ADD CONSTRAINT `person_session` FOREIGN KEY (`session_id`) REFERENCES `user` (`id`);

--
-- Constraints der Tabelle `physiotherapeut`
--
ALTER TABLE `physiotherapeut`
  ADD CONSTRAINT `physiotherapeut_ibfk_1` FOREIGN KEY (`person_id`) REFERENCES `person` (`id`);

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
