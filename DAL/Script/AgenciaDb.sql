Create database AgenciaDb4

use AgenciaDb4

create table TipoUsuarios(TipoUsuarioId int identity(1,1) primary key,
Descripcion varchar(50)
);

create table Usuarios(UsuarioId int identity(1,1) primary key,
NombreUsuario varchar(30),
Contrasena varchar(30),
Nombre varchar(50),
Apellido varchar(50),
Email varchar(30),
Telefono varchar(13),
FechaNacimiento datetime,
TipoUsuarioId int references TipoUsuarios(TipoUsuarioId)
);

create table Ciudades(CiudadId int identity(1,1) primary key,
Descripcion varchar(30)
);

create table Paises(PaisId int identity(1,1) primary key,
Descripcion varchar(30),
CiudadId int references Ciudades(CiudadId)
);

create table Destinos(DestinoId int primary key identity(1,1),
PaisId int references Paises(PaisId),
CiudadId int references Ciudades(CiudadId)
);

create table Viajes(ViajeId int identity(1,1) primary key,
DestinoId int references Destinos(DestinoId),
FechaInicial datetime,
FechaFinal datetime,
CantidadPersona int,
CantidadNino int,
EdadesNino varchar(30),
PrecioInicial float,
PrecioFinal float
);

create table CompaniaAeroLineas(CompaniaAeroLineaId int identity(1,1) primary key,
Descripcion varchar(50),
Email varchar(30)
);

create table Vuelos(VueloId int identity(1,1) primary key,
EleccionDestino bit,
UsuarioId int references Usuarios(UsuarioId),
ViajesId int References Viajes(ViajeId)
);

create table CompaniaCruceros(CompaniaCruceroId int primary key identity(1,1),
Descripcion varchar(50),
Email varchar(30)
);

create table CategoriaCrucero(CategoriaCruceroId int identity(1,1) primary key,
Descripcion varchar(30)
);

create table Cruceros(CruceroId int identity(1,1) primary key,
UsuarioId int references Usuarios(UsuarioId),
ViajesId int References Viajes(ViajeId),
CategoriaCruceroId int references CategoriaCrucero(CategoriaCruceroId),
CompaniaCruceroId int References CompaniaCruceros(CompaniaCruceroId)
);

create table DestinosViajes(DestinosViajeId int identity(1,1) primary key,
ViajesId int References Viajes(ViajeId),
DestinoId int references Destinos(DestinoId)
);

create table VueloDetalle(VueloDetalleId int identity(1,1) primary key,
UsuarioId int references Usuarios(UsuarioId),
ViajesId int References Viajes(ViajeId),
CompaniaAeroLineaId int references CompaniaAeroLineas(CompaniaAeroLineaId)
);

create table CiudadesHoteles(CiudadesHotelId int identity(1,1) primary key,
Descripcion varchar(50)
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
Fecha DateTime,
Precio float,
Impuesto float,
Total float
);

create table ReservacionVuelos(ReservacionVuelosId int identity(1,1) primary key,
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