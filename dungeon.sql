-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Mar 09, 2018 at 01:50 AM
-- Server version: 5.6.35
-- PHP Version: 7.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dungeon`
--
CREATE DATABASE IF NOT EXISTS `dungeon` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `dungeon`;

-- --------------------------------------------------------

--
-- Table structure for table `contents`
--

CREATE TABLE `contents` (
  `id` int(11) NOT NULL,
  `rooms` int(11) NOT NULL,
  `items` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `contents`
--

INSERT INTO `contents` (`id`, `rooms`, `items`) VALUES
(21, 7, 6),
(45, 3, 3),
(46, 3, 3),
(47, 3, 3),
(48, 3, 3),
(51, 6, 7),
(52, 0, 7),
(53, 10, 3),
(55, 6, 2),
(57, 7, 4);

-- --------------------------------------------------------

--
-- Table structure for table `inventory`
--

CREATE TABLE `inventory` (
  `id` int(11) NOT NULL,
  `items` int(11) NOT NULL,
  `pcs` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `inventory`
--

INSERT INTO `inventory` (`id`, `items`, `pcs`) VALUES
(32, 5, 2),
(33, 5, 2),
(35, 5, 2),
(36, 4, 2),
(39, 5, 2),
(40, 5, 2),
(41, 5, 2),
(42, 2, 2),
(43, 1, 2);

-- --------------------------------------------------------

--
-- Table structure for table `items`
--

CREATE TABLE `items` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `type` varchar(255) NOT NULL,
  `special` varchar(255) NOT NULL,
  `magic` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `items`
--

INSERT INTO `items` (`id`, `name`, `type`, `special`, `magic`) VALUES
(1, 'Nasty Sword', 'Weapon', '+5 Vorpal', 1),
(2, 'Suit of Shiny Armor', 'Armor', '+5', 1),
(3, 'Suit of Armor', 'Armor', 'Rusty', 1),
(4, 'Long, gnarled twig', 'Stick', '@=\"Magic Wand of Fireball\"', 0),
(5, 'Pile of Gold Pieces', 'treasure', 'A pile of gold coins. $50', 0),
(6, 'Pile of Gems', 'Treasure', 'A pretty pile of rubies and emeralds. $50', 0),
(7, 'Pile of Bones', 'Corpse', 'This is a pile of some sort of humanoid bones.', 0);

-- --------------------------------------------------------

--
-- Table structure for table `loot`
--

CREATE TABLE `loot` (
  `id` int(11) NOT NULL,
  `items` int(11) NOT NULL,
  `npcs` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `npcs`
--

CREATE TABLE `npcs` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `type` varchar(255) NOT NULL,
  `hp` int(11) NOT NULL,
  `ac` int(11) NOT NULL,
  `damage` int(11) NOT NULL,
  `lvl` int(11) NOT NULL,
  `room_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `npcs`
--

INSERT INTO `npcs` (`id`, `name`, `type`, `hp`, `ac`, `damage`, `lvl`, `room_id`) VALUES
(1, 'Snarling Orc', 'Monster', 1, 10, 6, 1, 2),
(2, 'Terrible, stinky Ogre', 'Monster', 0, 6, 6, 3, -1);

-- --------------------------------------------------------

--
-- Table structure for table `pcs`
--

CREATE TABLE `pcs` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `type` varchar(255) NOT NULL,
  `hp` int(11) NOT NULL,
  `ac` int(11) NOT NULL,
  `damage` int(11) NOT NULL,
  `lvl` int(11) NOT NULL,
  `exp` int(11) NOT NULL,
  `room_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `pcs`
--

INSERT INTO `pcs` (`id`, `name`, `type`, `hp`, `ac`, `damage`, `lvl`, `exp`, `room_id`) VALUES
(1, 'Not Empty', 'Dragon Librarian\'s Butt', 0, 333, 2, 1, 0, 2),
(2, 'Fred the Knight', 'Fighter', -1, 6, 10, 1, 0, 2),
(3, 'James Orcus', 'Package Swiffer', 14, 0, 3, 44, 0, 5),
(4, 'Joe the Mountain', 'Ninja Sculpture', 44, 222, 0, 63, 3500, 33),
(5, 'Derf The Straggler', 'Monk', 14, 6, 8, 1, 100, 1);

-- --------------------------------------------------------

--
-- Table structure for table `rooms`
--

CREATE TABLE `rooms` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `short_description` varchar(255) NOT NULL,
  `full_description` text NOT NULL,
  `light` tinyint(1) NOT NULL,
  `commands` varchar(255) NOT NULL,
  `RoomMapId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `rooms`
