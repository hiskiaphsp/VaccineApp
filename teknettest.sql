create database Vaccine
use Vaccine
CREATE TABLE users (
    id INT IDENTITY(1,1) PRIMARY KEY,
    email VARCHAR(255),
    username VARCHAR(255),
    password VARCHAR(255),
    roles VARCHAR(255),
    created_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE hospitals (
    id INT IDENTITY(1,1) PRIMARY KEY,
    hospital_name VARCHAR(255),
    address VARCHAR(255),
    city VARCHAR(255),
    province VARCHAR(255),
    country VARCHAR(255),
    phone_number VARCHAR(255),
    email VARCHAR(255),
);

CREATE TABLE vaccines (
    id INT IDENTITY(1,1) PRIMARY KEY,
    vaccine_name VARCHAR(255),
    vaccine_type VARCHAR(255),
    dose_count FLOAT,
    dose VARCHAR(255),
    price float
);

CREATE TABLE communities (
    id INT IDENTITY(1,1) PRIMARY KEY,
	nik VARCHAR(30),
    name VARCHAR(255),
    date_of_birth DATE,
    address VARCHAR(255),
    city VARCHAR(255),
    province VARCHAR(255),
    country VARCHAR(255),
    phone_number VARCHAR(255),
    email VARCHAR(255)
);

CREATE TABLE vaccine_records (
    id INT IDENTITY(1,1) PRIMARY KEY,
    community_id INT,
    hospital_id INT,
    vaccine_id INT,
    vaccine_date DATE,
    dose_number INT,
    administration_type VARCHAR(255),
    nurse_name VARCHAR(255),
);

CREATE TABLE producers (
    id INT IDENTITY(1,1) PRIMARY KEY,
    producer_name VARCHAR(255),
    address VARCHAR(255),
    city VARCHAR(255),
    province VARCHAR(255),
    country VARCHAR(255),
    phone_number VARCHAR(255)
);

CREATE TABLE vaccine_producers (
    id INT IDENTITY(1,1) PRIMARY KEY,
    producer_id INT,
    vaccine_id INT,
);

USE [Vaccine]
GO
SET IDENTITY_INSERT [dbo].[communities] ON 

INSERT [dbo].[communities] ([id], [nik], [name], [date_of_birth], [address], [city], [province], [country], [phone_number], [email]) VALUES (1, N'1234567890', N'John Doe', CAST(N'2023-06-02' AS Date), N'123 Main Street', N'New York', N'New York', N'USA', N'1234567890', N'johndoe@example.com')
INSERT [dbo].[communities] ([id], [nik], [name], [date_of_birth], [address], [city], [province], [country], [phone_number], [email]) VALUES (3, N'9876543210', N'David Johnson', CAST(N'1978-07-25' AS Date), N'789 Oak Avenue', N'Chicago', N'Illinois', N'USA', N'4567890123', N'davidjohnson@example.com')
INSERT [dbo].[communities] ([id], [nik], [name], [date_of_birth], [address], [city], [province], [country], [phone_number], [email]) VALUES (4, N'5432109876', N'Emily Davis', CAST(N'1995-03-02' AS Date), N'321 Pine Road', N'Houston', N'Texas', N'USA', N'7890123456', N'emilydavis@example.com')
INSERT [dbo].[communities] ([id], [nik], [name], [date_of_birth], [address], [city], [province], [country], [phone_number], [email]) VALUES (5, N'2345678901', N'Michael Brown', CAST(N'1982-09-17' AS Date), N'654 Cedar Lane', N'Phoenix', N'Arizona', N'USA', N'9012345678', N'michaelbrown@example.com')
INSERT [dbo].[communities] ([id], [nik], [name], [date_of_birth], [address], [city], [province], [country], [phone_number], [email]) VALUES (7, N'3456789012', N'Oliver Martinez', CAST(N'1998-08-05' AS Date), N'567 Walnut Street', N'San Antonio', N'Texas', N'USA', N'8901234567', N'olivermartinez@example.com')
INSERT [dbo].[communities] ([id], [nik], [name], [date_of_birth], [address], [city], [province], [country], [phone_number], [email]) VALUES (8, N'0123456789', N'Isabella Taylor', CAST(N'1989-06-12' AS Date), N'890 Birch Road', N'San Diego', N'California', N'USA', N'2345678901', N'isabellataylor@example.com')
INSERT [dbo].[communities] ([id], [nik], [name], [date_of_birth], [address], [city], [province], [country], [phone_number], [email]) VALUES (9, N'9012345678', N'William Anderson', CAST(N'1975-04-07' AS Date), N'123 Spruce Avenue', N'Dallas', N'Texas', N'USA', N'6789012345', N'williamanderson@example.com')
INSERT [dbo].[communities] ([id], [nik], [name], [date_of_birth], [address], [city], [province], [country], [phone_number], [email]) VALUES (10, N'4567890123', N'Mia Clark', CAST(N'1991-02-18' AS Date), N'456 Oak Lane', N'San Francisco', N'California', N'USA', N'0123456789', N'miaclark@example.com')
INSERT [dbo].[communities] ([id], [nik], [name], [date_of_birth], [address], [city], [province], [country], [phone_number], [email]) VALUES (11, N'3671121707030004', N'Hiskia Parhusip', CAST(N'2023-06-04' AS Date), N'Kayu Gede 1 Street', N'South Tangerang', N'Banten', N'Indonesia', N'0808898989', N'hiskiabangga@gmail.com')
SET IDENTITY_INSERT [dbo].[communities] OFF
SET IDENTITY_INSERT [dbo].[hospitals] ON 

INSERT [dbo].[hospitals] ([id], [hospital_name], [address], [city], [province], [country], [phone_number], [email]) VALUES (1, N'Hospital A', N'Address A', N'City A', N'Province A', N'Country A', N'1234567890', N'hospitalA@example.com')
INSERT [dbo].[hospitals] ([id], [hospital_name], [address], [city], [province], [country], [phone_number], [email]) VALUES (2, N'Hospital B', N'Address B', N'City B', N'Province B', N'Country B', N'2345678901', N'hospitalB@example.com')
INSERT [dbo].[hospitals] ([id], [hospital_name], [address], [city], [province], [country], [phone_number], [email]) VALUES (3, N'Hospital C', N'Address C', N'City C', N'Province C', N'Country C', N'3456789012', N'hospitalC@example.com')
INSERT [dbo].[hospitals] ([id], [hospital_name], [address], [city], [province], [country], [phone_number], [email]) VALUES (4, N'Hospital D', N'Address D', N'City D', N'Province D', N'Country D', N'4567890123', N'hospitalD@example.com')
INSERT [dbo].[hospitals] ([id], [hospital_name], [address], [city], [province], [country], [phone_number], [email]) VALUES (6, N'Sari Asih', N'Kayu Gede 1 Street', N'South Tangerang', N'Banten', N'Indonesia', N'0808898989', N'sariasih@mail.com')
SET IDENTITY_INSERT [dbo].[hospitals] OFF
SET IDENTITY_INSERT [dbo].[producers] ON 

INSERT [dbo].[producers] ([id], [producer_name], [address], [city], [province], [country], [phone_number]) VALUES (1, N'Producer A', N'Address A', N'City A', N'Province A', N'Country A', N'1234567890')
INSERT [dbo].[producers] ([id], [producer_name], [address], [city], [province], [country], [phone_number]) VALUES (2, N'Producer B', N'Address B', N'City B', N'Province B', N'Country B', N'2345678901')
INSERT [dbo].[producers] ([id], [producer_name], [address], [city], [province], [country], [phone_number]) VALUES (3, N'Producer C', N'Address C', N'City C', N'Province C', N'Country C', N'3456789012')
INSERT [dbo].[producers] ([id], [producer_name], [address], [city], [province], [country], [phone_number]) VALUES (4, N'Producer D', N'Address D', N'City D', N'Province D', N'Country D', N'4567890123')
INSERT [dbo].[producers] ([id], [producer_name], [address], [city], [province], [country], [phone_number]) VALUES (5, N'Producer E', N'Address E', N'City E', N'Province E', N'Country E', N'5678901234')
SET IDENTITY_INSERT [dbo].[producers] OFF
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id], [email], [username], [password], [roles], [created_at]) VALUES (1, N'user1@example.com', N'user1', N'password1', N'Hospital', CAST(N'2023-06-01 06:49:19.190' AS DateTime))
INSERT [dbo].[users] ([id], [email], [username], [password], [roles], [created_at]) VALUES (2, N'user2@example.com', N'user2', N'password2', N'BPOM', CAST(N'2023-06-01 06:49:19.190' AS DateTime))
INSERT [dbo].[users] ([id], [email], [username], [password], [roles], [created_at]) VALUES (3, N'user3@example.com', N'user3', N'password3', N'Pemerintah', CAST(N'2023-06-01 06:49:19.190' AS DateTime))
INSERT [dbo].[users] ([id], [email], [username], [password], [roles], [created_at]) VALUES (4, N'user4@example.com', N'user4', N'password4', N'Producer', CAST(N'2023-06-01 06:49:19.190' AS DateTime))
SET IDENTITY_INSERT [dbo].[users] OFF
SET IDENTITY_INSERT [dbo].[vaccine_producers] ON 

