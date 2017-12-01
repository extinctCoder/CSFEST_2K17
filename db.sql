-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema HomeAutomationDb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema HomeAutomationDb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `HomeAutomationDb` DEFAULT CHARACTER SET utf8 ;
USE `HomeAutomationDb` ;

-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`user` (
  `id` INT NULL AUTO_INCREMENT,
  `user_name` VARCHAR(45) NOT NULL,
  `first_name` VARCHAR(45) NULL,
  `middle_name` VARCHAR(45) NULL,
  `last_name` VARCHAR(45) NULL,
  `password` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`user_group`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`user_group` (
  `id` INT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `description` VARCHAR(45) NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`permission`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`permission` (
  `id` INT NULL AUTO_INCREMENT,
  `permission` ENUM('Admin User', 'Super User', 'Data Specialist', 'Express User', 'Moderate User', 'Regular User') NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`control_panel`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`control_panel` (
  `id` INT UNSIGNED NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `description` VARCHAR(45) NULL,
  `online_status` TINYINT NOT NULL,
  `enabaled_status` TINYINT NOT NULL,
  UNIQUE INDEX `id_UNIQUE` (`id` ASC),
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`component`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`component` (
  `id` INT UNSIGNED NULL AUTO_INCREMENT,
  `mode` INT NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  `description` VARCHAR(45) NULL,
  `value` INT NULL,
  `type` VARCHAR(45) NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`data`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`data` (
  `id` INT NULL AUTO_INCREMENT,
  `value` INT NOT NULL,
  `unit` VARCHAR(45) NULL,
  `data_tyoe` VARCHAR(45) NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`switch_condition`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`switch_condition` (
  `id` INT UNSIGNED NULL AUTO_INCREMENT,
  `evaluator` VARCHAR(45) NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`action`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`action` (
  `id` INT NULL AUTO_INCREMENT,
  `on_value` INT NULL,
  `off_value` INT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`scheduler`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`scheduler` (
  `id` INT NULL AUTO_INCREMENT,
  `from` VARCHAR(45) NULL,
  `to` VARCHAR(45) NULL,
  `freq` VARCHAR(45) NULL,
  `freq_unit` VARCHAR(45) NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`room`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`room` (
  `id` INT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `description` VARCHAR(45) NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`user_has_user_group`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`user_has_user_group` (
  `user_id` INT NOT NULL,
  `user_group_id` INT NOT NULL,
  PRIMARY KEY (`user_id`, `user_group_id`),
  INDEX `fk_user_has_user_group_user_group1_idx` (`user_group_id` ASC),
  INDEX `fk_user_has_user_group_user_idx` (`user_id` ASC),
  CONSTRAINT `fk_user_has_user_group_user`
    FOREIGN KEY (`user_id`)
    REFERENCES `HomeAutomationDb`.`user` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_user_has_user_group_user_group1`
    FOREIGN KEY (`user_group_id`)
    REFERENCES `HomeAutomationDb`.`user_group` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`user_group_has_permission`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`user_group_has_permission` (
  `user_group_id` INT NOT NULL,
  `permission_id` INT NOT NULL,
  PRIMARY KEY (`user_group_id`, `permission_id`),
  INDEX `fk_user_group_has_permission_permission1_idx` (`permission_id` ASC),
  INDEX `fk_user_group_has_permission_user_group1_idx` (`user_group_id` ASC),
  CONSTRAINT `fk_user_group_has_permission_user_group1`
    FOREIGN KEY (`user_group_id`)
    REFERENCES `HomeAutomationDb`.`user_group` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_user_group_has_permission_permission1`
    FOREIGN KEY (`permission_id`)
    REFERENCES `HomeAutomationDb`.`permission` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`user_has_permission`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`user_has_permission` (
  `user_id` INT NOT NULL,
  `permission_id` INT NOT NULL,
  PRIMARY KEY (`user_id`, `permission_id`),
  INDEX `fk_user_has_permission_permission1_idx` (`permission_id` ASC),
  INDEX `fk_user_has_permission_user1_idx` (`user_id` ASC),
  CONSTRAINT `fk_user_has_permission_user1`
    FOREIGN KEY (`user_id`)
    REFERENCES `HomeAutomationDb`.`user` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_user_has_permission_permission1`
    FOREIGN KEY (`permission_id`)
    REFERENCES `HomeAutomationDb`.`permission` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`user_has_control_panel`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`user_has_control_panel` (
  `user_id` INT NOT NULL,
  `control_panel_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`user_id`, `control_panel_id`),
  INDEX `fk_user_has_control_panel_control_panel1_idx` (`control_panel_id` ASC),
  INDEX `fk_user_has_control_panel_user1_idx` (`user_id` ASC),
  CONSTRAINT `fk_user_has_control_panel_user1`
    FOREIGN KEY (`user_id`)
    REFERENCES `HomeAutomationDb`.`user` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_user_has_control_panel_control_panel1`
    FOREIGN KEY (`control_panel_id`)
    REFERENCES `HomeAutomationDb`.`control_panel` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`control_panel_has_room`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`control_panel_has_room` (
  `control_panel_id` INT UNSIGNED NOT NULL,
  `room_id` INT NOT NULL,
  PRIMARY KEY (`control_panel_id`, `room_id`),
  INDEX `fk_control_panel_has_room_room1_idx` (`room_id` ASC),
  INDEX `fk_control_panel_has_room_control_panel1_idx` (`control_panel_id` ASC),
  CONSTRAINT `fk_control_panel_has_room_control_panel1`
    FOREIGN KEY (`control_panel_id`)
    REFERENCES `HomeAutomationDb`.`control_panel` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_control_panel_has_room_room1`
    FOREIGN KEY (`room_id`)
    REFERENCES `HomeAutomationDb`.`room` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`control_panel_has_component`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`control_panel_has_component` (
  `control_panel_id` INT UNSIGNED NOT NULL,
  `component_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`control_panel_id`, `component_id`),
  INDEX `fk_control_panel_has_component_component1_idx` (`component_id` ASC),
  INDEX `fk_control_panel_has_component_control_panel1_idx` (`control_panel_id` ASC),
  CONSTRAINT `fk_control_panel_has_component_control_panel1`
    FOREIGN KEY (`control_panel_id`)
    REFERENCES `HomeAutomationDb`.`control_panel` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_control_panel_has_component_component1`
    FOREIGN KEY (`component_id`)
    REFERENCES `HomeAutomationDb`.`component` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`component_has_room`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`component_has_room` (
  `component_id` INT UNSIGNED NOT NULL,
  `room_id` INT NOT NULL,
  PRIMARY KEY (`component_id`, `room_id`),
  INDEX `fk_component_has_room_room1_idx` (`room_id` ASC),
  INDEX `fk_component_has_room_component1_idx` (`component_id` ASC),
  CONSTRAINT `fk_component_has_room_component1`
    FOREIGN KEY (`component_id`)
    REFERENCES `HomeAutomationDb`.`component` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_component_has_room_room1`
    FOREIGN KEY (`room_id`)
    REFERENCES `HomeAutomationDb`.`room` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`component_has_data`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`component_has_data` (
  `component_id` INT UNSIGNED NOT NULL,
  `data_id` INT NOT NULL,
  PRIMARY KEY (`component_id`, `data_id`),
  INDEX `fk_component_has_data_data1_idx` (`data_id` ASC),
  INDEX `fk_component_has_data_component1_idx` (`component_id` ASC),
  CONSTRAINT `fk_component_has_data_component1`
    FOREIGN KEY (`component_id`)
    REFERENCES `HomeAutomationDb`.`component` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_component_has_data_data1`
    FOREIGN KEY (`data_id`)
    REFERENCES `HomeAutomationDb`.`data` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`data_has_switch_condition`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`data_has_switch_condition` (
  `data_id` INT NOT NULL,
  `switch_condition_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`data_id`, `switch_condition_id`),
  INDEX `fk_data_has_switch_condition_switch_condition1_idx` (`switch_condition_id` ASC),
  INDEX `fk_data_has_switch_condition_data1_idx` (`data_id` ASC),
  CONSTRAINT `fk_data_has_switch_condition_data1`
    FOREIGN KEY (`data_id`)
    REFERENCES `HomeAutomationDb`.`data` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_data_has_switch_condition_switch_condition1`
    FOREIGN KEY (`switch_condition_id`)
    REFERENCES `HomeAutomationDb`.`switch_condition` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`action_has_data`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`action_has_data` (
  `action_id` INT NOT NULL,
  `data_id` INT NOT NULL,
  PRIMARY KEY (`action_id`, `data_id`),
  INDEX `fk_action_has_data_data1_idx` (`data_id` ASC),
  INDEX `fk_action_has_data_action1_idx` (`action_id` ASC),
  CONSTRAINT `fk_action_has_data_action1`
    FOREIGN KEY (`action_id`)
    REFERENCES `HomeAutomationDb`.`action` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_action_has_data_data1`
    FOREIGN KEY (`data_id`)
    REFERENCES `HomeAutomationDb`.`data` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`action_has_switch_condition`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`action_has_switch_condition` (
  `action_id` INT NOT NULL,
  `switch_condition_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`action_id`, `switch_condition_id`),
  INDEX `fk_action_has_switch_condition_switch_condition1_idx` (`switch_condition_id` ASC),
  INDEX `fk_action_has_switch_condition_action1_idx` (`action_id` ASC),
  CONSTRAINT `fk_action_has_switch_condition_action1`
    FOREIGN KEY (`action_id`)
    REFERENCES `HomeAutomationDb`.`action` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_action_has_switch_condition_switch_condition1`
    FOREIGN KEY (`switch_condition_id`)
    REFERENCES `HomeAutomationDb`.`switch_condition` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`action_has_component`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`action_has_component` (
  `action_id` INT NOT NULL,
  `component_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`action_id`, `component_id`),
  INDEX `fk_action_has_component_component1_idx` (`component_id` ASC),
  INDEX `fk_action_has_component_action1_idx` (`action_id` ASC),
  CONSTRAINT `fk_action_has_component_action1`
    FOREIGN KEY (`action_id`)
    REFERENCES `HomeAutomationDb`.`action` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_action_has_component_component1`
    FOREIGN KEY (`component_id`)
    REFERENCES `HomeAutomationDb`.`component` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`action_has_scheduler`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`action_has_scheduler` (
  `action_id` INT NOT NULL,
  `scheduler_id` INT NOT NULL,
  PRIMARY KEY (`action_id`, `scheduler_id`),
  INDEX `fk_action_has_scheduler_scheduler1_idx` (`scheduler_id` ASC),
  INDEX `fk_action_has_scheduler_action1_idx` (`action_id` ASC),
  CONSTRAINT `fk_action_has_scheduler_action1`
    FOREIGN KEY (`action_id`)
    REFERENCES `HomeAutomationDb`.`action` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_action_has_scheduler_scheduler1`
    FOREIGN KEY (`scheduler_id`)
    REFERENCES `HomeAutomationDb`.`scheduler` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `HomeAutomationDb`.`component_has_scheduler`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `HomeAutomationDb`.`component_has_scheduler` (
  `component_id` INT UNSIGNED NOT NULL,
  `scheduler_id` INT NOT NULL,
  PRIMARY KEY (`component_id`, `scheduler_id`),
  INDEX `fk_component_has_scheduler_scheduler1_idx` (`scheduler_id` ASC),
  INDEX `fk_component_has_scheduler_component1_idx` (`component_id` ASC),
  CONSTRAINT `fk_component_has_scheduler_component1`
    FOREIGN KEY (`component_id`)
    REFERENCES `HomeAutomationDb`.`component` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_component_has_scheduler_scheduler1`
    FOREIGN KEY (`scheduler_id`)
    REFERENCES `HomeAutomationDb`.`scheduler` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
