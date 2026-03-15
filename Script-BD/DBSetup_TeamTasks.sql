

CREATE DATABASE [TaskTeamSetupDB];
GO

USE [TaskTeamSetupDB];
-- ==========================
-- Tabla Developers
-- ==========================
CREATE TABLE Developers (
    DeveloperId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE()
);

CREATE TABLE CodeGenericStatusProject (
    StatusProjectId INT IDENTITY(1,1) PRIMARY KEY,
    StatusProject NVARCHAR(20) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
	 CONSTRAINT CK_Project_Status_Project 
	 CHECK (StatusProject IN ('ToDo','InProgress','Blocked','Completed'))
);



CREATE TABLE CodeGenericStatusTask (
    StatusTaskId INT IDENTITY(1,1) PRIMARY KEY,
    StatusTask NVARCHAR(20) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
	 CONSTRAINT CK_Project_Status_Task
    CHECK (StatusTask IN ('ToDo','InProgress','Blocked','Completed'))
);

CREATE TABLE CodeGenericStatusPriority (
    StatusPriorityId INT IDENTITY(1,1) PRIMARY KEY,
    StatusPriority NVARCHAR(20) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
	 CONSTRAINT CK_Project_Status_Prioriy
    CHECK (StatusPriority IN ('Low','Medium','High'))
);

-- ==========================
-- Tabla Projects
-- ==========================
CREATE TABLE Projects (
    ProjectId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    ClientName NVARCHAR(200) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NULL,
    Status NVARCHAR(20) NOT NULL,
    
    CONSTRAINT CK_Project_Status 
    CHECK (Status IN ('ToDo','InProgress','Blocked','Completed'))
);


-- ==========================
-- Tabla Tasks
-- ==========================
CREATE TABLE Tasks (
    TaskId INT IDENTITY(1,1) PRIMARY KEY,
    ProjectId INT NOT NULL,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    AssigneeId INT NULL,
    Status NVARCHAR(20) NOT NULL,
    Priority NVARCHAR(20) NOT NULL,
    EstimatedComplexity INT NOT NULL,
    DueDate DATE NULL,
    CompletionDate DATE NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),

    -- Relaciones
    CONSTRAINT FK_Task_Project
        FOREIGN KEY (ProjectId) REFERENCES Projects(ProjectId),
            
    CONSTRAINT FK_Task_Developer
        FOREIGN KEY (AssigneeId) REFERENCES Developers(DeveloperId),

    -- Validaciones
    CONSTRAINT CK_Task_Status 
        CHECK (Status IN ('ToDo','InProgress','Blocked','Completed')),

    CONSTRAINT CK_Task_Priority
        CHECK (Priority IN ('Low','Medium','High')),

    CONSTRAINT CK_Task_Complexity
        CHECK (EstimatedComplexity BETWEEN 1 AND 5)
);


INSERT INTO CodeGenericStatusProject (StatusProject)
VALUES 
('ToDo'),
('InProgress'),
('Blocked'),
('Completed');

INSERT INTO CodeGenericStatusPriority (StatusPriority)
VALUES 
('Low'),
('Medium'),
('High');

INSERT INTO CodeGenericStatusTask (StatusTask)
VALUES 
('ToDo'),
('InProgress'),
('Blocked'),
('Completed');


-- ==========================
-- Insert Developers
-- ==========================

INSERT INTO Developers (FirstName, LastName, Email, IsActive)
VALUES
('Juan', 'Perez', 'juan.perez@company.com', 1),
('Maria', 'Gomez', 'maria.gomez@company.com', 1),
('Carlos', 'Rodriguez', 'carlos.rodriguez@company.com', 1),
('Ana', 'Martinez', 'ana.martinez@company.com', 1),
('Luis', 'Fernandez', 'luis.fernandez@company.com', 1);

-- ==========================
-- Insert Project
-- ==========================

