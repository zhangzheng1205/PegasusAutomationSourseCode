ALTER TABLE [dbo].[BDD_User]
    ADD CONSTRAINT [DF_BDD_User_EnrollStatus] DEFAULT ((0)) FOR [EnrollStatus];

