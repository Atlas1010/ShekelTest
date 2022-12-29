insert into Customers
values('Sarah Atlas','Michashwily','0533199240')
insert into Customers
values('Rachel Atlas','Yechezkel','0527187654')
insert into Customers
values('Giti Horvitz','Harav Grosbard','0533199345')
insert into Customers
values('Sheini Urbach','Yosef','0533186219')
insert into Customers
values('Sari Atlas','Yechezkel','035798765')
insert into Customers
values('Mati Atlas','Yechezkel','035798765')
insert into Customers
values('Leah Horvitz','Harav Grosbard','0533199345')


insert into Groups
values('IT')
insert into Groups
values('HR')
insert into Groups
values('Developers')
insert into Groups
values('Junior Developers')
insert into Groups
values('Bookkeeper')
insert into Groups
values('QA')


insert into Factories
values(2,'Hafenix',1)
insert into Factories
values(2,'Hafenix',4)
insert into Factories
values (1,'Shekel',1)
insert into Factories
values (1,'Shekel',2)
insert into Factories
values (1,'Shekel',3)


insert into FactoriesToCustomer
values(1,1,1)
insert into FactoriesToCustomer
values(1,1,2)
insert into FactoriesToCustomer
values(1,2,3)
insert into FactoriesToCustomer
values(4,2,4)
insert into FactoriesToCustomer
values(1,2,5)
insert into FactoriesToCustomer
values(1,1,6)







-----------AddCustomer
USE [shekel]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[AddNewCustomer]
@name [nvarchar](max),
@address [nvarchar](max),
@phone [nvarchar](max)
AS
BEGIN
	INSERT INTO dbo.Customers
		(
			name,
			address,
			phone
		)
    VALUES
		(
			@name,
			@address,
			@phone
		)
END
GO

----------GetCustomers
USE [shekel]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[GetCustomerList]
AS
BEGIN
select * from Customers
END
GO



-----------GetFactoriesCustomer
USE [shekel]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[GetFactoriesToCustomerList]
AS
BEGIN
select * from FactoriesToCustomer
END
GO



-------------AddNewCustomerToCustomersAndgroupsFactory
USE [Shekel]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[AddParam]
@name [nvarchar](max),
@address [nvarchar](max),
@phone [nvarchar](max),
@groupCode [nvarchar](max),
@FactoryCode [nvarchar](max)
AS
BEGIN
	INSERT INTO dbo.Customers
		(
			name,
			address,
			phone
		)
    VALUES
		(
			@name,
			@address,
			@phone
		)
		insert into FactoriesToCustomer(groupCode,factoryCode,customerId)
		values(@groupCode,@FactoryCode,
		(select customerId from Customers 
		where name=@name
		and address=@address
		and phone=@phone)
		)
END





------------GetGroupsCustomer
USE [Shekel]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[GetParam]
AS
BEGIN
	select  G.groupKod,G.groupName,FC.customerId from  Groups G
	INNER JOIN FactoriesToCustomer FC
	ON G.groupKod=FC.groupCode
END



EXEC [dbo].[GetParam];