INSERT INTO Projects (Name, ClientName, StartDate, EndDate, Status)
VALUES
('ERP Implementation', 'NutriExpress', '2026-01-10', NULL, 'InProgress'),
('Mobile Sales App', 'RetailCorp', '2026-02-01', NULL, 'InProgress'),
('Inventory AI System', 'LogiTech', '2026-03-01', NULL, 'Planned'),
('CRM Platform', 'SalesCorp', '2026-03-05', NULL, 'InProgress'),
('Logistics Dashboard', 'TransLog', '2026-03-06', NULL, 'InProgress'),
('E-Commerce Platform', 'ShopWorld', '2026-03-07', NULL, 'InProgress'),
('Payment Gateway', 'FinTechPro', '2026-03-08', NULL, 'Planned'),
('Customer Support System', 'HelpDesk Inc', '2026-03-09', NULL, 'Planned'),
('Analytics Platform', 'DataVision', '2026-03-10', NULL, 'InProgress'),
('Warehouse Automation', 'SmartLogistics', '2026-03-11', NULL, 'Planned'),
('Marketing Automation', 'AdMarket', '2026-03-12', NULL, 'Planned'),
('Social Media Manager', 'MediaTools', '2026-03-13', NULL, 'InProgress'),
('Booking Platform', 'TravelEasy', '2026-03-14', NULL, 'Planned'),
('Learning Platform', 'EduTech', '2026-03-15', NULL, 'InProgress'),
('Recruitment System', 'HRPro', '2026-03-16', NULL, 'Planned'),
('Cloud Migration', 'TechCloud', '2026-03-17', NULL, 'InProgress'),
('IoT Monitoring', 'SmartDevices', '2026-03-18', NULL, 'Planned'),
('Fleet Management', 'TransportCorp', '2026-03-19', NULL, 'InProgress'),
('Customer Loyalty App', 'RetailPlus', '2026-03-20', NULL, 'Planned'),
('Healthcare Portal', 'MediHealth', '2026-03-21', NULL, 'InProgress'),
('Finance Dashboard', 'FinCorp', '2026-04-01', NULL, 'InProgress'),
('HR Management System', 'PeopleSoft', '2026-04-02', NULL, 'Planned'),
('Logistics Tracker', 'MoveFast', '2026-04-03', NULL, 'InProgress'),
('Food Delivery Platform', 'QuickFood', '2026-04-04', NULL, 'Planned'),
('Real Estate Portal', 'HomeSearch', '2026-04-05', NULL, 'InProgress'),
('Hotel Reservation System', 'StayEasy', '2026-04-06', NULL, 'Planned'),
('Vehicle Rental App', 'RentCar', '2026-04-07', NULL, 'InProgress'),
('Event Management System', 'Eventify', '2026-04-08', NULL, 'Planned'),
('Online Learning Platform', 'EduSmart', '2026-04-09', NULL, 'InProgress'),
('Customer Feedback System', 'FeedbackPro', '2026-04-10', NULL, 'Planned'),
('Project 31','Client 31','2026-04-11',NULL,'InProgress'),
('Project 32','Client 32','2026-04-12',NULL,'Planned'),
('Project 33','Client 33','2026-04-13',NULL,'InProgress'),
('Project 34','Client 34','2026-04-14',NULL,'Planned'),
('Project 35','Client 35','2026-04-15',NULL,'InProgress'),
('Project 36','Client 36','2026-04-16',NULL,'Planned'),
('Project 37','Client 37','2026-04-17',NULL,'InProgress'),
('Project 38','Client 38','2026-04-18',NULL,'Planned'),
('Project 39','Client 39','2026-04-19',NULL,'InProgress'),
('Project 40','Client 40','2026-04-20',NULL,'Planned'),
('Project 41','Client 41','2026-04-21',NULL,'InProgress'),
('Project 42','Client 42','2026-04-22',NULL,'Planned'),
('Project 43','Client 43','2026-04-23',NULL,'InProgress'),
('Project 44','Client 44','2026-04-24',NULL,'Planned'),
('Project 45','Client 45','2026-04-25',NULL,'InProgress'),
('Project 46','Client 46','2026-04-26',NULL,'Planned'),
('Project 47','Client 47','2026-04-27',NULL,'InProgress'),
('Project 48','Client 48','2026-04-28',NULL,'Planned'),
('Project 49','Client 49','2026-04-29',NULL,'InProgress'),
('Project 50','Client 50','2026-04-30',NULL,'Planned'),
('Project 51','Client 51','2026-05-01',NULL,'InProgress'),
('Project 52','Client 52','2026-05-02',NULL,'Planned'),
('Project 53','Client 53','2026-05-03',NULL,'InProgress'),
('Project 54','Client 54','2026-05-04',NULL,'Planned'),
('Project 55','Client 55','2026-05-05',NULL,'InProgress'),
('Project 56','Client 56','2026-05-06',NULL,'Planned'),
('Project 57','Client 57','2026-05-07',NULL,'InProgress'),
('Project 58','Client 58','2026-05-08',NULL,'Planned'),
('Project 59','Client 59','2026-05-09',NULL,'InProgress'),
('Project 60','Client 60','2026-05-10',NULL,'Planned'),
('Project 61','Client 61','2026-05-11',NULL,'InProgress'),
('Project 62','Client 62','2026-05-12',NULL,'Planned'),
('Project 63','Client 63','2026-05-13',NULL,'InProgress'),
('Project 64','Client 64','2026-05-14',NULL,'Planned'),
('Project 65','Client 65','2026-05-15',NULL,'InProgress'),
('Project 66','Client 66','2026-05-16',NULL,'Planned'),
('Project 67','Client 67','2026-05-17',NULL,'InProgress'),
('Project 68','Client 68','2026-05-18',NULL,'Planned'),
('Project 69','Client 69','2026-05-19',NULL,'InProgress'),
('Project 70','Client 70','2026-05-20',NULL,'Planned'),
('Project 71','Client 71','2026-05-21',NULL,'InProgress'),
('Project 72','Client 72','2026-05-22',NULL,'Planned'),
('Project 73','Client 73','2026-05-23',NULL,'InProgress'),
('Project 74','Client 74','2026-05-24',NULL,'Planned'),
('Project 75','Client 75','2026-05-25',NULL,'InProgress'),
('Project 76','Client 76','2026-05-26',NULL,'Planned'),
('Project 77','Client 77','2026-05-27',NULL,'InProgress'),
('Project 78','Client 78','2026-05-28',NULL,'Planned'),
('Project 79','Client 79','2026-05-29',NULL,'InProgress'),
('Project 80','Client 80','2026-05-30',NULL,'Planned'),
('Project 81','Client 81','2026-05-31',NULL,'InProgress'),
('Project 82','Client 82','2026-06-01',NULL,'Planned'),
('Project 83','Client 83','2026-06-02',NULL,'InProgress'),
('Project 84','Client 84','2026-06-03',NULL,'Planned'),
('Project 85','Client 85','2026-06-04',NULL,'InProgress'),
('Project 86','Client 86','2026-06-05',NULL,'Planned'),
('Project 87','Client 87','2026-06-06',NULL,'InProgress'),
('Project 88','Client 88','2026-06-07',NULL,'Planned'),
('Project 89','Client 89','2026-06-08',NULL,'InProgress'),
('Project 90','Client 90','2026-06-09',NULL,'Planned'),
('Project 91','Client 91','2026-06-10',NULL,'InProgress'),
('Project 92','Client 92','2026-06-11',NULL,'Planned'),
('Project 93','Client 93','2026-06-12',NULL,'InProgress'),
('Project 94','Client 94','2026-06-13',NULL,'Planned'),
('Project 95','Client 95','2026-06-14',NULL,'InProgress'),
('Project 96','Client 96','2026-06-15',NULL,'Planned'),
('Project 97','Client 97','2026-06-16',NULL,'InProgress'),
('Project 98','Client 98','2026-06-17',NULL,'Planned'),
('Project 99','Client 99','2026-06-18',NULL,'InProgress'),
('Project 100','Client 100','2026-06-19',NULL,'Planned');


