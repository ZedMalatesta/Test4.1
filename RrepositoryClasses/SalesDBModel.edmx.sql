
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/10/2017 22:52:26
-- Generated from EDMX file: C:\newProjects\Project4\RrepositoryClasses\SalesDBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SaleDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ManagerSet'
CREATE TABLE [dbo].[ManagerSet] (
    [ManagerID] int  NOT NULL,
    [ManagerName] nvarchar(40)  NOT NULL
);
GO

-- Creating table 'SaleInfoSet'
CREATE TABLE [dbo].[SaleInfoSet] (
    [ManagerID] int IDENTITY(1,1) NOT NULL,
    [ClientName] nvarchar(max)  NOT NULL,
    [Product] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Cost] int  NOT NULL,
    [Manager_ManagerID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ManagerID] in table 'ManagerSet'
ALTER TABLE [dbo].[ManagerSet]
ADD CONSTRAINT [PK_ManagerSet]
    PRIMARY KEY CLUSTERED ([ManagerID] ASC);
GO

-- Creating primary key on [ManagerID] in table 'SaleInfoSet'
ALTER TABLE [dbo].[SaleInfoSet]
ADD CONSTRAINT [PK_SaleInfoSet]
    PRIMARY KEY CLUSTERED ([ManagerID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Manager_ManagerID] in table 'SaleInfoSet'
ALTER TABLE [dbo].[SaleInfoSet]
ADD CONSTRAINT [FK_ManagerSaleInfo]
    FOREIGN KEY ([Manager_ManagerID])
    REFERENCES [dbo].[ManagerSet]
        ([ManagerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerSaleInfo'
CREATE INDEX [IX_FK_ManagerSaleInfo]
ON [dbo].[SaleInfoSet]
    ([Manager_ManagerID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------