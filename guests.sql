-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Дек 26 2020 г., 12:45
-- Версия сервера: 10.3.22-MariaDB
-- Версия PHP: 7.1.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `hotel`
--

-- --------------------------------------------------------

--
-- Структура таблицы `guests`
--

CREATE TABLE `guests` (
  `ID` int(6) NOT NULL,
  `FirstName` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `SecondName` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `MiddleName` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `Seria` int(4) NOT NULL,
  `Nomer` int(6) NOT NULL,
  `Room` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `guests`
--

INSERT INTO `guests` (`ID`, `FirstName`, `SecondName`, `MiddleName`, `Seria`, `Nomer`, `Room`) VALUES
(20, 'Иван', 'Козлов', 'Семёнович', 7801, 122647, 3),
(21, 'Артём', 'Родин', 'Семёнович', 9664, 115264, 6),
(22, 'Павел', 'Никольский', 'Михайлович', 3301, 904757, 7),
(23, 'Лев', 'Кузнецов', 'Тимурович', 3256, 181555, 8);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `guests`
--
ALTER TABLE `guests`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `guests`
--
ALTER TABLE `guests`
  MODIFY `ID` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