-- ==========================
-- Insert Tasks
-- ==========================

INSERT INTO Tasks 
(ProjectId, Title, Description, AssigneeId, Status, Priority, EstimatedComplexity, DueDate, CompletionDate)
VALUES

-- ERP Implementation (ProjectId = 1)
(1,'Design database schema','Create relational model',1,'Completed','High',4,'2026-01-20','2026-01-19'),
(1,'Create authentication module','Login and JWT auth',2,'InProgress','High',3,'2026-03-20',NULL),
(1,'Implement user roles','Admin and user roles',3,'ToDo','Medium',2,'2026-03-25',NULL),
(1,'API documentation','Swagger documentation',4,'ToDo','Low',1,'2026-03-28',NULL),
(1,'Payment integration','Integrate payment gateway',5,'Blocked','High',5,'2026-04-05',NULL),
(1,'Unit testing','Test core modules',2,'InProgress','Medium',3,'2026-04-01',NULL),
(1,'Optimize queries','Improve DB performance',1,'ToDo','Medium',2,'2026-04-10',NULL),

-- Mobile Sales App (ProjectId = 2)
(2,'UI Wireframes','Design mobile screens',3,'Completed','Medium',2,'2026-02-10','2026-02-09'),
(2,'Flutter project setup','Initial mobile setup',4,'Completed','Low',1,'2026-02-15','2026-02-14'),
(2,'Product catalog API','Fetch products',2,'InProgress','High',3,'2026-03-18',NULL),
(2,'Shopping cart feature','Cart logic',1,'InProgress','High',4,'2026-03-30',NULL),
(2,'Order processing','Handle orders',5,'ToDo','High',4,'2026-04-05',NULL),
(2,'Push notifications','Firebase notifications',3,'ToDo','Medium',2,'2026-04-10',NULL),
(2,'User profile screen','Profile management',4,'ToDo','Low',1,'2026-04-15',NULL),

