SET NOCOUNT ON;
USE TaskMangerDB;
IF OBJECT_ID(N'TodoTasks', N'U') IS NOT NULL DROP TABLE dbo.TodoTasks;

CREATE TABLE dbo.TodoTasks
(
	taskid INT NOT NULL PRIMARY KEY IDENTITY(1,1) ,
	taskname NVARCHAR(50) NOT NULL,
	creatorname NVARCHAR(30) NOT NULL,
	description NVARCHAR(250) NOT NULL,
	creationdate DATETIME NOT NULL,
	isfinished BIT NOT NULL,
	/*CONSTRAINT PK_TodoTasks PRIMARY KEY(taskid)*/
);
GO

INSERT INTO dbo.TodoTasks(
	taskid,
	taskname,
	creatorname,
	creationdate,
	isfinished,
	description) VALUES
	(1,'Utworzenie kontrolera API','Dominik',N'20190616',0,'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus congue dolor nec nibh condimentum, sit amet ullamcorper erat vehicula. Praesent.'),
	(2,'Utworzenie EMAILSENDER','Dominik','20190615',0,'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus congue dolor nec nibh condimentum, sit amet ullamcorper erat vehicula. Praesent.'),
	(3,'Dodanie PAGINATION','Romek','20190615',0,'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus congue dolor nec nibh condimentum, sit amet ullamcorper erat vehicula. Praesent.'),
	(4,'Dodanie EntityFramework','Roman','20180401',1,'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus congue dolor nec nibh condimentum, sit amet ullamcorper erat vehicula. Praesent.'),
	(5,'Utworznie Projektu','Romek','20180329',1,'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus congue dolor nec nibh condimentum, sit amet ullamcorper erat vehicula. Praesent.');