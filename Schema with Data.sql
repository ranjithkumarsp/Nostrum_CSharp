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
  `Name` varchar(50) NOT NULL,
  `Phone` varchar(15) DEFAULT NULL,
  `Display_Name` varchar(30) NOT NULL,
  `Address` varchar(300) DEFAULT NULL,
  `TIN_No` varchar(50) DEFAULT NULL,
  `DL_No` varchar(50) DEFAULT NULL,
  `Type` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Display_Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES ('DR RAVENDRAN','9080088743','DR RAVENDRAN','ACHARAPAKKAM','','','Doctor'),('RAAJ MEDICALS & GENERALS','','DR SURESH PAVUNJUR','BAZZAR STREET\r\nPAVUNJUR','','','Pharmacist'),('DR.Hemnath .P','9003929916','DR.Hemnath','74-B/4, Pallikooda Street,\r\nV.A.K Nagar,\r\nArni - 632301','','104920','Doctor'),('DR.Lakshminarayanan','0422-2580123','DR.Lakshminarayanan','2, West Street, Agraharam,\r\nSinganallur,\r\nCoimbatore - 641005','','34700','Doctor'),('DR.MAMATHA','9942116932','DR.MAMATHA CLINIC','ARNI','','84127','Doctor'),('DR.Monisha','','DR.Monisha','Barathiyar Street,\r\nThiruvotriur','','','Doctor'),('DR.Rani','0422-2597201','DR.Rani','No: 2, Annaiyagadu Road,\r\nSinganallur,\r\nCoimbatore - 641005','','','Doctor'),('DR.Senthil Kumar','','DR.Senthil Kumar','29/1 - C TVS Road,\r\nRasipuram','','','Doctor'),('DR.Sindu Rekha','','DR.Sindu Rekha','Padma Nursing Home,\r\nArni','','','Doctor'),('DR.Venkatesh','','DR.Venkatesh Melmalaiyanur','Melmalaiyanur','','','Doctor'),('Durga Medicals','','Durga Medicals','ARNI','33624563358',' 06/VLT/363/20.21','Pharmacist'),('Ganesh Medicals','','Ganesh Medicals','1163/B3, ACS Nagar, E.B Nagar,\r\nSevoor,\r\nArni - 632316','','VLT/342/20-21','Pharmacist'),('Jaya Medicals','','Jaya Medicals','Cheyyur','33221680059','290/292C','Pharmacist'),('Kumar Medicals','04173-223251','Kumar Medical','Arni','33BSGPS6315H1ZO','06/VLT 156/20/21','Pharmacist'),('Nathan Pharmacy','9443038927','Nathan Pharmacy','No: 78, Arni Road,\r\nChetpet - 606801','33ADXPA5585G1Z9','66/65W/20-21','Pharmacist'),('Oliviya Medicals','9962528378','Oliviya Medicals','232/1, Bharathiyar Street,\r\nHariharan Nagar, \r\nIrumbedu - 632317\r\nArni','','06/VLT/1670/20/21','Pharmacist'),('GNANAVEL MEDIVALS','04367252457','RAAJ HOSPI','10, BALAKRISHNA STREET,\r\nMANNARGUDI 614001\r\n','33AFXPR3290M1ZL','TJT/2749/20/21','Pharmacist'),('Sathya Medical Center','0422-2496989','SMC','60 AB, Tatabad 1st Street,\r\nSivanandha Colony,\r\nCoimbatore - 12','33BNSPS4865F1F','CBE/7252/20-21','Pharmacist'),('Sri Sugam Medicals','','Sri Sugam Medicals','5C, R.K Pettai,\r\nARNI','33946327515','VLT/2058/20&21','Pharmacist'),('VINAYAGAR MEDICAL HALL','','VMH','840, EAST MAIN STREET,\r\nPUDUKKOTAI','33AAEPA5027B2ZM','','Pharmacist');
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_line_items`
--

DROP TABLE IF EXISTS `order_line_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_line_items` (
  `Order_Id` double NOT NULL,
  `FY` varchar(4) NOT NULL,
  `S_No` int NOT NULL,
  `Product_Name` varchar(25) NOT NULL,
  `Batch` varchar(25) NOT NULL,
  `Offer1` int DEFAULT NULL,
  `Offer2` int DEFAULT NULL,
  `Pack1` int DEFAULT NULL,
  `Pack2` int DEFAULT NULL,
  `Quantity` double DEFAULT NULL,
  `Rate` double DEFAULT NULL,
  PRIMARY KEY (`Order_Id`,`FY`,`S_No`),
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
INSERT INTO `order_line_items` VALUES (1,'2016',1,'NOSPAR PLUS','HLTS 1138',1,1,10,1,10,28),(1,'2017',1,'NOSPAR PLUS','CFT-042',1,1,10,1,20,28),(1,'FY16',1,'LEVONOX 500','NXB-01',1,1,10,10,12,555),(1,'FY17',1,'NOSPROVIT','MFL 18316',1,1,200,0,12,67.5),(2,'2016',1,'NOXIME 100','HLTS 1877',1,1,10,1,45,19),(2,'2016',2,'LEVONOX 500','NXB-01',1,1,10,1,50,6),(2,'2017',1,'NOSCAL D3','NNN-01',2,3,1,10,20,35.6),(2,'FY17',1,'NOSPAR PLUS','HLTS 1138',1,1,10,20,5,595),(3,'2016',1,'NOSPROVIT','MFL 18315',0,0,200,0,24,32),(3,'2017',1,'NOXIME 100','CFT-040',1,1,10,1,45,19),(3,'2017',2,'LEVONOX 500','NXB-02',1,1,10,1,20,6),(3,'FY17',1,'NOSCAL D3','NNN-01',2,3,10,1,8,36),(4,'2016',1,'NOSCAL D3','NNN-01',2,3,10,1,8,36),(4,'2017',1,'NOSPAR PLUS','CFT-042',1,1,10,20,1,560),(4,'FY17',1,'NOXIME 100','HLTS 1877',1,1,10,1,55,68.87),(5,'2016',1,'NOSCAL D3','NNN-01',1,1,10,10,5,320),(5,'2017',1,'AZINOS 500','NAN-01',2,1,10,1,42,148),(5,'FY17',1,'NOSCAL D3','NNN-01',1,1,10,10,5,360),(6,'2016',1,'NOSPROVIT','MFL 18315',0,0,200,0,24,32),(6,'2017',1,'NOSCAL D3','NNN-01',2,3,10,1,12,35.6),(6,'FY17',1,'NOSCAL D3','NNN-01',2,3,10,1,8,36),(6,'FY17',2,'NOSPROVIT','MFL 18316',0,0,200,0,10,50),(7,'2016',1,'LEVONOX 500','NXB-01',1,1,10,10,12,555),(7,'2017',1,'LEVONOX 500','NXB-02',1,1,10,10,15,565),(7,'FY17',1,'LEVONOX 500','NXB-01',1,1,10,10,13,555),(8,'2016',1,'AZINOS 500','NAN-01',2,1,10,10,10,1480),(8,'2017',1,'NOSCAL D3','NNN-01',2,3,10,1,12,35.6),(8,'FY17',1,'NOSPROVIT','MFL 18316',0,0,200,0,24,32),(9,'2016',1,'NOSPROVIT','MFL 18315',1,1,200,0,10,67.5),(9,'2017',1,'NOSPROVIT','MFL 10901',0,0,200,0,24,39),(9,'FY17',1,'NOSCAL D3','NNN-01',1,1,10,10,5,360),(10,'2016',1,'NOSPAR PLUS','HLTS 1138',7,3,10,1,28,28),(10,'2017',1,'NOSCAL D3','NNN-01',2,3,10,1,12,35.6),(10,'FY17',1,'NOXIME 100','HLTS 1877',1,1,10,1,45,19),(10,'FY17',2,'LEVONOX 500','NXB-01',1,1,10,1,20,6),(11,'2016',1,'NOXIME 100','HLTS 1877',1,1,10,1,30,19),(11,'2016',2,'LEVONOX 500','NXB-01',1,1,10,1,20,6),(11,'2017',1,'NOSPAR PLUS','CFT-042',1,1,20,10,5,570),(11,'FY17',1,'NOSPAR PLUS','HLTS 1138',1,1,10,20,1,200),(11,'FY17',2,'NOXIME 100','HLTS 1877',1,1,15,10,1,540),(12,'2016',1,'NOSCAL D3','NNN-01',2,3,10,1,4,36),(12,'2016',2,'NOSPROVIT','MFL 18315',0,0,200,0,10,50),(12,'2017',1,'NOXIME 100','CFT-040',1,1,10,15,2,285),(12,'FY17',1,'NOSPAR PLUS','HLTS 1138',7,3,10,1,28,28),(13,'2016',1,'NOSPAR PLUS','HLTS 1138',1,1,10,1,20,28),(13,'2016',2,'LEVONOX 500','NXB-01',1,1,10,1,20,55.6),(13,'2017',1,'NOXIME 100','CFT-040',1,1,10,1,45,19),(13,'2017',2,'LEVONOX 500','NXB-02',1,1,10,1,20,6),(13,'FY17',1,'NOXIME 100','HLTS 1877',1,1,10,1,15,69),(13,'FY17',2,'AZINOS 500','NAN-01',2,1,10,1,14,148),(13,'FY17',3,'NOSCAL D3','NNN-01',1,1,10,1,5,32),(13,'FY17',4,'NOSPROVIT','MFL 18316',1,1,200,0,5,67.8),(14,'2016',1,'NOSCAL D3','NNN-01',2,3,10,1,8,36),(14,'2017',1,'NOSPAR PLUS','CFT-042',7,3,10,1,28,28),(14,'FY17',1,'NOSCAL D3','NNN-01',2,3,10,1,8,36),(14,'FY17',2,'NOSPROVIT','MFL 18316',0,0,200,0,10,50),(15,'2016',1,'NOSPROVIT','MFL 18315',0,0,200,0,24,32),(15,'2017',1,'NOXIME 100','CFT-040',1,1,10,15,3,1085),(15,'2017',2,'NOSPAR PLUS','CFT-042',1,1,20,10,3,595),(15,'FY17',1,'NOSCAL D3','NNN-01',2,3,10,1,4,36),(16,'2016',1,'LEVONOX 500','NXB-01',1,1,10,10,12,555),(16,'2017',1,'NOSPROVIT','MFL 10901',1,1,200,0,5,74.8),(16,'FY17',1,'NOXIME 100','HLTS 1877',1,1,10,1,30,19),(16,'FY17',2,'LEVONOX 500','NXB-01',1,1,10,1,20,6),(17,'2016',1,'NOSCAL D3','NNN-01',2,3,10,1,8,36),(17,'2017',1,'NOSCAL D3','NNN-01',2,3,10,1,12,35.6),(17,'2017',2,'NOSPROVIT','MFL 18316',1,1,200,0,12,50),(17,'FY17',1,'NOSPROVIT','MFL 18316',0,0,200,0,24,32),(18,'2016',1,'NOSPROVIT','MFL 18315',1,1,200,0,6,67.5),(18,'2017',1,'NOSCAL D3','NNN-01',1,1,10,10,5,337),(18,'FY17',1,'NOSCAL D3','NNN-01',1,1,10,10,5,360),(19,'2016',1,'NOSPROVIT','MFL 18315',0,0,200,0,24,32),(19,'2017',1,'NOSCAL D3','NNN-01',2,3,10,1,12,35.6),(19,'FY17',1,'NOSPROVIT','MFL 18316',1,1,200,0,14,67.5),(19,'FY17',2,'NOSCAL D3','NNN-01',1,1,10,1,75,32),(20,'2016',1,'NOXIME 100','HLTS 1877',1,1,10,1,45,19),(20,'2016',2,'LEVONOX 500','NXB-01',1,1,10,1,20,6),(20,'2017',1,'NOSPAR PLUS','CFT-042',1,1,10,1,10,28),(20,'FY17',1,'NOSPROVIT','MFL 18316',1,1,200,0,50,63.75),(21,'2016',1,'NOSPAR PLUS','HLTS 1138',7,3,10,1,28,28),(21,'2017',1,'NOSCAL D3','NNN-01',1,1,10,10,5,337),(21,'F017',1,'AZINOS 500','NAN-01',2,1,10,1,14,148),(21,'F017',2,'NOSPROVIT','MFL 18316',1,1,200,0,5,67.8),(21,'F017',3,'NOSCAL D3','NNN-01',1,1,10,1,10,32),(21,'FY17',1,'NOSCAL D3','NNN-01',2,3,10,1,16,36),(21,'FY17',2,'NOSPROVIT','MFL 18316',0,0,200,0,20,50),(22,'2016',1,'NOSPAR PLUS','HLTS 884',1,1,10,20,2,200),(22,'2017',1,'NOSPAR PLUS','CFT-042',7,3,10,1,14,28),(22,'FY17',1,'LEVONOX 500','NXB-01',1,1,10,10,6,555),(23,'2016',1,'LEVONOX 500','NXB-01',1,1,10,1,10,55.6),(23,'2017',1,'NOXIME 100','CFT-040',1,1,10,1,45,19),(23,'2017',2,'LEVONOX 500','NXB-02',1,1,10,1,20,6),(23,'FY17',1,'NOSPROVIT','MFL 18316',1,1,200,0,10,67.5),(23,'FY17',2,'NOSCAL D3','NNN-01',1,1,10,10,6,360),(24,'2016',1,'NOSCAL D3','NNN-01',2,3,10,1,8,36),(24,'2017',1,'LEVONOX 500','NXB-02',1,1,10,10,1,579),(24,'2017',2,'AZINOS 500','NAN-01',1,1,10,10,1,1573),(24,'2017',3,'NOXIME 100','CFT-040',1,1,10,15,1,1084),(24,'FY17',1,'NOSPROVIT','MFL 18316',1,1,200,0,24,69.65),(25,'2016',1,'NOSPROVIT','MFL 18315',0,0,200,0,23,32),(25,'2016',2,'NOXIME 100','HLTS 1877',2,1,10,1,10,68.85),(25,'2017',1,'LEVONOX 500','NXB-02',1,1,10,10,14,565),(26,'2016',1,'NOSPROVIT','MFL 18316',1,1,200,0,24,63.75),(26,'2017',1,'NOSPROVIT','MFL 10901',1,1,200,0,10,56),(27,'2016',1,'NOSPROVIT','MFL 18315',0,0,200,0,9,50),(27,'2017',1,'NOSPROVIT','MFL 10901',0,0,200,0,48,39),(28,'2016',1,'NOSPROVIT','MFL 18316',1,1,200,0,6,67.5),(28,'2017',1,'AZINOS 500','NAN-01',2,1,1,10,20,148),(29,'2016',1,'NOSPAR PLUS','HLTS 1138',1,1,20,10,1,630),(29,'2017',1,'NOSPROVIT','MFL 10901',1,1,200,0,24,74),(30,'2016',1,'LEVONOX 500','NXB-01',1,1,10,10,15,555),(30,'2017',1,'NOSPAR PLUS','CFT-042',1,1,1,10,30,29.75),(31,'2016',1,'NOSPROVIT','MFL 18316',0,0,200,0,24,32),(31,'2017',1,'LEVONOX 500','NXB-02',7,3,1,10,7,54.56),(31,'2017',2,'NOXIME 100','CFT-040',7,3,1,10,7,68),(32,'2016',1,'NOXIME 100','HLTS 1877',1,1,10,1,45,19),(32,'2016',2,'LEVONOX 500','NXB-01',1,1,10,1,20,6),(32,'2017',1,'NOSCAL D3','NNN-01',2,3,1,10,4,35.6),(33,'2016',1,'NOSPROVIT','MFL 18316',5,1,200,0,5,60),(33,'2017',1,'NOSPROVIT','MFL 10901',1,1,200,0,50,74),(34,'2016',1,'NOSCAL D3','NNN-01',2,3,10,1,8,36),(34,'2017',1,'NOSPROVIT','MFL 10901',1,1,200,0,10,72.25),(34,'FY16',1,'NOXIME 100','HLTS 1363',1,1,1,10,45,19),(34,'FY16',2,'LEVONOX 500','NXB-01',1,1,1,10,30,6),(35,'2017',1,'NOSCAL D3','NNN-01',1,1,10,10,5,337),(35,'FY16',1,'NOSPAR PLUS','HLTS 884',1,1,20,10,1,200),(36,'2017',1,'NOXIME 100','CFT-040',1,1,1,10,45,19),(36,'2017',2,'LEVONOX 500','NXB-02',1,1,1,10,20,6),(36,'FY16',1,'NOSPROVIT','MFL 18314',0,0,200,0,24,32),(37,'2017',1,'NOSPAR PLUS','CFT-042',7,3,1,10,14,28),(37,'FY16',1,'NOSCAL D3','HLTS 1364',2,3,1,10,8,31.5),(37,'FY16',2,'NOSPROVIT','MFL 18314',0,0,200,0,10,50),(38,'2017',1,'NOXIME 100','CFT-040',1,1,10,15,3,1085),(38,'2017',2,'NOSPAR PLUS','CFT-042',1,1,10,20,3,595),(38,'FY16',1,'NOSCAL D3','HLTS 1364',1,1,10,10,3,315),(39,'2017',1,'LEVOTRUM','CFT-214',1,1,101,10,10,680),(39,'FY16',1,'NOSPROVIT','MFL 18314',0,0,200,0,24,32),(40,'2017',1,'LEVONOX 500','NXB-02',7,3,1,10,14,54.56),(40,'FY16',1,'NOSCAL D3','HLTS 1364',1,1,10,10,1,315),(41,'2017',1,'NOSPAR PLUS','CFT-042',1,1,10,1,30,29.75),(41,'2017',2,'NOSCAL D3','NNN-01',1,1,10,1,20,32),(41,'2017',3,'LEVONOX 500','NXB-02',1,1,101,1,10,58),(41,'FY16',1,'NOSCAL D3','HLTS 1364',1,1,10,10,1,315),(41,'FY16',2,'LEVONOX 500','NXB-01',1,1,10,10,3,588),(42,'2017',1,'NOSCAL D3','NNN-01',1,1,1,10,50,32),(42,'FY16',1,'LEVONOX 500','NXB-01',1,1,10,10,13,555),(43,'2017',1,'NOSCAL D3','NNN-01',1,1,10,10,5,337),(43,'FY16',1,'NOSPAR PLUS','HLTS 1138',1,1,10,1,10,28),(44,'2017',1,'NOSCAL D3','NNN-01',2,3,1,10,24,3.56),(44,'FY16',1,'NOSPAR PLUS','HLTS 1138',1,1,10,20,1,560),(45,'2017',1,'NOSCAL D3','NNN-01',1,1,10,10,5,337),(45,'FY16',1,'NOSPROVIT','MFL 18315',1,1,200,0,24,67.5),(45.1,'FY16',1,'NOSPAR PLUS','HLTS 884',1,1,1,10,50,29.75),(45.1,'FY16',2,'NOSPAR PLUS','HLTS 1138',1,1,1,10,150,29.75),(45.1,'FY16',3,'NOSPROVIT','MFL 18315',1,1,200,0,48,67.5),(45.1,'FY16',4,'NOXIME 100','HLTS 1877',1,1,15,10,4,1032.75),(46,'2017',1,'NOSPAR PLUS','CFT-042',1,1,1,10,10,25),(46,'2017',2,'NOSPROVIT','MFL 10901',1,1,200,0,2,60),(46,'FY16',1,'NOSPROVIT','MFL 18315',0,0,200,0,24,32),(47,'2017',1,'NOSPAR PLUS','CFT-042',1,0,1,10,200,8.9),(47,'FY16',1,'NOSPROVIT','MFL 18315',0,0,200,0,10,50),(48,'2017',1,'NOSPAR PLUS','CFT-042',1,1,10,20,4,50),(48,'FY16',1,'NOSPAR PLUS','HLTS 1138',1,1,10,20,5,525),(48,'FY16',2,'LEVONOX 500','NXB-01',1,1,10,10,5,523.2),(49,'2017',1,'NOXIME 100','CFT-040',1,1,1,10,45,17),(49,'2017',2,'LEVOTRUM','CFT-214',0,0,1,10,120,7.5),(49,'FY16',1,'NOXIME 100','HLTS 1877',1,1,10,1,45,19),(49,'FY16',2,'LEVONOX 500','NXB-01',1,1,10,1,50,6),(50,'2017',1,'LEVONOX 500','NXB-02',1,1,10,10,2,545.6),(50,'FY16',1,'NOSPAR PLUS','HLTS 884',7,3,10,1,28,28),(51,'2017',1,'NOSPAR PLUS','CFT-042',1,1,20,10,5,570),(51,'2017',2,'LEVONOX 500','NXB-02',1,1,10,10,5,565),(51,'2017',3,'NOXIME 100','CFT-040',1,1,10,15,5,850),(51,'2017',4,'NOSCAL D3','NNN-01',1,1,10,10,3,280),(51,'FY16',1,'NOXIME 100','HLTS 1877',1,1,10,15,5,1033),(52,'2017',1,'AZINOS 500','NAN-01',1,1,10,10,5,1480),(52,'2017',2,'LEVOTRUM','CFT-214',1,1,10,10,5,600),(52,'2017',3,'NOSPROVIT','MFL 10901',1,1,200,0,5,68),(52,'FY16',1,'NOSPROVIT','MFL 18315',0,0,200,0,24,32),(53,'2017',1,'LEVONOX 500','NXB-02',1,1,1,10,10,58),(53,'FY16',1,'NOSPROVIT','MFL 18315',0,0,200,0,10,50),(53,'FY16',2,'NOSCAL D3','NNN-01',2,3,10,1,8,36),(54,'FY16',1,'NOSPROVIT','MFL 18315',1,1,200,0,21,67.5),(54,'FY16',2,'NOSPROVIT','MFL 18315',0,0,200,0,1,33.75),(56,'FY16',1,'NOSPROVIT','MFL 18315',0,0,200,0,30,38);
/*!40000 ALTER TABLE `order_line_items` ENABLE KEYS */;
UNLOCK TABLES;
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
declare `saleqty` double;
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
declare `newsaleqty` double;
declare `oldsaleqty` double;
declare `saleqty` double;

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
declare `saleqty` double;
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
  `Order_Id` double NOT NULL,
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

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (1,'2016','2016-11-01','Sale','Oliviya Medicals',294,294,0,'30','In Person'),(1,'2017','2017-07-05','Sale','DR.Monisha',627,627,0,'30','Courier'),(1,'FY16','2016-08-04','Sale','RAAJ HOSPI',6993,6993,0,'30','COURIER'),(1,'FY17','2017-04-04','Sale','SMC',850,850,0,'30','Courier'),(2,'2016','2016-11-02','Sale','DR SURESH PAVUNJUR',1213,0,0,'30','In Person'),(2,'2017','2017-07-18','Sale','DR.Sindu Rekha',748,748,0,'30','IN PERSON'),(2,'FY17','2017-04-05','Sale','RAAJ HOSPI',3124,3124,0,'30','Courier'),(3,'2016','2016-11-12','Sale','VMH',806,806,0,'30','Courier'),(3,'2017','2017-07-26','Sale','DR SURESH PAVUNJUR',1092,1092,0,'30','In Person'),(3,'FY17','2017-04-08','Sale','DR.Sindu Rekha',302,302,0,'30','In Person'),(4,'2016','2016-11-16','Sale','DR.Sindu Rekha',302,302,0,'30','In Porson'),(4,'2017','2017-07-28','Sale','Durga Medicals',627,627,0,'30','In Person'),(4,'FY17','2017-04-12','Sale','DR.Senthil Kumar',3977,0,0,'30','Courier'),(5,'2016','2016-12-10','Sale','DR.MAMATHA CLINIC',1680,0,0,'30','In Porson'),(5,'2017','2017-08-09','Sale','DR.Monisha',6527,6527,0,'30','Courier'),(5,'FY17','2017-04-13','Sale','SMC',1890,1890,0,'30','Courier'),(6,'2016','2020-05-16','Sale','VMH',806,806,0,'30','Courier'),(6,'2017','2017-08-12','Sale','DR.Sindu Rekha',449,449,0,'30','Courier'),(6,'FY17','2017-04-19','Sale','DR.Sindu Rekha',827,827,0,'30','In Person'),(7,'2016','2016-12-13','Sale','RAAJ HOSPI',6993,6993,0,'30','Courier'),(7,'2017','2017-08-12','Sale','RAAJ HOSPI',9492,9492,0,'30','Courier'),(7,'FY17','2017-05-10','Sale','RAAJ HOSPI',7576,7576,0,'30','Courier'),(8,'2016','2016-12-13','Sale','RAAJ HOSPI',15540,15540,0,'30','Courier'),(8,'2017','2017-08-14','Sale','DR.Sindu Rekha',449,449,0,'30','IN PERSON'),(8,'FY17','2017-05-11','Sale','VMH',806,806,0,'30','Courier'),(9,'2016','2016-12-17','Sale','SMC',709,709,0,'30','Courier'),(9,'2017','2017-08-19','Sale','RAAJ HOSPI',1048,1048,0,'30','In Person'),(9,'FY17','2017-05-11','Sale','SMC',1890,1890,0,'30','Courier'),(10,'2016','2016-12-21','Sale','Jaya Medicals',823,823,0,'30','Courier'),(10,'2017','2017-09-06','Sale','DR.Sindu Rekha',449,449,0,'30','IN PERSON'),(10,'FY17','2017-05-17','Sale','DR SURESH PAVUNJUR',1024,0,0,'30','Courier'),(11,'2016','2016-12-21','Sale','DR SURESH PAVUNJUR',724,0,0,'30','Courier'),(11,'2017','2017-09-08','Sale','RAAJ HOSPI',3192,3192,0,'30','Courier'),(11,'FY17','2017-05-17','Sale','DR RAVENDRAN',777,0,0,'30','Courier'),(12,'2016','2016-12-21','Sale','DR.Sindu Rekha',676,676,0,'30','In Person'),(12,'2017','2017-09-13','Sale','DR RAVENDRAN',638,638,0,'30','Courier'),(12,'FY17','2017-05-17','Sale','Jaya Medicals',823,823,0,'30','Courier'),(13,'2016','2016-12-23','Sale','DR.Lakshminarayanan',1756,0,0,'30','Courier'),(13,'2017','2017-09-13','Sale','DR SURESH PAVUNJUR',1092,1092,0,'30','Courier'),(13,'FY17','2017-05-27','Sale','DR.Monisha',3786,0,0,'30','Courier'),(14,'2016','2017-01-07','Sale','DR.Sindu Rekha',302,302,0,'30','In Person'),(14,'2017','2017-09-13','Sale','Jaya Medicals',878,878,0,'30','Courier'),(14,'FY17','2017-06-07','Sale','DR.Sindu Rekha',827,827,0,'30','In Person'),(15,'2016','2017-01-16','Sale','DR.Sindu Rekha',806,806,0,'30','Courier'),(15,'2017','2017-09-14','Sale','DR.Senthil Kumar',5645,5645,0,'30',''),(15,'FY17','2017-06-16','Sale','DR.Sindu Rekha',151,151,0,'30','In Person'),(16,'2016','2017-01-21','Sale','RAAJ HOSPI',6993,6993,0,'30','Courier'),(16,'2017','2017-09-18','Sale','DR.Monisha',419,419,0,'30','Courier'),(16,'FY17','2017-06-21','Sale','DR SURESH PAVUNJUR',724,0,0,'30','In Person'),(17,'2016','2017-01-23','Sale','DR.Sindu Rekha',302,302,0,'30','In Person'),(17,'2017','2017-10-04','Sale','DR.Sindu Rekha',1079,1079,0,'30','IN PERSON'),(17,'FY17','2017-06-24','Sale','VMH',806,806,0,'30','Courier'),(18,'2016','2017-01-25','Sale','SMC',425,425,0,'30','Courier'),(18,'2017','2017-10-07','Sale','SMC',1769,1769,0,'30','Courier'),(18,'FY17','2017-06-24','Sale','SMC',1890,1890,0,'30','Courier'),(19,'2016','2017-01-31','Sale','VMH',806,806,0,'30','Courier'),(19,'2017','2017-11-08','Sale','DR.Sindu Rekha',449,449,0,'30','IN PERSON'),(19,'FY17','2017-06-24','Sale','RAAJ HOSPI',3512,3512,0,'30','Courier'),(20,'2016','2017-02-01','Sale','DR SURESH PAVUNJUR',1024,0,0,'30','Courier'),(20,'2017','2017-11-08','Sale','Durga Medicals',314,314,0,'30','In Person'),(20,'FY17','2017-06-25','Sale','DR.MAMATHA CLINIC',3347,0,0,'30','In Person'),(21,'2016','2017-02-01','Sale','Jaya Medicals',823,823,0,'30','Courier'),(21,'2017','2017-11-22','Sale','SMC',1769,1769,0,'30','Courier'),(21,'F017','2017-06-28','Sale','DR.Monisha',2868,0,0,'30','In Person'),(21,'FY17','2017-06-27','Sale','DR.Sindu Rekha',1655,1655,0,'30','In Person'),(22,'2016','2017-02-02','Sale','DR RAVENDRAN',420,0,0,'30','Courier'),(22,'2017','2017-11-22','Sale','Jaya Medicals',439,439,0,'30','Courier'),(22,'FY17','2017-06-29','Sale','RAAJ HOSPI',3496,3496,0,'30','courier'),(23,'2016','2017-02-14','Sale','DR.Lakshminarayanan',584,0,0,'30','Courier'),(23,'2017','2017-11-22','Sale','DR SURESH PAVUNJUR',1092,1092,0,'30','Courier'),(23,'FY17','2017-06-30','Sale','SMC',2977,2977,0,'30','Courier'),(24,'2016','2017-02-23','Sale','DR.Sindu Rekha',302,302,0,'30','In Person'),(24,'2017','2017-11-25','Sale','DR.Lakshminarayanan',3514,3514,0,'30','Courier'),(24,'FY17','2016-06-30','Sale','DR.Rani',1755,0,0,'30','Courier'),(25,'2016','2017-02-28','Sale','VMH',1496,1496,0,'30','Courier'),(25,'2017','2017-11-28','Sale','RAAJ HOSPI',8859,8859,0,'30','Courier'),(26,'2016','2017-03-06','Sale','DR.MAMATHA CLINIC',1606,0,0,'30','In Person'),(26,'2017','2017-11-28','Sale','DR.Sindu Rekha',627,627,0,'30','In Person'),(27,'2016','2017-03-14','Sale','DR.Sindu Rekha',472,472,0,'30','In Person'),(27,'2017','2017-11-29','Sale','VMH',2097,2097,0,'30','In Person'),(28,'2016','2017-03-20','Sale','SMC',425,425,0,'30','In Person'),(28,'2017','2017-12-05','Sale','DR.Monisha',3108,3108,0,'30','Courier'),(29,'2016','2017-03-21','Sale','Sri Sugam Medicals',662,662,0,'30','In Person'),(29,'2017','2017-12-11','Sale','DR.Senthil Kumar',1989,1989,0,'30','In Person'),(30,'2016','2017-03-24','Sale','RAAJ HOSPI',8741,8741,0,'30','Courier'),(30,'2017','2017-12-15','Sale','DR.Venkatesh Melmalaiyanur',1000,1000,0,'30','In Person'),(31,'2016','2017-03-29','Sale','VMH',806,806,0,'30','Courier'),(31,'2017','2017-12-28','Sale','Ganesh Medicals',961,961,0,'30','In Person'),(32,'2016','2017-03-30','Sale','DR SURESH PAVUNJUR',1024,0,0,'30','Courier'),(32,'2017','2017-12-29','Sale','DR.Sindu Rekha',150,150,0,'30','In Person'),(33,'2016','2017-03-30','Sale','Jaya Medicals',315,315,0,'30','Courier'),(33,'2017','2018-01-03','Sale','DR.MAMATHA CLINIC',4144,4144,0,'30','In Person'),(34,'2016','2017-03-30','Sale','DR.Sindu Rekha',302,302,0,'30','In Person'),(34,'2017','2018-01-05','Sale','DR.Hemnath',809,809,0,'30','In Person'),(34,'FY16','2016-08-17','Sale','DR SURESH PAVUNJUR',1087,0,0,'30','IN PERSON'),(35,'2017','2018-01-05','Sale','SMC',1769,1769,0,'30','Courier'),(35,'FY16','2016-08-17','Sale','DR RAVENDRAN',210,0,0,'30','IN PERSON'),(36,'2017','2018-01-10','Sale','DR SURESH PAVUNJUR',1092,1092,0,'30','Courier'),(36,'FY16','2016-08-18','Sale','VMH',806,806,0,'30','IN PERSON'),(37,'2017','2018-01-10','Sale','Jaya Medicals',439,439,0,'30','Courier'),(37,'FY16','2016-08-23','Sale','DR.Sindu Rekha',790,790,0,'30','in person'),(38,'2017','2018-01-24','Sale','DR.Senthil Kumar',5645,5645,0,'30','In Person'),(38,'FY16','2016-08-30','Sale','SMC',992,992,0,'30','COURIER'),(39,'2017','2018-01-26','Sale','RAAJ HOSPI',7616,7616,0,'30','Courier'),(39,'FY16','2016-09-06','Sale','VMH',806,806,0,'30','In Person'),(40,'2017','2018-01-28','Sale','Ganesh Medicals',856,856,0,'30','In Person'),(40,'FY16','2016-09-12','Sale','SMC',331,331,0,'30','COURIER'),(41,'2017','2018-02-17','Sale','DR.Venkatesh Melmalaiyanur',2321,2321,0,'30','In Person'),(41,'FY16','2016-09-15','Sale','SMC',2183,2183,0,'30','COURIER'),(42,'2017','2018-02-17','Sale','DR.MAMATHA CLINIC',1680,1680,0,'30','In Person'),(42,'FY16','2016-09-19','Sale','RAAJ HOSPI',7576,7576,0,'30','COURIER'),(43,'2017','2018-02-19','Sale','SMC',1769,1769,0,'30','Courier'),(43,'FY16','2016-09-19','Sale','RAAJ HOSPI',294,294,0,'30','COURIER'),(44,'2017','2018-03-08','Sale','DR.Sindu Rekha',90,90,0,'30','In Person'),(44,'FY16','2016-09-19','Sale','Durga Medicals',588,588,0,'30','In Person'),(45,'2017','2018-03-13','Sale','SMC',1769,1769,0,'30','Courier'),(45,'FY16','2016-09-21','Sale','DR.MAMATHA CLINIC',1611,0,90,'30','In Person'),(45.1,'FY16','2016-09-22','Sale','RAAJ HOSPI',13987,13987,0,'30','COURIER'),(46,'2017','2018-03-26','Sale','Oliviya Medicals',414,414,0,'30','In Person'),(46,'FY16','2016-09-26','Sale','VMH',806,806,0,'30','In Person'),(47,'2017','2018-03-27','Sale','Nathan Pharmacy',1994,1994,0,'30','In Person'),(47,'FY16','2016-09-27','Sale','DR.Sindu Rekha',525,525,0,'30','In Person'),(48,'2017','2018-03-27','Sale','DR RAVENDRAN',224,224,0,'30','In Person'),(48,'FY16','2016-09-29','Sale','Kumar Medical',5503,5503,0,'30','In Person'),(49,'2017','2018-03-27','Sale','DR SURESH PAVUNJUR',1865,1865,0,'30','In Person'),(49,'FY16','2016-10-06','Sale','DR SURESH PAVUNJUR',1213,0,0,'30','In Person'),(50,'2017','2018-03-27','Sale','DR.Rani',1222,1222,0,'30','Courier'),(50,'FY16','2016-10-06','Sale','Jaya Medicals',823,823,0,'30','In Person'),(51,'2017','2018-03-27','Sale','RAAJ HOSPI',11998,11998,0,'30','Courier'),(51,'FY16','2016-10-12','Sale','DR.Senthil Kumar',5423,0,0,'30','Courier'),(52,'2017','2018-03-27','Sale','RAAJ HOSPI',11511,11511,0,'30','Courier'),(52,'FY16','2016-10-18','Sale','VMH',806,806,0,'30','In Person'),(53,'2017','2018-03-27','Sale','DR.Venkatesh Melmalaiyanur',650,650,0,'30','Courier'),(53,'FY16','2016-10-18','Sale','DR.Sindu Rekha',827,827,0,'30','In Person'),(54,'FY16','2016-10-26','Sale','DR.Senthil Kumar',1524,-476,0,'30','COURIER'),(56,'FY16','2016-10-27','Sale','Kumar Medical',1197,1197,0,'30','In Person');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;
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
  `Order_ID` double NOT NULL,
  `FY` varchar(4) NOT NULL,
  `Payment` int NOT NULL,
  `Pay_Date` date NOT NULL,
  PRIMARY KEY (`Payment_ID`),
  KEY `Order-Payment-Key_idx` (`Order_ID`),
  KEY `Order-Payment-Key_idx1` (`Order_ID`,`FY`),
  CONSTRAINT `Order-Payment-Key` FOREIGN KEY (`Order_ID`, `FY`) REFERENCES `orders` (`Order_Id`, `FY`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payments`
