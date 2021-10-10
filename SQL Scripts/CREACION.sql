CREATE TABLE IF NOT EXISTS public."Branches"
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 9999 CACHE 1 ),
    name text COLLATE pg_catalog."default" NOT NULL,
    cant_rooms integer NOT NULL,
    address text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Branches_pkey" PRIMARY KEY (id)
);

-- CLASIFICACIONES
CREATE TABLE IF NOT EXISTS public."Classifications"
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    classif text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Classifications_pkey" PRIMARY KEY (id)
);

-- CLIENTES
CREATE TABLE IF NOT EXISTS public."Clients"
(
    id integer NOT NULL,
    first_name text COLLATE pg_catalog."default" NOT NULL,
    second_name text COLLATE pg_catalog."default",
    first_last_name text COLLATE pg_catalog."default" NOT NULL,
    second_last_name text COLLATE pg_catalog."default",
    phone text COLLATE pg_catalog."default" NOT NULL,
    birth_date date NOT NULL,
    _password text COLLATE pg_catalog."default" NOT NULL,
    _user text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Clients_pkey" PRIMARY KEY (id)
);

-- DIRECTORES
CREATE TABLE IF NOT EXISTS public."Directors"
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    first_name text COLLATE pg_catalog."default" NOT NULL,
    second_name text COLLATE pg_catalog."default",
    first_last_name text COLLATE pg_catalog."default" NOT NULL,
    second_last_name text COLLATE pg_catalog."default",
    CONSTRAINT "Directors_pkey" PRIMARY KEY (id)
);

-- PROTAGONISTS
CREATE TABLE IF NOT EXISTS public."Protagonists"
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    first_name text COLLATE pg_catalog."default" NOT NULL,
    second_name text COLLATE pg_catalog."default",
    first_last_name text COLLATE pg_catalog."default" NOT NULL,
    second_last_name text COLLATE pg_catalog."default",
    CONSTRAINT "Protagonists_pkey" PRIMARY KEY (id)
);

-- ROLES
CREATE TABLE IF NOT EXISTS public."Roles"
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 99999 CACHE 1 ),
    name text COLLATE pg_catalog."default" NOT NULL,
    description text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Roles_pkey" PRIMARY KEY (id)
);

-- EMPLOYEES
CREATE TABLE IF NOT EXISTS public."Employees"
(
    id integer NOT NULL,
    first_name text COLLATE pg_catalog."default" NOT NULL,
    second_name text COLLATE pg_catalog."default",
    first_last_name text COLLATE pg_catalog."default" NOT NULL,
    second_last_name text COLLATE pg_catalog."default",
    phone text COLLATE pg_catalog."default" NOT NULL,
    birth_date date NOT NULL,
    admission_date date NOT NULL,
    _password text COLLATE pg_catalog."default" NOT NULL,
    _user text COLLATE pg_catalog."default" NOT NULL,
    id_branch integer NOT NULL,
    id_rol integer NOT NULL,
    CONSTRAINT "Employees_pkey" PRIMARY KEY (id)
);

-- MOVIES
CREATE TABLE IF NOT EXISTS public."Movies"
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 99999 CACHE 1 ),
    name text COLLATE pg_catalog."default" NOT NULL,
    duration text COLLATE pg_catalog."default" NOT NULL,
    poster text COLLATE pg_catalog."default" NOT NULL,
    price_elder integer NOT NULL,
    price_adult integer NOT NULL,
    price_kid integer NOT NULL,
    id_director integer NOT NULL,
    id_classif integer NOT NULL,
    id_protagonist integer NOT NULL,
    CONSTRAINT "Movies_pkey" PRIMARY KEY (id)
);

-- ROOMS
CREATE TABLE IF NOT EXISTS public."Rooms"
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    capacity integer NOT NULL,
    rows integer NOT NULL,
    columns integer NOT NULL,
    id_branch integer NOT NULL,
    CONSTRAINT rooms_pkey PRIMARY KEY (id)
);

-- BILLS
CREATE TABLE IF NOT EXISTS public."Bills"
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    total double precision NOT NULL,
    id_employee integer NOT NULL,
    id_client integer NOT NULL,
    CONSTRAINT "Bills_pkey" PRIMARY KEY (id)
);

-- PROJECTION
CREATE TABLE IF NOT EXISTS public."Projections"
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    _time text COLLATE pg_catalog."default" NOT NULL,
    id_movie integer NOT NULL,
    id_room integer NOT NULL,
    CONSTRAINT "Projections_pkey" PRIMARY KEY (id)
);

-- SEATS
CREATE TABLE IF NOT EXISTS public."Seats"
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    _row integer NOT NULL,
    _column integer NOT NULL,
    _state integer NOT NULL,
    id_room integer NOT NULL,
    CONSTRAINT "Seats_pkey" PRIMARY KEY (id)
);

