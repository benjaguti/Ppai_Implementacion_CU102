---------------------------------------------------CREACION DE LAS TABLAS--------------------------------------------------------------
--Creacion tabla EMPLEADO
CREATE TABLE Empleado(
idEmpleado int,
codigoValidacion int,
nombre varchar(50) NOT NULL,
apellido varchar(50)NOT NULL,
tipoDocumento varchar(30),
nroDocumento int,
cuit varchar(11),
calle varchar(50),
idBarrio int,
fechaIngreso date,
fechaNacimiento date,
email varchar(50),
sexo varchar(30),
telefono int,
CONSTRAINT empleado_pk PRIMARY KEY (idEmpleado))


--Creacion tabla TIPO_DOCUMENTO
CREATE TABLE TipoDocumento(
tipoDoc varchar(30),
nroDoc int,
descripcion varchar(20),
CONSTRAINT tipoDocumento_pk PRIMARY KEY(tipoDoc, nroDoc))


--Creacion tabla BARRIO
CREATE TABLE Barrio(
idBarrio int,
nombre varchar(30),
CONSTRAINT barrio_pk PRIMARY KEY(idBarrio))

--Creacion de la tabla SESION
CREATE TABLE Sesion(
idSesion int,
fechaInicio date,
fechaFin date,
horaInicio time(0),
horaFin time(0),
idUsuario int,
CONSTRAINT sesion_pk PRIMARY KEY(idSesion))


--Creacion de la tabla USARIO
CREATE TABLE Usuario(
idUsuario int,
nombre varchar(30),
caducidad varchar(3),
contraseña varchar(30) NOT NULL,
idEmpleado int,
CONSTRAINT usuario_pk PRIMARY KEY (idUsuario))

--Creacion de la tabla SEDE
CREATE TABLE Sede(
idSede int,
nombre varchar(30),
descripcion varchar(50),
cantMaxVisitantes int,
cantMaxPorGuia int,
idTarifa int,
idExposicion int,
idEmpleado int,
CONSTRAINT sede_pk PRIMARY KEY (idSede))

--Creacion de la tabla ENTRADA
CREATE TABLE Entrada(
idEntrada int,
fechaVenta varchar(50),
horaVenta varchar(50),
monto int,
idSede int,
idTarifa int,
CONSTRAINT entrada_pk PRIMARY KEY(idEntrada))


--Creacion de la tabla TARIFA
CREATE TABLE Tarifa(
idTarifa int,
fechaFinVigencia date,
fechaInicioVigencia date,
monto int,
montoAdicionalGuia int,
idTipoVisita int,
idTipoEntrada int,
CONSTRAINT tarifa_pk PRIMARY KEY(idTarifa))

--Creacion de la Tabla TIPO_VISITA
CREATE TABLE TipoVisita(
idTipoVisita int,
nombre varchar(50),
descripcion varchar(30),
CONSTRAINT tipoVisita_pk PRIMARY KEY (idTipoVisita))

--Creacion de la tabla TIPO DE ENTRADA
CREATE TABLE TipoDeEntrada(
idTipoEntrada int,
nombre varchar(50),
descripcion varchar(30),
CONSTRAINT tipoDeEntrada_pk PRIMARY KEY(idTipoEntrada))

--Creacion de la tabla EXPOSICION
CREATE TABLE Exposicion(
idExposicion int,
nombre varchar(50),
fechaInicio date,
fechaFin date,
fechaInicioReplanificada date,
fechaFinReplanificada date,
horaApertura time(0),
horaCierre time(0),
idEmpleado int,
idDetalleExposicion int,
CONSTRAINT exposicion_pk PRIMARY KEY(idExposicion))

--Creacion de la tabla DETALLE_DE_EXPOSICION
CREATE TABLE DetalleExposicion(
idDetalleExposicion int,
lugarAsignado varchar(50),
idObra int,
CONSTRAINT detalleExposicion_pk PRIMARY KEY(idDetalleExposicion))

