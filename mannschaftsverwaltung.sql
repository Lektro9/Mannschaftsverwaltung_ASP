-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 24. Mrz 2020 um 08:07
-- Server-Version: 10.4.11-MariaDB
-- PHP-Version: 7.3.15

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
  `tore` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `fussballspieler`
--

INSERT INTO `fussballspieler` (`id`, `person_id`, `position`, `tore`) VALUES
(1, 12, 'Stürmer', 34),
(2, 17, 'Torwart', 0),
(3, 19, 'Mittelfeld', 23),
(11, 15, 'Stürmer', 10),
(12, 16, 'Außenmittelfeldspieler (Flügelspieler)', 15),
(13, 21, 'offensiver Mittelfeldspieler', 14),
(14, 2, 'defensiver Mittelfeldspieler', 28),
(15, 20, 'Außenverteidiger', 5),
(16, 22, 'Innenverteidiger', 2),
(17, 13, 'Stürmer', 45);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `handballspieler`
--

CREATE TABLE `handballspieler` (
  `id` int(11) NOT NULL,
  `person_id` int(11) NOT NULL,
  `position` text NOT NULL,
  `tore` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `handballspieler`
--

INSERT INTO `handballspieler` (`id`, `person_id`, `position`, `tore`) VALUES
(1, 16, 'Mittelfeld', 12),
(2, 21, 'Angriff', 25),
(3, 2, 'Verteidiger', 3),
(4, 12, 'Linksaußen', 4),
(5, 17, 'Rückraumlinks', 12),
(6, 19, 'Rückraummitte', 4),
(7, 23, 'Rückraumrechts', 23),
(8, 18, 'Rechtsaußen', 65),
(9, 13, 'Kreisläufer', 45),
(10, 15, 'Torwart', 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `mannschaft`
--

CREATE TABLE `mannschaft` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `mannschaft`
--

INSERT INTO `mannschaft` (`id`, `name`) VALUES
(1, 'FrankfurtSV'),
(2, 'TestMannschaft'),
(6, 'Stuttgart'),
(7, 'Dortmund'),
(8, 'Berlin'),
(9, 'Köln'),
(10, 'Manchester City'),
(11, 'FC Liverpool'),
(12, 'Real Madrid'),
(13, 'FC Barcelona');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `person`
--

CREATE TABLE `person` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `mannschaft_id` int(11) NOT NULL,
  `turnier_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `person`
--

INSERT INTO `person` (`id`, `name`, `mannschaft_id`, `turnier_id`) VALUES
(1, 'Vergil', 2, 1),
(2, 'Dante', 1, 2),
(12, 'Dennis', 6, 2),
(13, 'Klaus', 6, 2),
(14, 'Schmitt', 6, 2),
(15, 'Lars', 7, 2),
(16, 'Bern', 7, 2),
(17, 'Fernando', 7, 2),
(18, 'James', 8, 2),
(19, 'George', 8, 2),
(20, 'Michael', 8, 2),
(21, 'Chris', 9, 2),
(22, 'Randy', 9, 2),
(23, 'Gerry', 9, 2);

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
(1, 22, 'Medizin-Studium abgeschlossen'),
(2, 14, 'Medizin-Studium, 10 Jahre Erfahrung'),
(3, 1, 'Medizin-Studium abgeschlossen,\r\n15 Jahre Erfahrung'),
(4, 16, 'Medizin-Studium abgeschlossen'),
(5, 21, 'Medizin-Studium abgeschlossen'),
(6, 2, 'Medizin-Studium abgeschlossen'),
(7, 17, 'Medizin-Studium abgeschlossen'),
(8, 19, 'Medizin-Studium abgeschlossen'),
(9, 23, 'Medizin-Studium abgeschlossen'),
(10, 13, 'Medizin-Studium abgeschlossen');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tennisspieler`
--

CREATE TABLE `tennisspieler` (
  `id` int(11) NOT NULL,
  `person_id` int(11) NOT NULL,
  `aufschlaggeschwindigkeit` int(11) NOT NULL,
  `gewonnenespiele` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `tennisspieler`
--

INSERT INTO `tennisspieler` (`id`, `person_id`, `aufschlaggeschwindigkeit`, `gewonnenespiele`) VALUES
(1, 23, 86, 14),
(2, 18, 88, 44),
(3, 13, 98, 12),
(4, 16, 123, 2),
(5, 21, 23, 0),
(6, 2, 125, 25),
(7, 19, 90, 2),
(8, 15, 45, 24),
(9, 20, 119, 25),
(10, 1, 250, 67);

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
(1, 15, 13),
(2, 20, 10),
(3, 16, 1),
(4, 21, 2),
(5, 2, 3),
(6, 12, 4),
(7, 17, 5),
(8, 19, 6),
(9, 23, 7),
(10, 18, 8);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `turnier`
--

CREATE TABLE `turnier` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `turnier`
--

INSERT INTO `turnier` (`id`, `name`) VALUES
(1, 'TestTurnier'),
(2, 'Bundesliga'),
(3, 'Stb. Open'),
(4, 'Madness Competition'),
(5, 'Spring Cup\r\n'),
(6, 'Speedy Cup\r\n'),
(7, 'Royal Cup\r\n'),
(8, 'Easter, Winter Trophy\r\n'),
(9, 'Summerslam'),
(10, 'Spring Slam Series');

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
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `person`
--
ALTER TABLE `person`
  ADD PRIMARY KEY (`id`),
  ADD KEY `mannschaft_id` (`mannschaft_id`),
  ADD KEY `turnier_id` (`turnier_id`);

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT für Tabelle `physiotherapeut`
--
ALTER TABLE `physiotherapeut`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT für Tabelle `tennisspieler`
--
ALTER TABLE `tennisspieler`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT für Tabelle `trainer`
--
ALTER TABLE `trainer`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT für Tabelle `turnier`
--
ALTER TABLE `turnier`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

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
-- Constraints der Tabelle `person`
--
ALTER TABLE `person`
  ADD CONSTRAINT `person_ibfk_1` FOREIGN KEY (`mannschaft_id`) REFERENCES `mannschaft` (`id`),
  ADD CONSTRAINT `person_ibfk_2` FOREIGN KEY (`turnier_id`) REFERENCES `turnier` (`id`);

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
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
