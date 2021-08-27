-- ----------------------------
-- Table structure for meal_rates
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[meal_rates]') AND type IN ('U'))
	DROP TABLE [dbo].[meal_rates]
GO

CREATE TABLE [dbo].[meal_rates] (
  [meal_id] int  NOT NULL,
  [rate_per_person] int  NULL,
  [start_date] date  NULL,
  [end_date] date  NULL
)
GO

ALTER TABLE [dbo].[meal_rates] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of meal_rates
-- ----------------------------
INSERT INTO [dbo].[meal_rates] ([meal_id], [rate_per_person], [start_date], [end_date]) VALUES (N'2', N'20', N'2021-01-01', N'2021-05-31')
GO

INSERT INTO [dbo].[meal_rates] ([meal_id], [rate_per_person], [start_date], [end_date]) VALUES (N'2', N'25', N'2021-06-01', N'2021-12-31')
GO

INSERT INTO [dbo].[meal_rates] ([meal_id], [rate_per_person], [start_date], [end_date]) VALUES (N'3', N'25', N'2021-01-01', N'2021-05-31')
GO

INSERT INTO [dbo].[meal_rates] ([meal_id], [rate_per_person], [start_date], [end_date]) VALUES (N'3', N'30', N'2021-06-01', N'2021-12-31')
GO

INSERT INTO [dbo].[meal_rates] ([meal_id], [rate_per_person], [start_date], [end_date]) VALUES (N'1', N'5', N'2021-01-01', N'2021-05-31')
GO

INSERT INTO [dbo].[meal_rates] ([meal_id], [rate_per_person], [start_date], [end_date]) VALUES (N'1', N'10', N'2021-06-01', N'2021-12-31')
GO


-- ----------------------------
-- Table structure for meals
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[meals]') AND type IN ('U'))
	DROP TABLE [dbo].[meals]
GO

CREATE TABLE [dbo].[meals] (
  [meal_id] int  NOT NULL,
  [meal_type] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[meals] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of meals
-- ----------------------------
INSERT INTO [dbo].[meals] ([meal_id], [meal_type]) VALUES (N'1', N'Half Board')
GO

INSERT INTO [dbo].[meals] ([meal_id], [meal_type]) VALUES (N'2', N'Full Board')
GO

INSERT INTO [dbo].[meals] ([meal_id], [meal_type]) VALUES (N'3', N'All Inclusive')
GO


-- ----------------------------
-- Table structure for room_rates
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[room_rates]') AND type IN ('U'))
	DROP TABLE [dbo].[room_rates]
GO

CREATE TABLE [dbo].[room_rates] (
  [room_type_id] int  NOT NULL,
  [start_date] date  NULL,
  [end_date] date  NULL,
  [rate_per_room] int  NULL
)
GO

ALTER TABLE [dbo].[room_rates] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of room_rates
-- ----------------------------
INSERT INTO [dbo].[room_rates] ([room_type_id], [start_date], [end_date], [rate_per_room]) VALUES (N'1', N'2021-01-01', N'2021-01-15', N'70')
GO

INSERT INTO [dbo].[room_rates] ([room_type_id], [start_date], [end_date], [rate_per_room]) VALUES (N'1', N'2021-01-16', N'2021-04-29', N'50')
GO

INSERT INTO [dbo].[room_rates] ([room_type_id], [start_date], [end_date], [rate_per_room]) VALUES (N'1', N'2021-04-30', N'2021-12-31', N'100')
GO

INSERT INTO [dbo].[room_rates] ([room_type_id], [start_date], [end_date], [rate_per_room]) VALUES (N'2', N'2021-01-01', N'2021-01-15', N'50')
GO

INSERT INTO [dbo].[room_rates] ([room_type_id], [start_date], [end_date], [rate_per_room]) VALUES (N'2', N'2021-01-16', N'2021-04-29', N'30')
GO

INSERT INTO [dbo].[room_rates] ([room_type_id], [start_date], [end_date], [rate_per_room]) VALUES (N'2', N'2021-04-30', N'2021-12-31', N'60')
GO

INSERT INTO [dbo].[room_rates] ([room_type_id], [start_date], [end_date], [rate_per_room]) VALUES (N'3', N'2021-01-01', N'2021-01-15', N'40')
GO

INSERT INTO [dbo].[room_rates] ([room_type_id], [start_date], [end_date], [rate_per_room]) VALUES (N'3', N'2021-01-16', N'2021-04-29', N'20')
GO

INSERT INTO [dbo].[room_rates] ([room_type_id], [start_date], [end_date], [rate_per_room]) VALUES (N'3', N'2021-04-30', N'2021-12-31', N'50')
GO

INSERT INTO [dbo].[room_rates] ([room_type_id], [start_date], [end_date], [rate_per_room]) VALUES (N'4', N'2021-01-01', N'2021-01-15', N'200')
GO

INSERT INTO [dbo].[room_rates] ([room_type_id], [start_date], [end_date], [rate_per_room]) VALUES (N'4', N'2021-01-16', N'2021-04-29', N'150')
GO

INSERT INTO [dbo].[room_rates] ([room_type_id], [start_date], [end_date], [rate_per_room]) VALUES (N'4', N'2021-04-30', N'2021-12-31', N'350')
GO


-- ----------------------------
-- Table structure for room_types
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[room_types]') AND type IN ('U'))
	DROP TABLE [dbo].[room_types]
GO

CREATE TABLE [dbo].[room_types] (
  [id] int  NOT NULL,
  [room_type] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[room_types] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of room_types
-- ----------------------------
INSERT INTO [dbo].[room_types] ([id], [room_type]) VALUES (N'1', N'Sea View')
GO

INSERT INTO [dbo].[room_types] ([id], [room_type]) VALUES (N'2', N'Pool View')
GO

INSERT INTO [dbo].[room_types] ([id], [room_type]) VALUES (N'3', N'Garden View')
GO

INSERT INTO [dbo].[room_types] ([id], [room_type]) VALUES (N'4', N'Royal Suite')
GO


-- ----------------------------
-- Primary Key structure for table meals
-- ----------------------------
ALTER TABLE [dbo].[meals] ADD CONSTRAINT [PK__meals__2910B00FD8946869] PRIMARY KEY CLUSTERED ([meal_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table room_types
-- ----------------------------
ALTER TABLE [dbo].[room_types] ADD CONSTRAINT [PK__room_typ__3213E83F67859601] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table meal_rates
-- ----------------------------
ALTER TABLE [dbo].[meal_rates] ADD CONSTRAINT [meal_rates_id] FOREIGN KEY ([meal_id]) REFERENCES [dbo].[meals] ([meal_id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table room_rates
-- ----------------------------
ALTER TABLE [dbo].[room_rates] ADD CONSTRAINT [room_type] FOREIGN KEY ([room_type_id]) REFERENCES [dbo].[room_types] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