--Creacion de la tabla RESERVA DE VISITA
CREATE TABLE ReservaVisita(
idReservaVisita int,
cantAlumnos int,
cantAlumnosConfirmada int,
duracionEstimada time(0),
fechaHoraCreacion datetime,
fechaHoraReserva datetime,
horaFinReal time(0),
horaInicioReal time(0),
idSede int,
idEmpleado int,
CONSTRAINT reservaVisista_pk PRIMARY KEY(idReservaVisita))

--Creacion de la tabla OBRA
CREATE TABLE Obra(
idObra int,
alto int,
ancho int,
codigoSensor int,
descripcion varchar(30),
duracionExtendida time(0),
duracionResumida time(0),
fechaCreacion date,
fechaPrimeroIngreso date,
nombreObra varchar(30),
peso int,
valuacion varchar (30),
idEmpleado int,
CONSTRAINT obra_pk PRIMARY KEY(idObra))

-------------------------------------------AGREGACION DE LAS CLAVES FOREIGN-------------------------------------------------------------
ALTER TABLE Empleado
ADD CONSTRAINT empleado_tipoDoc_fk FOREIGN KEY (tipoDocumento, nroDocumento) REFERENCES tipoDocumento (tipoDoc,nroDoc)

ALTER TABLE Empleado
ADD CONSTRAINT empleado_barrio_fk FOREIGN KEY (idBarrio) REFERENCES barrio(idBarrio)

ALTER TABLE Sesion
ADD CONSTRAINT sesion_usuario_fk FOREIGN KEY(idUsuario) REFERENCES usuario(idUsuario)

ALTER TABLE Usuario
ADD CONSTRAINT usuario_empleado_fk FOREIGN KEY(idEmpleado) REFERENCES empleado(idEmpleado)

ALTER TABLE Sede
ADD CONSTRAINT sede_empleado_fk FOREIGN KEY(idEmpleado) REFERENCES empleado(idEmpleado)

ALTER TABLE Sede
ADD CONSTRAINT sede_tarifa_fk FOREIGN KEY(idTarifa) REFERENCES tarifa(idTarifa)

ALTER TABLE sede
ADD CONSTRAINT sede_exposicion_fk FOREIGN KEY(idExposicion) REFERENCES exposicion(idExposicion)

ALTER TABLE entrada
ADD CONSTRAINT entrada_sede_fk FOREIGN KEY(idSede) REFERENCES sede(idSede)

ALTER TABLE entrada
ADD CONSTRAINT entrada_tarifa_fk FOREIGN KEY(idTarifa) REFERENCES tarifa (idTarifa)

ALTER TABLE tarifa
ADD CONSTRAINT tarifa_tipoVisita_fk FOREIGN KEY(idTipoVisita) REFERENCES tipoVisita (idTipoVisita)

ALTER TABLE tarifa
ADD CONSTRAINT tarifa_tipoEntrada_fk FOREIGN KEY(idTipoEntrada) REFERENCES tipoDeEntrada (idTipoEntrada)

ALTER TABLE exposicion
ADD CONSTRAINT exposicion_empleado_fk FOREIGN KEY(idEmpleado) REFERENCES empleado(idEmpleado)

ALTER TABLE exposicion
ADD CONSTRAINT exposicion_detalleExposicion_fk FOREIGN KEY(idDetalleExposicion) REFERENCES detalleExposicion(idDetalleExposicion)

ALTER TABLE detalleExposicion
ADD CONSTRAINT detalleExposicion_Obra_fk FOREIGN KEY(idObra) REFERENCES obra(idObra)

ALTER TABLE reservaVisita
ADD CONSTRAINT reservaVisita_sede_fk FOREIGN KEY(idSede) REFERENCES sede(idSede)

