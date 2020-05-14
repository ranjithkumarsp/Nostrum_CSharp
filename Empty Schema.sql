CREATE DATABASE  IF NOT EXISTS `nostrumex` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `nostrumex`;
-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: nostrumex
-- ------------------------------------------------------
-- Server version	8.0.20

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
  `Type` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Display_Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `order_line_items`
--

DROP TABLE IF EXISTS `order_line_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_line_items` (
  `Order_Id` int NOT NULL,
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
  PRIMARY KEY (`Order_Id`,`FY`,`S_No`),
  KEY `Order-Key_idx` (`Order_Id`,`FY`),
  KEY `Order-Product-Key_idx` (`Product_Name`,`Batch`),
  CONSTRAINT `Order-Key` FOREIGN KEY (`Order_Id`, `FY`) REFERENCES `orders` (`Order_Id`, `FY`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `Order-Product-Key` FOREIGN KEY (`Product_Name`, `Batch`) REFERENCES `products` (`Name`, `Batch`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `Reduce_Stock` AFTER INSERT ON `order_line_items` FOR EACH ROW BEGIN
declare `saleqty` int;
set `saleqty` = NEW.quantity;
if (NEW.offer1 <> 0) then
	set `saleqty` = `saleqty` / NEW.offer1;
	set `saleqty` = `saleqty` * (NEW.offer1 + NEW.offer2);
end if;
if (NEW.pack2 <> 0) then
	set `saleqty` = `saleqty` * NEW.pack1 * NEW.pack2;
end if;
update stock set qty = qty - `saleqty` where product=NEW.Product_Name and batch=NEW.batch;

END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `UpdateStock` AFTER UPDATE ON `order_line_items` FOR EACH ROW BEGIN
declare `newsaleqty` int;
declare `oldsaleqty` int;
declare `saleqty` int;

set `newsaleqty` = NEW.quantity;
if (NEW.offer1 <> 0) then
	set `newsaleqty` = `newsaleqty` / NEW.offer1;
	set `newsaleqty` = `newsaleqty` * (NEW.offer1 + NEW.offer2);
end if;
if (NEW.pack2 <> 0) then
	set `newsaleqty` = `newsaleqty` * NEW.pack1 * NEW.pack2;
end if;

set `oldsaleqty` = OLD.quantity;
if (OLD.offer1 <> 0) then
	set `oldsaleqty` = `oldsaleqty` / OLD.offer1;
	set `oldsaleqty` = `oldsaleqty` * (OLD.offer1 + OLD.offer2);
end if;
if (OLD.pack2 <> 0) then
	set `oldsaleqty` = `oldsaleqty` * OLD.pack1 * OLD.pack2;
end if;
set `saleqty` = `newsaleqty`-`oldsaleqty`;
update stock set qty = qty - `saleqty` where product=NEW.product_name and batch=NEW.batch;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `Refill_Stock` AFTER DELETE ON `order_line_items` FOR EACH ROW BEGIN
declare `saleqty` int;
set `saleqty` = OLD.quantity;
if (OLD.offer1 <> 0) then
	set `saleqty` = `saleqty` / OLD.offer1;
	set `saleqty` = `saleqty` * (OLD.offer1 + OLD.offer2);
end if;
if (OLD.pack2 <> 0) then
	set `saleqty` = `saleqty` * OLD.pack1 * OLD.pack2;
end if;
update stock set qty = qty + `saleqty` where product=OLD.product_name and batch=OLD.batch;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `Order_Id` int NOT NULL,
  `FY` varchar(4) NOT NULL,
  `Order_Date` date NOT NULL,
  `Order_Type` enum('Donate','Sale') NOT NULL DEFAULT 'Sale',
  `Client_Name` varchar(45) NOT NULL,
  `Amount` int DEFAULT '0',
  `Balance` int DEFAULT '0',
  `Discount` double DEFAULT '0',
  `Payment_Terms` varchar(10) NOT NULL DEFAULT '30',
  `Dispatch_Mode` varchar(10) NOT NULL,
  PRIMARY KEY (`Order_Id`,`FY`),
  KEY `Order_Client_idx` (`Client_Name`),
  CONSTRAINT `Order_Client` FOREIGN KEY (`Client_Name`) REFERENCES `clients` (`Display_Name`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `orders_BEFORE_DELETE` BEFORE DELETE ON `orders` FOR EACH ROW BEGIN
	Delete from order_line_items where order_line_items.Order_Id = Old.Order_id and order_line_items.FY = Old.FY;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `payments`
--

DROP TABLE IF EXISTS `payments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payments` (
  `Payment_ID` int NOT NULL AUTO_INCREMENT,
  `Order_ID` int NOT NULL,
  `FY` varchar(4) NOT NULL,
  `Payment` int NOT NULL,
  `Pay_Date` date NOT NULL,
  PRIMARY KEY (`Payment_ID`),
  KEY `Order-Payment-Key_idx` (`Order_ID`),
  KEY `Order-Payment-Key_idx1` (`Order_ID`,`FY`),
  CONSTRAINT `Order-Payment-Key` FOREIGN KEY (`Order_ID`, `FY`) REFERENCES `orders` (`Order_Id`, `FY`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `payments_AFTER_INSERT` AFTER INSERT ON `payments` FOR EACH ROW BEGIN
	DECLARE `balance` INT;
    SET `balance` = (SELECT orders.Balance FROM orders WHERE orders.Order_Id = NEW.Order_Id AND orders.fy = NEW.fy);
    SET `balance` = `balance` - NEW.payment;
    UPDATE orders SET balance = `balance` WHERE orders.order_id = NEW.order_id AND orders.fy = NEW.fy;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `Name` varchar(25) NOT NULL,
  `Batch` varchar(25) NOT NULL,
  `Drug_Type` enum('Tablet','Syrup','Capsule','Suspension') NOT NULL,
  `Mfg_Date` datetime NOT NULL,
  `Exp_Date` datetime NOT NULL,
  `Pack1` int DEFAULT NULL,
  `Pack2` int DEFAULT NULL,
  `Quantity` int NOT NULL,
  `CGST` double NOT NULL,
  `SGST` double NOT NULL,
  `MRP` double NOT NULL,
  `Manufacturer` varchar(45) DEFAULT NULL,
  `Purchase_Date` date NOT NULL,
  `Purchase_Invoice` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Name`,`Batch`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `Create_Stock` AFTER INSERT ON `products` FOR EACH ROW BEGIN
SET @quantity = new.quantity;
if new.Drug_Type like 'Tablet' or new.Drug_Type like 'Capsule'
Then
	SET @quantity = @quantity * new.Pack1 * new.Pack2;
End if;
insert into stock values(new.Name,new.batch,@quantity);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `Update_Stock` AFTER UPDATE ON `products` FOR EACH ROW BEGIN
	declare `oldqty` int;
	declare `newqty` int;
	declare `qtydiff` int;

	if ((strcmp(old.Drug_Type, 'Tablet') = 0) or (strcmp(old.Drug_Type,'Capsule') = 0))
	then
		SET `oldqty` = old.quantity * old.pack1 * old.pack2;
	else
		SET `oldqty` = old.quantity;
	end if;

	if ((strcmp(New.Drug_Type, 'Tablet') = 0) or (strcmp(New.Drug_Type,'Capsule') = 0))
	then
		SET `newqty` = new.quantity * new.pack1 * new.pack2;
	else
		SET `newqty` = new.quantity;
	end if;

	set `qtydiff` = `newqty` - `oldqty`;
	update stock set qty = qty + `qtydiff` where Product=NEW.name and batch=NEW.batch;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `Remove_Stock` AFTER DELETE ON `products` FOR EACH ROW BEGIN
delete from stock where Product=OLD.name and batch=OLD.batch;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `stock`
--

DROP TABLE IF EXISTS `stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stock` (
  `Product` varchar(45) NOT NULL,
  `Batch` varchar(45) NOT NULL,
  `Qty` int DEFAULT NULL,
  PRIMARY KEY (`Product`,`Batch`),
  CONSTRAINT `Stock_product_key` FOREIGN KEY (`Product`, `Batch`) REFERENCES `products` (`Name`, `Batch`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping events for database 'nostrumex'
--

--
-- Dumping routines for database 'nostrumex'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-05-14 20:59:25