-- RELACION ENTRE TABLAS

ALTER TABLE "Bills"
ADD CONSTRAINT id_employee_fk 
FOREIGN KEY (id_employee) 
REFERENCES "Employees" (id);

ALTER TABLE "Bills"
ADD CONSTRAINT id_client_fk 
FOREIGN KEY (id_client) 
REFERENCES "Clients" (id);

ALTER TABLE "Projections"
ADD CONSTRAINT id_movie_fk 
FOREIGN KEY (id_movie) 
REFERENCES "Movies" (id);

ALTER TABLE "Projections"
ADD CONSTRAINT id_room_fk 
FOREIGN KEY (id_room) 
REFERENCES "Rooms" (id);

ALTER TABLE "Seats"
ADD CONSTRAINT id_room_seat_fk 
FOREIGN KEY (id_room) 
REFERENCES "Rooms" (id);

ALTER TABLE "Employees"
ADD CONSTRAINT id_employee_branch_fk 
FOREIGN KEY (id_branch) 
REFERENCES "Branches" (id);

ALTER TABLE "Employees"
ADD CONSTRAINT id_employee_rol_fk 
FOREIGN KEY (id_rol) 
REFERENCES "Roles" (id);

ALTER TABLE "Movies"
ADD CONSTRAINT id_movie_director_fk 
FOREIGN KEY (id_director) 
REFERENCES "Directors" (id);

ALTER TABLE "Movies"
ADD CONSTRAINT id_movie_classif_fk 
FOREIGN KEY (id_classif) 
REFERENCES "Classifications" (id);

ALTER TABLE "Movies"
ADD CONSTRAINT id_movie_prota_fk 
FOREIGN KEY (id_protagonist) 
REFERENCES "Protagonists" (id);

ALTER TABLE "Rooms"
ADD CONSTRAINT id_room_branch_fk 
FOREIGN KEY (id_branch) 
REFERENCES "Branches" (id);

-- INSERCIÓN DE ENTIDADES EN ESTE ORDEN

-- [PRIMER BLOQUE]
-- BRANCH
-- CLASSIFICATION
-- CLIENTS
-- DIRECTOR
-- PROTAGONIST
-- ROLES

-- [SEGUNDO BLOQUE]
-- EMPLOYEES
-- MOVIES
-- ROOMS

-- [TERCER BLOQUE]
-- BILLS
-- PROJECTION
-- SEATS

INSERT INTO public."Branches" (name, cant_rooms, address)
VALUES ('Cartago', 10, 'Cartago');

INSERT INTO public."Clients" (id, first_name, second_name, first_last_name, second_last_name, phone, birth_date, _password, _user)
VALUES(101110111, 'Primer Nombre', 'Segundo Nombre', 'Primer Apellido', 'Segundo Apellido', '11111111', '01-01-2021', 'Pasword123', 'User123');

INSERT INTO public."Clients" (id, first_name, second_name, first_last_name, second_last_name, phone, birth_date, _password, _user)
VALUES(202220222, 'Nombre1', 'SegNombre1', 'Apellido1', 'SegApellido1', '22222222', '2000-01-01', 'contraseña', 'usuario');

INSERT INTO public."Classifications" (classif)
VALUES('Adulto');

INSERT INTO public."Classifications" (classif)
VALUES('Niño');

INSERT INTO public."Directors" (first_name, second_name, first_last_name, second_last_name)
VALUES ('Dnombre1','Dnombre1','Dapellido1','Dapellido1');

INSERT INTO public."Protagonists" (first_name, second_name, first_last_name, second_last_name)
VALUES ('Pnombre1', 'Pnombre1', 'Papellido1', 'Papellido1');

INSERT INTO public."Roles" (name, description)
VALUES('cajero','cobra dinero');

INSERT INTO public."Employees" (id, first_name, second_name, first_last_name, second_last_name, phone, birth_date, admission_date, _password, _user, id_branch, id_rol)
VALUES (101110111, 'Nombre1', 'Nombre1', 'Apellido1', 'Apellido2','11111111','1999-02-10','2021-10-10', 'Contraseña', 'Usuario', 1, 1);

INSERT INTO public."Movies" (name, duration, poster, price_elder, price_adult, price_kid, id_director, id_classif, id_protagonist)
VALUES ('Peli1', '1:45', 'poster1', 1400, 1500, 1200, 1, 2,1);

INSERT INTO public."Rooms" (capacity, rows, columns, id_branch)
VALUES (30, 6, 5, 1);

INSERT INTO public."Bills" (total, id_employee, id_client)
VALUES(4700, 101110111, 202220222);

INSERT INTO public."Projections" (_time, id_movie, id_room)
VALUES ('14:40', 1, 1);

INSERT INTO public."Seats" (_row, _column, _state, id_room)
VALUES(3,4,1,1);
