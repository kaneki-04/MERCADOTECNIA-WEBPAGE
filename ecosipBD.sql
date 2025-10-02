drop database if exists EcosipDB;
create database if not exists EcosipDB;
use EcosipDB;


/*
create table Clientes(

	id_Cliente int auto_increment,
    Username varchar(20) not null,
    Passwd varchar(20) not null,
    Email varchar(50) not null,
    
	constraint usuarioPK primary key(id_cliente)

);
*/


create table Botellas  (

	id_Botellas int auto_increment,
    Nombre varchar(50),
    Descripcion varchar(50),
    Tipo varchar(20),
    
    constraint BotellaPK primary key(id_Botellas)
);

create table Espec_Botellas(

	id_espec int auto_increment,
    BotellaId int,
    Colores varchar(10),
    Size enum('Pequeña', 'Mediana', 'Grande') default('Mediana'),
    Tipo enum('Botella', 'Maceta', 'Galon'),
    
    constraint EspecPK primary key(id_espec),
    constraint EspecFK foreign key(BotellaID) references Botellas(id_Botellas) on update cascade on delete cascade
);

create table Repartidores(

	id_repartidor int auto_increment,
    Nombre varchar(50) not null,
    Telefono varchar(15) not null unique,
    Vehiculo varchar(50),
    
    constraint repartidorPK primary key(id_repartidor)
);

create table Pedido (

	id_Pedido INT AUTO_INCREMENT PRIMARY KEY,
    id_Usuario INT NOT NULL,
    id_Repartidor INT,
    Fecha DATETIME DEFAULT CURRENT_TIMESTAMP,
    Estado ENUM('Pendiente','En camino','Entregado','Cancelado') DEFAULT 'Pendiente',
    total DECIMAL(10,2) DEFAULT 0,
    FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente) on update cascade on delete cascade, 
    FOREIGN KEY (id_repartidor) REFERENCES repartidores(id_repartidor) on update cascade on delete cascade
);

CREATE TABLE DetallePedidos (
    id_Detalle INT AUTO_INCREMENT PRIMARY KEY,
    id_Pedido INT NOT NULL,
    id_Botellas INT NOT NULL,
    Cantidad INT NOT NULL CHECK (cantidad > 0),
    Precio_Unitario DECIMAL(10,2) NOT NULL,
    Subtotal DECIMAL(10,2) GENERATED ALWAYS AS (cantidad * precio_unitario) STORED,
    FOREIGN KEY (id_pedido) REFERENCES Pedido(id_pedido) on update cascade on delete cascade, 
    FOREIGN KEY (id_Botellas) REFERENCES Botellas(id_botellas) on update cascade on delete cascade
);

