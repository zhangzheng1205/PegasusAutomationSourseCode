ALTER DATABASE [$(DatabaseName)]
    ADD LOG FILE (NAME = [BDD_DB_log], FILENAME = '$(DefaultLogPath)Pegasus_Automation_v1.ldf', MAXSIZE = 2097152 MB, FILEGROWTH = 10 %);