--

INSERT INTO `rooms` (`id`, `name`, `short_description`, `full_description`, `light`, `commands`, `RoomMapId`) VALUES
(1, 'The Foyer', 'An entryway into the dungeon.', 'A dank, smelly entryway. It leads into a long, dark corridor that seems to slope downwards. Cobwebs reach for you from the ceiling.', 1, 'Search, Look, Describe, Use', 1),
(2, 'lil Meat Locker', 'This is the room where they keep some meat.', 'A room of naked stone walls dripping with moisture, clumped with lichens, mushrooms, and green slime in places. It smells like rot to match the decaying carcasses of several unknown animals hung on a few hooks descending from a strange rack system of corroded rails running an odd network across the ceiling.', 1, 'Search, Get, Examine, Move', 2),
(3, 'Anteroom', 'This is more an alcove than a room.', 'A tiny dusty alcove that is basically a corner hallway converted to a sleeping room as indicated by the filthy straw mat on the ground.', 1, 'test', 3),
(4, 'Trophy Room', 'This is a room where someone keeps their trophies.', 'This strange room is filled from top to bottom with cabinets and tables. The heads and badly stuffed corpses of all kinds of animals litter the room and hang off the walls.', 1, 'Scream', 4),
(5, 'Hallway', 'This is a long hallway.', 'There is nothing of note about this hallway except for maybe a bit of slime here and there.', 1, 'Move', 5),
(6, 'Dining Hall', 'A small room with crude tables and a cooking fire.', 'This is the room where the denizens of the dungeon meet to talk and eat. It smells unpleasant to say the least. They don\'t clean up after themselves!', 1, 'Get, Eat', 6),
(7, 'Throne Room', 'A throne room.', 'A really really big throne room.', 1, 'Sit', 7),
(8, 'Chamber of Sorrows', 'The torture chamber', 'This is a large, square room with hanging cages, skeletons shackled to the walls, and a fire pit holding various evil implements heating up for use.', 1, 'Flee', 8),
(9, 'Creepy Attic', 'A dusty attic full of stale air and dangerous footing.', 'A dusty, dank, attic with water stains in the corners and rotted wood beams caving in part of the ceiling.', 1, 'SEARCH', 9),
(10, 'Secret Room', 'A tiny little room where someone stashed their treasures for safe keeping.', 'You can cross through a tiny door and enter this chamber, but it\'s so small it\'s easier to just reach in and grab for stuff. ', 1, 'SEARCH', 10);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `contents`
--
ALTER TABLE `contents`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `inventory`
--
ALTER TABLE `inventory`
  ADD PRIMARY KEY (`id`),
  ADD KEY `items` (`items`),
  ADD KEY `pcs` (`pcs`);

--
-- Indexes for table `items`
--
ALTER TABLE `items`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `loot`
--
ALTER TABLE `loot`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `npcs`
--
ALTER TABLE `npcs`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `room_id` (`room_id`),
  ADD UNIQUE KEY `room_id_2` (`room_id`);

--
-- Indexes for table `pcs`
--
ALTER TABLE `pcs`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `rooms`
--
ALTER TABLE `rooms`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `contents`
--
ALTER TABLE `contents`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=58;
--
-- AUTO_INCREMENT for table `inventory`
--
ALTER TABLE `inventory`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;
--
-- AUTO_INCREMENT for table `items`
--
ALTER TABLE `items`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `loot`
--
ALTER TABLE `loot`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `npcs`
--
ALTER TABLE `npcs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `pcs`
--
ALTER TABLE `pcs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `rooms`
--
ALTER TABLE `rooms`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `inventory`
--
ALTER TABLE `inventory`
  ADD CONSTRAINT `inventory_ibfk_1` FOREIGN KEY (`items`) REFERENCES `items` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `inventory_ibfk_2` FOREIGN KEY (`pcs`) REFERENCES `pcs` (`id`) ON DELETE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
