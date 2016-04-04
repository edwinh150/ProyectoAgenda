Create database AgenciaDb4

use AgenciaDb4

create table TipoUsuarios(TipoUsuarioId int identity(1,1) primary key,
Descripcion varchar(50)
);

select * from Usuarios


create table Usuarios(UsuarioId int identity(1,1) primary key,
NombreUsuario varchar(50),
Contrasena varchar(50),
Nombre varchar(50),
Apellido varchar(50),
Email varchar(30),
Telefono varchar(13),
FechaNacimiento datetime,
TipoUsuarioId int references TipoUsuarios(TipoUsuarioId)
);

create table Paises(PaisId int identity(1,1) primary key,
Descripcion varchar(30)
);

create table Ciudades(CiudadId int identity(1,1) primary key,
Descripcion varchar(30),
PaisId int references Paises(PaisId)
);

create table TipoDestinos(TipoDestinoId int primary key identity(1,1),
Descripcion varchar(30)
);

select * from TipoDestinos

create table Destinos(DestinoId int primary key identity(1,1),
Descripcion varchar(50),
CiudadId int references Ciudades(CiudadId),
TipoDestinoId int references TipoDestinos(TipoDestinoId)
);

create table TipoSolicitudes(TipoSolicitudId int identity(1,1) primary key,
Descripcion varchar(50)
);

select * from Solicitudes

select * from SolicitudDetalles

create table Solicitudes(SolicitudId int identity(1,1) primary key,
UsuarioId int references Usuarios(UsuarioId),
FechaCreacion datetime,
Asunto varchar(50)
);

create table SolicitudDetalles(SolicitudDetalleId int identity(1,1) primary key,
EleccionDestino bit,
SolicitudId int references Solicitudes(SolicitudId),
TipoSolicitudId int references TipoSolicitudes(TipoSolicitudId),
CompaniaId int references Companias(CompaniaId),
CategoriaId int references Categorias(CategoriaId),
Origen varchar(100),
Destino varchar(100),
FechaInicial datetime,
FechaFinal datetime,
CantidadPersona int,
CantidadNino int,
CantidadBebe int,
PrecioInicial float,
PrecioFinal float
);

select * from SolicitudDetalles
drop table SolicitudDetalles

--quieres mostrar las fechas? si y olle el origen y el destino no estan referenciado pero quiero mostrar el nombre del ciudad ya que dentro de ese varchar esta su id
-- ok pero eso lo quieres mostrar en el dri? si
-- entonce no es el id que hay que guardar sino el nombre del drownlist ohh ya no olvidalo ok por ahora estara asi
-- primera vez que veo una tabla detalle con muchos id de otras deja ver como es que se hacer espera... pence que era solicitudes que se relacionaba con las demas tu no viste todos los dropview de mi detalle si
-- jeje a la primera nitido man gracias almenos entendi algo del innerjoin ok dnd cual quier cosa me dice olle entonces cuando aparesca en el dropview como hago que se ve asi cuando lo agrego 
-- tu obtiene el text del drown list y lo guarda en vez de guardar el id. mira ahi yo lo busque eso lo hago con el innerjoin pero cuando agrego
-- si el origen es varchar o integer? varchar pero lo del origen es facil yo digo los demas como ej tiposilicitud ha que muestre la descripcion en vez del id?si
-- dendria que hacer doble trabajo ya que los datos que guardas son del grid y lo que guardas el el id no el text entonces tendrias que hacer
-- una lista de lo que en realidad se guardara en el detalle solo haci creo que se puede hacer puedo dejar la misma esta y hacer otro con string y que llene el gridview de la que son de string y la otra se guarda en el detalle. exacto tato gracias loco dnd bro
select sd.SolicitudDetalleId, sd.EleccionDestino,s.SolicitudId, ts.Descripcion, cp.Descripcion, ct.Descripcion, sd.Origen, sd.Destino, sd.FechaInicial, sd.FechaFinal,
		sd.cantidadPersona, sd.CantidadNino, sd.CantidadBebe, sd.PrecioInicial, sd.PrecioFinal from SolicitudDetalles sd inner join Solicitudes s on 
		sd.SolicitudId = s.SolicitudId inner join TipoSolicitudes ts on ts.TipoSolicitudId = sd.TipoSolicitudId inner join Companias cp on cp.CompaniaId = sd.CompaniaId
		inner join Categorias ct on ct.CategoriaId = sd.CategoriaId where s.SolicitudId = 63

		select * from Solicitudes where SolicitudId = 63
 
insert into SolicitudDetalles(EleccionDestino,SolicitudId,TipoSolicitudId,CompaniaId,CategoriaId,Origen,Destino,CantidadPersona,CantidadNino,CantidadBebe,PrecioInicial,PrecioFinal) values(0,22,1,1,1,1,1,1,2,0,200,300);

create table TipoCompanias(TipoCompaniaId int primary key identity(1,1),
Descripcion varchar(50)
);

create table TipoCategorias(TipoCategoriaId int identity(1,1) primary key,
Descripcion varchar(30)
);

create table Companias(CompaniaId int identity(1,1) primary key,
Descripcion varchar(50),
Email varchar(30),
TipoCompaniaId int references TipoCompanias(TipoCompaniaId)
);

create table Categorias(CategoriaId int identity(1,1) primary key,
Descripcion varchar(30),
TipoCategoriaId int references TipoCategorias(TipoCategoriaId)
);

create table Reservaciones(ReservacionId int identity(1,1) primary key,
UsuarioId int references Usuarios(UsuarioId),
SolicitudId int references Solicitudes(SolicitudId),
FechaCreacion DateTime,
EsActivo bit,
Asunto varchar(30)
);

create table ReservacionDetalles(ReservacionDetalleId int identity(1,1) primary key,
EleccionDestino bit,
ReservacionId int references Reservaciones(ReservacionId),
TipoSolicitudId int references TipoSolicitudes(TipoSolicitudId),
CompaniaId int references Companias(CompaniaId),
CategoriaId int references Categorias(CategoriaId),
Origen varchar(100),
Destino varchar(100),
FechaInicial datetime,
FechaFinal datetime,
CantidadPersona int,
CantidadNino int,
CantidadBebe int,
Precio float,
Impuesto float,
Total float
);

select * from Reservaciones

create table RespuestaUsuarios(RespuestaUsuarioId int identity(1,1),
UsuarioId int References Usuarios(UsuarioId),
Descripcion varchar(50),
Precio float,
Impuesto float,
Total float
)

select * from Usuarios