INSERT [dbo].[vaccine_producers] ([id], [producer_id], [vaccine_id]) VALUES (1, 1, 1)
INSERT [dbo].[vaccine_producers] ([id], [producer_id], [vaccine_id]) VALUES (2, 2, 2)
INSERT [dbo].[vaccine_producers] ([id], [producer_id], [vaccine_id]) VALUES (3, 3, 3)
INSERT [dbo].[vaccine_producers] ([id], [producer_id], [vaccine_id]) VALUES (4, 4, 4)
INSERT [dbo].[vaccine_producers] ([id], [producer_id], [vaccine_id]) VALUES (5, 5, 5)
INSERT [dbo].[vaccine_producers] ([id], [producer_id], [vaccine_id]) VALUES (6, 1, 1)
INSERT [dbo].[vaccine_producers] ([id], [producer_id], [vaccine_id]) VALUES (7, 1, 2)
INSERT [dbo].[vaccine_producers] ([id], [producer_id], [vaccine_id]) VALUES (8, 2, 2)
INSERT [dbo].[vaccine_producers] ([id], [producer_id], [vaccine_id]) VALUES (9, 3, 3)
INSERT [dbo].[vaccine_producers] ([id], [producer_id], [vaccine_id]) VALUES (10, 4, 3)
SET IDENTITY_INSERT [dbo].[vaccine_producers] OFF
SET IDENTITY_INSERT [dbo].[vaccine_records] ON 

