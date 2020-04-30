-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: nostrumex
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clients` (
  `Name` varchar(30) NOT NULL,
  `Phone` varchar(15) DEFAULT NULL,
  `Display_Name` varchar(10) NOT NULL,
  `Address` varchar(300) DEFAULT NULL,
  `TIN_No` varchar(20) DEFAULT NULL,
  `DL_No` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Display_Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_line_items`
--

DROP TABLE IF EXISTS `order_line_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_line_items` (
  `Order_Id` varchar(10) NOT NULL,
  `FY` varchar(4) NOT NULL,
  `S_No` int NOT NULL,
  `Product_Name` varchar(25) NOT NULL,
  `Batch` varchar(25) NOT NULL,
  `Offer1` int DEFAULT NULL,
  `Offer2` int DEFAULT NULL,
  `Pack1` int DEFAULT NULL,
  `Pack2` int DEFAULT NULL,
  `Quantity` int DEFAULT NULL,
  `Rate` double DEFAULT NULL,
  KEY `Order-Key_idx` (`Order_Id`,`FY`),
  KEY `Order-Product-Key_idx` (`Product_Name`,`Batch`),
  CONSTRAINT `Order-Key` FOREIGN KEY (`Order_Id`, `FY`) REFERENCES `orders` (`Order_Id`, `FY`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `Order-Product-Key` FOREIGN KEY (`Product_Name`, `Batch`) REFERENCES `products` (`Name`, `Batch`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_line_items`
--

LOCK TABLES `order_line_items` WRITE;
/*!40000 ALTER TABLE `order_line_items` DISABLE KEYS */;
/*!40000 ALTER TABLE `order_line_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `Order_Id` varchar(10) NOT NULL,
  `FY` varchar(4) NOT NULL,
  `Order_Date` datetime NOT NULL,
  `Dispatch_Mode` varchar(10) NOT NULL,
  `Client_Name` varchar(45) NOT NULL,
  `Amount` double DEFAULT NULL,
  `Discount` double DEFAULT NULL,
  `Payment_Terms` int NOT NULL DEFAULT '30',
  `Order_Type` enum('Sale','Donate') NOT NULL DEFAULT 'Sale',
  PRIMARY KEY (`Order_Id`,`FY`),
  KEY `Order_Client_idx` (`Client_Name`),
  CONSTRAINT `Order_Client` FOREIGN KEY (`Client_Name`) REFERENCES `clients` (`Display_Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payments`
--

DROP TABLE IF EXISTS `payments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payments` (
  `Order_ID` varchar(10) NOT NULL,
  `FY` varchar(4) NOT NULL,
  `Payment` double NOT NULL,
  `Pay_Date` double NOT NULL,
  KEY `Order-Payment-Key_idx` (`Order_ID`,`FY`),
  CONSTRAINT `Order-Payment-Key` FOREIGN KEY (`Order_ID`, `FY`) REFERENCES `orders` (`Order_Id`, `FY`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payments`
--

LOCK TABLES `payments` WRITE;
/*!40000 ALTER TABLE `payments` DISABLE KEYS */;
/*!40000 ALTER TABLE `payments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `Name` varchar(25) NOT NULL,
  `Batch` varchar(25) NOT NULL,
  `Drug_Type` enum('Tablet','Syrup') NOT NULL,
  `Mfg_Date` datetime NOT NULL,
  `Exp_Date` datetime NOT NULL,
  `Quantity` int NOT NULL,
  `CGST` double NOT NULL,
  `SGST` double NOT NULL,
  `MRP` double NOT NULL,
  `Manufacturer` varchar(45) DEFAULT NULL,
  `Purchase_Date` datetime NOT NULL,
  `Purchase_Invoice` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Name`,`Batch`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-04-30 22:21:26
