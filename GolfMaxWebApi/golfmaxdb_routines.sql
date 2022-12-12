-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: golfmaxdb
-- ------------------------------------------------------
-- Server version	8.0.31

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
-- Dumping routines for database 'golfmaxdb'
--
/*!50003 DROP PROCEDURE IF EXISTS `DeleteCourse` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteCourse`()
BEGIN 
    DELETE FROM courses c
    WHERE c.id = @id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `DeleteUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteUser`(IN Id INt)
BEGIN 
    DELETE FROM users u
    WHERE u.id = Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `FindExistingCourse` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `FindExistingCourse`()
BEGIN 
    SELECT * FROM courses c 
    WHERE c.course_name = @CourseName
    OR c.id = @Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `FindExistingUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `FindExistingUser`(IN Username VARCHAR(45), IN Email VARCHAR(45), IN Id INT)
BEGIN
    SELECT * FROM users u 
    WHERE u.username = Username 
    OR u.email = Email
    OR u.id = Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GetAllCourses` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllCourses`()
BEGIN
    SELECT * FROM courses c 
    INNER JOIN hole_layouts hl 
    ON c.id = hl.course_id
    INNER JOIN holes h 
    ON c.id = h.course_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GetAllUsers` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllUsers`()
BEGIN 
    SELECT * FROM users;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GetCourseByCourseName` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetCourseByCourseName`()
BEGIN 
    SELECT * FROM courses c 
    INNER JOIN hole_layouts hl
    ON c.id = hl.course_id
    INNER JOIN holes h 
    ON c.id = h.course_id
    WHERE c.course_name = @CourseName;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GetCourseById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetCourseById`()
BEGIN 
    SELECT * FROM courses c 
    INNER JOIN hole_layouts hl
    ON c.id = hl.course_id
    INNER JOIN holes h 
    ON c.id = h.course_id
    WHERE c.id = @id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GetUserByEmail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetUserByEmail`(IN Email VARCHAR(45))
BEGIN 
    SELECT * FROM users u 
    WHERE u.email = Email;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GetUserById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetUserById`(IN Id INT)
BEGIN
    SELECT * FROM golfmaxdb.users u
    WHERE u.id = Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GetUserByUsername` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetUserByUsername`(IN Username VARCHAR(45))
BEGIN 
    SELECT * FROM users u 
    WHERE u.username = Username;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertCourse` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertCourse`()
BEGIN
    INSERT INTO courses (course_name)
    VALUES (@CourseName);
    SET @course_id = LAST_INSERT_ID();

    INSERT INTO hole_layouts (front_9_yards, back_9_yards, overall_par, course_rating, slope_rating, layout_type, course_id)
    VALUES (@Front9Yards, @Back9Yards, @OverallPar, @CourseRating, @SlopeRating, @LayoutType, @CourseId);
    SET @HoleLayoutId = LAST_INSERT_ID();

    INSERT INTO holes (yards, par, hole_number, course_id, hole_layout_id)
    VALUES
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId);

    INSERT INTO hole_layouts (front_9_yards, back_9_yards, overall_par, course_rating, slope_rating, layout_type, course_id)
    VALUES (@Front9Yards, @Back9Yards, @OverallPar, @CourseRating, @SlopeRating, @LayoutType, @CourseId);
    SET @HoleLayoutId = LAST_INSERT_ID();

    INSERT INTO holes (yards, par, hole_number, course_id, hole_layout_id)
    VALUES
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId);

    INSERT INTO hole_layouts (front_9_yards, back_9_yards, overall_par, course_rating, slope_rating, layout_type, course_id)
    VALUES (@Front9Yards, @Back9Yards, @OverallPar, @CourseRating, @SlopeRating, @LayoutType, @CourseId);
    SET @HoleLayoutId = LAST_INSERT_ID();

    INSERT INTO holes (yards, par, hole_number, course_id, hole_layout_id)
    VALUES
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId),
        (@Yards, @Par, @HoleNumber, @CourseId, @HoleLayoutId);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertUser`(IN FirstName varchar(45), IN LastName varchar(45),
                                                  IN Username varchar(45), IN Password varchar(45),
                                                  IN Email varchar(45))
BEGIN 
    INSERT INTO users (first_name, last_name, username, password, email) 
    VALUES (FirstName, LastName, Username, Password, Email);
    SELECT LAST_INSERT_ID();
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UpdateUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateUser`(IN Username varchar(45), IN Password varchar(45),
                                                  IN Email varchar(45), IN Id int)
BEGIN 
    UPDATE users u 
    SET
        u.username = Username,
        u.password = Password,
        u.email = Email
    WHERE u.id = Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-12-08 21:24:59