-- Inventory AI System (ProjectId = 3)
(3,'Data collection','Gather historical data',1,'ToDo','High',4,'2026-04-20',NULL),
(3,'Data cleaning','Prepare dataset',2,'ToDo','Medium',3,'2026-04-22',NULL),
(3,'Model training','Train prediction model',3,'ToDo','High',5,'2026-05-05',NULL),
(3,'API for predictions','Serve ML model',4,'ToDo','Medium',3,'2026-05-10',NULL),
(3,'Dashboard analytics','Visualization charts',5,'ToDo','Medium',3,'2026-05-15',NULL),
(3,'System deployment','Deploy AI service',1,'ToDo','High',4,'2026-05-20',NULL);

GO

--  Resumen de carga por desarrollador

CREATE VIEW ChargeDeveloperView
AS
  SELECT 
  d.DeveloperId, 
  CONCAT_WS(' ',d.FirstName,d.LastName) AS FullName,
  SUM(CASE 
        WHEN t.Status <> 'Completed' THEN 1 
        ELSE 0 
    END) AS OpenTasksCount,
  AVG(t.EstimatedComplexity) AS AverageEstimatedComplexity
  FROM Developers d
  LEFT JOIN Tasks t ON t.AssigneeId = d.DeveloperId 
  WHERE d.IsActive = 1
  GROUP BY d.DeveloperId,CONCAT_WS(' ',d.FirstName,d.LastName);

  GO
-- Vista para filtrar las tareas
   CREATE VIEW ProjectWithTaskListFilter AS 
  SELECT DISTINCT
    p.ProjectId,
  p.Name,
  p.ClientName,
  p.Status,
  t.AssigneeId
  FROM Projects p 
  LEFT JOIN Tasks t ON t.ProjectId = p.ProjectId
  WHERE t.AssigneeId IS NOT NULL;

  GO

  -- Tareas pr ximas a vencer
  CREATE VIEW JobsNextExpiration AS
  SELECT 
  t.TaskId,
  p.ClientName,
  t.Title,
  t.Description,
  CONCAT_WS(' ',d.FirstName,d.LastName) AS FullName,
  t.Priority,
  t.EstimatedComplexity
  FROM Tasks t
  INNER JOIN Projects p ON p.ProjectId = t.ProjectId
  INNER JOIN Developers d ON d.DeveloperId = t.AssigneeId
  WHERE 
  t.Status <> 'Completed' AND DATEDIFF(day,  GETDATE(), t.DueDate) BETWEEN 1 AND 7;

  GO



