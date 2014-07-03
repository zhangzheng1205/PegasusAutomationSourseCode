ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [BDD_DB], FILENAME = '$(DefaultDataPath)Pegasus_Automation_v1.mdf', FILEGROWTH = 1024 KB) TO FILEGROUP [PRIMARY];

