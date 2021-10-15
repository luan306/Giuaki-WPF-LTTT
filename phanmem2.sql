create database PhanmemQuanLydk
go

use PhanmemQuanLydk
go
create table Customer
(
	Id int primary key,
	Name nvarchar(100),
	Phone nvarchar(20),
	soluong nvarchar(20) ,
	ghichu nvarchar (200),
	DICHI nvarchar (200),
	chiphi nvarchar(100),
	NgayBatDau smalldatetime,
	NgayKetThuc smalldatetime
)
go
create table Unit
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max)
)
go
create table UserRole
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max)
)
go

insert into UserRole(DisplayName) values(N'Admin')
go
insert into UserRole(DisplayName) values(N'Nhân viên')
go

create table Users
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max),
	UserName nvarchar(100),
	Password nvarchar(max),
	IdRole int not null

	foreign key (IdRole) references UserRole(Id)
)
go
insert into Users(DisplayName, Username, Password, IdRole) values(N'Team', N'admin', N'db69fc039dcbd2962cb4d28f5891aae1', 1)
go
insert into Users(DisplayName, Username, Password, IdRole) values(N'Nhân viên', N'staff', N'978aae9bb6bee8fb75de3e4830a1be46', 2)
go

create table Input
(
	Id nvarchar(128) primary key,
	DateInput DateTime
)
go





