IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(max) NULL,
        [Role] nvarchar(max) NULL,
        [ProfilePic] nvarchar(max) NULL,
        [Discriminator] nvarchar(21) NOT NULL,
        [Admin_Payment_Method] nvarchar(max) NULL,
        [Class] nvarchar(max) NULL,
        [Coins] nvarchar(max) NULL,
        [Category] nvarchar(max) NULL,
        [City] nvarchar(max) NULL,
        [Address] nvarchar(max) NULL,
        [School] nvarchar(max) NULL,
        [Second_Lang] nvarchar(max) NULL,
        [Std_Phone] nvarchar(max) NULL,
        [Parent_Phone] nvarchar(max) NULL,
        [Student_Facebook_Link] nvarchar(max) NULL,
        [Balance] int NULL,
        [Student_ID_Number] nvarchar(max) NULL,
        [isActivated] bit NULL,
        [JoinedAt] nvarchar(max) NULL,
        [Teacher_ID_Number] nvarchar(max) NULL,
        [Subject] nvarchar(max) NULL,
        [Bio] nvarchar(max) NULL,
        [Payment_Method] nvarchar(max) NULL,
        [Students_No] int NULL,
        [ID_Number] nvarchar(max) NULL,
        [Facebook_Link] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [TeacherId] nvarchar(450) NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUsers_AspNetUsers_TeacherId] FOREIGN KEY ([TeacherId]) REFERENCES [AspNetUsers] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE TABLE [Categories] (
        [CategoryId] nvarchar(450) NOT NULL,
        [CategoryName] nvarchar(max) NULL,
        [CategoryThumbnail] nvarchar(max) NULL,
        [Lectures_No] int NOT NULL,
        [TeacherId] nvarchar(450) NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryId]),
        CONSTRAINT [FK_Categories_AspNetUsers_TeacherId] FOREIGN KEY ([TeacherId]) REFERENCES [AspNetUsers] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE TABLE [Codes] (
        [CodeId] nvarchar(450) NOT NULL,
        [CodeName] nvarchar(max) NULL,
        [Price] int NOT NULL,
        [StudentId] nvarchar(450) NULL,
        CONSTRAINT [PK_Codes] PRIMARY KEY ([CodeId]),
        CONSTRAINT [FK_Codes_AspNetUsers_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [AspNetUsers] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE TABLE [Quizzes] (
        [Quiz_ID] nvarchar(450) NOT NULL,
        [Quiz_Name] nvarchar(max) NULL,
        [TimeInMins] nvarchar(max) NULL,
        [NoOfQuestions] int NOT NULL,
        [NoOfValidDays] int NOT NULL,
        [PassingScore] int NOT NULL,
        [Thumbnail] nvarchar(max) NULL,
        [TeacherId] nvarchar(450) NULL,
        CONSTRAINT [PK_Quizzes] PRIMARY KEY ([Quiz_ID]),
        CONSTRAINT [FK_Quizzes_AspNetUsers_TeacherId] FOREIGN KEY ([TeacherId]) REFERENCES [AspNetUsers] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE TABLE [SubscriptionRequests] (
        [SubscriptionRequestId] nvarchar(450) NOT NULL,
        [StudentName] nvarchar(max) NULL,
        [isAccepted] bit NULL,
        [Acceptance_Date] nvarchar(max) NULL,
        [StudentId] nvarchar(450) NULL,
        [TeacherId] nvarchar(450) NULL,
        CONSTRAINT [PK_SubscriptionRequests] PRIMARY KEY ([SubscriptionRequestId]),
        CONSTRAINT [FK_SubscriptionRequests_AspNetUsers_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_SubscriptionRequests_AspNetUsers_TeacherId] FOREIGN KEY ([TeacherId]) REFERENCES [AspNetUsers] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE TABLE [Courses] (
        [CourseId] nvarchar(450) NOT NULL,
        [CourseName] nvarchar(max) NULL,
        [CourseDescription] nvarchar(max) NULL,
        [Thumbnail] nvarchar(max) NULL,
        [Valid_Period] nvarchar(max) NULL,
        [Price] int NOT NULL,
        [Pre_Requirement] nvarchar(max) NULL,
        [Videos_No] int NOT NULL,
        [TeacherId] nvarchar(450) NULL,
        [CategoryId] nvarchar(450) NULL,
        CONSTRAINT [PK_Courses] PRIMARY KEY ([CourseId]),
        CONSTRAINT [FK_Courses_AspNetUsers_TeacherId] FOREIGN KEY ([TeacherId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_Courses_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([CategoryId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE TABLE [Enrollments] (
        [Enrollment_ID] nvarchar(450) NOT NULL,
        [Payment_Type] nvarchar(max) NULL,
        [Payment_Amount] int NOT NULL,
        [PaymentDate] nvarchar(max) NULL,
        [CourseId] nvarchar(450) NULL,
        [StudentId] nvarchar(450) NULL,
        CONSTRAINT [PK_Enrollments] PRIMARY KEY ([Enrollment_ID]),
        CONSTRAINT [FK_Enrollments_AspNetUsers_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_Enrollments_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([CourseId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE TABLE [Homeworks] (
        [HW_ID] nvarchar(450) NOT NULL,
        [HW_Name] nvarchar(max) NULL,
        [HW_Description] nvarchar(max) NULL,
        [HW_Score] int NOT NULL,
        [Thumbnail] nvarchar(max) NULL,
        [CourseId] nvarchar(450) NULL,
        [TeacherId] nvarchar(450) NULL,
        CONSTRAINT [PK_Homeworks] PRIMARY KEY ([HW_ID]),
        CONSTRAINT [FK_Homeworks_AspNetUsers_TeacherId] FOREIGN KEY ([TeacherId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_Homeworks_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([CourseId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE TABLE [Materials] (
        [Material_Id] nvarchar(450) NOT NULL,
        [File_Id] nvarchar(max) NULL,
        [File_Name] nvarchar(max) NULL,
        [File_Link] nvarchar(max) NULL,
        [CourseId] nvarchar(450) NULL,
        CONSTRAINT [PK_Materials] PRIMARY KEY ([Material_Id]),
        CONSTRAINT [FK_Materials_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([CourseId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE TABLE [Questions] (
        [Question_ID] nvarchar(450) NOT NULL,
        [Question_Title] nvarchar(max) NULL,
        [Question_Description] nvarchar(max) NULL,
        [Thumbnail] nvarchar(max) NULL,
        [QuestionScore] int NOT NULL,
        [Choices] nvarchar(max) NULL,
        [CourseId] nvarchar(450) NULL,
        [Quiz_ID] nvarchar(450) NULL,
        CONSTRAINT [PK_Questions] PRIMARY KEY ([Question_ID]),
        CONSTRAINT [FK_Questions_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([CourseId]),
        CONSTRAINT [FK_Questions_Quizzes_Quiz_ID] FOREIGN KEY ([Quiz_ID]) REFERENCES [Quizzes] ([Quiz_ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE TABLE [Videos] (
        [Video_ID] nvarchar(450) NOT NULL,
        [Video_Title] nvarchar(max) NULL,
        [Video_Description] nvarchar(max) NULL,
        [Views_No] int NOT NULL,
        [Video_Path] nvarchar(max) NULL,
        [Thumbnail] nvarchar(max) NULL,
        [TeacherId] nvarchar(450) NULL,
        [CourseId] nvarchar(450) NULL,
        CONSTRAINT [PK_Videos] PRIMARY KEY ([Video_ID]),
        CONSTRAINT [FK_Videos_AspNetUsers_TeacherId] FOREIGN KEY ([TeacherId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_Videos_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([CourseId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE TABLE [HwAnswers] (
        [HwId] nvarchar(450) NOT NULL,
        [FileName] nvarchar(max) NULL,
        [FilePath] nvarchar(max) NULL,
        [Thumbnail] nvarchar(max) NULL,
        [StudentId] nvarchar(450) NULL,
        [Hw_ID] nvarchar(450) NULL,
        CONSTRAINT [PK_HwAnswers] PRIMARY KEY ([HwId]),
        CONSTRAINT [FK_HwAnswers_AspNetUsers_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_HwAnswers_Homeworks_Hw_ID] FOREIGN KEY ([Hw_ID]) REFERENCES [Homeworks] ([HW_ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_AspNetUsers_TeacherId] ON [AspNetUsers] ([TeacherId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Categories_TeacherId] ON [Categories] ([TeacherId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Codes_StudentId] ON [Codes] ([StudentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Courses_CategoryId] ON [Courses] ([CategoryId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Courses_TeacherId] ON [Courses] ([TeacherId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Enrollments_CourseId] ON [Enrollments] ([CourseId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Enrollments_StudentId] ON [Enrollments] ([StudentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Homeworks_CourseId] ON [Homeworks] ([CourseId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Homeworks_TeacherId] ON [Homeworks] ([TeacherId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_HwAnswers_Hw_ID] ON [HwAnswers] ([Hw_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_HwAnswers_StudentId] ON [HwAnswers] ([StudentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Materials_CourseId] ON [Materials] ([CourseId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Questions_CourseId] ON [Questions] ([CourseId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Questions_Quiz_ID] ON [Questions] ([Quiz_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Quizzes_TeacherId] ON [Quizzes] ([TeacherId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_SubscriptionRequests_StudentId] ON [SubscriptionRequests] ([StudentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_SubscriptionRequests_TeacherId] ON [SubscriptionRequests] ([TeacherId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Videos_CourseId] ON [Videos] ([CourseId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Videos_TeacherId] ON [Videos] ([TeacherId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240618090354_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240618090354_InitialCreate', N'8.0.6');
END;
GO

COMMIT;
GO

