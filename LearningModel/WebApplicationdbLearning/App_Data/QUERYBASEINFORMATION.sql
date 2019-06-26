CREATE DATABASE dbLearning
GO

USE dbLearning
GO
-- Creating table 'Role'

CREATE TABLE [dbo].[Role] (
    [RoleId] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [RoleName] nvarchar(max)  NOT NULL,
	DateCreated datetime Default GETDATE()
);
GO
-- Creating table 'Person'
CREATE TABLE [dbo].[Person] (
    [PersonId] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [RoleId] int  NOT NULL REFERENCES [dbo].[Role](RoleId),
    [UserName] nvarchar(max)  NOT NULL,
	DateCreated datetime Default GETDATE()
);
GO

CREATE TABLE [dbo].[Password] (
    [PasswordId] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [PersonId] int  NOT NULL REFERENCES [dbo].[Person]([PersonId]),
    [GUID] nvarchar(max)  NOT NULL,
    [CreateDate] datetime  NOT NULL DEFAULT GETDATE()
);
GO

CREATE TABLE [dbo].[Semantic] (
    [SemanticId] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [PersonId] int not null REFERENCES [dbo].[Person]([PersonId]),
	DateCreated datetime Default GETDATE()
);
GO

CREATE TABLE [dbo].[Concept] (
    [ConceptId] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL,
	SemanticId int not null REFERENCES [dbo].[Semantic]([SemanticId]),
    [PersonId] int not null REFERENCES [dbo].[Person]([PersonId]),
	DateCreated datetime Default GETDATE()
);
GO

CREATE TABLE [dbo].[Information] (

    [InformationId] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Description] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL,
	ConceptId int not null REFERENCES [dbo].[Concept]([ConceptId]),
    [PersonId] int not null REFERENCES [dbo].[Person]([PersonId]),
	DateCreated datetime Default GETDATE()
);
GO

CREATE TABLE [dbo].[InformationInspection] (

    [InformationInspectionId] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [InformationId]  int not null REFERENCES [dbo].[Information]([InformationId]),
	[PersonId] int not null REFERENCES [dbo].[Person]([PersonId]),
	DateCreated datetime Default GETDATE()
);
GO

