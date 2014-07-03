﻿INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (1, N'WsAdmin')
INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (2, N'CsAdmin')
INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (3, N'WsTeacher')
INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (4, N'WsStudent')
INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (5, N'CsTeacher')
INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (6, N'CsStudent')
INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (7, N'CsOrganizationAdmin')
INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (8, N'CsAide')
INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (9, N'CsTStudent')
INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (10, N'HedWsAdmin')
INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (11, N'HedCsAdmin')
INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (12, N'HedWsInstructor')
INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (13, N'CsSmsInstructor')
INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (14, N'CsSmsStudent')
INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (15, N'DPCsTeacher')
INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (16, N'DPCsStudent')
INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (17, N'DPCsOrganization')
INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (18, N'DPCsAide')
INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (19, N'SMSRegistration')
INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (20, N'RUMBARegistration')
INSERT [BDD_UserTypeLookUp] ([UserTypeID], [UserType]) VALUES (21, N'RumbaAdmin')
INSERT [BDD_User] ([UserID], [LoginName], [Password], [Email], [FirstName], [MiddleName], [LastName], [UserTypeID], [CreationStatus], [EnrollStatus], [PromotedAsTA]) VALUES (1, N'BDD_Workspace1', N'password11', N'user.bdd@excelindia.com', N'WsAdmin', NULL, N'School', 1, 1, 0, NULL)
INSERT [BDD_User] ([UserID], [LoginName], [Password], [Email], [FirstName], [MiddleName], [LastName], [UserTypeID], [CreationStatus], [EnrollStatus], [PromotedAsTA]) VALUES (2, N'cswsadmin', N'password', N'user.bdd@excelindia.com', N'CsAdmin', NULL, N'School', 2, 1, 0, NULL)
INSERT [BDD_User] ([UserID], [LoginName], [Password], [Email], [FirstName], [MiddleName], [LastName], [UserTypeID], [CreationStatus], [EnrollStatus], [PromotedAsTA]) VALUES (3, N'automation_wsadmin', N'password2', N'user.bdd@excelindia.com', N'WsAdmin', NULL, N'HEDCore', 10, 1, 0, NULL)
INSERT [BDD_User] ([UserID], [LoginName], [Password], [Email], [FirstName], [MiddleName], [LastName], [UserTypeID], [CreationStatus], [EnrollStatus], [PromotedAsTA]) VALUES (4, N'cswsadmin', N'password', N'user.bdd@excelindia.com', N'CsAdmin', NULL, N'HEDCore', 11, 1, 0, NULL)
INSERT [BDD_User] ([UserID], [LoginName], [Password], [Email], [FirstName], [MiddleName], [LastName], [UserTypeID], [CreationStatus], [EnrollStatus], [PromotedAsTA]) VALUES (5, N'smsins20121116151128', N'password1', N'manish.singh@imfinity.com', N'smsins20121021164115', N'smsins20121021164115', N'smsins20121021164115', 13, 0, 0, NULL)
INSERT [BDD_User] ([UserID], [LoginName], [Password], [Email], [FirstName], [MiddleName], [LastName], [UserTypeID], [CreationStatus], [EnrollStatus], [PromotedAsTA]) VALUES (6, N'smsstu2012111615139', N'password1', N'manish.singh@imfinity.com', N'smsstu2012111615139', N'smsstu2012111615139', N'smsstu2012111615139', 14, 0, 0, 1)
INSERT [BDD_User] ([UserID], [LoginName], [Password], [Email], [FirstName], [MiddleName], [LastName], [UserTypeID], [CreationStatus], [EnrollStatus], [PromotedAsTA]) VALUES (7, N'smsstu20121021164154', N'password1', N'manish.singh@imfinity.com', N'smsstu2012111115324', N'smsstu2012111615139', N'smsstu2012111115324', 14, 0, 0, 1)
INSERT [BDD_User] ([UserID], [LoginName], [Password], [Email], [FirstName], [MiddleName], [LastName], [UserTypeID], [CreationStatus], [EnrollStatus], [PromotedAsTA]) VALUES (8, N'smsstu2012115103330', N'password1', N'manish.singh@imfinity.com', N'smsstu2012115103330', N'smsstu2012115103330', N'smsstu2012111615139', 14, 0, 0, NULL)
INSERT [BDD_User] ([UserID], [LoginName], [Password], [Email], [FirstName], [MiddleName], [LastName], [UserTypeID], [CreationStatus], [EnrollStatus], [PromotedAsTA]) VALUES (9, N'smsstu2012115103615', N'password1', N'manish.singh@imfinity.com', N'smsstu2012115103615', N'smsstu2012115103615', N'smsstu2012115103615', 14, 0, 0, NULL)
INSERT [BDD_User] ([UserID], [LoginName], [Password], [Email], [FirstName], [MiddleName], [LastName], [UserTypeID], [CreationStatus], [EnrollStatus], [PromotedAsTA]) VALUES (10, N'smsstu2012115115122', N'password1', N'manish.singh@imfinity.com', N'smsstu2012115115122', N'smsstu2012115115122', N'smsstu2012115115122', 14, 0, 0, NULL)
INSERT [BDD_User] ([UserID], [LoginName], [Password], [Email], [FirstName], [MiddleName], [LastName], [UserTypeID], [CreationStatus], [EnrollStatus], [PromotedAsTA]) VALUES (11, N'smsstu201211511581', N'password1', N'manish.singh@imfinity.com', N'smsstu201211511581', N'smsstu201211511581', N'smsstu201211511581', 14, 0, 0, NULL)
INSERT [BDD_User] ([UserID], [LoginName], [Password], [Email], [FirstName], [MiddleName], [LastName], [UserTypeID], [CreationStatus], [EnrollStatus], [PromotedAsTA]) VALUES (12, N'smsstu2012115121610', N'password1', N'manish.singh@imfinity.com', N'smsstu2012115121610', N'smsstu2012115121610', N'smsstu2012115121610', 14, 0, 0, NULL)
INSERT [BDD_User] ([UserID], [LoginName], [Password], [Email], [FirstName], [MiddleName], [LastName], [UserTypeID], [CreationStatus], [EnrollStatus], [PromotedAsTA]) VALUES (13, N'smsstu201211515113', N'password1', N'manish.singh@imfinity.com', N'smsstu201211515113', N'smsstu201211515113', N'smsstu201211515113', 14, 0, 0, 1)
INSERT [BDD_User] ([UserID], [LoginName], [Password], [Email], [FirstName], [MiddleName], [LastName], [UserTypeID], [CreationStatus], [EnrollStatus], [PromotedAsTA]) VALUES (14, N'smsstu201211515365', N'password1', N'manish.singh@imfinity.com', N'smsstu201211515365', N'smsstu201211515365', N'smsstu201211515365', 14, 0, 0, NULL)
INSERT [BDD_User] ([UserID], [LoginName], [Password], [Email], [FirstName], [MiddleName], [LastName], [UserTypeID], [CreationStatus], [EnrollStatus], [PromotedAsTA]) VALUES (15, N'smsstu2012115154033', N'password1', N'manish.singh@imfinity.com', N'smsstu2012115154033', N'smsstu2012115154033', N'smsstu2012115154033', 14, 0, 0, NULL)
INSERT [BDD_User] ([UserID], [LoginName], [Password], [Email], [FirstName], [MiddleName], [LastName], [UserTypeID], [CreationStatus], [EnrollStatus], [PromotedAsTA]) VALUES (16, N'smsstu20121021164154', N'password1', N'manish.singh@imfinity.com', N'smsstu2012115154339', N'smsstu2012115154339', N'smsstu2012115154339', 14, 0, 0, NULL)
INSERT [BDD_User] ([UserID], [LoginName], [Password], [Email], [FirstName], [MiddleName], [LastName], [UserTypeID], [CreationStatus], [EnrollStatus], [PromotedAsTA]) VALUES (17, N'smsins20121021164115', N'password1', N'manish.sharma@imfinity.com', N'a', N'b', N'c', 13, 0, 0, NULL)
INSERT [BDD_User] ([UserID], [LoginName], [Password], [Email], [FirstName], [MiddleName], [LastName], [UserTypeID], [CreationStatus], [EnrollStatus], [PromotedAsTA]) VALUES (18, N'smsins2012112817436', N'automation11', N'manish.singh@imfinity.com', N'smsins2012112817436', N'smsins2012112817436', N'smsins2012112817436', 13, 1, 1, NULL)
INSERT [BDD_User] ([UserID], [LoginName], [Password], [Email], [FirstName], [MiddleName], [LastName], [UserTypeID], [CreationStatus], [EnrollStatus], [PromotedAsTA]) VALUES (19, N'smsstu2012112817522', N'password1', N'manish.singh@imfinity.com', N'smsstu2012112817522', N'smsstu2012112817522', N'smsstu2012112817522', 14, 1, 1, NULL)
INSERT [BDD_User] ([UserID], [LoginName], [Password], [Email], [FirstName], [MiddleName], [LastName], [UserTypeID], [CreationStatus], [EnrollStatus], [PromotedAsTA]) VALUES (20, N'Ins20121128225544', N'password14', N'auto@auto.com', N'Ins20121128225544', N'Ins20121128225544', N'Ins20121128225544', 12, 1, 1, NULL)
INSERT [BDD_UrlInfo] ([WS_URL], [CS_URL], [WSURL_HED], [CSURL_HED], [SMS_URL], [RUMBA_URL]) VALUES (N'http://ph.ws.st.56school2.excelindia.com/pegasus/', N'http://st.56school2.excelindia.com/pegasus/', N'http://ph.ws.st.hedcore57.excelindia.com/Pegasus/', N'http://st.hedcore57.excelindia.com/Pegasus/', N'http://register.cert.pearsoncmg.com/reg/register/reg1.jsp', NULL)
INSERT [BDD_TemplateTypeLookUp] ([TemplateTypeID], [TemplateTypeName]) VALUES (1, N'NovaNET')
INSERT [BDD_TemplateTypeLookUp] ([TemplateTypeID], [TemplateTypeName]) VALUES (2, N'DigitalPath')
INSERT [BDD_QuestionTypeLookUp] ([QuestionTypeID], [QuestionType]) VALUES (1, N'MultipleChoice')
INSERT [BDD_QuestionTypeLookUp] ([QuestionTypeID], [QuestionType]) VALUES (2, N'FillInTheBlank')
INSERT [BDD_QuestionTypeLookUp] ([QuestionTypeID], [QuestionType]) VALUES (3, N'SCO')
INSERT [BDD_ProgramTypeLookUp] ([ProgramTypeID], [ProgramType]) VALUES (1, N'NovaNET')
INSERT [BDD_ProgramTypeLookUp] ([ProgramTypeID], [ProgramType]) VALUES (2, N'DigitalPath')
INSERT [BDD_ProgramTypeLookUp] ([ProgramTypeID], [ProgramType]) VALUES (3, N'HedCore')
INSERT [BDD_ProgramTypeLookUp] ([ProgramTypeID], [ProgramType]) VALUES (4, N'HedMil')
INSERT [BDD_Program] ([ProgramID], [ProgramName], [EmptyCourseID], [CreationStatus], [ProgramTypeID]) VALUES (1, N'BDD_Prod20121019215010', NULL, 0, 3)
INSERT [BDD_Program] ([ProgramID], [ProgramName], [EmptyCourseID], [CreationStatus], [ProgramTypeID]) VALUES (2, N'BDD_Pgm2012112817014', NULL, 1, 3)
INSERT [BDD_ProductTypeLookUp] ([ProductTypeID], [ProductType]) VALUES (1, N'NovaNET')
INSERT [BDD_ProductTypeLookUp] ([ProductTypeID], [ProductType]) VALUES (2, N'DigitalPath')
INSERT [BDD_ProductTypeLookUp] ([ProductTypeID], [ProductType]) VALUES (3, N'HedCoreGeneral')
INSERT [BDD_ProductTypeLookUp] ([ProductTypeID], [ProductType]) VALUES (4, N'HedCoreProgram')
INSERT [BDD_ProductTypeLookUp] ([ProductTypeID], [ProductType]) VALUES (5, N'HedMilGeneral')
INSERT [BDD_ProductTypeLookUp] ([ProductTypeID], [ProductType]) VALUES (6, N'HedMilProgram')
INSERT [BDD_Product] ([ProductID], [ProductName], [CreationStatus], [ProgramCourseID], [ProductTypeID], [LicenseStatus], [RumbaResourceID], [RumbaProductID], [MCAssStatus]) VALUES (1, N'BDD_Prod20121021163759', 0, 1, 3, NULL, NULL, NULL, 1)
INSERT [BDD_Product] ([ProductID], [ProductName], [CreationStatus], [ProgramCourseID], [ProductTypeID], [LicenseStatus], [RumbaResourceID], [RumbaProductID], [MCAssStatus]) VALUES (2, N'BDD_Prod20121021163820', 0, 1, 4, NULL, NULL, NULL, 1)
INSERT [BDD_Product] ([ProductID], [ProductName], [CreationStatus], [ProgramCourseID], [ProductTypeID], [LicenseStatus], [RumbaResourceID], [RumbaProductID], [MCAssStatus]) VALUES (3, N'BDD_Prod201211281715', 1, 2, 3, NULL, NULL, NULL, 1)
INSERT [BDD_Product] ([ProductID], [ProductName], [CreationStatus], [ProgramCourseID], [ProductTypeID], [LicenseStatus], [RumbaResourceID], [RumbaProductID], [MCAssStatus]) VALUES (4, N'BDD_Prod2012112817129', 1, 2, 4, NULL, NULL, NULL, 1)
INSERT [BDD_OrgTypeLookUp] ([OrgTypeID], [OrgTypeName]) VALUES (1, N'NovaNET')
INSERT [BDD_OrgTypeLookUp] ([OrgTypeID], [OrgTypeName]) VALUES (2, N'DigitalPath')
INSERT [BDD_OrgLeveTypeLookUp] ([LevelID], [LevelName]) VALUES (1, N'State')
INSERT [BDD_OrgLeveTypeLookUp] ([LevelID], [LevelName]) VALUES (2, N'Region')
INSERT [BDD_OrgLeveTypeLookUp] ([LevelID], [LevelName]) VALUES (3, N'District')
INSERT [BDD_OrgLeveTypeLookUp] ([LevelID], [LevelName]) VALUES (4, N'School')
INSERT [BDD_CourseTypeLookUp] ([CourseTypeID], [CourseType]) VALUES (1, N'EmptyCourse')
INSERT [BDD_CourseTypeLookUp] ([CourseTypeID], [CourseType]) VALUES (2, N'ContainerCourse')
INSERT [BDD_CourseTypeLookUp] ([CourseTypeID], [CourseType]) VALUES (3, N'MasterLibrary')
INSERT [BDD_CourseTypeLookUp] ([CourseTypeID], [CourseType]) VALUES (4, N'MasterCourse')
INSERT [BDD_CourseTypeLookUp] ([CourseTypeID], [CourseType]) VALUES (5, N'AuthoredMasterLibrary')
INSERT [BDD_CourseTypeLookUp] ([CourseTypeID], [CourseType]) VALUES (6, N'AuthoredCourse')
INSERT [BDD_CourseTypeLookUp] ([CourseTypeID], [CourseType]) VALUES (7, N'MySpanishLabAuthoredCourse')
INSERT [BDD_CourseTypeLookUp] ([CourseTypeID], [CourseType]) VALUES (8, N'MySpanishLabMasterCourse')
INSERT [BDD_CourseTypeLookUp] ([CourseTypeID], [CourseType]) VALUES (9, N'InstructorCourse')
INSERT [BDD_CourseTypeLookUp] ([CourseTypeID], [CourseType]) VALUES (10, N'ProgramCourse')
INSERT [BDD_CourseTypeLookUp] ([CourseTypeID], [CourseType]) VALUES (11, N'TestingCourse')
INSERT [BDD_CourseTypeLookUp] ([CourseTypeID], [CourseType]) VALUES (12, N'SectionCourse')
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (1, N'Digit_Course', 6, 1, 0, 0, 0, NULL, NULL, NULL)
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (2, N'MySpanishLabRe-release', 7, 1, 0, 0, 0, NULL, NULL, NULL)
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (3, N'MySpanishLab20121021161746', 8, 0, NULL, 1, 1, NULL, NULL, NULL)
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (4, N'INSCOURSE20121021164313', 9, 0, NULL, 0, NULL, N'CRSKL5B-10002034', NULL, NULL)
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (5, N'PRGCOURSE2012102116489', 10, 0, NULL, 0, NULL, NULL, NULL, N'Section2012115111949')
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (6, N'INSCOURSE20121021164313', 9, 0, NULL, 0, NULL, N'CRSKL5B-10002034', NULL, NULL)
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (7, N'INSCOURSE20121021164313', 9, 0, NULL, 1, 1, N'CRSKL5B-10002034', NULL, NULL)
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (8, N'INSCOURSE2012102225749', 9, 0, NULL, 0, NULL, N'is being prepared and will be available soon.', NULL, NULL)
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (9, N'INSCOURSE20121022132927', 9, 0, NULL, 0, NULL, N'CRSKLTT-2004693', NULL, NULL)
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (10, N'INSCOURSE20121022154031', 9, 0, NULL, 0, NULL, N'CRSKLKQ-2004702', NULL, NULL)
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (11, N'INSCOURSE20121022155144', 9, 0, NULL, 0, NULL, N'CRSKLIM-10002064', NULL, NULL)
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (12, N'INSCOURSE20121023133119', 9, 0, NULL, 0, NULL, N'CRSKLEJ-10002083', NULL, NULL)
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (13, N'INSCOURSE20121116163839', 9, 0, NULL, 0, NULL, N'CRSKL8F-10002989', NULL, NULL)
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (14, N'PRGCOURSE2012103111157', 10, 0, NULL, 0, NULL, NULL, NULL, N'Section2012115111949')
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (15, N'PRGCOURSE2012103111936', 10, 0, NULL, 0, NULL, N'CRSKLWF-10002342', NULL, N'Section2012115111949')
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (16, N'PRGCOURSE201211511731', 10, 0, NULL, 0, NULL, N'CRSKL92-2004791', NULL, N'Section2012115111949')
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (17, N'PRGCOURSE2012115131340', 10, 0, NULL, 0, NULL, N'CRSKL23-2004796', NULL, N'Section2012115133125')
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (18, N'MySpanishLab2012112815430', 8, 1, NULL, 1, 1, NULL, NULL, NULL)
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (19, N'INSCOURSE20121128171539', 9, 1, NULL, 0, NULL, N'CRSKLM4-2005008', NULL, NULL)
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (20, N'PRGCOURSE20121128174353', 10, 1, NULL, 0, NULL, NULL, NULL, N'Section2012112914938')
INSERT [BDD_Course] ([CourseID], [Name], [CourseTypeID], [CreationStatus], [PreferenceStatus], [PublishStatus], [ApproveStatus], [EnrolCourseID], [TemplateName], [SectionName]) VALUES (21, N'TestingCourse20121128225629', 11, 1, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [BDD_ClassTypeLookUp] ([ClassTypeID], [ClassType]) VALUES (1, N'NovaNETTemplate')
INSERT [BDD_ClassTypeLookUp] ([ClassTypeID], [ClassType]) VALUES (2, N'NovaNETMasterLibrary')
INSERT [BDD_ClassTypeLookUp] ([ClassTypeID], [ClassType]) VALUES (3, N'DigitalPathTemplate')
INSERT [BDD_ClassTypeLookUp] ([ClassTypeID], [ClassType]) VALUES (4, N'DigitalPathMasterLibrary')
INSERT [BDD_ClassTypeLookUp] ([ClassTypeID], [ClassType]) VALUES (5, N'NovaNETPlaceHolder')
INSERT [BDD_ClassTypeLookUp] ([ClassTypeID], [ClassType]) VALUES (6, N'DigitalPathPlaceHolder')
INSERT [BDD_ActivityTypeLookUp] ([ActivityTypeID], [ActivityType]) VALUES (1, N'SkillStudyPlan')
INSERT [BDD_ActivityTypeLookUp] ([ActivityTypeID], [ActivityType]) VALUES (2, N'Homework')
INSERT [BDD_ActivityTypeLookUp] ([ActivityTypeID], [ActivityType]) VALUES (3, N'Folder')
INSERT [BDD_ActivityTypeLookUp] ([ActivityTypeID], [ActivityType]) VALUES (4, N'Essay')
INSERT [BDD_ActivityTypeLookUp] ([ActivityTypeID], [ActivityType]) VALUES (5, N'MyTest')
INSERT [BDD_ActivityTypeLookUp] ([ActivityTypeID], [ActivityType]) VALUES (6, N'StudyPlan')
INSERT [BDD_ActivityTypeLookUp] ([ActivityTypeID], [ActivityType]) VALUES (7, N'SpWith1Rem')
INSERT [BDD_ActivityTypeLookUp] ([ActivityTypeID], [ActivityType]) VALUES (8, N'Sp1With3Rem')
INSERT [BDD_ActivityTypeLookUp] ([ActivityTypeID], [ActivityType]) VALUES (9, N'Sp2With3Rem')
INSERT [BDD_Activity] ([ActivityID], [ActivityName], [ActivityTypeID], [CreationStatus], [SubmissionStatus]) VALUES (1, N'SAM 0A-33 El mundo hispano.', 4, 1, 1)
INSERT [BDD_Activity] ([ActivityID], [ActivityName], [ActivityTypeID], [CreationStatus], [SubmissionStatus]) VALUES (2, N'Test20121031103140', 5, 0, 1)
INSERT [BDD_Activity] ([ActivityID], [ActivityName], [ActivityTypeID], [CreationStatus], [SubmissionStatus]) VALUES (3, N'Test2012115172133', 5, 0, 0)
INSERT [BDD_Activity] ([ActivityID], [ActivityName], [ActivityTypeID], [CreationStatus], [SubmissionStatus]) VALUES (4, N'Test2012115173333', 5, 0, 0)
INSERT [BDD_Activity] ([ActivityID], [ActivityName], [ActivityTypeID], [CreationStatus], [SubmissionStatus]) VALUES (5, N'Test2012115175253', 5, 0, 0)
INSERT [BDD_Activity] ([ActivityID], [ActivityName], [ActivityTypeID], [CreationStatus], [SubmissionStatus]) VALUES (6, N'Test201211518240', 5, 0, 0)
INSERT [BDD_Activity] ([ActivityID], [ActivityName], [ActivityTypeID], [CreationStatus], [SubmissionStatus]) VALUES (7, N'SP2012112121050dd', 6, 0, 1)
INSERT [BDD_Activity] ([ActivityID], [ActivityName], [ActivityTypeID], [CreationStatus], [SubmissionStatus]) VALUES (8, N'Test2012115195020', 5, 0, 0)
INSERT [BDD_Activity] ([ActivityID], [ActivityName], [ActivityTypeID], [CreationStatus], [SubmissionStatus]) VALUES (9, N'Test2012115195519', 5, 0, 0)
INSERT [BDD_Activity] ([ActivityID], [ActivityName], [ActivityTypeID], [CreationStatus], [SubmissionStatus]) VALUES (10, N'Test201211520345', 5, 0, 0)
INSERT [BDD_Activity] ([ActivityID], [ActivityName], [ActivityTypeID], [CreationStatus], [SubmissionStatus]) VALUES (11, N'Test201211693434', 5, 0, 0)
INSERT [BDD_Activity] ([ActivityID], [ActivityName], [ActivityTypeID], [CreationStatus], [SubmissionStatus]) VALUES (12, N'Test201211510941', 5, 0, 0)
INSERT [BDD_Activity] ([ActivityID], [ActivityName], [ActivityTypeID], [CreationStatus], [SubmissionStatus]) VALUES (13, N'StudyPlan12012', 7, 1, 1)
INSERT [BDD_Activity] ([ActivityID], [ActivityName], [ActivityTypeID], [CreationStatus], [SubmissionStatus]) VALUES (14, N'StudyPlan22012', 8, 1, 1)
INSERT [BDD_Activity] ([ActivityID], [ActivityName], [ActivityTypeID], [CreationStatus], [SubmissionStatus]) VALUES (15, N'StudyPlan32012', 9, 1, 1)
INSERT [BDD_Activity] ([ActivityID], [ActivityName], [ActivityTypeID], [CreationStatus], [SubmissionStatus]) VALUES (16, N'Test20121129155634', 5, 1, 0)
INSERT [BDD_Activity] ([ActivityID], [ActivityName], [ActivityTypeID], [CreationStatus], [SubmissionStatus]) VALUES (17, N'Test20121129165613', 5, 1, 0)
