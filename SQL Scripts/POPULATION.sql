INSERT INTO public."Branches" (name_branch, cant_rooms_branch, address_branch)
VALUES ('CineTEC Terramall',12,'Tres Rios');

INSERT INTO public."Branches" (name_branch, cant_rooms_branch, address_branch)
VALUES ('CineTEC Paseo Metropoli',10,'Cartago');

INSERT INTO public."Clients" (id_client, first_name_client, second_name_client, first_last_name_client, second_last_name_client, phone_client, birth_date_client, password_client, user_client)
VALUES(616516165,'Brandon','Gomez','Gomez','gomez','56651651','2000-12-12','Admin','Brandon');

INSERT INTO public."Clients" (id_client, first_name_client, second_name_client, first_last_name_client, second_last_name_client, phone_client, birth_date_client, password_client, user_client)
VALUES(101110111,'Ronaldhino','Dihno','Gaucho','Laplace','66666666','2021-01-01','messirve','CR7');


INSERT INTO public."Classifications" (classif)
VALUES('Adulto');

INSERT INTO public."Classifications" (classif)
VALUES('Niño');

INSERT INTO public."Directors" (name_director)
VALUES ('Sylvester Stallone');

INSERT INTO public."Directors" (name_director)
VALUES ('Makoto Shinkai');

INSERT INTO public."Directors" (name_director)
VALUES ('Akiyuki Shinbo');

INSERT INTO public."Directors" (name_director)
VALUES ('Ridley Scott');

INSERT INTO public."Directors" (name_director)
VALUES ('Todd Phillips');

INSERT INTO public."Directors" (name_director)
VALUES ('Destin Daniel Cretton');

INSERT INTO public."Protagonists" (name_protagonist)
VALUES ('Personaje inventado');

INSERT INTO public."Protagonists" (name_protagonist)
VALUES ('Sylvester Stallone');

INSERT INTO public."Protagonists" (name_protagonist)
VALUES ('Hiroshi Kamiya');

INSERT INTO public."Protagonists" (name_protagonist)
VALUES ('Timothée Chalamet');

INSERT INTO public."Protagonists" (name_protagonist)
VALUES ('Ryunosuke Kamiki');

INSERT INTO public."Protagonists" (name_protagonist)
VALUES ('Anthony Hopkins');

INSERT INTO public."Protagonists" (name_protagonist)
VALUES ('Joaquin Phoenix');

INSERT INTO public."Protagonists" (name_protagonist)
VALUES ('Simu Liu');

INSERT INTO public."Roles" (name_rol, description_rol)
VALUES('cajero','cobra dinero');

INSERT INTO public."Roles" (name_rol, description_rol)
VALUES('Administrador','Administrar puestos y empleados');

INSERT INTO public."Employees" (id_employee, first_name_employee, second_name_employee, first_last_name_employee, second_last_name_employee, phone_employee, birth_date_employee, admission_date_employee, password_employee, user_employee, id_branch_employee, id_rol_employee)
VALUES (13241234,'Brandon','Moises','Gomez','Gomez','66666666666','2021-10-17','2021-10-17','seña','Contra',2,1);

INSERT INTO public."Employees" (id_employee, first_name_employee, second_name_employee, first_last_name_employee, second_last_name_employee, phone_employee, birth_date_employee, admission_date_employee, password_employee, user_employee, id_branch_employee, id_rol_employee)
VALUES (65651616,'Marco','Vinicio','Rivera','Serrano','515616161','2000-12-12','2000-12-12','Al Futuro','Marti',2,2);

INSERT INTO public."Movies" (name_movie, duration_movie, poster_movie, price_elder_movie, price_adult_movie, price_kid_movie, id_director_movie, id_classif_movie, id_protagonist_movie)
VALUES ('Kizumonogatari III: Reiketsu-hen','1:23:00','https://firebasestorage.googleapis.com/v0/b/cinetec-2824b.appspot.com/o/1634352423701?alt=media&token=04cbaff3-6da2-4545-8498-7d5002dfcb56',2000,3500,2000,3,1,2);

