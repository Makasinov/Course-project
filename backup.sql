-- MySQL dump 10.13  Distrib 5.5.23, for Win64 (x86)
--
-- Host: localhost    Database: mydb
-- ------------------------------------------------------
-- Server version	5.5.23-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `edu_plan`
--

DROP TABLE IF EXISTS `edu_plan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `edu_plan` (
  `semester_number` int(11) NOT NULL,
  `hours` int(11) NOT NULL,
  `year` int(11) NOT NULL,
  `Specs_id` int(11) NOT NULL,
  `Subjects_id` int(11) NOT NULL,
  PRIMARY KEY (`semester_number`,`year`,`Specs_id`,`Subjects_id`),
  KEY `fk_Edu_plan_Specs1_idx` (`Specs_id`),
  KEY `fk_Edu_plan_Subjects1_idx` (`Subjects_id`),
  CONSTRAINT `fk_Edu_plan_Specs1` FOREIGN KEY (`Specs_id`) REFERENCES `specs` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Edu_plan_Subjects1` FOREIGN KEY (`Subjects_id`) REFERENCES `subjects` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `edu_plan`
--

LOCK TABLES `edu_plan` WRITE;
/*!40000 ALTER TABLE `edu_plan` DISABLE KEYS */;
INSERT INTO `edu_plan` VALUES (1,900,2018,1,1),(1,1200,2018,2,1),(1,900,2018,3,1),(2,990,2018,2,2);
/*!40000 ALTER TABLE `edu_plan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `engaged_themes`
--

DROP TABLE IF EXISTS `engaged_themes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `engaged_themes` (
  `Students_id` int(11) NOT NULL,
  `Students_Groups_id` int(11) NOT NULL,
  `Themes_id` int(11) NOT NULL,
  `Themes_Subjects_id` int(11) NOT NULL,
  `Mark` int(11) DEFAULT NULL,
  PRIMARY KEY (`Students_id`,`Students_Groups_id`,`Themes_id`,`Themes_Subjects_id`),
  KEY `fk_Engaged_Themes_Students1_idx` (`Students_id`,`Students_Groups_id`),
  KEY `fk_Engaged_Themes_Themes1_idx` (`Themes_id`,`Themes_Subjects_id`),
  CONSTRAINT `fk_Engaged_Themes_Students1` FOREIGN KEY (`Students_id`, `Students_Groups_id`) REFERENCES `students` (`id`, `Groups_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Engaged_Themes_Themes1` FOREIGN KEY (`Themes_id`, `Themes_Subjects_id`) REFERENCES `themes` (`id`, `Subjects_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `engaged_themes`
--

LOCK TABLES `engaged_themes` WRITE;
/*!40000 ALTER TABLE `engaged_themes` DISABLE KEYS */;
INSERT INTO `engaged_themes` VALUES (1,1,11,6,0),(1,5,9,6,0),(2,5,10,6,0);
/*!40000 ALTER TABLE `engaged_themes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `groups`
--

DROP TABLE IF EXISTS `groups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `groups` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `Specs_spec_id` int(11) NOT NULL,
  PRIMARY KEY (`id`,`Specs_spec_id`),
  UNIQUE KEY `name_UNIQUE` (`name`),
  KEY `fk_Groups_Specs1_idx` (`Specs_spec_id`),
  CONSTRAINT `fk_Groups_Specs1` FOREIGN KEY (`Specs_spec_id`) REFERENCES `specs` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `groups`
--

LOCK TABLES `groups` WRITE;
/*!40000 ALTER TABLE `groups` DISABLE KEYS */;
INSERT INTO `groups` VALUES (5,'205',1),(2,'301',3),(4,'302',2),(1,'304-k',1);
/*!40000 ALTER TABLE `groups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `specs`
--

DROP TABLE IF EXISTS `specs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `specs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `code` varchar(15) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `code_UNIQUE` (`code`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `specs`
--

LOCK TABLES `specs` WRITE;
/*!40000 ALTER TABLE `specs` DISABLE KEYS */;
INSERT INTO `specs` VALUES (1,'Programming in Computer Systems','09.02.03'),(2,'Computer Network','09.02.02'),(3,'Marketing','42.02.01');
/*!40000 ALTER TABLE `specs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `students` (
  `id` int(11) NOT NULL,
  `surname` varchar(45) NOT NULL,
  `Groups_id` int(11) NOT NULL,
  PRIMARY KEY (`id`,`Groups_id`),
  KEY `fk_Students_Groups1_idx` (`Groups_id`),
  CONSTRAINT `fk_Students_Groups1` FOREIGN KEY (`Groups_id`) REFERENCES `groups` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students` VALUES (1,'Ovechkin',1),(1,'Ivanov',2),(1,'Maksimov',4),(1,'Rodin',5),(2,'Petruwin',1),(2,'Gruwin',2),(2,'Petrov',4),(2,'Glaktionov',5),(3,'Makovecki',1),(3,'Pavlenkov',2),(3,'Dubin',5),(4,'Chepuwilov',2);
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subjects`
--

DROP TABLE IF EXISTS `subjects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `subjects` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subjects`
--

LOCK TABLES `subjects` WRITE;
/*!40000 ALTER TABLE `subjects` DISABLE KEYS */;
INSERT INTO `subjects` VALUES (2,'Database managment'),(5,'English'),(6,'Math'),(1,'Programming');
/*!40000 ALTER TABLE `subjects` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `themes`
--

DROP TABLE IF EXISTS `themes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `themes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `Subjects_id` int(11) NOT NULL,
  PRIMARY KEY (`id`,`Subjects_id`),
  KEY `fk_Themes_Subjects1_idx` (`Subjects_id`),
  CONSTRAINT `fk_Themes_Subjects1` FOREIGN KEY (`Subjects_id`) REFERENCES `subjects` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `themes`
--

LOCK TABLES `themes` WRITE;
/*!40000 ALTER TABLE `themes` DISABLE KEYS */;
INSERT INTO `themes` VALUES (1,'Database of airport',1),(1,'Pascal arrays',2),(2,'Database of library',1),(2,'C++ Pointers',2),(6,'C# variables',1),(7,'Algorithms',6),(8,'Memory size',6),(9,'Variables',6),(10,'Lambda',6),(11,'Functions',6),(12,'Times',5);
/*!40000 ALTER TABLE `themes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `login` varchar(45) CHARACTER SET utf8 NOT NULL,
  `role` varchar(45) CHARACTER SET utf8 NOT NULL,
  `name` varchar(45) CHARACTER SET utf8 NOT NULL,
  `surname` varchar(45) CHARACTER SET utf8 NOT NULL,
  `gender` varchar(45) CHARACTER SET utf8 DEFAULT NULL,
  UNIQUE KEY `login_UNIQUE` (`login`)
) ENGINE=InnoDB DEFAULT CHARSET=utf16;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('depot','Depot','Aleksey','Panin','Male'),('larionova','Teacher','Elena','Larionova','Female'),('login','Teacher','Masha','Ivanova','Female'),('maksimov','Student','Ilya','Maksimov','Male'),('root','root','Ilya','Maksimov','');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-06-20 23:10:27
