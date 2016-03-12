Create database AgenciaDb4

use AgenciaDb4

create table TipoUsuarios(TipoUsuarioId int identity(1,1) primary key,
Descripcion varchar(50)
);

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
Descripcion varchar(50)
);

create table Destinos(DestinoId int primary key identity(1,1),
Descripcion varchar(50),
TipoDestinoId int references TipoDestinos(TipoDestinoId),
CiudadId int references Ciudades(CiudadId)
);

create table TipoSolicitudes(TipoSolicitudId int identity(1,1) primary key,
Descripcion varchar(50)
);

create table Solicitudes(SolicitudId int identity(1,1) primary key,
UsuarioId int references Usuarios(UsuarioId),
FechaCreacion datetime,
Asunto varchar(50)
);

drop table SolicitudDetalles

create table SolicitudDetalles(SolicitudDetalleId int identity(1,1) primary key,
EleccionDestino bit,
SolicitudId int references Solicitudes(SolicitudId),
TipoSolicitudId int references TipoSolicitudes(TipoSolicitudId),
CompaniaId int references Companias(CompaniaId),
CategoriaId int references Categorias(CategoriaId),
OrigenId int references Destinos(DestinoId),
DestinoId int references Destinos(DestinoId),
FechaInicial datetime,
FechaFinal datetime,
CantidadPersona int,
CantidadNino int,
CantidadBebe int,
PrecioInicial float,
PrecioFinal float,
);

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

create table CategoriaHabitaciones(CategoriaHabitacionId int identity(1,1) primary key,
Descripcion varchar(30)
);

create table HotelResorts(HotelResortId int identity(1,1) primary key,
Nombre varchar(40),
CiudadesHotelId int references CiudadesHoteles(CiudadesHotelId),
UsuarioId int references Usuarios(UsuarioId),
FechaInicial datetime,
FechaFinal datetime,
CategoriaHabitacionId int references CategoriaHabitaciones(CategoriaHabitacionId),
CantidadHabitacion int,
CantidadPersona int,
CantidadNino int,
PrecioInicial float,
PrecioFinal float,
EdadesNino varchar(30)
);

create table Reservaciones(ReservacionId int identity(1,1) primary key,
UsuarioId int references Usuarios(UsuarioId),
EsActivo bit,
FechaCreacion DateTime,
Precio float,
Impuesto float,
Total float
);

create table ReservacionDetalles(ReservacionDetalleId int identity(1,1) primary key,
ReservacionId int references Reservaciones(ReservacionId),
UsuarioId int references Usuarios(UsuarioId),
VueloId int references Vuelos(VueloId)
);

create table ReservacionCruceros(ReservacionCruceroId int primary key identity(1,1),
ReservacionId int references Reservaciones(ReservacionId),
UsuarioId int references Usuarios(UsuarioId),
CruceroId int References Cruceros(CruceroId)
);

create table ReservacionHoteles(ReservacionHotelId int primary key identity(1,1),
ReservacionId int references Reservaciones(ReservacionId),
UsuarioId int references Usuarios(UsuarioId),
HotelResortId int References HotelResorts(HotelResortId)
);

create table RespuestaUsuarios(RespuestaUsuarioId int identity(1,1),
UsuarioId int References Usuarios(UsuarioId),
Descripcion varchar(50),
Precio float,
Impuesto float,
Total float
)

select * from Usuarios