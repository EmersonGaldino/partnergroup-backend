USE PartnerGroup

CREATE TABLE dbo.[Brand]
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Brand] VARCHAR(300) NOT NULL,
	[DateRegister] DATETIME NOT NULL,
	[DateChange] DATETIME NULL,
	[Active] BIT NOT NULL
 )
 GO

CREATE TABLE dbo.[Patrimony]
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[BrandId] BIGINT NOT NULL,
	[Patrimony] VARCHAR(800) NOT NULL,
	[Description] VARCHAR(800) NOT NULL,
	[NumberTumble] VARCHAR(15) NOT NULL,
	[DateRegister] DATETIME NOT NULL,
	[DateChange] DATETIME NULL,
	[Active] BIT NOT NULL

	FOREIGN KEY (BrandId) REFERENCES dbo.[Brand](id),
 )
 GO

SELECT * FROM dbo.Patrimony (NOLOCK)

INSERT INTO dbo.Patrimony VALUES (2, 'Patrimony', 'Description', 'NumberTumble', GETDATE(), NULL, 1)

SELECT * FROM dbo.Brand WHERE Id = 1

TRUNCATE TABLE dbo.Brand 


SELECT 

P.[Id] 'P_Id',
P.[BrandId] 'P_BrandId',
P.[Patrimony] 'P_Patrimony',
P.[Description] 'P_Description',
P.[NumberTumble] 'P_NumberTumble',
P.[DateRegister] 'P_DateRegister',
P.[DateChange] 'P_DateChange',
P.[Active] 'P_Active',

B.[Id] 'B_Id',
B.[Brand] 'B_Brand',
B.[DateRegister] 'B_DateRegister',
B.[DateChange] 'B_DateChange',
B.[Active] 'B_Active'

FROM dbo.Patrimony (NOLOCK) P INNER JOIN dbo.Brand (NOLOCK) B ON B.Id = P.BrandId WHERE P.BrandId = @BranchId

