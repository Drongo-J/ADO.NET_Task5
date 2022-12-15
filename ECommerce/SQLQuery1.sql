create database ECommerceDb

use ECommerceDb


create table Products(
Id int primary key identity(1,1) not null,
[Name] nvarchar(30) not null,
[Description] nvarchar(30),
Price money not null default(0),
Discount float not null default(0),
Quantity int not null default(10)
)

insert into Products([Name],[Description],[Price],[Discount],[Quantity])
values('Samsung S21+','Normal Telefon',2555,5,100)


create table Customers(
Id int primary key identity(1,1) not null,
[Username] nvarchar(30) not null
)
select * from Customers


insert into Customers([Username])
values('elvin123'),('john123')

create table Orders(
Id int primary key identity(1,1) not null,	
[Date] datetime2 not null default(getdate()),
Amount int not null default(1),
ProductId int foreign key references Products(Id) not null,
CustomerId int foreign key references Customers(Id) not null,
)


create table Admins(
Id int primary key identity(1,1) not null,
[Username] nvarchar(30) not null,
[Password] nvarchar(30) not null
)

insert into Admins([Username],[Password])
values('admin','admin')


SELECT * FROM Products