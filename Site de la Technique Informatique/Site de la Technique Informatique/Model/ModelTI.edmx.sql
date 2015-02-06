
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/06/2015 13:58:35
-- Generated from EDMX file: C:\Users\Jacob\Source\Repos\SiteTIHiver2015\Site de la Technique Informatique\Site de la Technique Informatique\Model\ModelTI.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ProjetDeux_2015_2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AdminLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogJeu] DROP CONSTRAINT [FK_AdminLog];
GO
IF OBJECT_ID(N'[dbo].[FK_ConsultationForumEnteteForum]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConsultationForumJeu] DROP CONSTRAINT [FK_ConsultationForumEnteteForum];
GO
IF OBJECT_ID(N'[dbo].[FK_UtilisateurConsultationForum]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConsultationForumJeu] DROP CONSTRAINT [FK_UtilisateurConsultationForum];
GO
IF OBJECT_ID(N'[dbo].[FK_EnteteForumMessageForum]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MessageForumJeu] DROP CONSTRAINT [FK_EnteteForumMessageForum];
GO
IF OBJECT_ID(N'[dbo].[FK_SectionForumEnteteForum]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EnteteForumJeu] DROP CONSTRAINT [FK_SectionForumEnteteForum];
GO
IF OBJECT_ID(N'[dbo].[FK_UtilisateurEnteteForum]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EnteteForumJeu] DROP CONSTRAINT [FK_UtilisateurEnteteForum];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesseurEvenement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EvenementJeu] DROP CONSTRAINT [FK_ProfesseurEvenement];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesseurFAQ]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FAQJeu] DROP CONSTRAINT [FK_ProfesseurFAQ];
GO
IF OBJECT_ID(N'[dbo].[FK_UtilisateurMessageForum]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MessageForumJeu] DROP CONSTRAINT [FK_UtilisateurMessageForum];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesseurNouvelle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NouvelleJeu] DROP CONSTRAINT [FK_ProfesseurNouvelle];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesseurParutionMedia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParutionMediaJeu] DROP CONSTRAINT [FK_ProfesseurParutionMedia];
GO
IF OBJECT_ID(N'[dbo].[FK_Etudiant_inherits_Utilisateur]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UtilisateurJeu_Etudiant] DROP CONSTRAINT [FK_Etudiant_inherits_Utilisateur];
GO
IF OBJECT_ID(N'[dbo].[FK_Professeur_inherits_Utilisateur]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UtilisateurJeu_Professeur] DROP CONSTRAINT [FK_Professeur_inherits_Utilisateur];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesseurCours_CoursJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfesseurCours] DROP CONSTRAINT [FK_ProfesseurCours_CoursJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesseurCours_UtilisateurJeu_Professeur]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfesseurCours] DROP CONSTRAINT [FK_ProfesseurCours_UtilisateurJeu_Professeur];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeurJeuOffreEmploiJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OffreEmploiJeuSet] DROP CONSTRAINT [FK_EmployeurJeuOffreEmploiJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_LogJeuEmployeurJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogJeu] DROP CONSTRAINT [FK_LogJeuEmployeurJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_LogJeuUtilisateurJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogJeu] DROP CONSTRAINT [FK_LogJeuUtilisateurJeu];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AdminJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdminJeu];
GO
IF OBJECT_ID(N'[dbo].[ConsultationForumJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConsultationForumJeu];
GO
IF OBJECT_ID(N'[dbo].[CoursJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CoursJeu];
GO
IF OBJECT_ID(N'[dbo].[EnteteForumJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EnteteForumJeu];
GO
IF OBJECT_ID(N'[dbo].[EvenementJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EvenementJeu];
GO
IF OBJECT_ID(N'[dbo].[FAQJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FAQJeu];
GO
IF OBJECT_ID(N'[dbo].[LogJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogJeu];
GO
IF OBJECT_ID(N'[dbo].[MessageForumJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MessageForumJeu];
GO
IF OBJECT_ID(N'[dbo].[NouvelleJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NouvelleJeu];
GO
IF OBJECT_ID(N'[dbo].[ParutionMediaJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParutionMediaJeu];
GO
IF OBJECT_ID(N'[dbo].[SectionForumJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SectionForumJeu];
GO
IF OBJECT_ID(N'[dbo].[UtilisateurJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UtilisateurJeu];
GO
IF OBJECT_ID(N'[dbo].[UtilisateurJeu_Etudiant]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UtilisateurJeu_Etudiant];
GO
IF OBJECT_ID(N'[dbo].[UtilisateurJeu_Professeur]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UtilisateurJeu_Professeur];
GO
IF OBJECT_ID(N'[dbo].[VerTICJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VerTICJeu];
GO
IF OBJECT_ID(N'[dbo].[EmployeurJeuSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeurJeuSet];
GO
IF OBJECT_ID(N'[dbo].[OffreEmploiJeuSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OffreEmploiJeuSet];
GO
IF OBJECT_ID(N'[dbo].[DateEvenementVerTICJeuSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DateEvenementVerTICJeuSet];
GO
IF OBJECT_ID(N'[dbo].[ProfesseurCours]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfesseurCours];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AdminJeu'
CREATE TABLE [dbo].[AdminJeu] (
    [IDAdmin] int IDENTITY(1,1) NOT NULL,
    [usagerAdmin] nvarchar(20)  NOT NULL,
    [hashMotDePasse] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'ConsultationForumJeu'
CREATE TABLE [dbo].[ConsultationForumJeu] (
    [IDConsultationForum] int IDENTITY(1,1) NOT NULL,
    [dateConsulte] datetime  NOT NULL,
    [UtilisateurIDUtilisateur] int  NOT NULL,
    [EnteteForum_IDEnteteForum] int  NOT NULL
);
GO

-- Creating table 'CoursJeu'
CREATE TABLE [dbo].[CoursJeu] (
    [IDCours] int IDENTITY(1,1) NOT NULL,
    [nomCours] nvarchar(200)  NOT NULL,
    [noCours] nvarchar(20)  NOT NULL,
    [noSessionCours] int  NOT NULL,
    [descriptionCours] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EnteteForumJeu'
CREATE TABLE [dbo].[EnteteForumJeu] (
    [IDEnteteForum] int IDENTITY(1,1) NOT NULL,
    [titreEnteteForum] nvarchar(30)  NOT NULL,
    [dateEnteteForum] datetime  NOT NULL,
    [SectionForumIDSectionForum] int  NOT NULL,
    [UtilisateurIDUtilisateur] int  NOT NULL
);
GO

-- Creating table 'EvenementJeu'
CREATE TABLE [dbo].[EvenementJeu] (
    [IDEvenement] int IDENTITY(1,1) NOT NULL,
    [titreEvenement] nvarchar(250)  NOT NULL,
    [descriptionEvenement] nvarchar(max)  NOT NULL,
    [datePublication] datetime  NOT NULL,
    [ProfesseurIDProfesseur] int  NOT NULL,
    [dateDebutEvenement] datetime  NOT NULL,
    [dateFinEvenement] datetime  NULL
);
GO

-- Creating table 'FAQJeu'
CREATE TABLE [dbo].[FAQJeu] (
    [IDFAQ] int IDENTITY(1,1) NOT NULL,
    [texteQuestion] nvarchar(50)  NOT NULL,
    [texteReponse] nvarchar(500)  NOT NULL,
    [ProfesseurIDProfesseur] int  NOT NULL
);
GO

-- Creating table 'LogJeu'
CREATE TABLE [dbo].[LogJeu] (
    [IDLog] int IDENTITY(1,1) NOT NULL,
    [dateLog] datetime  NOT NULL,
    [actionLog] nvarchar(100)  NOT NULL,
    [ProfesseurIDProfesseur] int  NULL,
    [EtudiantIDEtudiant] int  NULL,
    [AdminIDAdmin] int  NULL,
    [UtilisateurIDUtilisateur] int  NOT NULL,
    [EmployeurJeu_IDEmployeur] int  NULL,
    [UtilisateurJeu_IDUtilisateur] int  NULL
);
GO

-- Creating table 'MessageForumJeu'
CREATE TABLE [dbo].[MessageForumJeu] (
    [IDMessageForum] int IDENTITY(1,1) NOT NULL,
    [texteMessage] nvarchar(2000)  NOT NULL,
    [dateMessage] datetime  NOT NULL,
    [EnteteForumIDEnteteForum] int  NOT NULL,
    [UtilisateurIDUtilisateur] int  NOT NULL
);
GO

-- Creating table 'NouvelleJeu'
CREATE TABLE [dbo].[NouvelleJeu] (
    [IDNouvelle] int IDENTITY(1,1) NOT NULL,
    [titreNouvelle] nvarchar(250)  NOT NULL,
    [texteNouvelle] nvarchar(max)  NOT NULL,
    [pathPhotoNouvelle] nvarchar(200)  NULL,
    [dateNouvelle] datetime  NOT NULL,
    [ProfesseurIDProfesseur] int  NOT NULL
);
GO

-- Creating table 'ParutionMediaJeu'
CREATE TABLE [dbo].[ParutionMediaJeu] (
    [IDParutionMedia] int IDENTITY(1,1) NOT NULL,
    [pathFichierPDF] nvarchar(200)  NOT NULL,
    [descriptionParution] nvarchar(max)  NULL,
    [dateParution] datetime  NOT NULL,
    [ProfesseurIDProfesseur] int  NOT NULL
);
GO

-- Creating table 'SectionForumJeu'
CREATE TABLE [dbo].[SectionForumJeu] (
    [IDSectionForum] int IDENTITY(1,1) NOT NULL,
    [titreSection] nvarchar(30)  NOT NULL,
    [descriptionSection] nvarchar(500)  NOT NULL
);
GO

-- Creating table 'UtilisateurJeu'
CREATE TABLE [dbo].[UtilisateurJeu] (
    [IDUtilisateur] int IDENTITY(1,1) NOT NULL,
    [nom] nvarchar(15)  NOT NULL,
    [prenom] nvarchar(15)  NOT NULL,
    [courriel] nvarchar(50)  NOT NULL,
    [hashMotDepasse] nvarchar(100)  NOT NULL,
    [pathPhotoProfil] nvarchar(200)  NULL,
    [photoDescription] nvarchar(500)  NULL,
    [temoignage] nvarchar(1000)  NULL,
    [dateTemoignage] datetime  NULL,
    [compteActif] bit  NOT NULL
);
GO

-- Creating table 'UtilisateurJeu_Etudiant'
CREATE TABLE [dbo].[UtilisateurJeu_Etudiant] (
    [IDEtudiant] int IDENTITY(1,1) NOT NULL,
    [dateNaissance] datetime  NOT NULL,
    [dateInscription] datetime  NOT NULL,
    [valideTemoignage] bit  NOT NULL,
    [valideCourriel] bit  NOT NULL,
    [IDUtilisateur] int  NOT NULL,
    [pathCV] nvarchar(200)  NULL
);
GO

-- Creating table 'UtilisateurJeu_Professeur'
CREATE TABLE [dbo].[UtilisateurJeu_Professeur] (
    [IDProfesseur] int IDENTITY(1,1) NOT NULL,
    [IDUtilisateur] int  NOT NULL,
    [presentation] nvarchar(2000)  NULL
);
GO

-- Creating table 'VerTICJeu'
CREATE TABLE [dbo].[VerTICJeu] (
    [IDVerTIC] int IDENTITY(1,1) NOT NULL,
    [descriptionLicence] nvarchar(2000)  NOT NULL,
    [descriptionLibre] nvarchar(2000)  NOT NULL,
    [caracteristiquesPortable] nvarchar(2000)  NOT NULL,
    [autrePortable] nvarchar(2000)  NOT NULL
);
GO

-- Creating table 'EmployeurJeuSet'
CREATE TABLE [dbo].[EmployeurJeuSet] (
    [IDEmployeur] int IDENTITY(1,1) NOT NULL,
    [nomEmployeur] nvarchar(100)  NOT NULL,
    [hashMotDepasse] nvarchar(100)  NOT NULL,
    [courriel] nvarchar(50)  NOT NULL,
    [compteActif] bit  NOT NULL,
    [valideCourriel] bit  NOT NULL,
    [dateInscription] datetime  NOT NULL
);
GO

-- Creating table 'OffreEmploiJeuSet'
CREATE TABLE [dbo].[OffreEmploiJeuSet] (
    [IDOffreEmploi] int IDENTITY(1,1) NOT NULL,
    [titreOffre] nvarchar(200)  NOT NULL,
    [descriptionOffre] nvarchar(2000)  NOT NULL,
    [dateOffre] datetime  NOT NULL,
    [dateExpiration] datetime  NULL,
    [dateDebutOffre] datetime  NOT NULL,
    [pathPDFDescription] nvarchar(200)  NULL,
    [salaire] decimal(18,0)  NOT NULL,
    [nbHeureSemaine] smallint  NOT NULL,
    [lieuTravail] nvarchar(100)  NOT NULL,
    [noTelephone] nvarchar(10)  NOT NULL,
    [noTelecopieur] nvarchar(10)  NULL,
    [courrielOffre] nvarchar(50)  NOT NULL,
    [personneRessource] nvarchar(100)  NOT NULL,
    [EmployeurJeuIDEmployeur] int  NOT NULL
);
GO

-- Creating table 'DateEvenementVerTICJeuSet'
CREATE TABLE [dbo].[DateEvenementVerTICJeuSet] (
    [IDDateEvenement] int IDENTITY(1,1) NOT NULL,
    [dateDescription] nvarchar(max)  NOT NULL,
    [Evenement] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProfesseurCours'
CREATE TABLE [dbo].[ProfesseurCours] (
    [CoursJeu_IDCours] int  NOT NULL,
    [UtilisateurJeu_Professeur_IDUtilisateur] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDAdmin] in table 'AdminJeu'
ALTER TABLE [dbo].[AdminJeu]
ADD CONSTRAINT [PK_AdminJeu]
    PRIMARY KEY CLUSTERED ([IDAdmin] ASC);
GO

-- Creating primary key on [IDConsultationForum] in table 'ConsultationForumJeu'
ALTER TABLE [dbo].[ConsultationForumJeu]
ADD CONSTRAINT [PK_ConsultationForumJeu]
    PRIMARY KEY CLUSTERED ([IDConsultationForum] ASC);
GO

-- Creating primary key on [IDCours] in table 'CoursJeu'
ALTER TABLE [dbo].[CoursJeu]
ADD CONSTRAINT [PK_CoursJeu]
    PRIMARY KEY CLUSTERED ([IDCours] ASC);
GO

-- Creating primary key on [IDEnteteForum] in table 'EnteteForumJeu'
ALTER TABLE [dbo].[EnteteForumJeu]
ADD CONSTRAINT [PK_EnteteForumJeu]
    PRIMARY KEY CLUSTERED ([IDEnteteForum] ASC);
GO

-- Creating primary key on [IDEvenement] in table 'EvenementJeu'
ALTER TABLE [dbo].[EvenementJeu]
ADD CONSTRAINT [PK_EvenementJeu]
    PRIMARY KEY CLUSTERED ([IDEvenement] ASC);
GO

-- Creating primary key on [IDFAQ] in table 'FAQJeu'
ALTER TABLE [dbo].[FAQJeu]
ADD CONSTRAINT [PK_FAQJeu]
    PRIMARY KEY CLUSTERED ([IDFAQ] ASC);
GO

-- Creating primary key on [IDLog] in table 'LogJeu'
ALTER TABLE [dbo].[LogJeu]
ADD CONSTRAINT [PK_LogJeu]
    PRIMARY KEY CLUSTERED ([IDLog] ASC);
GO

-- Creating primary key on [IDMessageForum] in table 'MessageForumJeu'
ALTER TABLE [dbo].[MessageForumJeu]
ADD CONSTRAINT [PK_MessageForumJeu]
    PRIMARY KEY CLUSTERED ([IDMessageForum] ASC);
GO

-- Creating primary key on [IDNouvelle] in table 'NouvelleJeu'
ALTER TABLE [dbo].[NouvelleJeu]
ADD CONSTRAINT [PK_NouvelleJeu]
    PRIMARY KEY CLUSTERED ([IDNouvelle] ASC);
GO

-- Creating primary key on [IDParutionMedia] in table 'ParutionMediaJeu'
ALTER TABLE [dbo].[ParutionMediaJeu]
ADD CONSTRAINT [PK_ParutionMediaJeu]
    PRIMARY KEY CLUSTERED ([IDParutionMedia] ASC);
GO

-- Creating primary key on [IDSectionForum] in table 'SectionForumJeu'
ALTER TABLE [dbo].[SectionForumJeu]
ADD CONSTRAINT [PK_SectionForumJeu]
    PRIMARY KEY CLUSTERED ([IDSectionForum] ASC);
GO

-- Creating primary key on [IDUtilisateur] in table 'UtilisateurJeu'
ALTER TABLE [dbo].[UtilisateurJeu]
ADD CONSTRAINT [PK_UtilisateurJeu]
    PRIMARY KEY CLUSTERED ([IDUtilisateur] ASC);
GO

-- Creating primary key on [IDUtilisateur] in table 'UtilisateurJeu_Etudiant'
ALTER TABLE [dbo].[UtilisateurJeu_Etudiant]
ADD CONSTRAINT [PK_UtilisateurJeu_Etudiant]
    PRIMARY KEY CLUSTERED ([IDUtilisateur] ASC);
GO

-- Creating primary key on [IDUtilisateur] in table 'UtilisateurJeu_Professeur'
ALTER TABLE [dbo].[UtilisateurJeu_Professeur]
ADD CONSTRAINT [PK_UtilisateurJeu_Professeur]
    PRIMARY KEY CLUSTERED ([IDUtilisateur] ASC);
GO

-- Creating primary key on [IDVerTIC] in table 'VerTICJeu'
ALTER TABLE [dbo].[VerTICJeu]
ADD CONSTRAINT [PK_VerTICJeu]
    PRIMARY KEY CLUSTERED ([IDVerTIC] ASC);
GO

-- Creating primary key on [IDEmployeur] in table 'EmployeurJeuSet'
ALTER TABLE [dbo].[EmployeurJeuSet]
ADD CONSTRAINT [PK_EmployeurJeuSet]
    PRIMARY KEY CLUSTERED ([IDEmployeur] ASC);
GO

-- Creating primary key on [IDOffreEmploi] in table 'OffreEmploiJeuSet'
ALTER TABLE [dbo].[OffreEmploiJeuSet]
ADD CONSTRAINT [PK_OffreEmploiJeuSet]
    PRIMARY KEY CLUSTERED ([IDOffreEmploi] ASC);
GO

-- Creating primary key on [IDDateEvenement] in table 'DateEvenementVerTICJeuSet'
ALTER TABLE [dbo].[DateEvenementVerTICJeuSet]
ADD CONSTRAINT [PK_DateEvenementVerTICJeuSet]
    PRIMARY KEY CLUSTERED ([IDDateEvenement] ASC);
GO

-- Creating primary key on [CoursJeu_IDCours], [UtilisateurJeu_Professeur_IDUtilisateur] in table 'ProfesseurCours'
ALTER TABLE [dbo].[ProfesseurCours]
ADD CONSTRAINT [PK_ProfesseurCours]
    PRIMARY KEY CLUSTERED ([CoursJeu_IDCours], [UtilisateurJeu_Professeur_IDUtilisateur] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AdminIDAdmin] in table 'LogJeu'
ALTER TABLE [dbo].[LogJeu]
ADD CONSTRAINT [FK_AdminLog]
    FOREIGN KEY ([AdminIDAdmin])
    REFERENCES [dbo].[AdminJeu]
        ([IDAdmin])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdminLog'
CREATE INDEX [IX_FK_AdminLog]
ON [dbo].[LogJeu]
    ([AdminIDAdmin]);
GO

-- Creating foreign key on [EnteteForum_IDEnteteForum] in table 'ConsultationForumJeu'
ALTER TABLE [dbo].[ConsultationForumJeu]
ADD CONSTRAINT [FK_ConsultationForumEnteteForum]
    FOREIGN KEY ([EnteteForum_IDEnteteForum])
    REFERENCES [dbo].[EnteteForumJeu]
        ([IDEnteteForum])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConsultationForumEnteteForum'
CREATE INDEX [IX_FK_ConsultationForumEnteteForum]
ON [dbo].[ConsultationForumJeu]
    ([EnteteForum_IDEnteteForum]);
GO

-- Creating foreign key on [UtilisateurIDUtilisateur] in table 'ConsultationForumJeu'
ALTER TABLE [dbo].[ConsultationForumJeu]
ADD CONSTRAINT [FK_UtilisateurConsultationForum]
    FOREIGN KEY ([UtilisateurIDUtilisateur])
    REFERENCES [dbo].[UtilisateurJeu]
        ([IDUtilisateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UtilisateurConsultationForum'
CREATE INDEX [IX_FK_UtilisateurConsultationForum]
ON [dbo].[ConsultationForumJeu]
    ([UtilisateurIDUtilisateur]);
GO

-- Creating foreign key on [EnteteForumIDEnteteForum] in table 'MessageForumJeu'
ALTER TABLE [dbo].[MessageForumJeu]
ADD CONSTRAINT [FK_EnteteForumMessageForum]
    FOREIGN KEY ([EnteteForumIDEnteteForum])
    REFERENCES [dbo].[EnteteForumJeu]
        ([IDEnteteForum])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EnteteForumMessageForum'
CREATE INDEX [IX_FK_EnteteForumMessageForum]
ON [dbo].[MessageForumJeu]
    ([EnteteForumIDEnteteForum]);
GO

-- Creating foreign key on [SectionForumIDSectionForum] in table 'EnteteForumJeu'
ALTER TABLE [dbo].[EnteteForumJeu]
ADD CONSTRAINT [FK_SectionForumEnteteForum]
    FOREIGN KEY ([SectionForumIDSectionForum])
    REFERENCES [dbo].[SectionForumJeu]
        ([IDSectionForum])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SectionForumEnteteForum'
CREATE INDEX [IX_FK_SectionForumEnteteForum]
ON [dbo].[EnteteForumJeu]
    ([SectionForumIDSectionForum]);
GO

-- Creating foreign key on [UtilisateurIDUtilisateur] in table 'EnteteForumJeu'
ALTER TABLE [dbo].[EnteteForumJeu]
ADD CONSTRAINT [FK_UtilisateurEnteteForum]
    FOREIGN KEY ([UtilisateurIDUtilisateur])
    REFERENCES [dbo].[UtilisateurJeu]
        ([IDUtilisateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UtilisateurEnteteForum'
CREATE INDEX [IX_FK_UtilisateurEnteteForum]
ON [dbo].[EnteteForumJeu]
    ([UtilisateurIDUtilisateur]);
GO

-- Creating foreign key on [ProfesseurIDProfesseur] in table 'EvenementJeu'
ALTER TABLE [dbo].[EvenementJeu]
ADD CONSTRAINT [FK_ProfesseurEvenement]
    FOREIGN KEY ([ProfesseurIDProfesseur])
    REFERENCES [dbo].[UtilisateurJeu_Professeur]
        ([IDUtilisateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesseurEvenement'
CREATE INDEX [IX_FK_ProfesseurEvenement]
ON [dbo].[EvenementJeu]
    ([ProfesseurIDProfesseur]);
GO

-- Creating foreign key on [ProfesseurIDProfesseur] in table 'FAQJeu'
ALTER TABLE [dbo].[FAQJeu]
ADD CONSTRAINT [FK_ProfesseurFAQ]
    FOREIGN KEY ([ProfesseurIDProfesseur])
    REFERENCES [dbo].[UtilisateurJeu_Professeur]
        ([IDUtilisateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesseurFAQ'
CREATE INDEX [IX_FK_ProfesseurFAQ]
ON [dbo].[FAQJeu]
    ([ProfesseurIDProfesseur]);
GO

-- Creating foreign key on [UtilisateurIDUtilisateur] in table 'MessageForumJeu'
ALTER TABLE [dbo].[MessageForumJeu]
ADD CONSTRAINT [FK_UtilisateurMessageForum]
    FOREIGN KEY ([UtilisateurIDUtilisateur])
    REFERENCES [dbo].[UtilisateurJeu]
        ([IDUtilisateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UtilisateurMessageForum'
CREATE INDEX [IX_FK_UtilisateurMessageForum]
ON [dbo].[MessageForumJeu]
    ([UtilisateurIDUtilisateur]);
GO

-- Creating foreign key on [ProfesseurIDProfesseur] in table 'NouvelleJeu'
ALTER TABLE [dbo].[NouvelleJeu]
ADD CONSTRAINT [FK_ProfesseurNouvelle]
    FOREIGN KEY ([ProfesseurIDProfesseur])
    REFERENCES [dbo].[UtilisateurJeu_Professeur]
        ([IDUtilisateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesseurNouvelle'
CREATE INDEX [IX_FK_ProfesseurNouvelle]
ON [dbo].[NouvelleJeu]
    ([ProfesseurIDProfesseur]);
GO

-- Creating foreign key on [ProfesseurIDProfesseur] in table 'ParutionMediaJeu'
ALTER TABLE [dbo].[ParutionMediaJeu]
ADD CONSTRAINT [FK_ProfesseurParutionMedia]
    FOREIGN KEY ([ProfesseurIDProfesseur])
    REFERENCES [dbo].[UtilisateurJeu_Professeur]
        ([IDUtilisateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesseurParutionMedia'
CREATE INDEX [IX_FK_ProfesseurParutionMedia]
ON [dbo].[ParutionMediaJeu]
    ([ProfesseurIDProfesseur]);
GO

-- Creating foreign key on [IDUtilisateur] in table 'UtilisateurJeu_Etudiant'
ALTER TABLE [dbo].[UtilisateurJeu_Etudiant]
ADD CONSTRAINT [FK_Etudiant_inherits_Utilisateur]
    FOREIGN KEY ([IDUtilisateur])
    REFERENCES [dbo].[UtilisateurJeu]
        ([IDUtilisateur])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IDUtilisateur] in table 'UtilisateurJeu_Professeur'
ALTER TABLE [dbo].[UtilisateurJeu_Professeur]
ADD CONSTRAINT [FK_Professeur_inherits_Utilisateur]
    FOREIGN KEY ([IDUtilisateur])
    REFERENCES [dbo].[UtilisateurJeu]
        ([IDUtilisateur])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CoursJeu_IDCours] in table 'ProfesseurCours'
ALTER TABLE [dbo].[ProfesseurCours]
ADD CONSTRAINT [FK_ProfesseurCours_CoursJeu]
    FOREIGN KEY ([CoursJeu_IDCours])
    REFERENCES [dbo].[CoursJeu]
        ([IDCours])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UtilisateurJeu_Professeur_IDUtilisateur] in table 'ProfesseurCours'
ALTER TABLE [dbo].[ProfesseurCours]
ADD CONSTRAINT [FK_ProfesseurCours_UtilisateurJeu_Professeur]
    FOREIGN KEY ([UtilisateurJeu_Professeur_IDUtilisateur])
    REFERENCES [dbo].[UtilisateurJeu_Professeur]
        ([IDUtilisateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesseurCours_UtilisateurJeu_Professeur'
CREATE INDEX [IX_FK_ProfesseurCours_UtilisateurJeu_Professeur]
ON [dbo].[ProfesseurCours]
    ([UtilisateurJeu_Professeur_IDUtilisateur]);
GO

-- Creating foreign key on [EmployeurJeuIDEmployeur] in table 'OffreEmploiJeuSet'
ALTER TABLE [dbo].[OffreEmploiJeuSet]
ADD CONSTRAINT [FK_EmployeurJeuOffreEmploiJeu]
    FOREIGN KEY ([EmployeurJeuIDEmployeur])
    REFERENCES [dbo].[EmployeurJeuSet]
        ([IDEmployeur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeurJeuOffreEmploiJeu'
CREATE INDEX [IX_FK_EmployeurJeuOffreEmploiJeu]
ON [dbo].[OffreEmploiJeuSet]
    ([EmployeurJeuIDEmployeur]);
GO

-- Creating foreign key on [EmployeurJeu_IDEmployeur] in table 'LogJeu'
ALTER TABLE [dbo].[LogJeu]
ADD CONSTRAINT [FK_LogJeuEmployeurJeu]
    FOREIGN KEY ([EmployeurJeu_IDEmployeur])
    REFERENCES [dbo].[EmployeurJeuSet]
        ([IDEmployeur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LogJeuEmployeurJeu'
CREATE INDEX [IX_FK_LogJeuEmployeurJeu]
ON [dbo].[LogJeu]
    ([EmployeurJeu_IDEmployeur]);
GO

-- Creating foreign key on [UtilisateurJeu_IDUtilisateur] in table 'LogJeu'
ALTER TABLE [dbo].[LogJeu]
ADD CONSTRAINT [FK_LogJeuUtilisateurJeu]
    FOREIGN KEY ([UtilisateurJeu_IDUtilisateur])
    REFERENCES [dbo].[UtilisateurJeu]
        ([IDUtilisateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LogJeuUtilisateurJeu'
CREATE INDEX [IX_FK_LogJeuUtilisateurJeu]
ON [dbo].[LogJeu]
    ([UtilisateurJeu_IDUtilisateur]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------