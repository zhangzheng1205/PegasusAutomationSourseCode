CREATE TABLE [dbo].[BDD_User] (
    [UserID]         INT            NOT NULL,
    [LoginName]      NVARCHAR (100) NOT NULL,
    [Password]       NVARCHAR (100) NOT NULL,
    [Email]          NVARCHAR (100) NOT NULL,
    [FirstName]      NVARCHAR (100) NOT NULL,
    [MiddleName]     NVARCHAR (100) NULL,
    [LastName]       NVARCHAR (100) NOT NULL,
    [UserTypeID]     INT            NOT NULL,
    [CreationStatus] BIT            NOT NULL,
    [EnrollStatus]   BIT            NULL,
    [PromotedAsTA]   BIT            NULL
);

