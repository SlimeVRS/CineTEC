-- CREACIÓN DE TABLAS

-- SUCURSALES
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