INSERT [dbo].[vaccine_records] ([id], [community_id], [hospital_id], [vaccine_id], [vaccine_date], [dose_number], [administration_type], [nurse_name]) VALUES (1, 1, 1, 1, CAST(N'2023-05-01' AS Date), 1, N'Intramuscular', N'Nurse B')
INSERT [dbo].[vaccine_records] ([id], [community_id], [hospital_id], [vaccine_id], [vaccine_date], [dose_number], [administration_type], [nurse_name]) VALUES (2, 2, 2, 1, CAST(N'2023-05-02' AS Date), 1, N'Intramuscular', N'Nurse B')
INSERT [dbo].[vaccine_records] ([id], [community_id], [hospital_id], [vaccine_id], [vaccine_date], [dose_number], [administration_type], [nurse_name]) VALUES (3, 3, 1, 2, CAST(N'2023-05-03' AS Date), 1, N'Intramuscular', N'Nurse C')
INSERT [dbo].[vaccine_records] ([id], [community_id], [hospital_id], [vaccine_id], [vaccine_date], [dose_number], [administration_type], [nurse_name]) VALUES (4, 4, 3, 2, CAST(N'2023-05-04' AS Date), 1, N'Intramuscular', N'Nurse D')
INSERT [dbo].[vaccine_records] ([id], [community_id], [hospital_id], [vaccine_id], [vaccine_date], [dose_number], [administration_type], [nurse_name]) VALUES (5, 5, 2, 3, CAST(N'2023-05-05' AS Date), 1, N'Intramuscular', N'Nurse E')
INSERT [dbo].[vaccine_records] ([id], [community_id], [hospital_id], [vaccine_id], [vaccine_date], [dose_number], [administration_type], [nurse_name]) VALUES (6, 1, 1, 2, CAST(N'2023-06-02' AS Date), 10, N'BPJS', N'Test')
SET IDENTITY_INSERT [dbo].[vaccine_records] OFF
SET IDENTITY_INSERT [dbo].[vaccines] ON 

