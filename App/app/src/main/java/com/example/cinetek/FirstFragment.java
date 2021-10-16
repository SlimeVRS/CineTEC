package com.example.cinetek;

import android.annotation.SuppressLint;
import android.database.Cursor;
import android.database.sqlite.SQLiteOpenHelper;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.SpinnerAdapter;
import android.widget.Toast;

import android.database.sqlite.SQLiteDatabase;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import com.example.cinetek.databinding.FragmentFirstBinding;
import com.google.android.material.snackbar.Snackbar;

import java.util.ArrayList;

public class FirstFragment extends Fragment {

    private FragmentFirstBinding binding;
    private Spinner SpinCine;
    private Spinner SpinPeli;
    private Spinner SpinHora;
    private Spinner SpinAsientos;
    private ImageView img_asientos;
    private ArrayAdapter<String> adapterCines;
    private ArrayAdapter<String> adapterPeli;
    private ArrayAdapter<String> adapterHora;
    private ArrayAdapter<String> adapterAsientos;
    private ArrayList<String> cines;
    private ArrayList<String> peli;
    private ArrayList<String> hora;
    private ArrayList<String> asientos;
    private String cinema;
    private String pelicula;
    private String horario;
    private SQLiteDatabase db;
    private String mov;
    private String room;
    private boolean boll_cine;
    private boolean boll_peli;
    private boolean boll_seat;
    private boolean boll_seat_type;
    private int precio;
    private int id_asiento;



