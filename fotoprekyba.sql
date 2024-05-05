-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 03, 2024 at 10:58 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `fotoprekyba`
--

-- --------------------------------------------------------

--
-- Table structure for table `busena`
--

CREATE TABLE `busena` (
  `id_Busena` int(11) NOT NULL,
  `NAME` char(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_lithuanian_ci;

--
-- Dumping data for table `busena`
--

INSERT INTO `busena` (`id_Busena`, `NAME`) VALUES
(1, 'Sumoketa'),
(2, 'Nesumoketa'),
(3, 'Atsaukta');

-- --------------------------------------------------------

--
-- Table structure for table `darbutojas`
--

CREATE TABLE `darbutojas` (
  `Darbuotojo_ID` int(11) NOT NULL,
  `Vardas` varchar(255) NOT NULL,
  `Pavarde` varchar(255) NOT NULL,
  `Telefono_numeris` decimal(11,0) NOT NULL,
  `El_Pasto_Adresas` varchar(255) NOT NULL,
  `Pareigos` varchar(255) NOT NULL,
  `Asmens_kodas` decimal(11,0) NOT NULL,
  `fk_Parduotuveid_Parduotuve` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_lithuanian_ci;

--
-- Dumping data for table `darbutojas`
--

INSERT INTO `darbutojas` (`Darbuotojo_ID`, `Vardas`, `Pavarde`, `Telefono_numeris`, `El_Pasto_Adresas`, `Pareigos`, `Asmens_kodas`, `fk_Parduotuveid_Parduotuve`) VALUES
(1, 'Jere', 'Pitman', 2147483647, 'jpitman0@bandcamp.com', 'Spausdinimo Technikas', 2147483647, 20),
(2, 'Keith', 'Hairsnape', 2147483647, 'khairsnape1@narod.ru', 'Sekretorius', 2147483647, 13),
(3, 'Norah', 'Preator', 2147483647, 'npreator2@gmpg.org', 'Laboratorijos technikas', 648996190, 17),
(4, 'Jervis', 'Youens', 2147483647, 'jyouens3@prnewswire.com', 'Užsienio Rinkų Vadybininkas', 2147483647, 2),
(5, 'Flemming', 'Meaney', 2147483647, 'fmeaney4@blog.com', 'Pardavimų Konsultantas', 2147483647, 11),
(6, 'Elizabet', 'Scholtz', 2147483647, 'escholtz5@tripod.com', 'Sekretorius', 485568624, 11),
(7, 'Karon', 'Hrinchenko', 2147483647, 'khrinchenko6@weebly.com', 'Vaizdo Apdorojimo Specialistas', 2147483647, 18),
(8, 'Jacinta', 'Wilkennson', 2147483647, 'jwilkennson7@pinterest.com', 'Spausdinimo Technikas', 2147483647, 4),
(9, 'Callie', 'Cleeves', 2147483647, 'ccleeves8@elpais.com', 'Vaizdo Apdorojimo Specialistas', 2147483647, 2),
(10, 'Maiga', 'Ucceli', 2147483647, 'mucceli9@yahoo.com', 'Sandėlio darbuotojas', 1941465692, 16),
(11, 'Dagmar', 'Mainz', 2147483647, 'dmainza@gov.uk', 'Vyr. Vadybininkas', 2147483647, 2),
(12, 'Sharona', 'Jurasz', 2147483647, 'sjuraszb@ovh.net', 'Įrangos Ekspertas', 2147483647, 17),
(13, 'Anatollo', 'Mitchelhill', 2147483647, 'amitchelhillc@netscape.com', 'Spausdinimo Technikas', 450332810, 4),
(14, 'Henry', 'Dennison', 2147483647, 'hdennisond@intel.com', 'Laboratorijos technikas', 1765774314, 8),
(15, 'Catina', 'Kleinhaus', 2147483647, 'ckleinhause@reverbnation.com', 'Spausdinimo Technikas', 2147483647, 12),
(16, 'Gusti', 'Charity', 2147483647, 'gcharityf@loc.gov', 'Įrangos Ekspertas', 2147483647, 7),
(17, 'Danny', 'Razzell', 2147483647, 'drazzellg@businessinsider.com', 'Administratorius', 605214778, 5),
(18, 'Janette', 'Shrimpton', 2147483647, 'jshrimptonh@w3.org', 'Spausdinimo Technikas', 1974919315, 10),
(19, 'Rodrique', 'Flavelle', 2147483647, 'rflavellei@yolasite.com', 'Laboratorijos technikas', 2147483647, 12),
(20, 'Baird', 'Bambrick', 2147483647, 'bbambrickj@cnet.com', 'Spausdinimo Technikas', 2147483647, 2);

-- --------------------------------------------------------

--
-- Table structure for table `gamintojas`
--

CREATE TABLE `gamintojas` (
  `Pavadinimas` varchar(255) NOT NULL,
  `Salis` varchar(255) NOT NULL,
  `Adresas` varchar(255) NOT NULL,
  `Pasto_kodas` varchar(255) NOT NULL,
  `El_pasto_adresas` varchar(255) NOT NULL,
  `id_Gamintojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_lithuanian_ci;

--
-- Dumping data for table `gamintojas`
--

INSERT INTO `gamintojas` (`Pavadinimas`, `Salis`, `Adresas`, `Pasto_kodas`, `El_pasto_adresas`, `id_Gamintojas`) VALUES
('Fliptune', 'Indonesia', '6 Corben Park', '76339', 'kreignard0@telegraph.co.uk', 1),
('Voonyx', 'Indonesia', '4580 Lillian Hill', '66179', 'mealles1@typepad.com', 2),
('Brightdog', 'China', '22 Roxbury Court', '81386', 'bholywell2@hostgator.com', 3),
('Kwimbee', 'Sweden', '3757 Karstens Plaza', '45092', 'kflement3@tripadvisor.com', 4),
('Brightbean', 'Philippines', '8688 Waxwing Point', '77148', 'hroney4@shop-pro.jp', 5),
('Vidoo', 'Portugal', '7 Donald Alley', '87837', 'dscallan5@feedburner.com', 6),
('Kazu', 'Bosnia and Herzegovina', '5327 Packers Alley', '64733', 'mwalford6@apache.org', 7),
('JumpXS', 'Bulgaria', '1 Mccormick Terrace', '12200', 'spendell7@virginia.edu', 8),
('Rhybox', 'China', '703 Clyde Gallagher Parkway', '15416', 'cwhimper8@nsw.gov.au', 9),
('Zoovu', 'China', '79072 Glacier Hill Crossing', '42291', 'gabbots9@fastcompany.com', 10),
('Flashpoint', 'Philippines', '750 Miller Court', '14702', 'egrebnera@vinaora.com', 11),
('Zoomlounge', 'Malawi', '5 Victoria Circle', '10717', 'dbrownsteinb@edublogs.org', 12),
('Voomm', 'Portugal', '775 Manufacturers Court', '21439', 'jhoovartc@wikimedia.org', 13),
('Vidoo', 'Tanzania', '23443 Stone Corner Junction', '94860', 'lmathewsond@hao123.com', 14),
('Realmix', 'Russia', '54613 Rieder Road', '37011', 'gfrohocke@yelp.com', 15),
('Wikizz', 'China', '1999 Merchant Hill', '97583', 'wgoodladf@walmart.com', 16),
('Wordware', 'Indonesia', '632 Moulton Parkway', '76452', 'lingerg@slate.com', 17),
('Photojam', 'Peru', '4018 Vera Way', '61800', 'ablackleechh@buzzfeed.com', 18),
('Feedfish', 'Portugal', '4384 Eggendart Crossing', '12074', 'bkretchmeri@slashdot.org', 19),
('Blognation', 'Mexico', '396 Esker Way', '20054', 'gdreesj@123-reg.co.uk', 20);

-- --------------------------------------------------------

--
-- Table structure for table `kategorija`
--

CREATE TABLE `kategorija` (
  `Pavadinimas` varchar(255) NOT NULL,
  `id_Kategorija` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_lithuanian_ci;

--
-- Dumping data for table `kategorija`
--

INSERT INTO `kategorija` (`Pavadinimas`, `id_Kategorija`) VALUES
('Fotoaparatas', 1),
('Objektyvas', 2),
('Priedas', 3),
('Apšvietimo įranga', 4),
('Dėklas', 5),
('Krepšys', 6),
('Stovas', 7),
('Laikiklis', 8),
('Atminties kortelė', 9),
('Knyga', 10),
('Žurnalas', 11),
('Spausdintuvas', 12),
('Spausdinimo reikmuo', 13),
('Albumas', 14),
('Rėmas', 15),
('Nuotraukų redagavimo programinė įranga', 16),
('Objektyvo filtras', 17),
('Objektyvo priedas', 18),
('Valymo rinkinys', 19),
('Valymo reikmuo', 20),
('Fotografijos kursai', 21);

-- --------------------------------------------------------

--
-- Table structure for table `parduotuve`
--

CREATE TABLE `parduotuve` (
  `Pavadinimas` varchar(255) NOT NULL,
  `Miestas` varchar(255) NOT NULL,
  `Adresas` varchar(255) NOT NULL,
  `Pasto_Kodas` varchar(255) NOT NULL,
  `Darbuotoju_Skaicius` int(11) NOT NULL,
  `id_Parduotuve` int(11) NOT NULL,
  `fk_Sandelysid_Sandelys` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_lithuanian_ci;

--
-- Dumping data for table `parduotuve`
--

INSERT INTO `parduotuve` (`Pavadinimas`, `Miestas`, `Adresas`, `Pasto_Kodas`, `Darbuotoju_Skaicius`, `id_Parduotuve`, `fk_Sandelysid_Sandelys`) VALUES
('Quaxo', 'Pleven', '5 Reindahl Drive', '67126', 8, 1, 5),
('Gabcube', 'Limbaan', '22029 Burning Wood Lane', '22566', 61, 2, 16),
('Twitterbridge', 'Damnica', '2710 Beilfuss Court', '90162', 1, 3, 5),
('Kamba', 'Jagna', '86575 Porter Court', '31471', 100, 4, 14),
('Photobug', 'Ya’erya', '77093 Becker Road', '58811', 12, 5, 14),
('Thoughtworks', 'Cartago', '59836 East Court', '46892', 54, 6, 2),
('Oodoo', 'Gikongoro', '791 Beilfuss Court', '27226', 38, 7, 13),
('Ntags', 'Guanshan', '09475 Lukken Terrace', '97760', 93, 8, 18),
('Fivespan', 'Pizarro', '47032 Eastlawn Plaza', '66478', 3, 9, 9),
('Meeveo', 'Kalpin', '473 Maryland Place', '51592', 45, 10, 14),
('Topicware', 'Krasnyy Profintern', '53678 Columbus Place', '50578', 24, 11, 7),
('Gigaclub', 'Zonghan', '4060 Monument Trail', '59345', 55, 12, 6),
('Gabtype', 'Rejoso', '217 Clyde Gallagher Point', '62864', 48, 13, 19),
('Plambee', 'Egvekinot', '935 Hanson Center', '89330', 21, 14, 9),
('Jaxnation', 'Melaka', '56 Oxford Road', '41134', 54, 15, 1),
('Topicblab', 'Saint-Sauveur', '123 Knutson Lane', '60711', 54, 16, 5),
('Skibox', 'Phú Khương', '1497 Schlimgen Lane', '55220', 58, 17, 20),
('Buzzdog', 'Sabá', '42 Eggendart Street', '41282', 69, 18, 8),
('Quinu', 'Nha Trang', '63 Tomscot Junction', '19789', 25, 19, 12),
('Skajo', 'Wasquehal', '99633 Corry Court', '38651', 30, 20, 4);

-- --------------------------------------------------------

--
-- Table structure for table `pirkejas`
--

CREATE TABLE `pirkejas` (
  `Pirkejo_ID` int(11) NOT NULL,
  `Vardas` varchar(255) NOT NULL,
  `Pavarde` varchar(255) NOT NULL,
  `Telefono_numeris` decimal(11,0) NOT NULL,
  `El_Pasto_Adresas` varchar(255) NOT NULL,
  `Miestas` varchar(255) NOT NULL,
  `Adresas` varchar(255) NOT NULL,
  `Pasto_Kodas` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_lithuanian_ci;

--
-- Dumping data for table `pirkejas`
--

INSERT INTO `pirkejas` (`Pirkejo_ID`, `Vardas`, `Pavarde`, `Telefono_numeris`, `El_Pasto_Adresas`, `Miestas`, `Adresas`, `Pasto_Kodas`) VALUES
(1, 'Darice', 'Gilcrist', 8462248276, 'dgilcrist0@comsenz.com', 'Alunda', '2 Hauk Way', '15193'),
(2, 'Den', 'Parkes', 1752738583, 'dparkes1@bloglovin.com', 'San Miguel', '5 Miller Crossing', '48441'),
(3, 'Mirabelle', 'Sprionghall', 8819123386, 'msprionghall2@lulu.com', 'Leiden', '60 Buhler Point', '31487'),
(4, 'Raynor', 'Martinets', 3839232306, 'rmartinets3@google.fr', 'São Borja', '59 Sherman Point', '96565'),
(5, 'Ryley', 'Pourvoieur', 9507771931, 'rpourvoieur4@nytimes.com', 'Shumerlya', '1792 Warrior Pass', '42511'),
(6, 'Joycelin', 'Willows', 1661828917, 'jwillows5@thetimes.co.uk', 'El Ángel', '6874 Hintze Crossing', '24309'),
(7, 'Manya', 'Lutz', 6995438934, 'mlutz6@canalblog.com', 'Espargos', '1215 Westridge Way', '52365'),
(8, 'Mabelle', 'Basnett', 8126947595, 'mbasnett7@nps.gov', 'Askaniya Nova', '3343 Basil Alley', '17782'),
(9, 'Rance', 'Dacombe', 9226594028, 'rdacombe8@sfgate.com', 'Vân Đình', '5383 Sutteridge Street', '57880'),
(10, 'Edythe', 'Powling', 6268482084, 'epowling9@cnn.com', 'Duanjia', '0 Jana Avenue', '78681'),
(11, 'Reidar', 'Jobke', 9757769460, 'rjobkea@economist.com', 'Breia', '98 Bartillon Place', '29530'),
(12, 'Gabbie', 'O\'Cullinane', 8131040630, 'gocullinaneb@google.co.uk', 'Tampa', '102 Homewood Place', '32507'),
(13, 'Holden', 'Southey', 2896728750, 'hsoutheyc@a8.net', 'Budakovo', '01 Annamark Court', '21261'),
(14, 'Tani', 'Yearnsley', 5215405870, 'tyearnsleyd@dagondesign.com', 'Promissão', '51930 Kim Trail', '49374'),
(15, 'Kary', 'Woodhouse', 2012241869, 'kwoodhousee@hexun.com', 'Iwakura', '0738 Cody Trail', '17543'),
(16, 'Desmund', 'Ralfe', 1058755235, 'dralfef@elpais.com', 'Kalān Deh', '50964 American Avenue', '74027'),
(17, 'Drusilla', 'Keers', 8011316531, 'dkeersg@php.net', 'Onueke', '3 Iowa Road', '58942'),
(18, 'Erich', 'Rubinovitsch', 8525161448, 'erubinovitschh@e-recht24.de', 'Senta', '23661 Eliot Hill', '12452'),
(19, 'Glyn', 'Livingston', 7151875034, 'glivingstoni@123-reg.co.uk', 'Dongjin', '92608 Little Fleur Terrace', '49746'),
(20, 'Patric', 'Tickel', 3307765366, 'ptickelj@bing.com', 'Sofiyivka', '012 Paget Center', '78224');

-- --------------------------------------------------------

--
-- Table structure for table `preke`
--

CREATE TABLE `preke` (
  `Prekes_ID` int(11) NOT NULL,
  `Tipas` varchar(255) NOT NULL,
  `Pavadinimas` varchar(255) NOT NULL,
  `Kaina` decimal(10,2) NOT NULL,
  `Ivertinimas` int(11) NOT NULL,
  `fk_Gamintojasid_Gamintojas` int(11) NOT NULL,
  `fk_Kategorijaid_Kategorija` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_lithuanian_ci;

--
-- Dumping data for table `preke`
--

INSERT INTO `preke` (`Prekes_ID`, `Tipas`, `Pavadinimas`, `Kaina`, `Ivertinimas`, `fk_Gamintojasid_Gamintojas`, `fk_Kategorijaid_Kategorija`) VALUES
(1, 'Profesionalui', 'Babbleset', 1238.00, 1, 1, 2),
(2, 'Laisvalaikiui', 'Ntag', 1471.00, 4, 2, 18),
(3, 'Pradedančiajam', 'Blogtags', 1665.00, 1, 3, 16),
(4, 'Laisvalaikiui', 'Yodoo', 1227.00, 3, 11, 10),
(5, 'Pradedančiajam', 'Agivu', 1002.00, 3, 18, 5),
(6, 'Pradedančiajam', 'Digitube', 206.00, 5, 5, 2),
(7, 'Pradedančiajam', 'Oba', 1339.00, 3, 2, 2),
(8, 'Pradedančiajam', 'Quire', 928.00, 3, 8, 12),
(9, 'Laisvalaikiui', 'Jaxbean', 232.00, 4, 6, 18),
(10, 'Pradedančiajam', 'Oba', 1517.00, 4, 11, 20),
(11, 'Pradedančiajam', 'Realblab', 1309.00, 3, 1, 15),
(12, 'Pradedančiajam', 'Digitube', 92.00, 2, 14, 19),
(13, 'Laisvalaikiui', 'Gevee', 641.00, 2, 6, 4),
(14, 'Laisvalaikiui', 'Meedoo', 446.00, 1, 15, 9),
(15, 'Vidutiniokui', 'Linktype', 402.00, 4, 19, 18),
(16, 'Pradedančiajam', 'Dazzlesphere', 1192.00, 4, 2, 6),
(17, 'Laisvalaikiui', 'Thoughtbridge', 548.00, 4, 15, 16),
(18, 'Profesionalui', 'Zooxo', 1988.00, 4, 19, 2),
(19, 'Laisvalaikiui', 'Gigabox', 1124.00, 2, 17, 15),
(20, 'Pradedančiajam', 'Meembee', 1794.00, 2, 18, 21);

-- --------------------------------------------------------

--
-- Table structure for table `sandelys`
--

CREATE TABLE `sandelys` (
  `Miestas` varchar(255) NOT NULL,
  `Adresas` varchar(255) NOT NULL,
  `Pasto_Kodas` varchar(255) NOT NULL,
  `Darbuotojus_skaicius` int(11) NOT NULL,
  `id_Sandelys` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_lithuanian_ci;

--
-- Dumping data for table `sandelys`
--

INSERT INTO `sandelys` (`Miestas`, `Adresas`, `Pasto_Kodas`, `Darbuotojus_skaicius`, `id_Sandelys`) VALUES
('Zafarwāl', '7 Del Sol Alley', '71378', 14, 1),
('Conqueiros', '65708 Jay Crossing', '17036', 26, 2),
('Xiangqiao', '19048 Daystar Street', '59886', 47, 3),
('Vozuća', '7 Lindbergh Pass', '28386', 60, 4),
('Legrada', '77751 Farragut Park', '43654', 48, 5),
('Gorang', '6850 3rd Way', '12475', 1, 6),
('Nioro du Rip', '59 Cottonwood Lane', '10577', 83, 7),
('Cibunar', '1 Sullivan Avenue', '65491', 32, 8),
('Asopós', '6 Myrtle Road', '16086', 86, 9),
('Barrinha', '4710 Granby Center', '19565', 19, 10),
('General Santos', '114 Crest Line Court', '55053', 21, 11),
('Solnechnogorsk', '2 Green Ridge Plaza', '35245', 26, 12),
('Wangcun', '0 Bobwhite Drive', '20288', 100, 13),
('\'s-Hertogenbosch', '2269 Everett Way', '49977', 64, 14),
('Talshand', '92025 Westport Avenue', '27516', 3, 15),
('Kuchinarai', '0 Rigney Street', '31650', 28, 16),
('Akropong', '79 Hagan Street', '78280', 82, 17),
('Chalchuapa', '2119 Calypso Trail', '59134', 72, 18),
('Tomas', '2 Warbler Center', '45678', 61, 19),
('Dahua', '49033 Butterfield Plaza', '42947', 9, 20);

-- --------------------------------------------------------

--
-- Table structure for table `saskaita`
--

CREATE TABLE `saskaita` (
  `Saskaitos_ID` int(11) NOT NULL,
  `DATA` date NOT NULL,
  `Suma` decimal(10,2) NOT NULL,
  `Busena` int(11) NOT NULL,
  `fk_UzsakymasUzsakymo_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_lithuanian_ci;

--
-- Dumping data for table `saskaita`
--

INSERT INTO `saskaita` (`Saskaitos_ID`, `DATA`, `Suma`, `Busena`, `fk_UzsakymasUzsakymo_ID`) VALUES
(1, '2022-04-16', 2363.52, 2, 1),
(2, '2020-03-03', 2212.67, 3, 2),
(3, '2020-04-22', 3304.54, 3, 3),
(4, '2023-11-25', 3491.82, 3, 4),
(5, '2023-01-11', 894.46, 1, 5),
(6, '2020-10-30', 4473.79, 1, 6),
(7, '2022-03-11', 361.26, 1, 7),
(8, '2020-05-16', 274.69, 1, 8),
(9, '2021-09-24', 714.17, 1, 9),
(10, '2020-12-08', 4659.32, 2, 10),
(11, '2020-08-08', 1083.31, 1, 11),
(12, '2023-08-18', 3107.10, 3, 12),
(13, '2020-07-23', 1087.78, 1, 13),
(14, '2022-06-15', 1913.35, 3, 14),
(15, '2022-03-29', 350.90, 3, 15),
(16, '2022-08-25', 3469.46, 1, 16),
(17, '2020-03-11', 4747.08, 3, 17),
(18, '2020-12-05', 3970.29, 1, 18),
(19, '2022-06-02', 1130.23, 2, 19),
(20, '2023-11-28', 2490.68, 2, 20);

-- --------------------------------------------------------

--
-- Table structure for table `talpina`
--

CREATE TABLE `talpina` (
  `fk_PrekePrekes_ID` int(11) NOT NULL,
  `fk_Sandelysid_Sandelys` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_lithuanian_ci;

--
-- Dumping data for table `talpina`
--

INSERT INTO `talpina` (`fk_PrekePrekes_ID`, `fk_Sandelysid_Sandelys`) VALUES
(2, 8),
(2, 9),
(5, 18),
(6, 7),
(6, 9),
(6, 20),
(7, 17),
(8, 5),
(8, 15),
(9, 15),
(9, 17),
(10, 19),
(11, 9),
(14, 20),
(15, 3),
(15, 9),
(16, 8),
(17, 6),
(18, 9),
(18, 10);

-- --------------------------------------------------------

--
-- Table structure for table `uzsakymas`
--

CREATE TABLE `uzsakymas` (
  `Uzsakymo_ID` int(11) NOT NULL,
  `Kaina` decimal(10,2) NOT NULL,
  `DATA` date NOT NULL,
  `fk_PirkejasPirkejo_ID` int(11) NOT NULL,
  `fk_DarbutojasDarbuotojo_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_lithuanian_ci;

--
-- Dumping data for table `uzsakymas`
--

INSERT INTO `uzsakymas` (`Uzsakymo_ID`, `Kaina`, `DATA`, `fk_PirkejasPirkejo_ID`, `fk_DarbutojasDarbuotojo_ID`) VALUES
(1, 1557.49, '2022-10-26', 4, 15),
(2, 1122.00, '2022-03-07', 13, 17),
(3, 1105.97, '2022-02-15', 11, 18),
(4, 1434.87, '2024-01-15', 17, 18),
(5, 1873.42, '2021-10-06', 19, 19),
(6, 1313.47, '2023-08-09', 11, 3),
(7, 2105.68, '2022-03-05', 7, 9),
(8, 673.76, '2023-12-29', 8, 17),
(9, 1821.65, '2022-06-27', 10, 19),
(10, 2224.26, '2022-01-01', 5, 19),
(11, 1973.48, '2021-04-24', 12, 2),
(12, 476.58, '2023-07-17', 9, 16),
(13, 1763.46, '2021-06-27', 15, 15),
(14, 1781.17, '2022-11-16', 9, 20),
(15, 894.29, '2023-01-06', 2, 6),
(16, 141.18, '2023-12-26', 15, 15),
(17, 1248.25, '2023-01-28', 10, 19),
(18, 1051.80, '2022-01-08', 18, 5),
(19, 66.76, '2022-12-14', 4, 15),
(20, 2194.66, '2023-07-04', 10, 19);

-- --------------------------------------------------------

--
-- Table structure for table `uzsakyta_preke`
--

CREATE TABLE `uzsakyta_preke` (
  `Kiekis` int(11) NOT NULL,
  `id_Uzsakyta_Preke` int(11) NOT NULL,
  `fk_PrekePrekes_ID` int(11) NOT NULL,
  `fk_UzsakymasUzsakymo_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_lithuanian_ci;

--
-- Dumping data for table `uzsakyta_preke`
--

INSERT INTO `uzsakyta_preke` (`Kiekis`, `id_Uzsakyta_Preke`, `fk_PrekePrekes_ID`, `fk_UzsakymasUzsakymo_ID`) VALUES
(77, 1, 17, 16),
(71, 2, 8, 18),
(91, 3, 8, 5),
(37, 4, 5, 3),
(15, 5, 1, 7),
(46, 6, 7, 11),
(19, 7, 3, 1),
(70, 8, 4, 1),
(22, 9, 19, 7),
(82, 10, 1, 10),
(39, 11, 20, 4),
(61, 12, 19, 9),
(54, 13, 20, 1),
(54, 14, 14, 14),
(38, 15, 11, 20),
(27, 16, 1, 2),
(57, 17, 1, 10),
(26, 18, 7, 14),
(87, 19, 13, 3),
(89, 20, 9, 14);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `busena`
--
ALTER TABLE `busena`
  ADD PRIMARY KEY (`id_Busena`);

--
-- Indexes for table `darbutojas`
--
ALTER TABLE `darbutojas`
  ADD PRIMARY KEY (`Darbuotojo_ID`),
  ADD KEY `dirba` (`fk_Parduotuveid_Parduotuve`);

--
-- Indexes for table `gamintojas`
--
ALTER TABLE `gamintojas`
  ADD PRIMARY KEY (`id_Gamintojas`);

--
-- Indexes for table `kategorija`
--
ALTER TABLE `kategorija`
  ADD PRIMARY KEY (`id_Kategorija`);

--
-- Indexes for table `parduotuve`
--
ALTER TABLE `parduotuve`
  ADD PRIMARY KEY (`id_Parduotuve`),
  ADD KEY `turi` (`fk_Sandelysid_Sandelys`);

--
-- Indexes for table `pirkejas`
--
ALTER TABLE `pirkejas`
  ADD PRIMARY KEY (`Pirkejo_ID`);

--
-- Indexes for table `preke`
--
ALTER TABLE `preke`
  ADD PRIMARY KEY (`Prekes_ID`),
  ADD KEY `gamina` (`fk_Gamintojasid_Gamintojas`),
  ADD KEY `priklauso_prekei` (`fk_Kategorijaid_Kategorija`);

--
-- Indexes for table `sandelys`
--
ALTER TABLE `sandelys`
  ADD PRIMARY KEY (`id_Sandelys`);

--
-- Indexes for table `saskaita`
--
ALTER TABLE `saskaita`
  ADD PRIMARY KEY (`Saskaitos_ID`),
  ADD UNIQUE KEY `fk_UzsakymasUzsakymo_ID` (`fk_UzsakymasUzsakymo_ID`),
  ADD KEY `Busena` (`Busena`);

--
-- Indexes for table `talpina`
--
ALTER TABLE `talpina`
  ADD PRIMARY KEY (`fk_PrekePrekes_ID`,`fk_Sandelysid_Sandelys`);

--
-- Indexes for table `uzsakymas`
--
ALTER TABLE `uzsakymas`
  ADD PRIMARY KEY (`Uzsakymo_ID`),
  ADD KEY `daro` (`fk_PirkejasPirkejo_ID`),
  ADD KEY `tvirtina` (`fk_DarbutojasDarbuotojo_ID`);

--
-- Indexes for table `uzsakyta_preke`
--
ALTER TABLE `uzsakyta_preke`
  ADD PRIMARY KEY (`id_Uzsakyta_Preke`),
  ADD KEY `gali_but` (`fk_PrekePrekes_ID`),
  ADD KEY `priklauso` (`fk_UzsakymasUzsakymo_ID`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `darbutojas`
--
ALTER TABLE `darbutojas`
  ADD CONSTRAINT `dirba` FOREIGN KEY (`fk_Parduotuveid_Parduotuve`) REFERENCES `parduotuve` (`id_Parduotuve`);

--
-- Constraints for table `parduotuve`
--
ALTER TABLE `parduotuve`
  ADD CONSTRAINT `turi` FOREIGN KEY (`fk_Sandelysid_Sandelys`) REFERENCES `sandelys` (`id_Sandelys`);

--
-- Constraints for table `preke`
--
ALTER TABLE `preke`
  ADD CONSTRAINT `gamina` FOREIGN KEY (`fk_Gamintojasid_Gamintojas`) REFERENCES `gamintojas` (`id_Gamintojas`),
  ADD CONSTRAINT `priklauso_prekei` FOREIGN KEY (`fk_Kategorijaid_Kategorija`) REFERENCES `kategorija` (`id_Kategorija`);

--
-- Constraints for table `saskaita`
--
ALTER TABLE `saskaita`
  ADD CONSTRAINT `gali_tureti` FOREIGN KEY (`fk_UzsakymasUzsakymo_ID`) REFERENCES `uzsakymas` (`Uzsakymo_ID`),
  ADD CONSTRAINT `saskaita_ibfk_1` FOREIGN KEY (`Busena`) REFERENCES `busena` (`id_Busena`);

--
-- Constraints for table `talpina`
--
ALTER TABLE `talpina`
  ADD CONSTRAINT `talpina` FOREIGN KEY (`fk_PrekePrekes_ID`) REFERENCES `preke` (`Prekes_ID`);

--
-- Constraints for table `uzsakymas`
--
ALTER TABLE `uzsakymas`
  ADD CONSTRAINT `daro` FOREIGN KEY (`fk_PirkejasPirkejo_ID`) REFERENCES `pirkejas` (`Pirkejo_ID`),
  ADD CONSTRAINT `tvirtina` FOREIGN KEY (`fk_DarbutojasDarbuotojo_ID`) REFERENCES `darbutojas` (`Darbuotojo_ID`);

--
-- Constraints for table `uzsakyta_preke`
--
ALTER TABLE `uzsakyta_preke`
  ADD CONSTRAINT `gali_but` FOREIGN KEY (`fk_PrekePrekes_ID`) REFERENCES `preke` (`Prekes_ID`),
  ADD CONSTRAINT `priklauso` FOREIGN KEY (`fk_UzsakymasUzsakymo_ID`) REFERENCES `uzsakymas` (`Uzsakymo_ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