INSERT [dbo].[vaccines] ([id], [vaccine_name], [vaccine_type], [dose_count], [dose], [price]) VALUES (1, N'Vaccine Z', N'Type A', 2, N'First Dose', 10.5)
INSERT [dbo].[vaccines] ([id], [vaccine_name], [vaccine_type], [dose_count], [dose], [price]) VALUES (2, N'Vaccine B', N'Type B', 2, N'Second Dose', 15.75)
INSERT [dbo].[vaccines] ([id], [vaccine_name], [vaccine_type], [dose_count], [dose], [price]) VALUES (3, N'Vaccine C', N'Type C', 1, N'Single Dose', 20)
INSERT [dbo].[vaccines] ([id], [vaccine_name], [vaccine_type], [dose_count], [dose], [price]) VALUES (4, N'Vaccine D', N'Type D', 3, N'First Dose', 25)
INSERT [dbo].[vaccines] ([id], [vaccine_name], [vaccine_type], [dose_count], [dose], [price]) VALUES (5, N'Vaccine E', N'Type E', 2, N'Second Dose', 30.5)
INSERT [dbo].[vaccines] ([id], [vaccine_name], [vaccine_type], [dose_count], [dose], [price]) VALUES (6, N'Vaccine A', N'Type A', 2, N'First Dose', 10.5)
INSERT [dbo].[vaccines] ([id], [vaccine_name], [vaccine_type], [dose_count], [dose], [price]) VALUES (7, N'Vaccine B', N'Type B', 2, N'Second Dose', 15.75)
INSERT [dbo].[vaccines] ([id], [vaccine_name], [vaccine_type], [dose_count], [dose], [price]) VALUES (8, N'Vaccine C', N'Type C', 1, N'Single Dose', 20)
INSERT [dbo].[vaccines] ([id], [vaccine_name], [vaccine_type], [dose_count], [dose], [price]) VALUES (9, N'Vaccine D', N'Type D', 3, N'First Dose', 25)
INSERT [dbo].[vaccines] ([id], [vaccine_name], [vaccine_type], [dose_count], [dose], [price]) VALUES (10, N'Vaccine E', N'Type E', 2, N'Second Dose', 30.5)
INSERT [dbo].[vaccines] ([id], [vaccine_name], [vaccine_type], [dose_count], [dose], [price]) VALUES (12, N'Sinovac', N'B', 1, N'1', 20000)
INSERT [dbo].[vaccines] ([id], [vaccine_name], [vaccine_type], [dose_count], [dose], [price]) VALUES (13, N'Sinovac', N'B', 1, N'1', 50000)
INSERT [dbo].[vaccines] ([id], [vaccine_name], [vaccine_type], [dose_count], [dose], [price]) VALUES (14, N'Sinovac', N'B', 1, N'1', 15500)
INSERT [dbo].[vaccines] ([id], [vaccine_name], [vaccine_type], [dose_count], [dose], [price]) VALUES (15, N'Sinovac', N'B', 1, N'1', 15500)
INSERT [dbo].[vaccines] ([id], [vaccine_name], [vaccine_type], [dose_count], [dose], [price]) VALUES (16, N'Sinovac', N'B', 1, N'1', 100000)
SET IDENTITY_INSERT [dbo].[vaccines] OFF