CREATE PROCEDURE SP_InsertTask
@ProjectId INT,
@Title NVARCHAR(200),
@Description NVARCHAR(MAX),
@AssigneeId INT,
@Status NVARCHAR(20),
@Priority NVARCHAR(20),
@EstimatedComplexity INT,
@DueDate DATE,
@CompletionDate DATE
AS
BEGIN

SET NOCOUNT ON;

BEGIN TRY

            IF NOT EXISTS (
            SELECT 1 
            FROM Projects p 
            WHERE p.ProjectId = @ProjectId
        )
        BEGIN
            THROW 50001, 'El proyecto no existe.', 1;
        END


        IF NOT EXISTS (
            SELECT 1 
            FROM Developers d 
            WHERE d.DeveloperId = @AssigneeId
        )
        BEGIN
            THROW 50002, 'El desarrollador no existe.', 1;
        END

    BEGIN TRANSACTION;

    INSERT INTO Tasks
    (
        ProjectId,
        Title,
        Description,
        AssigneeId,
        Status,
        Priority,
        EstimatedComplexity,
        DueDate,
        CompletionDate
    )
    VALUES
    (
        @ProjectId,
        @Title,
        @Description,
        @AssigneeId,
        @Status,
        @Priority,
        @EstimatedComplexity,
        @DueDate,
        @CompletionDate
    );

    COMMIT TRANSACTION;

END TRY

BEGIN CATCH

    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;
    THROW;

END CATCH

END;
GO

 -- Resumen de estado por proyecto
 CREATE PROCEDURE Sp_StatusForProJect
  AS 
  BEGIN
     

     WITH CteStatus AS
     (
      SELECT 
  p.ProjectId,
  p.Name,
  p.ClientName,
  p.Status,
  SUM(CASE 
        WHEN t.Status <> 'Completed' THEN 1 
        ELSE 0 
    END) AS OpenTasks,

  SUM(CASE 
        WHEN t.Status = 'Completed' THEN 1 
        ELSE 0 
    END) AS CompletedTasks
  FROM Projects p
  LEFT JOIN Tasks t ON t.ProjectId = p.ProjectId 
  GROUP BY p.Name,p.ProjectId,p.ClientName,p.Status
     )
     SELECT 
     ct.*,
     ISNULL(ct.OpenTasks,0) + ISNULL(ct.CompletedTasks,0) AS TotalTasks
     FROM CteStatus ct;

  END;

  GO

  CREATE PROCEDURE LoadInformationInitial AS
  BEGIN

  SELECT CAST((
    SELECT
        JSON_QUERY((
            SELECT p.ProjectId AS StatusProjectId, p.ClientName AS StatusProject
            FROM Projects p
            FOR JSON PATH
        )) AS Projects,
		JSON_QUERY((
		SELECT p.StatusTaskId, p.StatusTask
            FROM CodeGenericStatusTask p WHERE p.IsActive = 1
            FOR JSON PATH
		)) AS Tasks,
        JSON_QUERY((
            SELECT d.DeveloperId,
                   CONCAT_WS(' ', d.FirstName, d.LastName) AS FullName
            FROM Developers d
            WHERE d.IsActive = 1
            FOR JSON PATH
        )) AS Developers,
		JSON_QUERY((
            SELECT d.StatusPriorityId,d.StatusPriority
            FROM CodeGenericStatusPriority d
            WHERE d.IsActive = 1
            FOR JSON PATH
        )) AS Priority
    FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
) AS NVARCHAR(MAX))


  END;

  GO

  
  CREATE PROCEDURE SP_FilterForTask 
  @ProjectId INT
  AS
  BEGIN

     IF @ProjectId IS NULL BEGIN 
	     THROW 50001, 'El proyecto no existe.', 1;
	 END;

    SELECT 
	t.Title,
	CONCAT_WS('',d.FirstName,d.LastName) AS Fullname,
	t.Status,
	t.Priority,
	t.EstimatedComplexity,
	t.CreatedAt,
	t.DueDate,
	t.AssigneeId
	FROM Tasks t
	INNER JOIN Developers d ON d.DeveloperId = t.AssigneeId AND d.IsActive = 1
	WHERE t.ProjectId = @ProjectId;

  END

  GO
