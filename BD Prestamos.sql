create database Prestamos
go

use Prestamos

go

create table Calculo (
numero int  identity (1,1) constraint  pk_calculo primary key ,
monto decimal(8,2),
tasa_int decimal (8,2),
plazo int,
tipo_moneda int,
tipo_cambio decimal (8,2))

create table Moneda (
tipo_moneda int constraint pk_moneda primary key,
descripcion nvarchar(40))

alter table Calculo 
add constraint fk_calculo_moneda foreign key (tipo_moneda) references moneda(tipo_moneda) 

go

create procedure inserta_calculo 
@monto decimal(8,2),
@tasa_int decimal (8,2),
@plazo int,
@tipo_moneda int,
@tipo_cambio decimal (8,2)
as
begin

	insert into Calculo (monto,tasa_int,plazo,tipo_moneda,tipo_cambio)
	values (@monto,@tasa_int,@plazo,@tipo_moneda,@tipo_cambio)


end
go


CREATE procedure Consulta_Usuario
as
begin
	select u.nom_usuario as "Nombre de Usuario" ,u.nombre as "Nombre", u.apellido1 as "Apellido1", apellido2 as "Apellido2",p.descripcion as "Perfil"
	from Usuario U inner join Perfil P ON u.cod_perfil = p.codigo


end

Go

CREATE procedure Inserta_Usuario @nom_usuario nvarchar(30),@contrasena nvarchar(30),@nombre nvarchar(40),
@apellido1 nvarchar (40),@apellido2 nvarchar(40),@cod_perfil int
as 
begin

	insert into Usuario (nom_usuario,contrasena,nombre,apellido1,apellido2,cod_perfil)
	values
	(@nom_usuario,@contrasena,@nombre,@apellido1,@apellido2,@cod_perfil)

end


insert into Moneda (tipo_moneda,descripcion) values (1,'Colones')
insert into Moneda (tipo_moneda,descripcion) values (2,'Dolares')