USE master
CREATE DATABASE Billing
ON
(
	NAME = 'KURSOVOI_PROJECT',
	SIZE = 2048,
	MAXSIZE = 4096,
	FILEGROWTH = 10%
)
LOG ON
(
	NAME = 'KURSOVOI_PROJECT_log',
	SIZE = 1024KB,
	MAXSIZE = 4096KB,
	FILEGROWTH = 10%
)
GO

USE Billing
GO
SET DATEFIRST 7
GO
CREATE TYPE [dbo].[TYEAR] FROM [smallint] NOT NULL
GO
CREATE TYPE [dbo].[CASH] FROM [numeric](15, 2) NOT NULL
GO
CREATE TYPE [dbo].[PKFIELD] FROM [int] NOT NULL
GO
CREATE TYPE [dbo].[TMONTH] FROM [smallint] NOT NULL
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

USE Billing
GO 
/*_________ Street ___________*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE Street (
	StreetCD [dbo].[PKFIELD] NOT NULL,
	StreetName VARCHAR(50) COLLATE Cyrillic_General_CS_AS check (StreetName LIKE REPLICATE('[ А-Яа-я-,]', LEN(StreetName)))
	CONSTRAINT [PK_STREET] PRIMARY KEY CLUSTERED
	(
	StreetCD ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/*_________ Disrepair ___________*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE Disrepair (
	FailureCD [dbo].[PKFIELD] NOT NULL,
	FailureName VARCHAR(50) COLLATE Cyrillic_General_CS_AS check (FailureName LIKE REPLICATE('[ А-Яа-я-,]', LEN(FailureName)))
	CONSTRAINT [PK_DISREPAIR] PRIMARY KEY CLUSTERED
	(
	FailureCD ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/*_________ Executor ___________*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE Executor (
	ExecutorCD [dbo].[PKFIELD] NOT NULL,
	FIO VARCHAR(50) COLLATE Cyrillic_General_CS_AS check (FIO LIKE REPLICATE('[ А-Яа-я-.,]', LEN(FIO)))
	CONSTRAINT [PK_EXECUTOR] PRIMARY KEY CLUSTERED
	(
	ExecutorCD ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/*_________ Unit ___________*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE Unit (
	UnitCD int NOT NULL identity(1,1),
	UnitsName VARCHAR(15) NOT NULL
)
GO
SET ANSI_PADDING OFF
GO

ALTER TABLE Unit
ADD
CONSTRAINT PK_Unit primary key (UnitCD)
GO
/*_________ ReceptionPoint ___________*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE ReceptionPoint (
	ReceptionPointCD int NOT NULL identity(1,1),
	ReceptionName VARCHAR(50) NOT NULL check(ReceptionName LIKE REPLICATE('[ А-Яа-я-,]', LEN(ReceptionName)))
)
GO
SET ANSI_PADDING OFF
GO

ALTER TABLE ReceptionPoint
ADD
CONSTRAINT PK_ReceptionPoint primary key (ReceptionPointCD)
GO
/*_________ Abonent ___________*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE Abonent (
	AccountCD varchar(6) COLLATE Cyrillic_General_CI_AS NOT NULL check(AccountCD LIKE '[0-9][0-9][0-9][0-9][0-9][0-9]'),
	FIO varchar(70) COLLATE Cyrillic_General_CS_AS check (FIO LIKE REPLICATE('[ А-Яа-я-,.]', LEN(FIO))),
	StreetCD [dbo].[PKFIELD] NULL,
	HouseNo smallint NULL check(HouseNo > 0),
	FlatNo smallint NULL check(FlatNo > 0),
	Phone varchar(17) COLLATE Cyrillic_General_CI_AS NULL,
	Сorpus int check(Сorpus > 0),
	District VARCHAR(20),
	CountPerson int check(CountPerson > 0),
	SizeFlat float check(SizeFlat > 0)

	CONSTRAINT [PK_ABONENT] PRIMARY KEY CLUSTERED (
	AccountCD ASC 
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

ALTER TABLE Abonent
WITH CHECK ADD CONSTRAINT 
[FK_ABONENT_STREET] foreign key (StreetCD) references Street(StreetCD)
ON UPDATE CASCADE
ON DELETE SET NULL
GO
GO
ALTER TABLE Abonent CHECK CONSTRAINT [FK_ABONENT_STREET]
GO
/*_________ Services ___________*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE Services (
	ServiceCD [dbo].[PKFIELD] NOT NULL,
	ServiceName VARCHAR(50) COLLATE Cyrillic_General_CS_AS check (ServiceName LIKE REPLICATE('[ А-Яа-я-,]', LEN(ServiceName))),
	UnitsCD int NOT NULL
	CONSTRAINT [PK_SERVICES] PRIMARY KEY CLUSTERED
	(
	ServiceCD ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

ALTER TABLE Services
ADD
CONSTRAINT FK_Services_Unit foreign key (UnitsCD) references Unit(UnitCD)
GO
/*_________ Mode ___________*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE Mode (
	ModeCD int NOT NULL identity(1,1),
	ModeName VARCHAR(230) NOT NULL check (ModeName LIKE REPLICATE('[- 0-9А-Яа-я,().]', LEN(ModeName))),
	Norma numeric(15,4) NOT NULL check(NORMA > 0),
	ServiceCD int NOT NULL
)
GO
SET ANSI_PADDING OFF
GO

ALTER TABLE Mode
ADD
CONSTRAINT PK_Mode primary key (ModeCD),
CONSTRAINT FK_Mode_Services foreign key (ServiceCD) references Services(ServiceCD)
GO

/*_________ AbonentMode ___________*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE AbonentMode (
	AbonentModeСD int NOT NULL identity(1,1),
	AccountCD varchar(6) NOT NULL,
	ModeCD int NOT NULL,
	Counterr bit NOT NULL
)
GO
SET ANSI_PADDING OFF
GO

ALTER TABLE AbonentMode
ADD
CONSTRAINT PK_AbonentMode primary key (AbonentModeСD),
CONSTRAINT FK_AbonentMode_Abonent foreign key (AccountCD) references Abonent(AccountCD),
CONSTRAINT FK_AbonentMode_Mode foreign key (ModeCD) references Mode(ModeCD)
GO

/*_________ NachislSumma ___________*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE NachislSumma (
	NachislFactCD [dbo].[PKFIELD] NOT NULL,
	NachislSum [dbo].[CASH] NULL,
	NachislYear [dbo].[TYEAR] NULL check(NachislYear BETWEEN 1990 AND 2100),
	NachislMonth [dbo].[TMONTH] NULL check(NachislMonth BETWEEN 1 AND 12),
	NachType varchar(20),
	AbonentModeСD [dbo].[PKFIELD] NOT NULL,
	CountResources numeric(15,2) NOT NULL check(CountResources >= 0)
	CONSTRAINT [PK_NACHISLSUMMA] PRIMARY KEY CLUSTERED
	(
	NachislFactCD ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

ALTER TABLE NachislSumma
WITH CHECK ADD CONSTRAINT 
[FK_NACHISLSUMMA_ABONENTMODE] foreign key (AbonentModeСD) references AbonentMode(AbonentModeСD)
ON UPDATE CASCADE
GO
ALTER TABLE NachislSumma CHECK CONSTRAINT [FK_NACHISLSUMMA_ABONENTMODE]
GO
/*_________ PaySumma ___________*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE PaySumma (
	PayFactCD [dbo].[PKFIELD] NOT NULL,
	PaySum [dbo].[CASH] NULL,
	PayDate date NULL,
	PayMonth [dbo].[TMONTH] NULL check(PayMonth BETWEEN 1 AND 12),
	PayYear [dbo].[TYEAR] NULL check(PayYear BETWEEN 1990 AND 2100),
	AbonentModeСD int NOT NULL,
	PayType varchar(30),
	ReceptionPointCD int NOT NULL
	CONSTRAINT [PK_PAYSUMMA] PRIMARY KEY CLUSTERED
	(
	PayFactCD ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

ALTER TABLE PaySumma
WITH CHECK ADD CONSTRAINT 
FK_PaySumma_AbonMode foreign key (AbonentModeСD) references AbonentMode(AbonentModeСD)
ON UPDATE CASCADE
GO
ALTER TABLE PaySumma CHECK CONSTRAINT FK_PaySumma_AbonMode
GO
ALTER TABLE PaySumma
WITH CHECK ADD CONSTRAINT 
FK_PaySumma_ReceptionPoint foreign key (ReceptionPointCD) references ReceptionPoint(ReceptionPointCD)
ON UPDATE CASCADE
GO
ALTER TABLE PaySumma CHECK CONSTRAINT FK_PaySumma_ReceptionPoint
GO
/*_________ Request ___________*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE Request (
	RequestCD [dbo].[PKFIELD] NOT NULL,
	AccountCD varchar(6) NULL,
	FailureCD [dbo].[PKFIELD] NULL,
	ExecutorCD [dbo].[PKFIELD] NULL,
	IncomingDate date DEFAULT GETDATE() NOT NULL,
	ExecutionDate date,
	Executed bit DEFAULT 0 NOT NULL,
	check(ExecutionDate >= IncomingDate),

	CONSTRAINT [PK_REQUEST] PRIMARY KEY CLUSTERED
	(
	RequestCD ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

ALTER TABLE Request
WITH CHECK ADD CONSTRAINT
[FK_REQUEST_ABONENT] foreign key (AccountCD) references Abonent(AccountCD)
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE Request CHECK CONSTRAINT [FK_REQUEST_ABONENT]
GO
ALTER TABLE Request
WITH CHECK ADD CONSTRAINT 
[FK_REQUEST_DISREPAIR] foreign key (FailureCD) references Disrepair(FailureCD)
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE Request CHECK CONSTRAINT [FK_REQUEST_DISREPAIR]
GO
ALTER TABLE Request
WITH CHECK ADD CONSTRAINT 
FK_Request_Executor foreign key (ExecutorCD) references Executor(ExecutorCD)
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE Request CHECK CONSTRAINT [FK_REQUEST_EXECUTOR]
GO
/*_________ Price ___________*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE Price (
	PriceCD int NOT NULL identity(1,1),
	PriceValue numeric(15,4) NOT NULL check(PriceValue > 0),
	ModeCD int NOT NULL
)
GO
SET ANSI_PADDING OFF
GO

ALTER TABLE Price
ADD
CONSTRAINT PK_Price primary key (PriceCD),
CONSTRAINT FK_Price_Servicess foreign key (ModeCD) references Mode(ModeCD)
GO
/*_________ Remains ___________*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE Remains (
	RemainCD int NOT NULL identity(1,1),
	AccountCD varchar(6) NOT NULL,
	ServiceCD int NOT NULL,
	Remmonth smallint NOT NULL check(Remmonth BETWEEN 1 AND 12),
	Remyear smallint NOT NULL,
	Remainsum numeric(15,2) DEFAULT 0,
)
GO
SET ANSI_PADDING OFF
GO

ALTER TABLE Remains
ADD
CONSTRAINT PK_Remains primary key (RemainCD),
CONSTRAINT FK_Remains_Abonent foreign key (AccountCD) references Abonent(AccountCD),
CONSTRAINT FK_Remains_Servicess foreign key (ServiceCD) references Services(ServiceCD)
GO


INSERT INTO Street (StreetCD, StreetName)
VALUES
(3, 'ВОЙКОВ ПЕРЕУЛОК'),
(7, 'КУТУЗОВА УЛИЦА'),
(6, 'МОСКОВСКАЯ УЛИЦА'),
(8, 'МОСКОВСКОЕ ШОССЕ'),
(4, 'ТАТАРСКАЯ УЛИЦА'),
(5, 'ГАГАРИНА УЛИЦА'),
(1, 'ЦИОЛКОВСКОГО УЛИЦА'),
(2, 'НОВАЯ УЛИЦА');
GO

INSERT INTO Disrepair (FailureCD, FailureName)
VALUES 
(1, 'Засорилась водогрейная колонка'),
(2, 'Не горит АГВ'),
(3, 'Течет из водогрейной колонки'),
(4, 'Неисправна печная горелка'),
(5, 'Неисправен газовый счетчик'),
(6, 'Плохое поступление газа на горелку плиты'),
(7, 'Туго поворачивается пробка крана плиты'),
(8, 'При закрытии краника горелка плиты не гаснет'),
(12, 'Неизвестна');
GO

INSERT INTO Executor (ExecutorCD, FIO)
VALUES 
(1, 'Стародубцев Е. М.'),
(2, 'Булгаков Т. И.'),
(3, 'Шубин В. Г.'),
(4, 'Шлюков М. К.'),
(5, 'Школьников С. М.'),
(6, 'Степанов А. В.');
GO

DBCC CHECKIDENT('Unit', RESEED, 1)
INSERT INTO Unit VALUES 
('Гкал'),
('кВт*ч'),
('м3'),
('м2')
GO

DBCC CHECKIDENT('ReceptionPoint', RESEED, 1)
INSERT INTO ReceptionPoint VALUES 
('Касса'),
('Банк'),
('Терминал'),
('ТСЖ')
GO


INSERT INTO Abonent (AccountCD, FIO, StreetCD, HouseNo, FlatNo, Phone, Сorpus, District, CountPerson, SizeFlat)
VALUES 
('005488','Аксенов С. А.',3,4,1,'556893',4,'Советский р-н',4,60),
('115705','Мищенко Е. В.',3,1,82,'769975',3,'Советский р-н',3,54),
('015527','Конюхов В. С.',3,1,65,'761699',5,'Советский р-н',5,52.3),
('443690','Тулупова М. И.',7,5,1,'214833',3,'Железнодорожный р-н',3,55),
('136159','Свирина З. А.',7,39,1,NULL,7,'Железнодорожный р-н',4,46),
('443069','Стародубцев Е. В.',4,51,55,'683014',9,'Железнодорожный р-н',2,57.1),
('136160','Шмаков С. В.',4,9,15,NULL,8,'Железнодорожный р-н',4,43.50),
('126112','Маркова В. П.',4,7,11,'683301',2,'Железнодорожный р-н',4,65.50),
('136169','Денисова Е. К.',4,7,13,'680305',3,'Железнодорожный р-н',2,55.1),
('080613','Лукашина Р. М.',8,35,11,'254417',5,'Московский р-н',3,54.7),
('080047','Шубина Т. П.',8,39,36,'257842',3,'Московский р-н',2,55.1),
('080270','Тимошкина Н. Г.',6,35,6,'321002',3,'Железнодорожный р-н',2,55.1)
GO


INSERT INTO Services (ServiceCD, ServiceName, UnitsCD)
VALUES 
(1, 'Газоснабжение',3),
(2, 'Электроснабжение',2),
(3, 'Теплоснабжение',1),
(4, 'Водоснабжение',3),

(5,'Горячее водоснабжение',3),
(6, 'Холодное водоснабжение',3),
(7, 'Капитальный ремонт',4),
(8, 'Коммунальные услуги на общедомовые нужды',3),
(9, 'Обращение с ТКО',3),
(10, 'Водоотведение',3)
GO

DBCC CHECKIDENT('Mode', RESEED, 1)
INSERT INTO Mode VALUES 
('Многоквартирные и жилые дома со стенами из камня, кирпича',0.0388,3),
('Многоквартирные и жилые дома со стенами из панелей, блоков',0.0376,3),


('Жилые дома, с централизованными водопроводом, канализацией, горячим водоснабжением, оборудованные ваннами, унитазами (закрытый водоразбор ГВС)',3.23,5),
('Жилые дома, с централизованными водопроводом, канализацией, горячим водоснабжением, оборудованные ваннами, унитазами (открытый водоразбор ГВС)',2.7,5),
('Жилые дома, с централизованными водопроводом, канализацией, горячим водоснабжением, оборудованные душами, унитазами (закрытый водоразбор ГВС)',2.85,5),

('Многоквартирные и жилые дома со стенами из смешанных и других материалов (в т.ч. щитовые, засыпные)',0.0485,3),

('Жилые дома, с централизованными водопроводом, канализацией, горячим водоснабжением, оборудованные ваннами, унитазами (закрытый водоразбор ГВС)',4.29,6),
('Жилые дома, с централизованными водопроводом, канализацией, горячим водоснабжением, оборудованные ваннами, унитазами (открытый водоразбор ГВС)',4.82,6),
('Жилые дома, с централизованными водопроводом, канализацией, горячим водоснабжением, оборудованные душами, унитазами (открытый водоразбор ГВС)',4.44,6),
('Жилые дома, с централизованными водопроводом, канализацией, горячим водоснабжением, оборудованные душами общего пользования, унитазами (закрытый водоразбор ГВС)',3.97,6),

('Жилые дома, с централизованными водопроводом, канализацией, горячим водоснабжением, оборудованные ваннами, унитазами',7.52,10),
('Жилые дома, с централизованными водопроводом, канализацией, горячим водоснабжением, оборудованные душами, унитазами',6.82,10),

('Коммунальная услуга по холодному водоснабжению на общедомовые нужды (кроме МКД с централизованным ХВС, водонагревателями, водоотведением, этажностью 10-16, более 16)',0.03,8),
('Коммунальная услуга по холодному водоснабжению на общедомовые нужды для МКД с централизованным ХВС, водонагревателями, водоотведением, этажностью 10-16, более 16',0.02,8),

('Население, проживающее в городах, поселках городского типа',1,2),
('Население, проживающее в городских населенных пунктах, в домах, оборудованных в установленном порядке стационарными электроплитами и (или) электроотопительными установками',1,2),
('Население, проживающее в сельских населенных пунктах',1,2),

('Многоквартиные дома',2.28,9),
('Индивидуальные жилые дома',2.31,9),

('Жилые дома',1,7),

('Газовая плита при наличии центрального отопления и горячего водоснабжения',10,1),
('Газовая плита при отсутствии газового водонагревателя и центрального горячего водоснабжения',16.5,1),

('Многоквартирные и жилые дома со стенами из дерева',0.0347,3),
('Газовый водонагреватель',15,1),
('Жилые дома, с централизованными водопроводом, канализацией, горячим водоснабжением, оборудованные душами, унитазами (открытый водоразбор ГВС)',8,5),
('Жилые дома, с централизованными водопроводом, канализацией, горячим водоснабжением, оборудованные душами общего пользования, унитазами (закрытый водоразбор ГВС))',2.85,5),
('Жилые дома, с централизованными водопроводом, канализацией, горячим водоснабжением, оборудованные душами общего пользования, унитазами (открытый водоразбор ГВС))',2.38,5),
('Жилые дома, с централизованными водопроводом, канализацией, горячим водоснабжением, оборудованные душами, унитазами (закрытый водоразбор ГВС)',3.97,6),

('Коммунальная услуга по горячему водоснабжению на общедомовые нужд',0.03,8),

('Жилые дома, с централизованными водопроводом, канализацией, горячим водоснабжением, оборудованные душами общего пользования, унитазам',6.82,10),
('Жилые дома, с централизованными водопроводом, канализацией, горячим водоснабжением, оборудованные унитазами',3.82,10)
GO


DBCC CHECKIDENT('AbonentMode', RESEED, 1)
INSERT INTO AbonentMode VALUES 
('005488',2,0),
('005488',3,1),
('005488',7,1),
('005488',11,0),
('005488',13,0),
('005488',15,1),
('005488',18,0),
('005488',20,0),
('005488',21,1),

('015527',1,0),
('015527',4,1),
('015527',8,0),
('015527',11,0),
('015527',13,0),
('015527',15,1),
('015527',18,0),
('015527',20,0),
('015527',21,0),

('443069',6,0),
('443069',5,1),
('443069',28,1),
('443069',12,0),
('443069',13,0),
('443069',15,1),
('443069',18,0),
('443069',20,0),
('443069',21,0),

('080047',6,0),
('080047',5,1),
('080047',28,1),
('080047',12,0),
('080047',13,0),
('080047',15,1),
('080047',18,0),
('080047',20,0),
('080047',21,0),

('080270',2,0),
('080270',3,1),
('080270',7,1),
('080270',11,0),
('080270',13,0),
('080270',15,1),
('080270',18,0),
('080270',20,0),
('080270',21,1),

('136169',23,0),
('136169',4,1),
('136169',8,0),
('136169',11,0),
('136169',13,0),
('136169',17,1),
('136169',19,0),
('136169',20,0),
('136169',21,0),

('115705',1,0),
('115705',4,1),
('115705',8,0),
('115705',11,0),
('115705',13,0),
('115705',15,1),
('115705',18,0),
('115705',20,0),
('115705',21,0),

('126112',2,0),
('126112',3,1),
('126112',7,1),
('126112',11,0),
('126112',13,0),
('126112',15,1),
('126112',18,0),
('126112',20,0),
('126112',21,1),

('136159',6,0),
('136159',5,1),
('136159',28,1),
('136159',12,0),
('136159',13,0),
('136159',15,1),
('136159',18,0),
('136159',20,0),
('136159',21,0),

('136160',23,0),
('136160',4,1),
('136160',8,0),
('136160',11,0),
('136160',13,0),
('136160',17,1),
('136160',19,0),
('136160',20,0),
('136160',21,0),

('443690',6,0),
('443690',5,1),
('443690',28,1),
('443690',12,0),
('443690',13,0),
('443690',15,1),
('443690',18,0),
('443690',20,0),
('443690',21,0),

('080613',23,0),
('080613',4,1),
('080613',8,0),
('080613',11,0),
('080613',13,0),
('080613',17,1),
('080613',19,0),
('080613',20,0),
('080613',21,0)
GO


INSERT INTO NachislSumma (NachislFactCD, NachType, AbonentModeСD, NachislSum, NachislMonth, NachislYear, CountResources)
VALUES
(19, 'фактический', 6, 58.7, 12, 2019, 11),
(2, 'фактический', 6, 46, 12, 2018, 11),
(3, 'фактический', 6, 56, 4, 2021, 11),
(4, 'фактический', 60, 40, 1, 2018, 11),
(5, 'фактический', 60, 250, 9, 2019, 11),
(13, 'фактический', 87, 20, 5, 2019, 11),
(1, 'фактический', 87, 56, 1, 2021, 11),
(15, 'фактический', 51, 20, 5, 2019, 11),
(7, 'фактический', 33, 80, 10, 2020, 11),
(8, 'фактический', 33, 80, 10, 2019, 11),
(9, 'фактический', 42, 46, 12, 2019, 11),
(10, 'фактический', 105, 56, 6, 2019, 11),
(11, 'фактический', 60, 250, 9, 2018, 11),
(12, 'фактический', 60, 58.7, 8, 2019, 11),
(16, 'фактический', 51, 58.7, 11, 2019, 11),
(17, 'фактический', 24, 80, 9, 2019, 11),
(18, 'фактический', 24, 38.5, 8, 2019, 11),
(6, 'нормативный', 90, 18.3, 1, 2020, 11),
(20, 'нормативный', 18, 28.32, 7, 2020, 11),
(21, 'нормативный', 36, 19.56, 3, 2020, 11),
(22, 'нормативный', 108, 10.6, 9, 2020, 11),
(23, 'нормативный', 27, 38.28, 12, 2020, 11),
(24, 'нормативный', 18, 38.32, 4, 2021, 11),
(25, 'нормативный', 63, 37.15, 10, 2021, 11),
(26, 'нормативный', 108, 12.6, 8, 2018, 11),
(27, 'нормативный', 54, 25.32, 1, 2021, 11),
(28, 'фактический', 45, 57.1, 2, 2020, 11),
(29, 'нормативный', 81, 8.3, 8, 2021, 11),
(30, 'фактический', 9, 62.13, 4, 2018, 11),
(31, 'нормативный', 63, 37.8, 5, 2019, 11),
(32, 'нормативный', 99, 17.8, 6, 2020, 11),
(33, 'нормативный', 36, 22.56, 5, 2021, 11),
(34, 'фактический', 72, 15.3, 8, 2018, 11),
(35, 'нормативный', 36, 32.56, 9, 2019, 11),
(36, 'нормативный', 108, 12.6, 4, 2020, 11),
(37, 'нормативный', 63, 37.15, 11, 2021, 11),
(38, 'фактический', 45, 58.1, 12, 2018, 11),
(39, 'нормативный', 54, 28.32, 1, 2019, 11),
(40, 'нормативный', 18, 18.32, 2, 2020, 11),
(41, 'нормативный', 99, 21.67, 3, 2021, 11),
(42, 'нормативный', 108, 22.86, 4, 2018, 11),
(43, 'фактический', 45, 60.1, 5, 2019, 11),
(44, 'нормативный', 54, 28.32, 2, 2020, 11),
(45, 'нормативный', 36, 22.2, 7, 2021, 11),
(46, 'фактический', 72, 25.3, 8, 2019, 11),
(47, 'нормативный', 27, 38.32, 9, 2019, 11),
(48, 'нормативный', 81, 8.3, 10, 2020, 11),
(49, 'нормативный', 63, 37.15, 6, 2021, 11),
(50, 'нормативный', 90, 18.3, 12, 2018, 11),
(51, 'нормативный', 1, 279.8, 5, 2020, 11),
(52, 'нормативный', 1, 266.7, 2, 2021, 11),
(53, 'нормативный', 10, 343.36, 11, 2021, 11),
(54, 'нормативный', 28, 271.6, 2, 2021, 11),
(55, 'нормативный', 37, 278.25, 11, 2021, 11),
(56, 'нормативный', 100, 254.4, 7, 2019, 11),
(57, 'нормативный', 100, 258.8, 2, 2021, 11),
(58, 'нормативный', 100, 239.33, 5, 2021, 11),
(59, 'нормативный', 64, 179.9, 4, 2020, 11),
(60, 'нормативный', 73, 180.13, 9, 2021, 11),
(61, 'нормативный', 82, 238.8, 3, 2018, 11),
(62, 'нормативный', 82, 237.38, 3, 2019, 11),
(63, 'нормативный', 46, 349.19, 6, 2020, 11),
(64, 'нормативный', 46, 346.18, 7, 2020, 11),
(65, 'нормативный', 91, 290.33, 3, 2021, 11),
(66, 'фактический', 11, 580.1, 7, 2020, 11),
(67, 'нормативный', 12, 611.3, 10, 2021, 11),
(68, 'фактический', 38, 444.34, 3, 2019, 11),
(69, 'фактический', 39, 453.43, 6, 2020, 11),
(70, 'фактический', 38, 454.6, 4, 2021, 11),
(71, 'фактический', 56, 553.85, 1, 2020, 11),
(72, 'фактический', 66, 435.5, 6, 2020, 11),
(73, 'фактический', 75, 349.38, 4, 2019, 11),
(74, 'фактический', 74, 418.88, 6, 2020, 11),
(75, 'фактический', 47, 528.44, 10, 2021, 11),
(76, 'фактический', 20, 466.69, 5, 2020, 11),
(77, 'фактический', 21, 444.45, 10, 2021, 11),
(78, 'фактический', 93, 480.88, 8, 2019, 11),
(79, 'фактический', 92, 500.13, 9, 2020, 11);
GO


INSERT INTO PaySumma (PayFactCD, PayType, AbonentModeСD, PaySum, PayDate, PayMonth, PayYear, ReceptionPointCD)
VALUES 
(1, 'фактический', 6, 58.7, '2020-01-08', 12, 2019, 1),
(2, 'фактический', 6, 40, '2019-01-06', 12, 2018, 1),
(3, 'фактический', 6, 56, '2021-05-06', 4, 2021, 1),
(4, 'фактический', 60, 40, '2018-02-10', 1, 2018, 1),
(5, 'фактический', 60, 250, '2019-10-03', 9, 2019, 1),
(6, 'фактический', 87, 20, '2019-06-13', 5, 2019, 1),
(7, 'фактический', 87, 56, '2021-02-12', 1, 2021, 2),
(8, 'фактический', 51, 20, '2019-06-22', 5, 2021, 2),
(9, 'фактический', 33, 80, '2020-11-26', 10, 2020, 2),
(10, 'фактический', 33, 80, '2019-11-21', 10, 2019, 2),
(11, 'фактический', 42, 30, '2020-01-03', 12, 2019, 2),
(12, 'фактический', 105, 58.5, '2019-07-19', 6, 2019, 2),
(13, 'фактический', 60, 250, '2018-10-06', 9, 2018, 3),
(14, 'фактический', 60, 58.7, '2019-09-04', 8, 2019, 3),
(15, 'фактический', 51, 58.7, '2019-12-01', 11, 2019, 3),
(16, 'фактический', 24, 80, '2019-10-03', 9, 2019, 3),
(17, 'фактический', 24, 38.5, '2019-09-13', 8, 2019, 4),
(18, 'нормативный', 90, 18, '2020-02-05', 1, 2020, 2),
(19, 'нормативный', 18, 30, '2020-08-03', 7, 2020, 2),
(20, 'нормативный', 36, 19.56, '2020-04-02', 3, 2020, 2),
(21, 'нормативный', 108, 11, '2020-10-03', 9, 2020, 2),
(22, 'нормативный', 27, 38.28, '2021-02-04', 12, 2020, 2),
(23, 'нормативный', 18, 40, '2021-05-07', 4, 2021, 2),
(24, 'нормативный', 63, 37.15, '2021-11-04', 10, 2021, 4),
(25, 'нормативный', 108, 12, '2018-09-20', 8, 2018, 4),
(26, 'нормативный', 54, 25.32, '2021-02-03', 1, 2021, 4),
(27, 'фактический', 45, 60, '2020-03-05', 2, 2020, 4),
(28, 'нормативный', 81, 8.3, '2021-09-10', 8, 2021, 4),
(29, 'фактический', 9, 65, '2018-05-03', 4, 2018, 4),
(30, 'нормативный', 63, 37.8, '2019-07-12', 5, 2019, 4),
(31, 'нормативный', 99, 20, '2020-07-10', 6, 2020, 4),
(32, 'нормативный', 36, 22.56, '2021-06-25', 5, 2021, 1),
(33, 'фактический', 72, 15.3, '2018-09-08', 8, 2018, 1),
(34, 'нормативный', 36, 32.56, '2019-10-18', 9, 2019, 1),
(35, 'нормативный', 108, 12.6, '2020-05-22', 4, 2020, 1),
(36, 'нормативный', 63, 37.15, '2021-12-23', 11, 2021, 1),
(37, 'фактический', 45, 58.1, '2019-01-07', 12, 2018, 1),
(38, 'нормативный', 54, 28.32, '2019-02-08', 1, 2019, 1),
(39, 'нормативный', 18, 20, '2020-03-18', 2, 2020, 1),
(40, 'нормативный', 99, 19.47, '2021-04-10', 3, 2021, 1),
(41, 'нормативный', 108, 22.86, '2018-05-04', 4, 2018, 3),
(42, 'фактический', 45, 60, '2019-06-07', 5, 2019, 3),
(43, 'нормативный', 54, 28.32, '2020-03-05', 2, 2020, 3),
(44, 'нормативный', 36, 22.2, '2021-08-10', 7, 2021, 3),
(45, 'фактический', 72, 25.3, '2019-09-10', 8, 2019, 3),
(46, 'нормативный', 27, 38.32, '2019-10-09', 9, 2019, 3),
(47, 'нормативный', 81, 8.3, '2020-11-14', 10, 2020, 3),
(48, 'нормативный', 63, 37.15, '2021-08-10', 6, 2021, 3),
(49, 'нормативный', 90, 16, '2019-01-07', 12, 2018, 3),
(50, 'нормативный', 1, 280, '2020-06-10', 5, 2020, 4),
(51, 'нормативный', 1, 260, '2021-03-11', 2, 2021, 4),
(52, 'нормативный', 10, 345, '2021-12-15', 11, 2021, 4),
(53, 'нормативный', 28, 271.6, '2021-03-12', 2, 2021, 4),
(54, 'нормативный', 37, 278, '2021-12-06', 11, 2021, 4),
(55, 'нормативный', 100, 254.4, '2019-08-10', 7, 2019, 4),
(56, 'нормативный', 100, 258.8, '2021-03-8', 2, 2021, 4),
(57, 'нормативный', 100, 239.35, '2021-06-11', 5, 2021, 4),
(58, 'нормативный', 64, 179.9, '2020-05-01', 4, 2020, 4),
(59, 'нормативный', 73, 180.13, '2021-10-21', 9, 2021, 4),
(60, 'нормативный', 82, 240, '2018-04-04', 3, 2018, 1),
(61, 'нормативный', 82, 200, '2019-04-06', 3, 2019, 1),
(62, 'нормативный', 46, 349.19, '2020-07-14', 6, 2020, 1),
(63, 'нормативный', 46, 346.18, '2020-08-13', 7, 2020, 1),
(64, 'нормативный', 91, 295, '2021-04-09', 3, 2021, 1),
(65, 'фактический', 12, 580.1, '2020-08-08', 7, 2020, 1),
(66, 'фактический', 11, 611.3, '2021-11-03', 10, 2021, 1),
(67, 'фактический', 38, 444.5, '2019-04-18', 3, 2019, 1),
(68, 'фактический', 39, 450, '2020-07-14', 6, 2020, 1),
(69, 'фактический', 38, 460, '2021-05-12', 4, 2021, 1),
(70, 'нормативный', 57, 553.85, '2020-02-02', 1, 2020, 2),
(71, 'фактический', 66, 435.5, '2020-07-12', 6, 2020, 2),
(72, 'фактический', 74, 349.38, '2019-05-18', 4, 2019, 2),
(73, 'фактический', 75, 420, '2020-07-09', 6, 2020, 2),
(74, 'нормативный', 48, 528.44, '2021-11-26', 10, 2021, 2),
(75, 'фактический', 20, 466.69, '2020-06-03', 5, 2020, 2),
(76, 'фактический', 21, 444.45, '2021-11-16', 10, 2021, 2),
(77, 'фактический', 93, 485, '2019-09-05', 8, 2019, 2);
GO


INSERT INTO Request (RequestCD, AccountCD, ExecutorCD, FailureCD, IncomingDate, ExecutionDate, Executed)
VALUES
(1, '005488', 1, 1, '2019-12-17', '2019-12-20', 1),
(2, '115705', 3, 1, '2019-08-07', '2019-08-12', 1),
(3, '015527', 1, 12, '2020-02-28', '2020-03-08', 0),
(5, '080270', 4, 1, '2019-12-31', NULL, 0),
(6, '080613', 1, 6, '2019-06-16', '2019-06-24', 1),
(7, '080047', 3, 2, '2020-10-20', '2020-10-24', 1),
(9, '136169', 2, 1, '2019-11-06', '2019-11-08', 1),
(10, '136159', 3, 12, '2019-04-01', '2019-04-03', 0),
(11, '136160', 1, 6, '2021-01-12', '2021-01-12', 1),
(12, '443069', 5, 2, '2019-08-08', '2019-08-10', 1),
(13, '005488', 5, 8, '2018-09-04', '2018-12-05', 1),
(14, '005488', 4, 6, '2021-04-04', '2021-04-13', 1),
(15, '115705', 4, 5, '2018-09-20', '2018-09-23', 1),
(16, '115705', NULL, 3, '2019-12-28', NULL, 0),
(17, '115705', 1, 5, '2019-08-15', '2019-09-06', 1),
(18, '115705', 2, 3, '2020-12-28', '2021-01-04', 1),
(19, '080270', 4, 8, '2019-12-17', '2019-12-27', 1),
(20, '080047', 3, 2, '2019-10-11', '2019-10-11', 1),
(21, '443069', 1, 2, '2019-09-13', '2019-09-14', 1),
(22, '136160', 1, 7, '2019-05-18', '2019-05-25', 1),
(23, '136169', 5, 7, '2019-05-07', '2019-05-08', 1);
GO


DBCC CHECKIDENT('Price', RESEED, 1)
INSERT INTO Price VALUES
(2414.62,1),
(2414.62,2),
(184.35,3),
(184.35,4),
(172.27,5),
(2414.62,6),
(28.21,7),
(28.21,8),
(28.21,9),
(28.21,10),
(32.84,11),
(32.84,12),
(28.21,13),
(28.21,14),
(5.08,15),
(3.56,16),
(3.56,17),
(95.94,18),
(97.20,19),
(11.65,20),
(73.17,21),
(120.7305,22),
(2414.62,23),
(109.755,24),
(178.31,25),
(227.88,26),
(227.88,27),
(178.31,28),
(190.38,29),
(32.84,30),
(32.84,31)
GO

DBCC CHECKIDENT('Remains', RESEED, 1)
INSERT INTO Remains VALUES 
('005488',1,9,2021,0),
('115705',1,9,2021,0),
('115705',3,9,2021,0),
('136159',3,9,2021,0),
('080613',3,9,2021,0),
('136159',1,9,2021,0),
('443069',3,9,2021,0),
('080047',3,9,2021,0),
('005488',3,9,2021,0),
('126112',3,10,2021,0),
('136159',3,10,2021,0),
('126112',3,8,2021,0),
('115705',3,10,2021,0),
('005488',1,10,2021,0),
('115705',1,10,2021,0),
('080613',3,10,2021,0),
('126112',1,8,2021,0),
('136159',1,10,2021,0),
('080613',1,8,2021,0),
('005488',4,10,2021,0),
('443069',3,10,2021,0),
('005488',1,11,2021,0),
('005488',4,8,2021,0),
('115705',1,11,2021,0),
('115705',3,11,2021,0),
('136159',3,11,2021,0),
('080613',3,11,2021,0),
('136159',1,11,2021,0),
('443069',3,11,2021,0),
('005488',1,8,2021,0),
('136159',3,8,2021,0),
('080613',3,8,2021,0)
GO