INSERT INTO public."Movies" (name_movie, duration_movie, poster_movie, price_elder_movie, price_adult_movie, price_kid_movie, id_director_movie, id_classif_movie, id_protagonist_movie)
VALUES ('Rocky IV','1:31:00','https://firebasestorage.googleapis.com/v0/b/cinetec-2824b.appspot.com/o/1634352816118?alt=media&token=8a15c7ff-8869-4930-b964-4d945d5f9558',2000,3500,2000,1,2,1);

INSERT INTO public."Movies" (name_movie, duration_movie, poster_movie, price_elder_movie, price_adult_movie, price_kid_movie, id_director_movie, id_classif_movie, id_protagonist_movie)
VALUES ('Kimi no Na wa','1:06:00','https://firebasestorage.googleapis.com/v0/b/cinetec-2824b.appspot.com/o/1634405719885?alt=media&token=e3be4545-dcd2-4b9a-a77b-d1047ef58d05',2000,3500,2000,2,2,4);

INSERT INTO public."Movies" (name_movie, duration_movie, poster_movie, price_elder_movie, price_adult_movie, price_kid_movie, id_director_movie, id_classif_movie, id_protagonist_movie)
VALUES ('Hannibal','2:11:00','https://firebasestorage.googleapis.com/v0/b/cinetec-2824b.appspot.com/o/1634409808132?alt=media&token=cd5f808d-165d-4c34-ae07-cf306f24282c',2000,3500,2000,4,1,5);

INSERT INTO public."Movies" (name_movie, duration_movie, poster_movie, price_elder_movie, price_adult_movie, price_kid_movie, id_director_movie, id_classif_movie, id_protagonist_movie)
VALUES ('Joker','2:02:00','https://firebasestorage.googleapis.com/v0/b/cinetec-2824b.appspot.com/o/1634495549928?alt=media&token=306200f3-c0d3-4d63-90e4-4c714576229d',2000,3500,2000,5,1,6);

INSERT INTO public."Rooms" (capacity_room, rows_room, columns_room, id_branch_room)
VALUES (30, 6, 5, 1);

INSERT INTO public."Rooms" (capacity_room, rows_room, columns_room, id_branch_room)
VALUES (84,7,12,1);

INSERT INTO public."Rooms" (capacity_room, rows_room, columns_room, id_branch_room)
VALUES (96,8,12,1);

INSERT INTO public."Rooms" (capacity_room, rows_room, columns_room, id_branch_room)
VALUES (70,7,10,1);

INSERT INTO public."Rooms" (capacity_room, rows_room, columns_room, id_branch_room)
VALUES (96,8,12,2);

INSERT INTO public."Rooms" (capacity_room, rows_room, columns_room, id_branch_room)
VALUES (80,8,10,2);

INSERT INTO public."Projections" (time_projection, day_projection, id_movie_projection, id_room_projection)
VALUES ('6pm','2021-10-30',3,4);

INSERT INTO public."Projections" (time_projection, day_projection, id_movie_projection, id_room_projection)
VALUES ('1pm','2021-10-28',4,4);

INSERT INTO public."Projections" (time_projection, day_projection, id_movie_projection, id_room_projection)
VALUES ('7pm','2021-10-22',5,4);

INSERT INTO public."Projections" (time_projection, day_projection, id_movie_projection, id_room_projection)
VALUES ('5pm','2021-10-28',3,4);

