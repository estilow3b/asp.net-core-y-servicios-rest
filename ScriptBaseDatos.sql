Go
Use master
Go
---------------CREACION DE BASE DE DATOS---------------
Go
------------VALIDACION DE EXISTENCIA DE BASE DE DATOS EMPRESA------------------
If Exists(Select Top 1 1 From sysdatabases Where Name='BD_Empresa')
	Begin
		Drop DataBase BD_Empresa
	End
Go
Go
Create DataBase BD_Empresa
Go

Go
Use BD_Empresa
Go
------------------CREACION DE TABLAS------------------
Go
------------VALIDACION DE EXISTENCIA DE TABLA EMPLEADO------------------
If Exists(Select Top 1 1 From INFORMATION_SCHEMA.TABLES Where TABLE_SCHEMA='dbo' and TABLE_NAME='Tb_Empleado')
	Begin
		Drop Table Tb_Empleado
	End
Go
------------CREACION DE TABLA EMPLEADO------------------
Go
Create Table Tb_Empleado
(
	Codi_Empleado				Int Primary Key Identity,
	Nombres_Empleado			Varchar(100),
	Apellidos_Empleado			Varchar(100),
	Direccion_Empleado			Varchar(200),
	Telefono_Empleado			Varchar(200),
	Email_Empleado				Varchar(200),
	FechaNacimiento_Empleado	DateTime,
	Sueldo_Empleado				Real,
	Activo						Bit
)
Go

------------CREACION DE PROCEDIMIENTOS ALMACENADOS------------------
-------------Listar Todos los Empleados----------------
Go
Create Procedure usp_Empleado_Listar
as
	Select 
		Codi_Empleado				,
		Nombres_Empleado			,
		Apellidos_Empleado			,
		Direccion_Empleado			,
		Telefono_Empleado			,
		Email_Empleado				,
		FechaNacimiento_Empleado	,
		Sueldo_Empleado				,
		Activo						
	From Tb_Empleado
Go

-------------Filtrar los Empleados----------------
Go
Create Procedure usp_Empleado_Filtrar
@Nombres_Empleado			Varchar(100),
@Apellidos_Empleado			Varchar(100)
as
	Select 
		Codi_Empleado				,
		Nombres_Empleado			,
		Apellidos_Empleado			,
		Direccion_Empleado			,
		Telefono_Empleado			,
		Email_Empleado				,
		FechaNacimiento_Empleado	,
		Sueldo_Empleado				,
		Activo						
	From Tb_Empleado
	Where Nombres_Empleado like '%'+ @Nombres_Empleado +'%'
	and Apellidos_Empleado like '%'+ @Apellidos_Empleado +'%'
Go

------------Registrar el Empleado------------------
Go
Create Procedure usp_Empleado_Registrar
@Nombres_Empleado			Varchar(100),
@Apellidos_Empleado			Varchar(100),
@Direccion_Empleado			Varchar(200),
@Telefono_Empleado			Varchar(200),
@Email_Empleado				Varchar(200),
@FechaNacimiento_Empleado	DateTime,
@Sueldo_Empleado			Real,
@Activo						Bit
As
	
	Insert Into Tb_Empleado
	(
		Nombres_Empleado			, 
		Apellidos_Empleado			, 
		Direccion_Empleado			,
		Telefono_Empleado			, 
		Email_Empleado				, 
		FechaNacimiento_Empleado	,
		Sueldo_Empleado				,  
		Activo						
	)
	Values
	(
		@Nombres_Empleado			, 
		@Apellidos_Empleado			, 
		@Direccion_Empleado			,
		@Telefono_Empleado			, 
		@Email_Empleado				, 
		@FechaNacimiento_Empleado	,
		@Sueldo_Empleado			,  
		@Activo							
	)
Go

------------Modificar el Empleado------------------
Go
Create Procedure usp_Empleado_Modificar
@Codi_Empleado				Int,
@Nombres_Empleado			Varchar(100),
@Apellidos_Empleado			Varchar(100),
@Direccion_Empleado			Varchar(200),
@Telefono_Empleado			Varchar(200),
@Email_Empleado				Varchar(200),
@FechaNacimiento_Empleado	DateTime,
@Sueldo_Empleado			Real,
@Activo						Bit
As
	
	Update Tb_Empleado
	Set
		Nombres_Empleado			= @Nombres_Empleado			, 
		Apellidos_Empleado			= @Apellidos_Empleado		, 
		Direccion_Empleado			= @Direccion_Empleado		,
		Telefono_Empleado			= @Telefono_Empleado		, 
		Email_Empleado				= @Email_Empleado			, 
		FechaNacimiento_Empleado	= @FechaNacimiento_Empleado	,
		Sueldo_Empleado				= @Sueldo_Empleado			, 
		Activo						= @Activo
	Where Codi_Empleado = @Codi_Empleado
Go

------------Eliminar el Empleado------------------
Go
Create Procedure usp_Empleado_Eliminar
@Codi_Empleado				Int
As
	
	Delete From Tb_Empleado
	Where Codi_Empleado = @Codi_Empleado
Go
