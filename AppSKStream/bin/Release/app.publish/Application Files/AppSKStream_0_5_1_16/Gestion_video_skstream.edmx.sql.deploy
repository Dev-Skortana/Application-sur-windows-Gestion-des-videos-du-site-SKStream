
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/28/2018 08:17:27
-- Generated from EDMX file: C:\Users\spart\OneDrive\Documents\Visual Studio 2015\Projects\AppSKStream\AppSKStream\Gestion_video_skstream.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Gestion_skstream];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AnimerDetail_animer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sommaire_seriesSet_Detail_animer] DROP CONSTRAINT [FK_AnimerDetail_animer];
GO
IF OBJECT_ID(N'[dbo].[FK_Series_Detailseries]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sommaire_seriesSet_Detail_series] DROP CONSTRAINT [FK_Series_Detailseries];
GO
IF OBJECT_ID(N'[dbo].[FK_Video_serie_inherits_Videos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VideosSet_Video_serie] DROP CONSTRAINT [FK_Video_serie_inherits_Videos];
GO
IF OBJECT_ID(N'[dbo].[FK_Animer_inherits_Video_serie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VideosSet_Animer] DROP CONSTRAINT [FK_Animer_inherits_Video_serie];
GO
IF OBJECT_ID(N'[dbo].[FK_Detail_animer_inherits_Sommaire_series]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sommaire_seriesSet_Detail_animer] DROP CONSTRAINT [FK_Detail_animer_inherits_Sommaire_series];
GO
IF OBJECT_ID(N'[dbo].[FK_Series_inherits_Video_serie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VideosSet_Series] DROP CONSTRAINT [FK_Series_inherits_Video_serie];
GO
IF OBJECT_ID(N'[dbo].[FK_Detail_series_inherits_Sommaire_series]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sommaire_seriesSet_Detail_series] DROP CONSTRAINT [FK_Detail_series_inherits_Sommaire_series];
GO
IF OBJECT_ID(N'[dbo].[FK_Films_inherits_Videos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VideosSet_Films] DROP CONSTRAINT [FK_Films_inherits_Videos];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[VideosSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VideosSet];
GO
IF OBJECT_ID(N'[dbo].[Sommaire_seriesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sommaire_seriesSet];
GO
IF OBJECT_ID(N'[dbo].[VideosSet_Video_serie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VideosSet_Video_serie];
GO
IF OBJECT_ID(N'[dbo].[VideosSet_Animer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VideosSet_Animer];
GO
IF OBJECT_ID(N'[dbo].[Sommaire_seriesSet_Detail_animer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sommaire_seriesSet_Detail_animer];
GO
IF OBJECT_ID(N'[dbo].[VideosSet_Series]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VideosSet_Series];
GO
IF OBJECT_ID(N'[dbo].[Sommaire_seriesSet_Detail_series]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sommaire_seriesSet_Detail_series];
GO
IF OBJECT_ID(N'[dbo].[VideosSet_Films]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VideosSet_Films];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'VideosSet'
CREATE TABLE [dbo].[VideosSet] (
    [Titre] nvarchar(100) NOT NULL,
    [Acteure] nvarchar(100)  NOT NULL,
    [Genre] nvarchar(100)  NOT NULL,
    [Pays] nvarchar(100)  NOT NULL,
    [Duree] time  NOT NULL,
    [Creer_par] nvarchar(100)  NOT NULL,
    [Categorie] nvarchar(100)  NOT NULL,
    [Description] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Sommaire_seriesSet'
CREATE TABLE [dbo].[Sommaire_seriesSet] (
    [Saison] bigint  NOT NULL,
    [Episode] bigint  NOT NULL,
    [Lien] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'VideosSet_Video_serie'
CREATE TABLE [dbo].[VideosSet_Video_serie] (
    [NBsaison] bigint  NOT NULL,
    [NBepisode] bigint  NOT NULL,
    [Annee_lancement] bigint  NOT NULL,
    [Titre] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'VideosSet_Animer'
CREATE TABLE [dbo].[VideosSet_Animer] (
    [Titre] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Sommaire_seriesSet_Detail_animer'
CREATE TABLE [dbo].[Sommaire_seriesSet_Detail_animer] (
    [Titre] nvarchar(100)  NOT NULL,
    [Saison] bigint  NOT NULL,
    [Episode] bigint  NOT NULL
);
GO

-- Creating table 'VideosSet_Series'
CREATE TABLE [dbo].[VideosSet_Series] (
    [Titre] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Sommaire_seriesSet_Detail_series'
CREATE TABLE [dbo].[Sommaire_seriesSet_Detail_series] (
    [Titre] nvarchar(100)  NOT NULL,
    [Saison] bigint  NOT NULL,
    [Episode] bigint  NOT NULL
);
GO

-- Creating table 'VideosSet_Films'
CREATE TABLE [dbo].[VideosSet_Films] (
    [Anne_production] bigint  NOT NULL,
    [Date_sortie] datetime  NOT NULL,
    [Lien] nvarchar(100)  NOT NULL,
    [Titre] nvarchar(100)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Titre] in table 'VideosSet'
ALTER TABLE [dbo].[VideosSet]
ADD CONSTRAINT [PK_VideosSet]
    PRIMARY KEY CLUSTERED ([Titre] ASC);
GO

-- Creating primary key on [Saison], [Episode] in table 'Sommaire_seriesSet'
ALTER TABLE [dbo].[Sommaire_seriesSet]
ADD CONSTRAINT [PK_Sommaire_seriesSet]
    PRIMARY KEY CLUSTERED ([Saison], [Episode] ASC);
GO

-- Creating primary key on [Titre] in table 'VideosSet_Video_serie'
ALTER TABLE [dbo].[VideosSet_Video_serie]
ADD CONSTRAINT [PK_VideosSet_Video_serie]
    PRIMARY KEY CLUSTERED ([Titre] ASC);
GO

-- Creating primary key on [Titre] in table 'VideosSet_Animer'
ALTER TABLE [dbo].[VideosSet_Animer]
ADD CONSTRAINT [PK_VideosSet_Animer]
    PRIMARY KEY CLUSTERED ([Titre] ASC);
GO

-- Creating primary key on [Saison], [Episode] in table 'Sommaire_seriesSet_Detail_animer'
ALTER TABLE [dbo].[Sommaire_seriesSet_Detail_animer]
ADD CONSTRAINT [PK_Sommaire_seriesSet_Detail_animer]
    PRIMARY KEY CLUSTERED ([Saison], [Episode] ASC);
GO

-- Creating primary key on [Titre] in table 'VideosSet_Series'
ALTER TABLE [dbo].[VideosSet_Series]
ADD CONSTRAINT [PK_VideosSet_Series]
    PRIMARY KEY CLUSTERED ([Titre] ASC);
GO

-- Creating primary key on [Saison], [Episode] in table 'Sommaire_seriesSet_Detail_series'
ALTER TABLE [dbo].[Sommaire_seriesSet_Detail_series]
ADD CONSTRAINT [PK_Sommaire_seriesSet_Detail_series]
    PRIMARY KEY CLUSTERED ([Saison], [Episode] ASC);
GO

-- Creating primary key on [Titre] in table 'VideosSet_Films'
ALTER TABLE [dbo].[VideosSet_Films]
ADD CONSTRAINT [PK_VideosSet_Films]
    PRIMARY KEY CLUSTERED ([Titre] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Titre] in table 'Sommaire_seriesSet_Detail_animer'
ALTER TABLE [dbo].[Sommaire_seriesSet_Detail_animer]
ADD CONSTRAINT [FK_AnimerDetail_animer]
    FOREIGN KEY ([Titre])
    REFERENCES [dbo].[VideosSet_Animer]
        ([Titre])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AnimerDetail_animer'
CREATE INDEX [IX_FK_AnimerDetail_animer]
ON [dbo].[Sommaire_seriesSet_Detail_animer]
    ([Titre]);
GO

-- Creating foreign key on [Titre] in table 'Sommaire_seriesSet_Detail_series'
ALTER TABLE [dbo].[Sommaire_seriesSet_Detail_series]
ADD CONSTRAINT [FK_Series_Detailseries]
    FOREIGN KEY ([Titre])
    REFERENCES [dbo].[VideosSet_Series]
        ([Titre])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Series_Detailseries'
CREATE INDEX [IX_FK_Series_Detailseries]
ON [dbo].[Sommaire_seriesSet_Detail_series]
    ([Titre]);
GO

-- Creating foreign key on [Titre] in table 'VideosSet_Video_serie'
ALTER TABLE [dbo].[VideosSet_Video_serie]
ADD CONSTRAINT [FK_Video_serie_inherits_Videos]
    FOREIGN KEY ([Titre])
    REFERENCES [dbo].[VideosSet]
        ([Titre])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Titre] in table 'VideosSet_Animer'
ALTER TABLE [dbo].[VideosSet_Animer]
ADD CONSTRAINT [FK_Animer_inherits_Video_serie]
    FOREIGN KEY ([Titre])
    REFERENCES [dbo].[VideosSet_Video_serie]
        ([Titre])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Saison], [Episode] in table 'Sommaire_seriesSet_Detail_animer'
ALTER TABLE [dbo].[Sommaire_seriesSet_Detail_animer]
ADD CONSTRAINT [FK_Detail_animer_inherits_Sommaire_series]
    FOREIGN KEY ([Saison], [Episode])
    REFERENCES [dbo].[Sommaire_seriesSet]
        ([Saison], [Episode])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Titre] in table 'VideosSet_Series'
ALTER TABLE [dbo].[VideosSet_Series]
ADD CONSTRAINT [FK_Series_inherits_Video_serie]
    FOREIGN KEY ([Titre])
    REFERENCES [dbo].[VideosSet_Video_serie]
        ([Titre])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Saison], [Episode] in table 'Sommaire_seriesSet_Detail_series'
ALTER TABLE [dbo].[Sommaire_seriesSet_Detail_series]
ADD CONSTRAINT [FK_Detail_series_inherits_Sommaire_series]
    FOREIGN KEY ([Saison], [Episode])
    REFERENCES [dbo].[Sommaire_seriesSet]
        ([Saison], [Episode])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Titre] in table 'VideosSet_Films'
ALTER TABLE [dbo].[VideosSet_Films]
ADD CONSTRAINT [FK_Films_inherits_Videos]
    FOREIGN KEY ([Titre])
    REFERENCES [dbo].[VideosSet]
        ([Titre])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------