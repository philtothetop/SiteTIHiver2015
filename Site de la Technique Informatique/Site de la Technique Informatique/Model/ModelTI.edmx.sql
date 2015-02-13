
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/13/2015 13:45:14
-- Generated from EDMX file: C:\Users\Raphael Brouard\Source\Repos\SiteTIHiver2015\Site de la Technique Informatique\Site de la Technique Informatique\Model\ModelTI.edmx
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

IF OBJECT_ID(N'[dbo].[FK_UtilisateurJeuLogJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogJeu] DROP CONSTRAINT [FK_UtilisateurJeuLogJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_UtilisateurJeuOffreEmploiJeuSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OffreEmploiJeuSet] DROP CONSTRAINT [FK_UtilisateurJeuOffreEmploiJeuSet];
GO
IF OBJECT_ID(N'[dbo].[FK_UtilisateurJeuMessageForumJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MessageForumJeu] DROP CONSTRAINT [FK_UtilisateurJeuMessageForumJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_UtilisateurJeuConsultationForumJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConsultationForumJeu] DROP CONSTRAINT [FK_UtilisateurJeuConsultationForumJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_UtilisateurJeuEnteteForumJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EnteteForumJeu] DROP CONSTRAINT [FK_UtilisateurJeuEnteteForumJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_VilleOffreEmploiJeuSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OffreEmploiJeuSet] DROP CONSTRAINT [FK_VilleOffreEmploiJeuSet];
GO
IF OBJECT_ID(N'[dbo].[FK_UtilisateurJeu_ProfesseurCoursJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CoursJeu] DROP CONSTRAINT [FK_UtilisateurJeu_ProfesseurCoursJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_UtilisateurJeu_ProfesseurEvenementJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EvenementJeu] DROP CONSTRAINT [FK_UtilisateurJeu_ProfesseurEvenementJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_UtilisateurJeu_ProfesseurParutionMediaJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParutionMediaJeu] DROP CONSTRAINT [FK_UtilisateurJeu_ProfesseurParutionMediaJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_UtilisateurJeu_ProfesseurFAQJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FAQJeu] DROP CONSTRAINT [FK_UtilisateurJeu_ProfesseurFAQJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_UtilisateurJeu_ProfesseurNouvelleJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NouvelleJeu] DROP CONSTRAINT [FK_UtilisateurJeu_ProfesseurNouvelleJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_ConsultationForumJeuEnteteForumJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConsultationForumJeu] DROP CONSTRAINT [FK_ConsultationForumJeuEnteteForumJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_EnteteForumJeuMessageForumJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MessageForumJeu] DROP CONSTRAINT [FK_EnteteForumJeuMessageForumJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_SectionForumJeuEnteteForumJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EnteteForumJeu] DROP CONSTRAINT [FK_SectionForumJeuEnteteForumJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_UtilisateurJeu_Professeur_inherits_UtilisateurJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UtilisateurJeu_UtilisateurJeu_Professeur] DROP CONSTRAINT [FK_UtilisateurJeu_Professeur_inherits_UtilisateurJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_UtilisateurJeu_Etudiant_inherits_UtilisateurJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UtilisateurJeu_UtilisateurJeu_Etudiant] DROP CONSTRAINT [FK_UtilisateurJeu_Etudiant_inherits_UtilisateurJeu];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ConsultationForumJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConsultationForumJeu];
GO
IF OBJECT_ID(N'[dbo].[CoursJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CoursJeu];
GO
IF OBJECT_ID(N'[dbo].[DateEvenementVerTICJeuSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DateEvenementVerTICJeuSet];
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
IF OBJECT_ID(N'[dbo].[OffreEmploiJeuSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OffreEmploiJeuSet];
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
IF OBJECT_ID(N'[dbo].[VerTICJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VerTICJeu];
GO
IF OBJECT_ID(N'[dbo].[VilleSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VilleSet];
GO
IF OBJECT_ID(N'[dbo].[UtilisateurJeu_UtilisateurJeu_Professeur]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UtilisateurJeu_UtilisateurJeu_Professeur];
GO
IF OBJECT_ID(N'[dbo].[UtilisateurJeu_UtilisateurJeu_Etudiant]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UtilisateurJeu_UtilisateurJeu_Etudiant];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ConsultationForumJeu'
CREATE TABLE [dbo].[ConsultationForumJeu] (
    [IDConsultationForum] int IDENTITY(1,1) NOT NULL,
    [dateConsulte] datetime  NOT NULL,
    [UtilisateurIDUtilisateur] int  NOT NULL,
    [UtilisateurJeuIDUtilisateur] int  NOT NULL,
    [EnteteForumJeuIDEnteteForum] int  NOT NULL
);
GO

-- Creating table 'CoursJeu'
CREATE TABLE [dbo].[CoursJeu] (
    [IDCours] int IDENTITY(1,1) NOT NULL,
    [nomCours] nvarchar(200)  NOT NULL,
    [noCours] nvarchar(20)  NOT NULL,
    [noSessionCours] int  NOT NULL,
    [descriptionCours] nvarchar(max)  NOT NULL,
    [UtilisateurJeu_ProfesseurIDUtilisateur] int  NULL
);
GO

-- Creating table 'DateEvenementVerTICJeuSet'
CREATE TABLE [dbo].[DateEvenementVerTICJeuSet] (
    [IDDateEvenement] int IDENTITY(1,1) NOT NULL,
    [dateDescription] nvarchar(max)  NOT NULL,
    [Evenement] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EnteteForumJeu'
CREATE TABLE [dbo].[EnteteForumJeu] (
    [IDEnteteForum] int IDENTITY(1,1) NOT NULL,
    [titreEnteteForum] nvarchar(30)  NOT NULL,
    [dateEnteteForum] datetime  NOT NULL,
    [SectionForumIDSectionForum] int  NOT NULL,
    [UtilisateurJeuIDUtilisateur] int  NOT NULL,
    [SectionForumJeuIDSectionForum] int  NOT NULL
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
    [dateFinEvenement] datetime  NULL,
    [UtilisateurJeu_ProfesseurIDUtilisateur] int  NOT NULL
);
GO

-- Creating table 'FAQJeu'
CREATE TABLE [dbo].[FAQJeu] (
    [IDFAQ] int IDENTITY(1,1) NOT NULL,
    [texteQuestion] nvarchar(50)  NOT NULL,
    [texteReponse] nvarchar(500)  NOT NULL,
    [UtilisateurJeu_ProfesseurIDUtilisateur] int  NOT NULL
);
GO

-- Creating table 'LogJeu'
CREATE TABLE [dbo].[LogJeu] (
    [IDLog] int IDENTITY(1,1) NOT NULL,
    [dateLog] datetime  NOT NULL,
    [actionLog] nvarchar(100)  NOT NULL,
    [typeLog] smallint  NOT NULL,
    [UtilisateurJeuIDUtilisateur] int  NULL
);
GO

-- Creating table 'MessageForumJeu'
CREATE TABLE [dbo].[MessageForumJeu] (
    [IDMessageForum] int IDENTITY(1,1) NOT NULL,
    [texteMessage] nvarchar(2000)  NOT NULL,
    [dateMessage] datetime  NOT NULL,
    [EnteteForumIDEnteteForum] int  NOT NULL,
    [UtilisateurJeuIDUtilisateur] int  NOT NULL,
    [EnteteForumJeuIDEnteteForum] int  NOT NULL
);
GO

-- Creating table 'NouvelleJeu'
CREATE TABLE [dbo].[NouvelleJeu] (
    [IDNouvelle] int IDENTITY(1,1) NOT NULL,
    [titreNouvelle] nvarchar(250)  NOT NULL,
    [texteNouvelle] nvarchar(max)  NOT NULL,
    [pathPhotoNouvelle] nvarchar(200)  NULL,
    [dateNouvelle] datetime  NOT NULL,
    [UtilisateurJeu_ProfesseurIDUtilisateur] int  NOT NULL
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
    [adresseTravail] nvarchar(200)  NOT NULL,
    [noTelephone] nvarchar(10)  NOT NULL,
    [noTelecopieur] nvarchar(10)  NULL,
    [courrielOffre] nvarchar(50)  NOT NULL,
    [personneRessource] nvarchar(100)  NOT NULL,
    [EmployeurJeuIDEmployeur] int  NOT NULL,
    [UtilisateurJeuIDUtilisateur] int  NOT NULL,
    [VilleIDVille] int  NOT NULL
);
GO

-- Creating table 'ParutionMediaJeu'
CREATE TABLE [dbo].[ParutionMediaJeu] (
    [IDParutionMedia] int IDENTITY(1,1) NOT NULL,
    [pathFichierPDF] nvarchar(200)  NOT NULL,
    [descriptionParution] nvarchar(max)  NULL,
    [dateParution] datetime  NOT NULL,
    [UtilisateurJeu_ProfesseurIDUtilisateur] int  NOT NULL
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
    [compteActif] bit  NOT NULL,
    [typeDeCompte] smallint  NOT NULL
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

-- Creating table 'VilleSet'
CREATE TABLE [dbo].[VilleSet] (
    [IDVille] int IDENTITY(1,1) NOT NULL,
    [nomVille] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'UtilisateurJeu_UtilisateurJeu_Professeur'
CREATE TABLE [dbo].[UtilisateurJeu_UtilisateurJeu_Professeur] (
    [IDProfesseur] int IDENTITY(1,1) NOT NULL,
    [presentation] nvarchar(2000)  NULL,
    [IDUtilisateur] int  NOT NULL
);
GO

-- Creating table 'UtilisateurJeu_UtilisateurJeu_Etudiant'
CREATE TABLE [dbo].[UtilisateurJeu_UtilisateurJeu_Etudiant] (
    [IDEtudiant] int IDENTITY(1,1) NOT NULL,
    [dateNaissance] datetime  NOT NULL,
    [dateInscription] datetime  NOT NULL,
    [valideTemoignage] bit  NOT NULL,
    [valideCourriel] bit  NOT NULL,
    [pathCV] nvarchar(200)  NULL,
    [IDUtilisateur] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

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

-- Creating primary key on [IDDateEvenement] in table 'DateEvenementVerTICJeuSet'
ALTER TABLE [dbo].[DateEvenementVerTICJeuSet]
ADD CONSTRAINT [PK_DateEvenementVerTICJeuSet]
    PRIMARY KEY CLUSTERED ([IDDateEvenement] ASC);
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

-- Creating primary key on [IDOffreEmploi] in table 'OffreEmploiJeuSet'
ALTER TABLE [dbo].[OffreEmploiJeuSet]
ADD CONSTRAINT [PK_OffreEmploiJeuSet]
    PRIMARY KEY CLUSTERED ([IDOffreEmploi] ASC);
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

-- Creating primary key on [IDVerTIC] in table 'VerTICJeu'
ALTER TABLE [dbo].[VerTICJeu]
ADD CONSTRAINT [PK_VerTICJeu]
    PRIMARY KEY CLUSTERED ([IDVerTIC] ASC);
GO

-- Creating primary key on [IDVille] in table 'VilleSet'
ALTER TABLE [dbo].[VilleSet]
ADD CONSTRAINT [PK_VilleSet]
    PRIMARY KEY CLUSTERED ([IDVille] ASC);
GO

-- Creating primary key on [IDUtilisateur] in table 'UtilisateurJeu_UtilisateurJeu_Professeur'
ALTER TABLE [dbo].[UtilisateurJeu_UtilisateurJeu_Professeur]
ADD CONSTRAINT [PK_UtilisateurJeu_UtilisateurJeu_Professeur]
    PRIMARY KEY CLUSTERED ([IDUtilisateur] ASC);
GO

-- Creating primary key on [IDUtilisateur] in table 'UtilisateurJeu_UtilisateurJeu_Etudiant'
ALTER TABLE [dbo].[UtilisateurJeu_UtilisateurJeu_Etudiant]
ADD CONSTRAINT [PK_UtilisateurJeu_UtilisateurJeu_Etudiant]
    PRIMARY KEY CLUSTERED ([IDUtilisateur] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UtilisateurJeuIDUtilisateur] in table 'LogJeu'
ALTER TABLE [dbo].[LogJeu]
ADD CONSTRAINT [FK_UtilisateurJeuLogJeu]
    FOREIGN KEY ([UtilisateurJeuIDUtilisateur])
    REFERENCES [dbo].[UtilisateurJeu]
        ([IDUtilisateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UtilisateurJeuLogJeu'
CREATE INDEX [IX_FK_UtilisateurJeuLogJeu]
ON [dbo].[LogJeu]
    ([UtilisateurJeuIDUtilisateur]);
GO

-- Creating foreign key on [UtilisateurJeuIDUtilisateur] in table 'OffreEmploiJeuSet'
ALTER TABLE [dbo].[OffreEmploiJeuSet]
ADD CONSTRAINT [FK_UtilisateurJeuOffreEmploiJeuSet]
    FOREIGN KEY ([UtilisateurJeuIDUtilisateur])
    REFERENCES [dbo].[UtilisateurJeu]
        ([IDUtilisateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UtilisateurJeuOffreEmploiJeuSet'
CREATE INDEX [IX_FK_UtilisateurJeuOffreEmploiJeuSet]
ON [dbo].[OffreEmploiJeuSet]
    ([UtilisateurJeuIDUtilisateur]);
GO

-- Creating foreign key on [UtilisateurJeuIDUtilisateur] in table 'MessageForumJeu'
ALTER TABLE [dbo].[MessageForumJeu]
ADD CONSTRAINT [FK_UtilisateurJeuMessageForumJeu]
    FOREIGN KEY ([UtilisateurJeuIDUtilisateur])
    REFERENCES [dbo].[UtilisateurJeu]
        ([IDUtilisateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UtilisateurJeuMessageForumJeu'
CREATE INDEX [IX_FK_UtilisateurJeuMessageForumJeu]
ON [dbo].[MessageForumJeu]
    ([UtilisateurJeuIDUtilisateur]);
GO

-- Creating foreign key on [UtilisateurJeuIDUtilisateur] in table 'ConsultationForumJeu'
ALTER TABLE [dbo].[ConsultationForumJeu]
ADD CONSTRAINT [FK_UtilisateurJeuConsultationForumJeu]
    FOREIGN KEY ([UtilisateurJeuIDUtilisateur])
    REFERENCES [dbo].[UtilisateurJeu]
        ([IDUtilisateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UtilisateurJeuConsultationForumJeu'
CREATE INDEX [IX_FK_UtilisateurJeuConsultationForumJeu]
ON [dbo].[ConsultationForumJeu]
    ([UtilisateurJeuIDUtilisateur]);
GO

-- Creating foreign key on [UtilisateurJeuIDUtilisateur] in table 'EnteteForumJeu'
ALTER TABLE [dbo].[EnteteForumJeu]
ADD CONSTRAINT [FK_UtilisateurJeuEnteteForumJeu]
    FOREIGN KEY ([UtilisateurJeuIDUtilisateur])
    REFERENCES [dbo].[UtilisateurJeu]
        ([IDUtilisateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UtilisateurJeuEnteteForumJeu'
CREATE INDEX [IX_FK_UtilisateurJeuEnteteForumJeu]
ON [dbo].[EnteteForumJeu]
    ([UtilisateurJeuIDUtilisateur]);
GO

-- Creating foreign key on [VilleIDVille] in table 'OffreEmploiJeuSet'
ALTER TABLE [dbo].[OffreEmploiJeuSet]
ADD CONSTRAINT [FK_VilleOffreEmploiJeuSet]
    FOREIGN KEY ([VilleIDVille])
    REFERENCES [dbo].[VilleSet]
        ([IDVille])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VilleOffreEmploiJeuSet'
CREATE INDEX [IX_FK_VilleOffreEmploiJeuSet]
ON [dbo].[OffreEmploiJeuSet]
    ([VilleIDVille]);
GO

-- Creating foreign key on [UtilisateurJeu_ProfesseurIDUtilisateur] in table 'CoursJeu'
ALTER TABLE [dbo].[CoursJeu]
ADD CONSTRAINT [FK_UtilisateurJeu_ProfesseurCoursJeu]
    FOREIGN KEY ([UtilisateurJeu_ProfesseurIDUtilisateur])
    REFERENCES [dbo].[UtilisateurJeu_UtilisateurJeu_Professeur]
        ([IDUtilisateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UtilisateurJeu_ProfesseurCoursJeu'
CREATE INDEX [IX_FK_UtilisateurJeu_ProfesseurCoursJeu]
ON [dbo].[CoursJeu]
    ([UtilisateurJeu_ProfesseurIDUtilisateur]);
GO

-- Creating foreign key on [UtilisateurJeu_ProfesseurIDUtilisateur] in table 'EvenementJeu'
ALTER TABLE [dbo].[EvenementJeu]
ADD CONSTRAINT [FK_UtilisateurJeu_ProfesseurEvenementJeu]
    FOREIGN KEY ([UtilisateurJeu_ProfesseurIDUtilisateur])
    REFERENCES [dbo].[UtilisateurJeu_UtilisateurJeu_Professeur]
        ([IDUtilisateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UtilisateurJeu_ProfesseurEvenementJeu'
CREATE INDEX [IX_FK_UtilisateurJeu_ProfesseurEvenementJeu]
ON [dbo].[EvenementJeu]
    ([UtilisateurJeu_ProfesseurIDUtilisateur]);
GO

-- Creating foreign key on [UtilisateurJeu_ProfesseurIDUtilisateur] in table 'ParutionMediaJeu'
ALTER TABLE [dbo].[ParutionMediaJeu]
ADD CONSTRAINT [FK_UtilisateurJeu_ProfesseurParutionMediaJeu]
    FOREIGN KEY ([UtilisateurJeu_ProfesseurIDUtilisateur])
    REFERENCES [dbo].[UtilisateurJeu_UtilisateurJeu_Professeur]
        ([IDUtilisateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UtilisateurJeu_ProfesseurParutionMediaJeu'
CREATE INDEX [IX_FK_UtilisateurJeu_ProfesseurParutionMediaJeu]
ON [dbo].[ParutionMediaJeu]
    ([UtilisateurJeu_ProfesseurIDUtilisateur]);
GO

-- Creating foreign key on [UtilisateurJeu_ProfesseurIDUtilisateur] in table 'FAQJeu'
ALTER TABLE [dbo].[FAQJeu]
ADD CONSTRAINT [FK_UtilisateurJeu_ProfesseurFAQJeu]
    FOREIGN KEY ([UtilisateurJeu_ProfesseurIDUtilisateur])
    REFERENCES [dbo].[UtilisateurJeu_UtilisateurJeu_Professeur]
        ([IDUtilisateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UtilisateurJeu_ProfesseurFAQJeu'
CREATE INDEX [IX_FK_UtilisateurJeu_ProfesseurFAQJeu]
ON [dbo].[FAQJeu]
    ([UtilisateurJeu_ProfesseurIDUtilisateur]);
GO

-- Creating foreign key on [UtilisateurJeu_ProfesseurIDUtilisateur] in table 'NouvelleJeu'
ALTER TABLE [dbo].[NouvelleJeu]
ADD CONSTRAINT [FK_UtilisateurJeu_ProfesseurNouvelleJeu]
    FOREIGN KEY ([UtilisateurJeu_ProfesseurIDUtilisateur])
    REFERENCES [dbo].[UtilisateurJeu_UtilisateurJeu_Professeur]
        ([IDUtilisateur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UtilisateurJeu_ProfesseurNouvelleJeu'
CREATE INDEX [IX_FK_UtilisateurJeu_ProfesseurNouvelleJeu]
ON [dbo].[NouvelleJeu]
    ([UtilisateurJeu_ProfesseurIDUtilisateur]);
GO

-- Creating foreign key on [EnteteForumJeuIDEnteteForum] in table 'ConsultationForumJeu'
ALTER TABLE [dbo].[ConsultationForumJeu]
ADD CONSTRAINT [FK_ConsultationForumJeuEnteteForumJeu]
    FOREIGN KEY ([EnteteForumJeuIDEnteteForum])
    REFERENCES [dbo].[EnteteForumJeu]
        ([IDEnteteForum])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConsultationForumJeuEnteteForumJeu'
CREATE INDEX [IX_FK_ConsultationForumJeuEnteteForumJeu]
ON [dbo].[ConsultationForumJeu]
    ([EnteteForumJeuIDEnteteForum]);
GO

-- Creating foreign key on [EnteteForumJeuIDEnteteForum] in table 'MessageForumJeu'
ALTER TABLE [dbo].[MessageForumJeu]
ADD CONSTRAINT [FK_EnteteForumJeuMessageForumJeu]
    FOREIGN KEY ([EnteteForumJeuIDEnteteForum])
    REFERENCES [dbo].[EnteteForumJeu]
        ([IDEnteteForum])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EnteteForumJeuMessageForumJeu'
CREATE INDEX [IX_FK_EnteteForumJeuMessageForumJeu]
ON [dbo].[MessageForumJeu]
    ([EnteteForumJeuIDEnteteForum]);
GO

-- Creating foreign key on [SectionForumJeuIDSectionForum] in table 'EnteteForumJeu'
ALTER TABLE [dbo].[EnteteForumJeu]
ADD CONSTRAINT [FK_SectionForumJeuEnteteForumJeu]
    FOREIGN KEY ([SectionForumJeuIDSectionForum])
    REFERENCES [dbo].[SectionForumJeu]
        ([IDSectionForum])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SectionForumJeuEnteteForumJeu'
CREATE INDEX [IX_FK_SectionForumJeuEnteteForumJeu]
ON [dbo].[EnteteForumJeu]
    ([SectionForumJeuIDSectionForum]);
GO

-- Creating foreign key on [IDUtilisateur] in table 'UtilisateurJeu_UtilisateurJeu_Professeur'
ALTER TABLE [dbo].[UtilisateurJeu_UtilisateurJeu_Professeur]
ADD CONSTRAINT [FK_UtilisateurJeu_Professeur_inherits_UtilisateurJeu]
    FOREIGN KEY ([IDUtilisateur])
    REFERENCES [dbo].[UtilisateurJeu]
        ([IDUtilisateur])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IDUtilisateur] in table 'UtilisateurJeu_UtilisateurJeu_Etudiant'
ALTER TABLE [dbo].[UtilisateurJeu_UtilisateurJeu_Etudiant]
ADD CONSTRAINT [FK_UtilisateurJeu_Etudiant_inherits_UtilisateurJeu]
    FOREIGN KEY ([IDUtilisateur])
    REFERENCES [dbo].[UtilisateurJeu]
        ([IDUtilisateur])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------