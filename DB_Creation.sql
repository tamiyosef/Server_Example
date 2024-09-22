Use master
Go
IF EXISTS (SELECT * FROM sys.databases WHERE name = N'MyAppName_DB')
BEGIN
    DROP DATABASE MyAppName_DB;
END
Go
Create Database MyAppName_DB
Go
Use MyAppName_DB
Go

-- יצירת טבלת תלמידים
CREATE TABLE Students (
    StudentId INT PRIMARY KEY,        -- מפתח ראשי
    FullName NVARCHAR(100),           -- שם מלא של התלמיד
    DateOfBirth DATE                  -- תאריך לידה של התלמיד
);

-- יצירת טבלת מורים
CREATE TABLE Teachers (
    TeacherId INT PRIMARY KEY,        -- מפתח ראשי
    TeacherName NVARCHAR(100)         -- שם מלא של המורה
);

-- יצירת טבלת מקצועות לימוד
CREATE TABLE Subjects (
    SubjectId INT PRIMARY KEY,        -- מפתח ראשי
    SubjectName NVARCHAR(100),        -- שם המקצוע
    TeacherId INT,                    -- מפתח זר לטבלת מורים
    FOREIGN KEY (TeacherId) REFERENCES Teachers(TeacherId)   -- קישור לטבלת המורים
);

-- יצירת טבלת חדרי לימוד
CREATE TABLE Classrooms (
    ClassroomId INT PRIMARY KEY,      -- מפתח ראשי
    ClassroomName NVARCHAR(100),      -- שם חדר הלימוד
    Capacity INT                      -- כמות מקומות בחדר
);

-- יצירת טבלת רישום
CREATE TABLE Enrollments (
    EnrollmentId INT PRIMARY KEY,     -- מפתח ראשי
    StudentId INT,                    -- מפתח זר לטבלת תלמידים
    SubjectId INT,                    -- מפתח זר לטבלת מקצועות לימוד
    EnrollmentDate DATE,              -- תאריך הרישום
    Grade DECIMAL(5, 2),              -- ציון
    FOREIGN KEY (StudentId) REFERENCES Students(StudentId),   -- קישור לטבלת התלמידים
    FOREIGN KEY (SubjectId) REFERENCES Subjects(SubjectId)    -- קישור לטבלת המקצועות
);

-- יצירת טבלת שיבוץ מקצועות בחדרי לימוד
CREATE TABLE SubjectClassroomAssignments (
    AssignmentId INT PRIMARY KEY,     -- מפתח ראשי
    SubjectId INT,                    -- מפתח זר לטבלת מקצועות לימוד
    ClassroomId INT,                  -- מפתח זר לטבלת חדרי לימוד
    Schedule NVARCHAR(100),           -- לוח זמנים לשיעור
    FOREIGN KEY (SubjectId) REFERENCES Subjects(SubjectId),   -- קישור לטבלת המקצועות
    FOREIGN KEY (ClassroomId) REFERENCES Classrooms(ClassroomId)  -- קישור לטבלת חדרי הלימוד
);

-- Create a login for the admin user
CREATE LOGIN [TaskAdminLogin] WITH PASSWORD = 'kukuPassword';
Go

-- Create a user in the TamiDB database for the login
CREATE USER [TaskAdminUser] FOR LOGIN [TaskAdminLogin];
Go

-- Add the user to the db_owner role to grant admin privileges
ALTER ROLE db_owner ADD MEMBER [TaskAdminUser];
Go



select * from subjects

insert into Students values (1, N'אבי כהן', '2000-01-01')
insert into Teachers values (1, N'תמי יוסף')
insert into Subjects values (1, N'מתמטיקה', 1)
insert into Subjects values (2, N'שירותי רשת', 1)
GO

--EF Code
/*
scaffold-DbContext "Server = (localdb)\MSSQLLocalDB;Initial Catalog=MyAppName_DB;User ID=TaskAdminLogin;Password=kukuPassword;" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models -Context TamiDBContext -DataAnnotations -force
*/