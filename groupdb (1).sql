-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 23, 2024 at 08:59 AM
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
-- Database: `groupdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `ID` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `number` bigint(11) NOT NULL,
  `remarks` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`ID`, `name`, `address`, `number`, `remarks`) VALUES
(1, 'Jean Clark', 'Paris, France', 9831237582, 'Loves clothes'),
(2, 'Calix Damien', 'Florida, USA', 9881736682, 'Often calls for hardware supplies'),
(3, 'Kyle Migalang', 'Mabalacat, Pampanga', 9875643712, 'Techy'),
(4, 'Sophia Galvez', 'Ottawa, Canada', 9637200301, 'Skincare enthusiast'),
(5, 'Jazmin Dela Cruz', 'Mabalacat, Pampanga', 9842374823, 'Food vlogger'),
(6, 'Hiro Hamada', 'Tokyo, Japan', 9323848921, 'Genius, Robotics enthusiast');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `ID` int(11) NOT NULL,
  `SN` bigint(20) NOT NULL,
  `name` varchar(255) NOT NULL,
  `category` varchar(255) NOT NULL,
  `price` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `description` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`ID`, `SN`, `name`, `category`, `price`, `quantity`, `description`) VALUES
(1, 123123, 'Chocolate', 'Food', 150, 123, 'Yummy,very good!'),
(2, 74732, 'Television', 'Gadget', 15000, 10, 'For entertainment purposes'),
(3, 378123, 'Body Soap', 'Hygiene', 60, 456, 'Cleanses the skin and deeply moisturizes it'),
(4, 127863871, 'T-shirt', 'Clothing', 4000, 28, 'Luxury clothing\r\n'),
(5, 12361872, 'Hammer', 'Hardware', 250, 40, 'Used in construction'),
(6, 1237812638, 'Dutchmill Proyo', 'Food', 60, 424, 'Nice yogurt drink'),
(8, 123321, 'Dutchmill', 'Food', 15, 312, 'Favorite!');

-- --------------------------------------------------------

--
-- Table structure for table `suppliers`
--

CREATE TABLE `suppliers` (
  `ID` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `number` bigint(11) NOT NULL,
  `remarks` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `suppliers`
--

INSERT INTO `suppliers` (`ID`, `name`, `address`, `number`, `remarks`) VALUES
(1, 'Regal Supplies', 'Mabalacat, Pampanga', 9712345678, 'Hardware supply'),
(2, 'Pearl Market', 'Angeles, Pampanga', 9781237432, 'Food supply'),
(3, 'Big Market', 'Bamban, Tarlac', 9874237432, 'Clothing supply'),
(4, 'Rentoor', 'Magalang, Pampanga', 9811107092, 'Hygiene supply'),
(5, 'Dark Market', 'San Fernando, Pampanga', 9812310809, 'Gadget supply'),
(6, 'Samsung PH', 'Clark, Pampanga', 9283748929, 'Gadget supply');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `ID` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `role` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`ID`, `username`, `password`, `name`, `role`) VALUES
(1, 'admin', 'admin', 'Admin Account', 'Admin'),
(2, 'admin1', '123123', 'Kyle Migalang', 'Manager'),
(4, 'admin2', 'admin2', 'Sophia Galvez', 'Employee');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `suppliers`
--
ALTER TABLE `suppliers`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `suppliers`
--
ALTER TABLE `suppliers`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