ALTER TABLE reservaVisita
ADD CONSTRAINT reservaVisita_empleado_fk FOREIGN KEY(idEmpleado) REFERENCES empleado(idEmpleado)

ALTER TABLE obra
ADD CONSTRAINT obra_empleado_fk FOREIGN KEY(idEmpleado) REFERENCES empleado(idEmpleado)

--------------------------------------------CARGA DE DATOS EN LAS TABLAS---------------------------------------------------------
INSERT INTO Barrio(idBarrio,nombre)
VALUES (1,'Crisol Sur'), (2,'General Paz'),(3, 'Arenales'),(4,'Centro')

INSERT INTO TipoDocumento(tipoDoc,nroDoc,descripcion)
VALUES ('Dni',38123456,''),('Dni',38977075,''),('Dni',37547962,''),('Dni',38369987,'')

INSERT INTO TipoVisita(idTipoVisita,nombre,descripcion)
VALUES (1,'Completa', ''),(2,'Por Exposicion', '')

INSERT INTO TipoDeEntrada(idTipoEntrada,nombre,descripcion)
VALUES (1,'Publico General',''),(2,'Menores', ''), (3,'Jubilados', ''),(4,'Estudiantes', '')

INSERT INTO Empleado (idEmpleado,codigoValidacion,nombre,apellido,tipoDocumento,nroDocumento,cuit,calle,idBarrio,fechaIngreso,fechaNacimiento,email,sexo,telefono)
VALUES(100, 010,'Santiago','Perez','Dni',38123456,'2381234569','Manuel Andrada',3,'2021/06/09','1995-07-28','santiago@gmail.com','masculino',4915634),
      (101, 011,'Maria','Rodriguez','Dni',38977075,'3389770753','Obispo Trejo',4,'2020/08/13','1995-10-21','maria@gmail.com','femenino',4918852),
	  (102, 012,'Victoria','Ibañez','Dni',37547962,'1375479622','Murcia',1,'2021/02/10','1994-07-25','vicky@gmail.com','femenino',4919164),
	  (103, 013,'Matias','Vasquez','Dni',38369987,'7383699876','21 de Septiembre',2,'2020/12/05','1995-03-06','matias@gmail.com','masculino',4968947)

INSERT INTO Obra(idObra,alto,ancho,codigoSensor,descripcion,duracionExtendida,duracionResumida,fechaCreacion,fechaPrimeroIngreso,nombreObra,peso,valuacion,idEmpleado)
VALUES (1,150,70,0001,'','2:00:00','1:30:00','2021/01/20','2021/01/25','La noche Estrellada',2,'2000000',100),
       (2,200,50,0002,'','1:30:00','1:00:00','2021/02/15','2021/02/20','La Gioconda',1,'5000000',101),
	   (3,100,75,0003,'','3:00:00','1:20:00','2021/03/8','2021/03/15','La ultima Cena',3,'100000000',102),
	   (4,250,30,0004,'','2:40:00','1:40:00','2021/04/3','2021/04/7','Las Meninas',2,'2500000',103)

INSERT INTO DetalleExposicion(idDetalleExposicion,lugarAsignado,idObra)
VALUES (1,'Sector1',1),(2,'Sector2',2),(3,'Sector3',3),(4,'Sector4',4)

INSERT Exposicion(idExposicion,nombre,fechaInicio,fechaFin,fechaInicioReplanificada,fechaFinReplanificada,horaApertura,horaCierre,idEmpleado,idDetalleExposicion)
VALUES (01,'Arte Contemporaneo','2021/06/18','2021/06/20','2021/06/21','2021/07/21','14:00:00','15:30:00',100,1),
       (02,'El arte abstracto','2021/04/12','2021/07/12','2021/04/18','2021/08/18','15:00:00','16:30:00',101,2),
	   (03,'La figura del artista','2021/05/15','2021/06/15','2021/05/20','2021/06/20','18:00:00','19:30:00',102,3),
	   (04,'La pintura como legado','2021/03/7','2021/07/7','2021/03/10','2021/07/10','13:00:00','14:30:00',103,4)

