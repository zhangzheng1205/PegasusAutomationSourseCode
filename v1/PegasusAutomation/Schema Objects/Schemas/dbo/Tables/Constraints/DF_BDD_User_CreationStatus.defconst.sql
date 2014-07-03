ALTER TABLE [dbo].[BDD_User]
    ADD CONSTRAINT [DF_BDD_User_CreationStatus] DEFAULT ((0)) FOR [CreationStatus];

