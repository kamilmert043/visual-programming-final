-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 03 Oca 2023, 12:58:27
-- Sunucu sürümü: 10.4.24-MariaDB
-- PHP Sürümü: 8.1.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `sales_automation`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `carts`
--

CREATE TABLE `carts` (
  `id` int(11) NOT NULL,
  `customerID` int(11) NOT NULL,
  `nameSurname` varchar(255) NOT NULL,
  `phone` varchar(50) NOT NULL,
  `productID` int(11) NOT NULL,
  `productName` varchar(255) NOT NULL,
  `productType` varchar(255) NOT NULL,
  `unitPrice` double NOT NULL,
  `amount` double NOT NULL,
  `totalPrice` double NOT NULL,
  `tax` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `carts`
--

INSERT INTO `carts` (`id`, `customerID`, `nameSurname`, `phone`, `productID`, `productName`, `productType`, `unitPrice`, `amount`, `totalPrice`, `tax`) VALUES
(116, 1, 'Kamil MERT', '555-555-55-55', 3, 'Elma', 'Meyve', 11.75, 2, 23.5, 18);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `customers`
--

CREATE TABLE `customers` (
  `id` int(11) NOT NULL,
  `nameSurname` varchar(100) NOT NULL,
  `phone` varchar(50) NOT NULL,
  `adress` text NOT NULL,
  `mail` varchar(70) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `customers`
--

INSERT INTO `customers` (`id`, `nameSurname`, `phone`, `adress`, `mail`) VALUES
(1, 'Kamil MERT', '555-555-55-55', 'process.addCustomers(txtNameSurname, txtPhone, txtAdress, txtMail);', 'mail@mail.com'),
(2, 'John Doe', '555-555-55-55', '555555555555555555555555555555555555555555', '55555@mail.com');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `lostpassword`
--

CREATE TABLE `lostpassword` (
  `id` int(11) NOT NULL,
  `code` int(11) NOT NULL,
  `userID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `productss`
--

CREATE TABLE `productss` (
  `id` int(11) NOT NULL,
  `productName` varchar(255) NOT NULL,
  `productType` varchar(255) NOT NULL,
  `productQuantity` double NOT NULL,
  `productPurchasePrice` double NOT NULL,
  `productpurchaseDate` date NOT NULL,
  `productSalePrice` float NOT NULL,
  `productTax` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `productss`
--

INSERT INTO `productss` (`id`, `productName`, `productType`, `productQuantity`, `productPurchasePrice`, `productpurchaseDate`, `productSalePrice`, `productTax`) VALUES
(3, 'Elma', 'Meyve', 396, 5.75, '2022-12-25', 11.75, 18),
(4, 'Karpuz', 'Meyve', 386, 5.25, '2022-12-25', 9.35, 18),
(5, 'Marul', 'Sebze', 288, 4.85, '2022-12-25', 8, 18),
(7, 'Erik', 'Meyve', 2, 15.85, '2022-12-25', 19.5, 18),
(8, 'Balıkesir Elması', 'Meyve', 550, 1000, '2022-12-28', 10000, 18),
(9, 'Patates', 'Sebze', 800, 4, '2022-12-28', 7, 18),
(10, 'Salatalık', 'Sebze', 580, 3, '2022-12-28', 6.5, 18),
(11, 'Kabak', 'Sebze', 525, 7, '2022-12-28', 12, 18),
(12, 'Patlıcan', 'Sebze', 420, 5, '2022-12-28', 9, 18);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `products_name`
--

CREATE TABLE `products_name` (
  `id` int(11) NOT NULL,
  `typeID` int(11) NOT NULL,
  `pName` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `products_name`
--

INSERT INTO `products_name` (`id`, `typeID`, `pName`) VALUES
(1, 1, 'Elma'),
(2, 2, 'Marul'),
(3, 1, 'Karpuz'),
(4, 2, 'Patlıcan'),
(5, 1, 'Kiraz'),
(6, 1, 'Erik'),
(7, 2, 'Patates'),
(8, 2, 'Kabak'),
(9, 2, 'Salatalık'),
(10, 2, 'Karnabahar'),
(11, 1, 'Balıkesir Elması');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `products_type`
--

CREATE TABLE `products_type` (
  `id` int(11) NOT NULL,
  `productType` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `products_type`
--

INSERT INTO `products_type` (`id`, `productType`) VALUES
(1, 'Meyve'),
(2, 'Sebze');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `sales`
--

CREATE TABLE `sales` (
  `id` int(11) NOT NULL,
  `customerID` int(11) NOT NULL,
  `customerNameSurname` varchar(255) NOT NULL,
  `customerPhone` varchar(50) NOT NULL,
  `productID` int(11) NOT NULL,
  `productName` varchar(255) NOT NULL,
  `productType` varchar(255) NOT NULL,
  `unitPrice` float NOT NULL,
  `amount` float NOT NULL,
  `totalPrice` float NOT NULL,
  `tax` int(11) NOT NULL,
  `orderTime` date NOT NULL DEFAULT current_timestamp(),
  `description` text DEFAULT NULL,
  `CartID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `sales`
--

INSERT INTO `sales` (`id`, `customerID`, `customerNameSurname`, `customerPhone`, `productID`, `productName`, `productType`, `unitPrice`, `amount`, `totalPrice`, `tax`, `orderTime`, `description`, `CartID`) VALUES
(13, 2, 'John Doe', '555-555-55-55', 4, 'Karpuz', 'Meyve', 9, 0, 0, 18, '2022-12-19', 'test', 89),
(14, 1, 'Kamil MERT', '555-555-55-55', 7, 'Erik', 'Meyve', 19, 6, 114, 18, '2022-12-25', '5 adet ürün iadesi gerçekleştirildi.27.12.2022 03:29:531 adet ürün iadesi gerçekleştirildi.27.12.2022 03:31:40   2 adet ürün iadesi gerçekleştirildi.27.12.2022 03:37:19', 90),
(15, 1, 'Kamil MERT', '555-555-55-55', 3, 'Elma', 'Meyve', 11, 1, 11, 18, '2022-12-24', '', 91),
(16, 1, 'Kamil MERT', '555-555-55-55', 7, 'Erik', 'Meyve', 19, 0, 0, 18, '2022-12-27', '', 92),
(17, 2, 'John Doe', '555-555-55-55', 4, 'Karpuz', 'Meyve', 9, 1, 9, 18, '2022-12-27', '', 93),
(18, 2, 'John Doe', '555-555-55-55', 5, 'Marul', 'Sebze', 8, 2, 16, 18, '2022-12-27', '   0 adet ürün iadesi gerçekleştirildi.27.12.2022 07:12:09   0 adet ürün iadesi gerçekleştirildi.27.12.2022 07:12:19', 94),
(19, 1, 'Kamil MERT', '555-555-55-55', 3, 'Elma', 'Meyve', 11, 40, 470, 18, '2022-12-27', NULL, 95),
(20, 1, 'Kamil MERT', '555-555-55-55', 3, 'Elma', 'Meyve', 11, 4, 47, 18, '2022-12-27', NULL, 96),
(21, 1, 'Kamil MERT', '555-555-55-55', 5, 'Marul', 'Sebze', 8, 5, 40, 18, '2022-12-27', NULL, 97),
(22, 1, 'Kamil MERT', '555-555-55-55', 5, 'Marul', 'Sebze', 8, 6, 48, 18, '2022-12-27', NULL, 98),
(23, 1, 'Kamil MERT', '555-555-55-55', 3, 'Elma', 'Meyve', 11, 2, 23, 18, '2022-12-27', NULL, 99),
(24, 1, 'Kamil MERT', '555-555-55-55', 7, 'Erik', 'Meyve', 19, 4, 78, 18, '2022-12-27', NULL, 100),
(25, 1, 'Kamil MERT', '555-555-55-55', 3, 'Elma', 'Meyve', 11, 2, 23, 18, '2022-12-27', NULL, 101),
(26, 1, 'Kamil MERT', '555-555-55-55', 5, 'Marul', 'Sebze', 8, 3, 24, 18, '2022-12-27', NULL, 102),
(27, 1, 'Kamil MERT', '555-555-55-55', 4, 'Karpuz', 'Meyve', 9, 5, 46, 18, '2022-12-27', NULL, 103),
(28, 1, 'Kamil MERT', '555-555-55-55', 5, 'Marul', 'Sebze', 8, 2, 16, 18, '2022-12-27', NULL, 104),
(29, 1, 'Kamil MERT', '555-555-55-55', 3, 'Elma', 'Meyve', 11, 1, 11, 18, '2022-12-27', NULL, 105),
(30, 1, 'Kamil MERT', '555-555-55-55', 5, 'Marul', 'Sebze', 8, 1, 8, 18, '2022-12-27', NULL, 106),
(31, 1, 'Kamil MERT', '555-555-55-55', 7, 'Erik', 'Meyve', 19, 3, 58, 18, '2022-12-27', NULL, 107),
(32, 1, 'Kamil MERT', '555-555-55-55', 3, 'Elma', 'Meyve', 11, 1, 11, 18, '2022-12-28', NULL, 108),
(33, 1, 'Kamil MERT', '555-555-55-55', 7, 'Erik', 'Meyve', 19, 4, 78, 18, '2022-12-28', NULL, 109),
(34, 1, 'Kamil MERT', '555-555-55-55', 4, 'Karpuz', 'Meyve', 9, 5, 46, 18, '2022-12-28', NULL, 110),
(35, 1, 'Kamil MERT', '555-555-55-55', 8, 'Balıkesir Elması', 'Meyve', 10000, 400, 4000000, 18, '2022-12-28', NULL, 111),
(36, 1, 'Kamil MERT', '555-555-55-55', 3, 'Elma', 'Meyve', 11, 2, 23, 18, '2023-01-03', NULL, 112),
(37, 1, 'Kamil MERT', '555-555-55-55', 5, 'Marul', 'Sebze', 8, 3, 24, 18, '2023-01-03', NULL, 113),
(38, 2, 'John Doe', '555-555-55-55', 4, 'Karpuz', 'Meyve', 9, 3, 28, 18, '2023-01-03', NULL, 115);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `surname` varchar(255) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `mail` varchar(255) NOT NULL,
  `phone` varchar(255) NOT NULL,
  `rank` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `users`
--

INSERT INTO `users` (`id`, `name`, `surname`, `username`, `password`, `mail`, `phone`, `rank`) VALUES
(5, 'test', 'test', 'test', 'o/pLcsD9nDY=', 'kamil_mert_043@hotmail.com', 'tested', '5'),
(7, ' deneme1', 'deneme1', 'deneme1', 'FA1SUXQ/4jU=', 'deneme124@hotmail.com', 'deneme1', 'deneme1'),
(8, 'deneme2', 'deneme2', 'deneme2', 'LWUUlTeQOOc=', 'deneme1@hotmail.com', 'deneme2', 'deneme2'),
(9, 'demo', 'tested', 'demo', 'o/pLcsD9nDY=', 'demo@demo.com', 'demod', '5'),
(10, 'test', 'test', 'test3', 'o/pLcsD9nDY=', 'test@tested.com', '054444444444', '3');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `carts`
--
ALTER TABLE `carts`
  ADD PRIMARY KEY (`id`),
  ADD KEY `customerID` (`customerID`),
  ADD KEY `phoneID` (`productID`);

--
-- Tablo için indeksler `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `lostpassword`
--
ALTER TABLE `lostpassword`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `productss`
--
ALTER TABLE `productss`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `products_name`
--
ALTER TABLE `products_name`
  ADD PRIMARY KEY (`id`),
  ADD KEY `typeID` (`typeID`);

--
-- Tablo için indeksler `products_type`
--
ALTER TABLE `products_type`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `sales`
--
ALTER TABLE `sales`
  ADD PRIMARY KEY (`id`),
  ADD KEY `customerID` (`customerID`),
  ADD KEY `productID` (`productID`),
  ADD KEY `CartID` (`CartID`);

--
-- Tablo için indeksler `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `mail` (`mail`),
  ADD UNIQUE KEY `phone` (`phone`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `carts`
--
ALTER TABLE `carts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=117;

--
-- Tablo için AUTO_INCREMENT değeri `customers`
--
ALTER TABLE `customers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Tablo için AUTO_INCREMENT değeri `lostpassword`
--
ALTER TABLE `lostpassword`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Tablo için AUTO_INCREMENT değeri `productss`
--
ALTER TABLE `productss`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Tablo için AUTO_INCREMENT değeri `products_name`
--
ALTER TABLE `products_name`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Tablo için AUTO_INCREMENT değeri `products_type`
--
ALTER TABLE `products_type`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tablo için AUTO_INCREMENT değeri `sales`
--
ALTER TABLE `sales`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;

--
-- Tablo için AUTO_INCREMENT değeri `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Dökümü yapılmış tablolar için kısıtlamalar
--

--
-- Tablo kısıtlamaları `products_name`
--
ALTER TABLE `products_name`
  ADD CONSTRAINT `products_name_ibfk_1` FOREIGN KEY (`typeID`) REFERENCES `products_type` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Tablo kısıtlamaları `sales`
--
ALTER TABLE `sales`
  ADD CONSTRAINT `sales_ibfk_1` FOREIGN KEY (`productID`) REFERENCES `productss` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `sales_ibfk_2` FOREIGN KEY (`customerID`) REFERENCES `customers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