--

LOCK TABLES `payments` WRITE;
/*!40000 ALTER TABLE `payments` DISABLE KEYS */;
INSERT INTO `payments` VALUES (9,35,'FY16',210,'2016-05-16'),(10,22,'2016',0,'2016-05-16'),(11,22,'2016',420,'2017-05-16'),(12,11,'FY17',777,'2017-05-16'),(13,11,'2016',724,'2017-05-16'),(14,20,'2016',0,'2017-05-16'),(15,34,'FY16',1087,'2017-05-16'),(16,49,'FY16',1213,'2017-05-16'),(17,2,'2016',1213,'2017-05-16'),(18,20,'2016',1024,'2017-05-16'),(19,10,'FY17',1024,'2017-05-16'),(20,32,'2016',1024,'2017-05-16'),(21,16,'FY17',724,'2018-05-16'),(22,13,'2016',1756,'2017-05-16'),(23,23,'2016',584,'2017-05-16'),(24,45,'FY16',1611,'2017-05-16'),(25,5,'2016',1680,'2017-05-16'),(26,26,'2016',1606,'2017-05-16'),(27,20,'FY17',3347,'2018-05-16'),(28,13,'FY17',3786,'2017-05-16'),(29,21,'F017',2868,'2017-05-16'),(30,24,'FY17',1755,'2017-05-16'),(31,51,'FY16',5423,'2017-05-16'),(32,54,'FY16',2000,'2017-05-16'),(33,4,'FY17',3977,'2017-05-16');
/*!40000 ALTER TABLE `payments` ENABLE KEYS */;
UNLOCK TABLES;
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

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES ('AZINOS 500','COT-1091','Tablet','2020-03-01 00:00:00','2022-02-01 00:00:00',1,3,1000,6,6,70,'CHENNAI OSCAR BIO PHARMACEUTICALS PVT LTD','2020-03-25','1185/19-20'),('AZINOS 500','COT-554','Tablet','2019-04-01 00:00:00','2021-03-01 00:00:00',20,3,48,6,6,60,'ChENNAI OSCAR BIO PHARMACEUTICALS PVT LTD','2019-05-10','73/19-20'),('AZINOS 500','COT-728','Tablet','2019-09-01 00:00:00','2021-08-01 00:00:00',1,3,1186,6,6,70,'CHENNAI OSCAR BIO PHARMACEUTICALS PVT LTD','2019-09-26','497/19-20'),('AZINOS 500','COT-891','Tablet','2019-12-01 00:00:00','2021-11-01 00:00:00',1,3,800,6,6,70,'CHENNAI OSCAR BIO PHARMACEUTICALS PVT LTD','2019-12-26','868/19-20'),('AZINOS 500','COT-959','Tablet','2020-01-01 00:00:00','2021-12-01 00:00:00',1,3,960,6,6,70,'CHENNAI OSCAR BIO PHARMACEUTICALS PVT LTD','2020-01-31','987/19-20'),('AZINOS 500','NAN-01','Tablet','2016-11-01 00:00:00','2018-10-01 00:00:00',10,10,246,0,5,185,'NTK PHARMAA','2016-11-14','NTK/F201/16-17'),('LEVONOX 500','NLEV-01','Tablet','2019-12-01 00:00:00','2021-11-01 00:00:00',10,10,191,6,6,85,'NTK PHARMAA','2019-12-06','NTK/S00433/19-20'),('LEVONOX 500','NXB-01','Tablet','2016-07-01 00:00:00','2018-06-01 00:00:00',10,10,245,0,5,65.4,'NTK PHARMAA','2016-08-04','NTK/E076/16-17'),('LEVONOX 500','NXB-02','Tablet','2017-06-01 00:00:00','2019-05-01 00:00:00',10,10,220,6,6,68.2,'NTK PHARMAA','2017-07-01','NTK/FG067/17-18'),('LEVONOX 500','NXB-03','Tablet','2019-01-01 00:00:00','2020-12-01 00:00:00',10,10,243,6,6,65.4,'NTK PHARMAA','2019-01-28','NTK/341/18-19'),('LEVOTRUM','1061','Tablet','2020-03-01 00:00:00','2022-02-01 00:00:00',1,10,1010,6,6,90,'CHENNAI OSCAR BIO PHARMACEUTICALS PVT LTD','2020-03-25','1191/19-20'),('LEVOTRUM','CFT-214','Tablet','2018-01-01 00:00:00','2019-11-01 00:00:00',10,10,244,6,6,80,'CARE FORMULATIONS','2018-01-12','0302'),('LEVOTRUM','COT-547','Tablet','2019-04-01 00:00:00','2021-03-01 00:00:00',10,10,96,6,6,90,'CHENNAI OSCAR BIO PHARMACEUTICALS PVT LTD','2019-05-10','74/19-20'),('LEVOTRUM','COT-797','Tablet','2019-11-01 00:00:00','2021-10-01 00:00:00',1,10,990,6,6,90,'CHENNAI OSCAR BIO PHARMACEUTICALS PVT LTD','2019-11-23','728/19-20'),('NOCETZ','MFL 28001','Syrup','2020-01-01 00:00:00','2022-12-01 00:00:00',60,1,401,6,6,38.5,'MOTHERLAND FORMULATIONS PVT LTD','2020-02-14','487'),('NOSCAL D3','HLTS 1364','Tablet','2015-06-01 00:00:00','2016-11-01 00:00:00',10,10,12,0,5,35,'DR HARRY LIFE SCIENCES','2015-07-07','DH/0176'),('NOSCAL D3','NNN-01','Tablet','2016-10-01 00:00:00','2018-09-01 00:00:00',10,10,241,0,5,40,'NTK PHARMAA','2016-10-07','NTK/F156/16-17'),('NOSCAL D3','NNN-02','Tablet','2018-07-01 00:00:00','2020-06-01 00:00:00',10,10,191,6,6,40,'NTK PHARMAA','2018-07-13','NTK/088/18-19'),('NOSCAL D3','NNOS-02','Tablet','2020-03-01 00:00:00','2022-02-01 00:00:00',10,10,192,6,6,40,'NTK PHARMAA','2020-03-07','NTK/S00548/19-20'),('NOSCOF DX','MFL 27501','Syrup','2020-01-01 00:00:00','2022-06-01 00:00:00',60,1,374,6,6,55,'MOTHERLAND FORMULATIONS PVT LTD','2020-01-23','452'),('NOSCOLD DROPS','MFL 27401','Syrup','2020-01-01 00:00:00','2022-12-01 00:00:00',15,1,624,6,6,45,'MOTHERLAND FORMULATIONS PVT LTD','2020-01-23','452'),('NOSPAR 120','MFL 27101','Suspension','2020-02-01 00:00:00','2022-07-01 00:00:00',60,1,409,6,6,34.5,'MOTHERLAND FORMULATIONS PVT LTD','2020-02-14','487'),('NOSPAR 250','MFL 27001','Suspension','2020-01-01 00:00:00','2022-06-01 00:00:00',60,1,389,6,6,39.5,'MOTHERLAND FORMULATIONS PVT LTD','2020-01-23','452'),('NOSPAR PLUS','1075','Tablet','2020-03-01 00:00:00','2022-02-01 00:00:00',1,10,1476,6,6,45,'CHENNAI OSCAR BIO PHARMACEUTICALS PVT LTD','2020-03-25','1191/19-20'),('NOSPAR PLUS','CFT-042','Tablet','2017-07-01 00:00:00','2019-05-01 00:00:00',10,10,246,6,6,35,'CARE FORMULATIONS','2017-07-27','002'),('NOSPAR PLUS','COT-398','Tablet','2018-11-01 00:00:00','2020-10-01 00:00:00',20,10,123,6,6,0,'CHENNAI OSCAR BIO PHARMACEUTICALS PVT LTD','2018-11-30','410'),('NOSPAR PLUS','COT-564','Tablet','2019-05-01 00:00:00','2021-04-01 00:00:00',1,10,1474,6,6,45,'CHENNAI OSCAR BIO PHARMACEUTICALS PVT LTD','2019-05-21','91/19-20'),('NOSPAR PLUS','COT-728','Tablet','2019-09-01 00:00:00','2021-08-01 00:00:00',1,10,1455,6,6,45,'CHENNAI OSCAR BIO PHARMACEUTICALS PVT LTD','2019-09-18','467/19-20'),('NOSPAR PLUS','COT-973','Tablet','2020-01-01 00:00:00','2021-12-01 00:00:00',1,10,1512,6,6,45,'CHENNAI OSCAR BIO PHARMACEUTICALS PVT LTD','2020-01-31','985/19-20'),('NOSPAR PLUS','HLTS 1138','Tablet','2015-02-01 00:00:00','2018-01-01 00:00:00',20,10,70,0,5,35,'DR HARRY LIFE SCIENCES','2015-02-19','HE414'),('NOSPAR PLUS','HLTS 884','Tablet','2014-09-01 00:00:00','2017-08-01 00:00:00',20,10,13,0,5,35,'DR HARRY LIFE SCIENCES','2014-10-18','HE209'),('NOSPROVIT','MFL 10901','Syrup','2017-08-01 00:00:00','2019-01-01 00:00:00',200,1,481,6,6,85,'MOTHERLAND FORMULATIONS PVT LTD','2017-09-11','052&076'),('NOSPROVIT','MFL 10902','Syrup','2018-08-01 00:00:00','2020-01-01 00:00:00',200,1,485,6,6,85,'MOTHERLAND FORMULATIONS PVT LTD','2018-08-07','139'),('NOSPROVIT','MFL 10903','Syrup','2019-02-01 00:00:00','2020-07-01 00:00:00',200,1,486,6,6,85,'MOTHERLAND FORMULATIONS PVT LTD','2019-02-14','426'),('NOSPROVIT','MFL 10904','Syrup','2019-08-01 00:00:00','2021-01-01 00:00:00',200,1,489,6,6,100,'MOTHERLAND FORMULATIONS PVT LTD','2019-08-10','150'),('NOSPROVIT','MFL 10905','Syrup','2020-02-01 00:00:00','2021-01-01 00:00:00',200,1,489,6,6,100,'MOTHERLAND FORMULATIONS PVT LTD','2020-02-14','487'),('NOSPROVIT','MFL 18314','Syrup','2016-03-01 00:00:00','2017-08-01 00:00:00',200,1,58,0,5,75,'MOTHERLAND FORMULATIONS PVT LTD','2016-03-25','446/2015-16'),('NOSPROVIT','MFL 18315','Syrup','2016-08-01 00:00:00','2018-01-01 00:00:00',200,1,488,0,5,75,'MOTHERLAND FORMULATIONS PVT LTD','2016-08-26','MFL/2016-17 170'),('NOSPROVIT','MFL 18316','Syrup','2017-03-01 00:00:00','2018-08-01 00:00:00',200,1,488,0,5,75,'MOTHERLAND FORMULATIONS PVT LTD','2017-03-04','MFL/2016-17 456'),('NOSTRON','MFL 27301','Syrup','2020-02-01 00:00:00','2022-01-01 00:00:00',30,1,322,6,6,37,'MOTHERLAND FORMULATIONS PVT LTD','2020-02-14','487'),('NOXIME 100','CFT-040','Tablet','2017-07-01 00:00:00','2019-05-01 00:00:00',10,10,147,6,6,81,'CARE FORMULATIONS','2017-07-27','001'),('NOXIME 100','CFT-048','Tablet','2018-06-01 00:00:00','2020-04-01 00:00:00',1,10,1365,6,6,85,'CARE FORMULATIONS','2018-06-12','060'),('NOXIME 100','HLTS 1363','Tablet','2015-06-01 00:00:00','2017-05-01 00:00:00',15,10,6,0,5,81,'DR HARRY LIFE SCIENCES','2015-07-07','DH/0176'),('NOXIME 100','HLTS 1877','Tablet','2016-05-01 00:00:00','2018-02-01 00:00:00',15,10,70,0,5,81,'DR HARRY LIFE SCIENCES','2016-04-30','HE/042'),('RABETRUM DSR','COC-070','Capsule','2019-12-01 00:00:00','2021-11-01 00:00:00',1,10,985,6,6,80,'CHENNAI OSCAR BIO PHARMACEUTICALS PVT LTD','2019-12-30','906/19-20');
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;
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
-- Dumping data for table `stock`
--

