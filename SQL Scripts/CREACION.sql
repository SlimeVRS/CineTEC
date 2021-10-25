CREATE TABLE IF NOT EXISTS public."Branches"
(
    id_branch integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 9999 CACHE 1 ),
    name_branch text COLLATE pg_catalog."default" NOT NULL,
    cant_rooms_branch integer NOT NULL,
    address_branch text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Branches_pkey" PRIMARY KEY (id_branch)
);

-- CLASIFICACIONES
CREATE TABLE IF NOT EXISTS public."Classifications"
(
    id_classif integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    classif text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Classifications_pkey" PRIMARY KEY (id_classif)
);

-- CLIENTES
CREATE TABLE IF NOT EXISTS public."Clients"
(
    id_client integer NOT NULL,
    first_name_client text COLLATE pg_catalog."default" NOT NULL,
    second_name_client text COLLATE pg_catalog."default",
    first_last_name_client text COLLATE pg_catalog."default" NOT NULL,
    second_last_name_client text COLLATE pg_catalog."default",
    phone_client text COLLATE pg_catalog."default" NOT NULL,
    birth_date_client date NOT NULL,
    password_client text COLLATE pg_catalog."default" NOT NULL,
    user_client text COLLATE pg_catalog."default" NOT NULL UNIQUE,
    CONSTRAINT "Clients_pkey" PRIMARY KEY (id_client)
);

-- DIRECTORES
CREATE TABLE IF NOT EXISTS public."Directors"
(
    id_director integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    name_director text COLLATE pg_catalog."default",
    CONSTRAINT "Directors_pkey" PRIMARY KEY (id_director)
);

-- PROTAGONISTS
CREATE TABLE IF NOT EXISTS public."Protagonists"
(
    id_protagonist integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    name_protagonist text COLLATE pg_catalog."default",
    CONSTRAINT "Protagonists_pkey" PRIMARY KEY (id_protagonist)
);

-- ROLES
CREATE TABLE IF NOT EXISTS public."Roles"
(
    id_rol integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 99999 CACHE 1 ),
    name_rol text COLLATE pg_catalog."default" NOT NULL,
    description_rol text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Roles_pkey" PRIMARY KEY (id_rol)
);

-- EMPLOYEES
CREATE TABLE IF NOT EXISTS public."Employees"
(
    id_employee integer NOT NULL,
    first_name_employee text COLLATE pg_catalog."default" NOT NULL,
    second_name_employee text COLLATE pg_catalog."default",
    first_last_name_employee text COLLATE pg_catalog."default" NOT NULL,
    second_last_name_employee text COLLATE pg_catalog."default",
    phone_employee text COLLATE pg_catalog."default" NOT NULL,
    birth_date_employee date NOT NULL,
    admission_date_employee date NOT NULL,
    password_employee text COLLATE pg_catalog."default" NOT NULL,
    user_employee text COLLATE pg_catalog."default" NOT NULL UNIQUE,
    id_branch_employee integer NOT NULL,
    id_rol_employee integer NOT NULL,
    CONSTRAINT "Employees_pkey" PRIMARY KEY (id_employee)
);

-- MOVIES
CREATE TABLE IF NOT EXISTS public."Movies"
(
    id_movie integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 99999 CACHE 1 ),
    name_movie text COLLATE pg_catalog."default" NOT NULL,
    duration_movie text COLLATE pg_catalog."default" NOT NULL,
    poster_movie text COLLATE pg_catalog."default" NOT NULL,
    price_elder_movie integer NOT NULL,
    price_adult_movie integer NOT NULL,
    price_kid_movie integer NOT NULL,
    id_director_movie integer NOT NULL,
    id_classif_movie integer NOT NULL,
    id_protagonist_movie integer NOT NULL,
    CONSTRAINT "Movies_pkey" PRIMARY KEY (id_movie)
);

-- ROOMS
CREATE TABLE IF NOT EXISTS public."Rooms"
(
    id_room integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    capacity_room integer NOT NULL,
    rows_room integer NOT NULL,
    columns_room integer NOT NULL,
    id_branch_room integer NOT NULL,
    CONSTRAINT rooms_pkey PRIMARY KEY (id_room)
);

-- BILLS
CREATE TABLE IF NOT EXISTS public."Bills"
(
    id_bill integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    total_bill double precision NOT NULL,
    id_employee_bill integer NOT NULL,
    id_client_bill integer NOT NULL,
    CONSTRAINT "Bills_pkey" PRIMARY KEY (id_bill)
);

-- PROJECTION
CREATE TABLE IF NOT EXISTS public."Projections"
(
    id_projection integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    time_projection text COLLATE pg_catalog."default" NOT NULL,
	day_projection date NOT NULL,
    id_movie_projection integer NOT NULL,
    id_room_projection integer NOT NULL,
    CONSTRAINT "Projections_pkey" PRIMARY KEY (id_projection)
);

-- SEATS
CREATE TABLE IF NOT EXISTS public."Seats"
(
    id_seat integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    row_seat integer NOT NULL,
    column_seat integer NOT NULL,
    state_seat integer NOT NULL,
    id_room_seat integer NOT NULL,
    CONSTRAINT "Seats_pkey" PRIMARY KEY (id_seat)
);

-- RELACION ENTRE TABLAS

ALTER TABLE "Bills"
ADD CONSTRAINT id_employee_fk 
FOREIGN KEY (id_employee_bill) 
REFERENCES "Employees" (id_employee);

ALTER TABLE "Bills"
ADD CONSTRAINT id_client_fk 
FOREIGN KEY (id_client_bill) 
REFERENCES "Clients" (id_client);

ALTER TABLE "Projections"
ADD CONSTRAINT id_movie_fk 
FOREIGN KEY (id_movie_projection) 
REFERENCES "Movies" (id_movie);

ALTER TABLE "Projections"
ADD CONSTRAINT id_room_fk 
FOREIGN KEY (id_room_projection) 
REFERENCES "Rooms" (id_room);

ALTER TABLE "Seats"
ADD CONSTRAINT id_room_seat_fk 
FOREIGN KEY (id_room_seat) 
REFERENCES "Rooms" (id_room);

ALTER TABLE "Employees"
ADD CONSTRAINT id_employee_branch_fk 
FOREIGN KEY (id_branch_employee) 
REFERENCES "Branches" (id_branch);

ALTER TABLE "Employees"
ADD CONSTRAINT id_employee_rol_fk 
FOREIGN KEY (id_rol_employee) 
REFERENCES "Roles" (id_rol);

ALTER TABLE "Movies"
ADD CONSTRAINT id_movie_director_fk 
FOREIGN KEY (id_director_movie) 
REFERENCES "Directors" (id_director);

ALTER TABLE "Movies"
ADD CONSTRAINT id_movie_classif_fk 
FOREIGN KEY (id_classif_movie) 
REFERENCES "Classifications" (id_classif);

ALTER TABLE "Movies"
ADD CONSTRAINT id_movie_prota_fk 
FOREIGN KEY (id_protagonist_movie) 
REFERENCES "Protagonists" (id_protagonist);

ALTER TABLE "Rooms"
ADD CONSTRAINT id_room_branch_fk 
FOREIGN KEY (id_branch_room) 
REFERENCES "Branches" (id_branch);