    @Override
    public View onCreateView(
            LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState
    ) {

        binding = FragmentFirstBinding.inflate(inflater, container, false);
        return binding.getRoot();

    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        //obtencion del spin del layout




        binding.buttonFirst.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                spin_cine();
            }

        });
        binding.butComprar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (boll_cine && boll_peli && boll_seat && boll_seat_type){
                    db.rawQuery("INSERT INTO Bills (total_bill, id_employee_bill, id_client_bill) VALUES ("+precio+", 101110111, 202220222);",null);
                    db.execSQL("UPDATE Seats SET state_seat=0 WHERE id_seat="+id_asiento+";");
                    String query="INSERT INTO Bills (total_bill, id_employee_bill, id_client_bill) VALUES ("+precio+", 101110111, 202220222);" ;


                    NavHostFragment.findNavController(FirstFragment.this)
                            .navigate(R.id.action_FirstFragment_to_SecondFragment);
                }
                else{
                    Snackbar.make(view, "Debe rellenar todos los espacios", Snackbar.LENGTH_LONG)
                            .setAction("Action", null).show();
                }

            }
        });
    }
    private void spin_cine(){
        //Obtencion del spin
        SpinCine = getActivity().findViewById(R.id.spin_cine);
        //creacion de los arrays
        cines=new ArrayList();
        //llamada de la funcion de carga de los cines
        cine();
        //carga de los arrays a los adapters
        adapterCines=new ArrayAdapter<String>(getActivity(),android.R.layout.simple_spinner_item,cines);
        adapterCines.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        //asignacion de los adapters a los spinners
        SpinCine.setAdapter(adapterCines);
        SpinCine.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int posicion, long l) {
                cinema = (String) SpinCine.getAdapter().getItem(posicion);
                if (posicion>0){
                    boll_cine=true;
                    spin_pelicula();

                }
                else{
                    boll_cine=false;
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });
    }
    private void spin_pelicula(){
        //Obtencion del spin
        SpinPeli = getActivity().findViewById(R.id.spin_peli);
        //creacion de los arrays
        peli=new ArrayList();
        //llamada de la funcion de carga de los cines
        pelicula();
        //carga de los arrays a los adapters
        adapterPeli=new ArrayAdapter<String>(getActivity(),android.R.layout.simple_spinner_item,peli);
        adapterPeli.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        //asignacion de los adapters a los spinners
        SpinPeli.setAdapter(adapterPeli);
        SpinPeli.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int posicion, long l) {
                if (posicion>0){

                    String dato=(String) SpinPeli.getAdapter().getItem(posicion);
                    dato=dato.replace("Hora: ","");
                    dato=dato.replace("Sala: ","");
                    String[] datos=dato.split(",");
                    System.out.println(datos[1]);
                    pelicula = datos[0];
                    horario=datos[1];
                    room=datos[2];
                    boll_peli=true;
                    cargar_img();
                    spin_asiento_tipo();
                    spin_asientos_();
                }
                else{
                    boll_peli=false;
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });
    }

    private void spin_asiento_tipo(){
        //Obtencion del spin
        SpinHora = getActivity().findViewById(R.id.spin_hora);
        //creacion de los arrays
        hora=new ArrayList();
        //llamada de la funcion de carga de los cines
        asiento_tipo();
        //carga de los arrays a los adapters
        adapterHora=new ArrayAdapter<String>(getActivity(),android.R.layout.simple_spinner_item,hora);
        adapterHora.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        //asignacion de los adapters a los spinners
        SpinHora.setAdapter(adapterHora);
        SpinHora.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int posicion, long l) {
                horario = (String) SpinHora.getAdapter().getItem(posicion);
                if (posicion>0){
                    boll_seat_type=true;
                    String[] datos=horario.split(":");
                    precio=Integer.parseInt(datos[1]);
                    System.out.println("precio");
                    System.out.println(precio);
                }else{
                    boll_seat_type=false;
                }

            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });
    }
    private void spin_asientos_(){
        //Obtencion del spin
        SpinAsientos = getActivity().findViewById(R.id.spin_asiento);
        //creacion de los arrays
        asientos=new ArrayList();
        //llamada de la funcion de carga de los cines
        asientos();
        //carga de los arrays a los adapters
        adapterAsientos=new ArrayAdapter<String>(getActivity(),android.R.layout.simple_spinner_item,asientos);
        adapterAsientos.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        //asignacion de los adapters a los spinners
        SpinAsientos.setAdapter(adapterAsientos);
        SpinAsientos.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int posicion, long l) {
                String asiento = (String) SpinAsientos.getAdapter().getItem(posicion);
                if (posicion>0){
                    boll_seat=true;
                    String[] datos=asiento.split(",");
                    id_asiento=Integer.parseInt(datos[0]);
                    System.out.println("id asiento");
                    System.out.println(id_asiento);
                }else{
                    boll_seat=false;
                    precio=0;
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });
    }

    private  void  asientos(){

        String query="select id_seat,row_seat,column_seat\n" +
                "from seats\n" +
                "where state_seat=1 and id_room_seat="+room+";" ;
        Cursor consulta = db.rawQuery(query, null);
        int respuestas=consulta.getCount();
        if (consulta != null && respuestas>0) {
            asientos.add("Seleccione un asiento");
            consulta.moveToFirst();
            do {
                //Asignamos el valor en nuestras variables para usarlos en lo que necesitemos
                @SuppressLint("Range")String id = consulta.getString(consulta.getColumnIndex("id_seat"));
                @SuppressLint("Range")String fila= consulta.getString(consulta.getColumnIndex("row_seat"));
                @SuppressLint("Range") String columna= consulta.getString(consulta.getColumnIndex("column_seat"));
                asientos.add(id+",Fila: "+fila+",columna: "+columna);
            } while (consulta.moveToNext());
        }else{
            asientos.add("No hay espacios disponibles para esta pelicula");
        }
    }
    private void asiento_tipo(){
        hora.add("Seleccione un tipo de asiento");
        String query="select price_elder_movie,price_adult_movie,price_kid_movie\n" +
                "from movies\n" +
                "where name_movie=\""+pelicula+"\";" ;
        Cursor consulta = db.rawQuery(query, null);
        if (consulta != null) {
            consulta.moveToFirst();
            do {
                //Asignamos el valor en nuestras variables para usarlos en lo que necesitemos
                @SuppressLint("Range")String ancino = consulta.getString(consulta.getColumnIndex("price_elder_movie"));
                @SuppressLint("Range")String adulto= consulta.getString(consulta.getColumnIndex("price_adult_movie"));
                @SuppressLint("Range") String nino= consulta.getString(consulta.getColumnIndex("price_kid_movie"));
                hora.add("Adulto mayor:"+ancino);
                hora.add("Adulto:"+adulto);
                hora.add("Niño:"+nino);
            } while (consulta.moveToNext());
        }
    }
    @SuppressLint("Range")
    private void pelicula() {
        System.out.println(cinema);
        String query="select name_movie,id_room_projection\n" +
                "from (projections join movies on id_movie_projection=id_movie)\n" +
                "where id_room_projection in(SELECT id_room FROM (rooms JOIN branches ON id_branch_room = id_branch) where name_branch=\""+cinema+"\");" ;

        Cursor consulta = db.rawQuery(query, null);

        int respuestas=consulta.getCount();
        if (consulta != null && respuestas>0) {
            peli.add("Seleccione una pelicula");
            consulta.moveToFirst();
            do {
                //Asignamos el valor en nuestras variables para usarlos en lo que necesitemos
                mov = consulta.getString(consulta.getColumnIndex("name_movie"));
                String hora= consulta.getString(consulta.getColumnIndex("id_room_projection"));
                room= consulta.getString(consulta.getColumnIndex("id_room_projection"));
                peli.add(mov+",Hora: "+hora+",Sala: "+room);
            } while (consulta.moveToNext());
        }
        else{
            peli.add("No hay peliculas en este cine");
        }



    }
    private void cine(){
        cines.add("Seleccione un cine");
        try {
            db=SQLiteDatabase.openDatabase("/data/data/com.example.cinetek/databases/cinetek.db",null,SQLiteDatabase.CREATE_IF_NECESSARY);

        }catch (Exception  e){
            createDataBase();
        };
        Cursor branch = db.rawQuery("SELECT name_branch FROM Branches", null);

        if (branch != null) {
            branch.moveToFirst();
            do {
                //Asignamos el valor en nuestras variables para usarlos en lo que necesitemos
                @SuppressLint("Range") String branches = branch.getString(branch.getColumnIndex("name_branch"));
                cines.add(branches);
            } while (branch.moveToNext());
        }
    }
    private void cargar_img(){
        img_asientos = getActivity().findViewById(R.id.asientos_img);
        String img;
        String query="Select rows_room,columns_room from rooms where id_room="+Integer.parseInt(room)+";" ;

        Cursor consulta = db.rawQuery(query, null);
        if (consulta != null) {
            consulta.moveToFirst();
            do {
                //Asignamos el valor en nuestras variables para usarlos en lo que necesitemos
                @SuppressLint("Range")String fila = consulta.getString(consulta.getColumnIndex("rows_room"));
                @SuppressLint("Range")String columna= consulta.getString(consulta.getColumnIndex("columns_room"));
                img="sala_"+fila+"x"+columna;
                try {
                    int img_id =getContext().getResources().getIdentifier("drawable/"+img,null,getContext().getPackageName());
                    img_asientos.setImageResource(img_id);
                }catch (Error e){
                    img_asientos.setImageResource(R.drawable.not_found);
                }

            } while (consulta.moveToNext());
        }


    }
    private void createDataBase(){
        //creacion y populacion inicial de la tabla
        db=SQLiteDatabase.openOrCreateDatabase("/data/data/com.example.cinetek/databases/cinete.db",null);
        //tabla de facturas
            db.rawQuery("CREATE TABLE Bills (id_bill integer NOT NULL CONSTRAINT Bills_pkey PRIMARY KEY AUTOINCREMENT NOT NULL, total_bill DOUBLE NOT NULL, id_employee_bill integer NOT NULL CONSTRAINT \"id_employee_fk \" REFERENCES Employees (id_employee), id_client_bill integer NOT NULL CONSTRAINT \"id_client_fk \" REFERENCES Clients (id_client));",null);
        //tabla de sucursales
        db.rawQuery("CREATE TABLE \"Branches\"\n" +
                "(\n" +
                "    id_branch integer NOT NULL CONSTRAINT \"Branches_pkey\" PRIMARY KEY AUTOINCREMENT NOT NULL,\n" +
                "    name_branch text NOT NULL,\n" +
                "    cant_rooms_branch integer NOT NULL,\n" +
                "    address_branch text NOT NULL\n" +
                ");",null);
        //tabla de clasificaciones
        db.rawQuery("CREATE TABLE \"Classifications\"\n" +
                "(\n" +
                "    id_classif integer NOT NULL CONSTRAINT \"Classifications_pkey\" PRIMARY KEY AUTOINCREMENT NOT NULL,\n" +
                "    classif text NOT NULL\n" +
                ");",null);
        //tabla de Clientes
        db.rawQuery("CREATE TABLE \"Clients\"\n" +
                "(\n" +
                "    id_client integer NOT NULL,\n" +
                "    first_name_client text NOT NULL,\n" +
                "    second_name_client text,\n" +
                "    first_last_name_client text NOT NULL,\n" +
                "    second_last_name_client text,\n" +
                "    phone_client text NOT NULL,\n" +
                "    birth_date_client date NOT NULL,\n" +
                "    password_client text NOT NULL,\n" +
                "    user_client text NOT NULL UNIQUE,\n" +
                "    CONSTRAINT \"Clients_pkey\" PRIMARY KEY (id_client)\n" +
                ");",null);
        //tabla de Directores
        db.rawQuery("CREATE TABLE \"Directors\"\n" +
                "(\n" +
                "    id_director integer NOT NULL CONSTRAINT \"Directors_pkey\" PRIMARY KEY AUTOINCREMENT NOT NULL,\n" +
                "    name_director text\n" +
                ");",null);
        //tabla de empleados
        db.rawQuery("CREATE TABLE Employees (id_employee integer NOT NULL CONSTRAINT Employees_pkey PRIMARY KEY AUTOINCREMENT NOT NULL, first_name_employee text NOT NULL, second_name_employee text, first_last_name_employee text NOT NULL, second_last_name_employee text, phone_employee text NOT NULL, birth_date_employee date NOT NULL, admission_date_employee date NOT NULL, password_employee text NOT NULL, user_employee text NOT NULL UNIQUE, id_branch_employee integer NOT NULL CONSTRAINT \"id_employee_branch_fk \" REFERENCES Branches (id_branch), id_rol_employee integer NOT NULL CONSTRAINT id_employee_rol_fk REFERENCES Roles (id_rol));",null);
        //tabla de peliculas
        db.rawQuery("CREATE TABLE Movies (id_movie integer NOT NULL CONSTRAINT Movies_pkey PRIMARY KEY AUTOINCREMENT NOT NULL, name_movie text NOT NULL, duration_movie text NOT NULL, poster_movie text NOT NULL, price_elder_movie integer NOT NULL, price_adult_movie integer NOT NULL, price_kid_movie integer NOT NULL, id_director_movie integer NOT NULL CONSTRAINT \"id_movie_director_fk \" REFERENCES Directors (id_director), id_classif_movie integer NOT NULL CONSTRAINT id_movie_classif_fk REFERENCES Classifications (id_classif), id_protagonist_movie integer NOT NULL CONSTRAINT id_movie_prota_fk REFERENCES Protagonists (id_protagonist));\n",null);
        //tabla de Proyecciones
        db.rawQuery("CREATE TABLE Projections (id_projection integer NOT NULL CONSTRAINT Projections_pkey PRIMARY KEY AUTOINCREMENT NOT NULL, time_projection text NOT NULL,day_projection DATE NOT NULL, id_movie_projection integer NOT NULL CONSTRAINT \"id_movie_fk \" REFERENCES Movies (id_movie), id_room_projection integer NOT NULL CONSTRAINT \"id_room_fk \" REFERENCES Rooms (id_room));",null);
        //tabla de protagonistas
        db.rawQuery("CREATE TABLE \"Protagonists\"\n" +
                "(\n" +
                "    id_protagonist integer NOT NULL CONSTRAINT  \"Protagonists_pkey\" PRIMARY KEY AUTOINCREMENT NOT NULL,\n" +
                "    name_protagonist text\n" +
                ");",null);
        //tabla de Roles
        db.rawQuery("CREATE TABLE \"Roles\"\n" +
                "(\n" +
                "    id_rol integer NOT NULL CONSTRAINT \"Roles_pkey\" PRIMARY KEY AUTOINCREMENT NOT NULL,\n" +
                "    name_rol text NOT NULL,\n" +
                "    description_rol text NOT NULL\n" +
                ");",null);
        //tabla de salas

        db.rawQuery("CREATE TABLE Rooms (id_room integer NOT NULL CONSTRAINT rooms_pkey PRIMARY KEY AUTOINCREMENT NOT NULL, capacity_room integer NOT NULL, rows_room integer NOT NULL, columns_room integer NOT NULL, id_branch_room integer NOT NULL CONSTRAINT id_room_branch_fk REFERENCES Branches (id_branch));",null);
        //tabla de
        db.rawQuery("CREATE TABLE Seats (id_seat integer NOT NULL CONSTRAINT Seats_pkey PRIMARY KEY AUTOINCREMENT NOT NULL, row_seat integer NOT NULL, column_seat integer NOT NULL, state_seat integer NOT NULL, id_room_seat integer NOT NULL CONSTRAINT \"id_room_seat_fk \" REFERENCES Rooms (id_room));",null);

        //populacion
        db.rawQuery("INSERT INTO Bills (id_bill, total_bill, id_employee_bill, id_client_bill) VALUES (1, 4700.0, 101110111, 202220222);",null);
        db.rawQuery("INSERT INTO Branches (id_branch, name_branch, cant_rooms_branch, address_branch) VALUES (1, 'Cartago', 10, 'Cartago');",null);
        db.rawQuery("INSERT INTO Classifications (id_classif, classif) VALUES (1, 'Adulto');",null);
        db.rawQuery("INSERT INTO Classifications (id_classif, classif) VALUES (2, 'Niño');",null);
        db.rawQuery("INSERT INTO Clients (id_client, first_name_client, second_name_client, first_last_name_client, second_last_name_client, phone_client, birth_date_client, password_client, user_client) VALUES (101110111, 'Primer Nombre', 'Segundo Nombre', 'Primer Apellido', 'Segundo Apellido', '11111111', '01-01-2021', 'Pasword123', 'User123');\n",null);
        db.rawQuery("INSERT INTO Clients (id_client, first_name_client, second_name_client, first_last_name_client, second_last_name_client, phone_client, birth_date_client, password_client, user_client) VALUES (202220222, 'Nombre1', 'SegNombre1', 'Apellido1', 'SegApellido1', '22222222', '2000-01-01', 'contraseña', 'usuario');",null);
        db.rawQuery("INSERT INTO Directors (id_director, name_director) VALUES (1, 'Director Inventado');",null);
        db.rawQuery("INSERT INTO Employees (id_employee, first_name_employee, second_name_employee, first_last_name_employee, second_last_name_employee, phone_employee, birth_date_employee, admission_date_employee, password_employee, user_employee, id_branch_employee, id_rol_employee) VALUES (101110111, 'Nombre1', 'Nombre1', 'Apellido1', 'Apellido2', '11111111', '1999-02-10', '2021-10-10', 'Contraseña', 'Usuario', 1, 1);",null);
        db.rawQuery("INSERT INTO Movies (id_movie, name_movie, duration_movie, poster_movie, price_elder_movie, price_adult_movie, price_kid_movie, id_director_movie, id_classif_movie, id_protagonist_movie) VALUES (1, 'Peli1', '1:45', 'poster1', 1400, 1500, 1200, 1, 2, 1);",null);
        db.rawQuery("INSERT INTO Projections (id_projection, time_projection,day_projection, id_movie_projection, id_room_projection) VALUES (1, '14:40','2021-11-1', 1, 1);",null);
        db.rawQuery("INSERT INTO Protagonists (id_protagonist, name_protagonist) VALUES (1, 'Personaje inventado');",null);
        db.rawQuery("INSERT INTO Roles (id_rol, name_rol, description_rol) VALUES (1, 'cajero', 'cobra dinero');",null);
        db.rawQuery("INSERT INTO Rooms (id_room, capacity_room, rows_room, columns_room, id_branch_room) VALUES (1, 30, 6, 5, 1);",null);
        db.rawQuery("INSERT INTO Seats (id_seat, row_seat, column_seat, state_seat, id_room_seat) VALUES (1, 3, 4, 1, 1);\n",null);
        //despues de este punto se deberia de sincronizar la tabla con la de postgress
        sincro();
    }


    private void sincro(){

    }
    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }

}