--tipoVisita(1,Completa,2,PorExposicion) --tipoEntrada(1,'Publico General',2,'Menores', 3,'Jubilados', 4,'Estudiantes')
INSERT INTO Tarifa(idTarifa,fechaFinVigencia,fechaInicioVigencia,monto,montoAdicionalGuia,idTipoVisita,idTipoEntrada)
VALUES (001,'2022/06/09','2021-06-09',1000,700,1,1),
       (002,'2022/10/10','2021-10-10',700,300,2,2),
	   (003,'2021/04/20','2020-04-20',500,250,1,3),
	   (004,'2022/09/15','2020-09-15',1000,500,1,4),
	   (005,'2021/01/05','2020-01-05',700,300,2,4),
	   (006,'2022/06/21','2020-06-21',800,200,2,3),
	   (007,'2021/01/05','2020-01-05',700,300,2,1),
	   (008,'2022/03/08','2021-03-08',700,100,1,2)

INSERT INTO Sede(idSede,nombre,descripcion,cantMaxVisitantes,cantMaxPorGuia,idTarifa,idExposicion,idEmpleado)
VALUES (01,'Centro','',250,50,001,01,100),(04,'Zona Sur','',200,35,002,03,101),(07,'Zona Norte','',150,25,003,04,102),
       (02,'Centro','',250,50,004,04,100),(05,'Zona Sur','',200,35,006,02,101),(08,'Zona Norte','',150,25,001,01,102),
	   (03,'Centro','',250,50,008,02,100),(06,'Zona Sur','',200,35,007,04,101),(09,'Zona Norte','',150,25,005,03,102)


INSERT INTO ReservaVisita(idReservaVisita,cantAlumnos,cantAlumnosConfirmada,duracionEstimada,fechaHoraCreacion,fechaHoraReserva,horaFinReal,horaInicioReal,idSede,idEmpleado)
VALUES (1,200,78,'','','','','',1,100)

INSERT INTO Usuario(idUsuario,nombre,caducidad,contraseña,idEmpleado)
VALUES(1,'Juan','ON','12345',100), (2,'Jose','ON','164612',101), (3,'Lucia','ON','73313546',102), (4,'Gustavo','ON','3777465',103)

INSERT INTO Sesion(idSesion,fechaInicio,fechaFin,horaInicio,horaFin,idUsuario)
VALUES (1,'2021/06/10','2021/06/10','09:00:00','9:45:00',1),(2,'2021/06/11','2021/06/11','11:10:00','12:00:00',2), 
       (3,'2021/06/10','2021/06/10','08:25:00','9:05:00',3),(4,'2021/06/15','2021/06/15','15:35:00','15:55:00',4)

INSERT INTO Entrada(idEntrada,fechaVenta,horaVenta,monto,idSede,idTarifa)
VALUES (000001,'2021/06/13','10:00:05',1700,01,001), (000002,'2021/05/30','14:22:08',1000,03,002), 
       (000003,'2021/05/24','13:45:20',750,01,003), (000004,'2021/05/25','22:22:01',1500,02,004),
       (000005,'2021/06/14','15:00:00',1000,02,005), (000006,'2021/06/22','18:24:25',1000,03,006)

--------------------------------------------------CONSULTAS----------------------------------------------------------------

SELECT * FROM Barrio
SELECT * FROM DetalleExposicion
SELECT * FROM Empleado
SELECT * FROM Entrada
SELECT * FROM Exposicion
SELECT * FROM Obra
SELECT * FROM ReservaVisita
SELECT * FROM Sede
SELECT * FROM Sesion
SELECT * FROM Tarifa
SELECT * FROM TipoDeEntrada
SELECT * FROM TipoDocumento
SELECT * FROM TipoVisita
SELECT * FROM Usuario