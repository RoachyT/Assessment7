
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/14/2018 10:01:45
-- Generated from EDMX file: C:\Users\rtoles\Desktop\Assessment7\Put_me_on_the_list_chief\Put_me_on_the_list_chief\Models\PartyDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PartyDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Dish]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dish];
GO
IF OBJECT_ID(N'[dbo].[Guest]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Guest];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Dishes'
CREATE TABLE [dbo].[Dishes] (
    [DishID] int IDENTITY(1,1) NOT NULL,
    [PersonName] nvarchar(50)  NULL,
    [PhoneNumber] nvarchar(24)  NULL,
    [DishName] nvarchar(50)  NULL,
    [DishDescription] nvarchar(100)  NULL,
    [Restriction] nvarchar(20)  NULL
);
GO

-- Creating table 'Guests'
CREATE TABLE [dbo].[Guests] (
    [GuestID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NULL,
    [AttendanceDate] datetime  NULL,
    [EmailAddress] nvarchar(50)  NULL,
    [Guest1] nvarchar(50)  NULL,
    [Attending] nvarchar(5)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [DishID] in table 'Dishes'
ALTER TABLE [dbo].[Dishes]
ADD CONSTRAINT [PK_Dishes]
    PRIMARY KEY CLUSTERED ([DishID] ASC);
GO

-- Creating primary key on [GuestID] in table 'Guests'
ALTER TABLE [dbo].[Guests]
ADD CONSTRAINT [PK_Guests]
    PRIMARY KEY CLUSTERED ([GuestID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------