LOCK TABLES `stock` WRITE;
/*!40000 ALTER TABLE `stock` DISABLE KEYS */;
INSERT INTO `stock` VALUES ('AZINOS 500','COT-1091',3000),('AZINOS 500','COT-554',2880),('AZINOS 500','COT-728',3558),('AZINOS 500','COT-891',2400),('AZINOS 500','COT-959',2880),('AZINOS 500','NAN-01',20550),('LEVONOX 500','NLEV-01',19100),('LEVONOX 500','NXB-01',1100),('LEVONOX 500','NXB-02',10480),('LEVONOX 500','NXB-03',24300),('LEVOTRUM','1061',10100),('LEVOTRUM','CFT-214',2000),('LEVOTRUM','COT-547',9600),('LEVOTRUM','COT-797',9900),('NOCETZ','MFL 28001',401),('NOSCAL D3','HLTS 1364',0),('NOSCAL D3','NNN-01',5000),('NOSCAL D3','NNN-02',19100),('NOSCAL D3','NNOS-02',19200),('NOSCOF DX','MFL 27501',374),('NOSCOLD DROPS','MFL 27401',624),('NOSPAR 120','MFL 27101',409),('NOSPAR 250','MFL 27001',389),('NOSPAR PLUS','1075',14760),('NOSPAR PLUS','CFT-042',11400),('NOSPAR PLUS','COT-398',24600),('NOSPAR PLUS','COT-564',14740),('NOSPAR PLUS','COT-728',14550),('NOSPAR PLUS','COT-973',15120),('NOSPAR PLUS','HLTS 1138',3800),('NOSPAR PLUS','HLTS 884',0),('NOSPROVIT','MFL 10901',197),('NOSPROVIT','MFL 10902',485),('NOSPROVIT','MFL 10903',486),('NOSPROVIT','MFL 10904',489),('NOSPROVIT','MFL 10905',489),('NOSPROVIT','MFL 18314',0),('NOSPROVIT','MFL 18315',33),('NOSPROVIT','MFL 18316',46),('NOSTRON','MFL 27301',322),('NOXIME 100','CFT-040',5900),('NOXIME 100','CFT-048',13650),('NOXIME 100','HLTS 1363',0),('NOXIME 100','HLTS 1877',250),('RABETRUM DSR','COC-070',9850);
/*!40000 ALTER TABLE `stock` ENABLE KEYS */;
UNLOCK TABLES;

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

-- Dump completed on 2020-05-17 21:46:14