INSERT INTO public."Projections" (time_projection, day_projection, id_movie_projection, id_room_projection)
VALUES ('9pm','2021-10-21',2,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,4,1,1);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,0,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,1,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,2,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,3,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,4,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,5,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,6,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,7,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,8,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,9,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,10,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,11,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,0,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,1,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,2,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,3,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,4,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,5,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,6,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,7,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,8,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,9,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,10,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,11,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,0,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,1,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,2,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,3,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,4,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,5,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,6,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,7,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,8,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,9,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,10,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,11,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,0,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,1,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,2,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,3,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,4,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,5,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,6,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,7,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,8,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,9,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,10,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,11,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,0,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,1,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,2,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,3,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,4,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,5,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,6,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,7,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,8,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,9,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,10,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,11,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,0,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,1,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,2,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,3,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,4,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,5,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,6,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,7,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,8,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,9,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,10,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,11,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,0,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,1,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,2,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,3,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,4,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,5,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,6,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,7,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,8,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,9,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,10,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,11,1,2);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,0,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,1,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,2,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,3,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,4,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,5,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,6,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,7,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,8,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,9,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,10,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,11,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,0,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,1,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,2,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,3,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,4,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,5,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,6,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,7,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,8,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,9,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,10,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,11,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,0,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,1,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,2,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,3,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,4,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,5,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,6,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,7,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,8,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,9,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,10,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,11,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,0,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,1,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,2,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,3,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,4,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,5,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,6,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,7,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,8,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,9,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,10,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,11,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,0,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,1,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,2,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,3,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,4,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,5,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,6,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,7,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,8,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,9,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,10,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,11,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,0,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,1,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,2,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,3,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,4,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,5,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,6,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,7,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,8,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,9,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,10,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,11,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,0,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,1,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,2,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,3,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,4,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,5,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,6,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,7,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,8,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,9,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,10,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,11,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,0,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,1,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,2,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,3,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,4,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,5,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,6,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,7,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,8,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,9,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,10,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,11,1,3);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,0,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,1,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,2,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,3,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,4,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,5,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,6,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,7,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,8,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,9,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,0,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,1,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,2,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,3,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,4,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,5,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,6,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,7,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,8,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,9,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,0,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,1,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,2,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,3,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,4,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,5,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,6,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,7,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,8,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,9,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,0,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,1,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,2,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,3,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,4,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,5,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,6,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,7,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,8,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,9,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,0,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,1,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,2,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,3,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,4,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,5,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,6,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,7,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,8,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,9,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,0,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,1,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,2,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,3,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,4,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,5,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,6,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,7,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,8,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,9,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,0,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,1,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,2,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,3,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,4,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,5,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,6,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,7,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,8,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,9,1,4);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,0,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,1,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,2,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,3,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,4,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,5,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,6,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,7,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,8,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,9,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,10,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,11,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,0,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,1,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,2,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,3,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,4,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,5,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,6,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,7,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,8,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,9,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,10,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,11,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,0,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,1,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,2,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,3,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,4,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,5,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,6,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,7,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,8,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,9,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,10,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,11,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,0,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,1,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,2,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,3,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,4,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,5,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,6,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,7,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,8,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,9,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,10,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,11,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,0,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,1,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,2,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,3,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,4,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,5,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,6,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,7,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,8,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,9,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,10,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,11,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,0,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,1,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,2,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,3,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,4,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,5,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,6,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,7,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,8,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,9,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,10,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,11,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,0,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,1,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,2,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,3,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,4,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,5,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,6,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,7,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,8,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,9,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,10,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,11,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,0,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,1,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,2,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,3,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,4,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,5,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,6,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,7,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,8,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,9,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,10,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,11,1,5);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,0,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,1,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,2,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,3,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,4,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,5,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,6,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,7,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,8,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(0,9,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,0,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,1,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,2,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,3,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,4,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,5,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,6,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,7,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,8,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(1,9,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,0,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,1,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,2,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,3,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,4,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,5,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,6,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,7,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,8,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(2,9,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,0,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,1,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,2,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,3,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,4,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,5,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,6,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,7,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,8,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(3,9,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,0,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,1,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,2,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,3,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,4,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,5,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,6,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,7,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,8,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(4,9,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,0,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,1,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,2,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,3,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,4,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,5,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,6,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,7,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,8,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(5,9,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,0,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,1,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,2,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,3,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,4,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,5,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,6,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,7,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,8,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(6,9,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,0,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,1,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,2,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,3,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,4,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,5,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,6,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,7,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,8,1,6);

INSERT INTO public."Seats" (row_seat, column_seat, state_seat, id_room_seat)
VALUES(7,9,1,6);