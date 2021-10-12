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
                    spin_pelicula();
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
                    spin_asiento_tipo();
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
                    Toast.makeText(getActivity(),"cine:"+cinema+", pelicula:"+pelicula+", hora:"+horario,Toast.LENGTH_LONG).show();
                    cargar_img();
                    spin_asientos_();
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
                    spin_pelicula();
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });
    }

    private  void  asientos(){
        asientos.add("Seleccione un asiento");
        String query="select id,_row,_column\n" +
                "from seats\n" +
                "where _state=1 and id_room="+room+";" ;
        Cursor consulta = db.rawQuery(query, null);
        if (consulta != null) {
            consulta.moveToFirst();
            do {
                //Asignamos el valor en nuestras variables para usarlos en lo que necesitemos
                @SuppressLint("Range")String id = consulta.getString(consulta.getColumnIndex("id"));
                @SuppressLint("Range")String fila= consulta.getString(consulta.getColumnIndex("_row"));
                @SuppressLint("Range") String columna= consulta.getString(consulta.getColumnIndex("_column"));
                asientos.add(id+",Fila: "+fila+",columna: "+columna);
            } while (consulta.moveToNext());
        }
    }
    private void asiento_tipo(){
        hora.add("Seleccione un tipo de asiento");
        String query="select price_elder,price_adult,price_kid\n" +
                "from movies\n" +
                "where name=\""+pelicula+"\";" ;
        Cursor consulta = db.rawQuery(query, null);
        if (consulta != null) {
            consulta.moveToFirst();
            do {
                //Asignamos el valor en nuestras variables para usarlos en lo que necesitemos
                @SuppressLint("Range")String ancino = consulta.getString(consulta.getColumnIndex("price_elder"));
                @SuppressLint("Range")String adulto= consulta.getString(consulta.getColumnIndex("price_adult"));
                @SuppressLint("Range") String nino= consulta.getString(consulta.getColumnIndex("price_kid"));
                hora.add("Adulto mayor: "+ancino);
                hora.add("Adulto: "+adulto);
                hora.add("Niño: "+nino);
            } while (consulta.moveToNext());
        }
    }
    @SuppressLint("Range")
    private void pelicula() {
        peli.add("Seleccione una pelicula");
        System.out.println(cinema);
        String query="select m.name,p._time,p.id_room\n" +
                "from (projections as p join movies as m on p.id_movie=m.id)\n" +
                "where p.id_room in(SELECT r.id FROM (rooms as r JOIN branches as b ON id_branch = b.id) where b.name=\""+cinema+"\");" ;
        Cursor consulta = db.rawQuery(query, null);
        if (consulta != null) {
            consulta.moveToFirst();
            do {
                //Asignamos el valor en nuestras variables para usarlos en lo que necesitemos
                mov = consulta.getString(consulta.getColumnIndex("m.name"));
                String hora= consulta.getString(consulta.getColumnIndex("p._time"));
                room= consulta.getString(consulta.getColumnIndex("p.id_room"));
                peli.add(mov+",Hora: "+hora+",Sala: "+room);
            } while (consulta.moveToNext());
        }

    }
    private void cine(){
        cines.add("Seleccione un cine");
        try {
            db=SQLiteDatabase.openDatabase("/data/data/com.example.cinetek/databases/cinetek.db",null,SQLiteDatabase.CREATE_IF_NECESSARY);

        }catch (Exception  e){
            createDataBase();
        };
        Cursor branch = db.rawQuery("SELECT name FROM Branches", null);
        if (branch != null) {
            branch.moveToFirst();
            do {
                //Asignamos el valor en nuestras variables para usarlos en lo que necesitemos
                @SuppressLint("Range") String branches = branch.getString(branch.getColumnIndex("name"));
                cines.add(branches);
            } while (branch.moveToNext());
        }
    }
    private void cargar_img(){
        img_asientos = getActivity().findViewById(R.id.asientos_img);
        String img;
        String query="Select rows,columns \n" +
                "from rooms\n" +
                "where id="+Integer.parseInt(room)+";" ;
        Cursor consulta = db.rawQuery(query, null);
        if (consulta != null) {
            consulta.moveToFirst();
            do {
                //Asignamos el valor en nuestras variables para usarlos en lo que necesitemos
                @SuppressLint("Range")String fila = consulta.getString(consulta.getColumnIndex("rows"));
                @SuppressLint("Range")String columna= consulta.getString(consulta.getColumnIndex("columns"));
                img="sala_"+fila+"x"+columna;
                int img_id =getContext().getResources().getIdentifier("drawable/"+img,null,getContext().getPackageName());
                img_asientos.setImageResource(img_id);
            } while (consulta.moveToNext());
        }


    }
    private void createDataBase(){
        //creacion y populacion inicial de la tabla
        db=SQLiteDatabase.openOrCreateDatabase("/data/data/com.example.cinetek/databases/cinete.db",null);
        //tabla de facturas
        db.rawQuery("CREATE TABLE Bills (id integer CONSTRAINT Bills_pkey PRIMARY KEY AUTOINCREMENT NOT NULL, total double NOT NULL, id_employee integer NOT NULL CONSTRAINT \"id_employee_fk \" REFERENCES Employees (id), id_client integer NOT NULL CONSTRAINT id_client_fk REFERENCES Clients (id));\n",null);
        //tabla de sucursales
        db.rawQuery("CREATE TABLE \"Branches\" \n" +
                "( \n" +
                "    id INTEGER CONSTRAINT Bills_pkey PRIMARY KEY AUTOINCREMENT  NOT NULL, \n" +
                "    name text , \n" +
                "    cant_rooms integer NOT NULL, \n" +
                "    address text   \n" +
                ");",null);
        //tabla de clasificaciones
        db.rawQuery("CREATE TABLE \"Classifications\" \n" +
                "( \n" +
                "    id integer CONSTRAINT Classifications_pkey PRIMARY KEY AUTOINCREMENT  NOT NULL, \n" +
                "    classif text\n" +
                ");",null);
        //tabla de Clientes
        db.rawQuery("CREATE TABLE \"Clients\" \n" +
                "( \n" +
                "    id integer CONSTRAINT Clients_pkey PRIMARY KEY AUTOINCREMENT  NOT NULL, \n" +
                "    first_name text , \n" +
                "    second_name text , \n" +
                "    first_last_name text NOT NULL, \n" +
                "    second_last_name text, \n" +
                "    phone text , \n" +
                "    birth_date date NOT NULL, \n" +
                "    _password text, \n" +
                "    _user text     \n" +
                ");",null);
        //tabla de Directores
        db.rawQuery("CREATE TABLE \"Directors\" \n" +
                "( \n" +
                "    id integer  CONSTRAINT \"Directors_pkey\" PRIMARY KEY AUTOINCREMENT  NOT NULL, \n" +
                "    first_name text , \n" +
                "    second_name text , \n" +
                "    first_last_name text NOT NULL, \n" +
                "    second_last_name text\n" +
                ");",null);
        //tabla de empleados
        db.rawQuery("CREATE TABLE Employees (id integer CONSTRAINT Employees_pkey PRIMARY KEY AUTOINCREMENT NOT NULL, first_name text NOT NULL, second_name text, first_last_name text NOT NULL, second_last_name text, phone text NOT NULL, birth_date date NOT NULL, admission_date date NOT NULL, _password text NOT NULL, _user text NOT NULL, id_branch integer NOT NULL CONSTRAINT id_employee_branch_fk REFERENCES Branches (id), id_rol integer NOT NULL CONSTRAINT id_employee_rol_fk REFERENCES Roles (id));\n",null);
        //tabla de peliculas
        db.rawQuery("CREATE TABLE Movies (id integer CONSTRAINT Movies_pkey PRIMARY KEY AUTOINCREMENT NOT NULL, name text NOT NULL, duration text NOT NULL, poster text NOT NULL, price_elder integer NOT NULL, price_adult integer NOT NULL, price_kid integer NOT NULL, id_director integer NOT NULL CONSTRAINT id_movie_director_fk REFERENCES Directors (id), id_classif integer NOT NULL CONSTRAINT id_movie_classif_fk REFERENCES Classifications (id), id_protagonist integer NOT NULL CONSTRAINT id_movie_prota_fk REFERENCES Protagonists (id));\n",null);
        //tabla de Proyecciones
        db.rawQuery("CREATE TABLE Projections (id integer CONSTRAINT Projections_pkey PRIMARY KEY AUTOINCREMENT NOT NULL, _time text NOT NULL, id_movie integer NOT NULL CONSTRAINT id_movie_fk REFERENCES Movies (id), id_room integer NOT NULL CONSTRAINT id_room_fk REFERENCES Rooms (id));\n",null);
        //tabla de protagonistas
        db.rawQuery("CREATE TABLE \"Protagonists\" \n" +
                "( \n" +
                "    id integer CONSTRAINT \"Protagonists_pkey\" PRIMARY KEY AUTOINCREMENT  NOT NULL, \n" +
                "    first_name text  NOT NULL, \n" +
                "    second_name text , \n" +
                "    first_last_name text  NOT NULL, \n" +
                "    second_last_name text\n" +
                ");",null);
        //tabla de Roles
        db.rawQuery("CREATE TABLE \"Roles\" \n" +
                "( \n" +
                "    id integer CONSTRAINT  \"Roles_pkey\" PRIMARY KEY AUTOINCREMENT  NOT NULL, \n" +
                "    name text , \n" +
                "    description text\n" +
                ");",null);
        //tabla de salas

        db.rawQuery("CREATE TABLE Rooms (id integer CONSTRAINT rooms_pkey PRIMARY KEY AUTOINCREMENT NOT NULL, capacity integer NOT NULL, \"rows\" integer NOT NULL, columns integer NOT NULL, id_branch integer NOT NULL CONSTRAINT id_room_branch_fk REFERENCES Branches (id));\n",null);
        //tabla de
        db.rawQuery("CREATE TABLE Seats (id integer CONSTRAINT Seats_pkey PRIMARY KEY AUTOINCREMENT NOT NULL, _row integer NOT NULL, _column integer NOT NULL, _state integer NOT NULL, id_room integer NOT NULL CONSTRAINT id_room_seat_fk REFERENCES Rooms (id));\n",null);

        //populacion
        db.rawQuery("INSERT INTO Bills (id, total, id_employee, id_client) VALUES (1, 4700.0, 101110111, 202220222);\n",null);
        db.rawQuery("INSERT INTO Branches (id, name, cant_rooms, address) VALUES (1, 'Cartago', 10, 'Cartago');\n",null);
        db.rawQuery("INSERT INTO Classifications (id, classif) VALUES (1, 'Adulto');",null);
        db.rawQuery("INSERT INTO Classifications (id, classif) VALUES (2, 'Niño');",null);
        db.rawQuery("INSERT INTO Clients (id, first_name, second_name, first_last_name, second_last_name, phone, birth_date, _password, _user) VALUES (101110111, 'Primer Nombre', 'Segundo Nombre', 'Primer Apellido', 'Segundo Apellido', '11111111', '01-01-2021', 'Pasword123', 'User123');\n",null);
        db.rawQuery("INSERT INTO Clients (id, first_name, second_name, first_last_name, second_last_name, phone, birth_date, _password, _user) VALUES (202220222, 'Nombre1', 'SegNombre1', 'Apellido1', 'SegApellido1', '22222222', '2000-01-01', 'contraseña', 'usuario');\n",null);
        db.rawQuery("INSERT INTO Directors (id, first_name, second_name, first_last_name, second_last_name) VALUES (1, 'Dnombre1', 'Dnombre1', 'Dapellido1', 'Dapellido1');\n",null);
        db.rawQuery("INSERT INTO Employees (id, first_name, second_name, first_last_name, second_last_name, phone, birth_date, admission_date, _password, _user, id_branch, id_rol) VALUES (101110111, 'Nombre1', 'Nombre1', 'Apellido1', 'Apellido2', '11111111', '1999-02-10', '2021-10-10', 'Contraseña', 'Usuario', 1, 1);\n",null);
        db.rawQuery("INSERT INTO Movies (id, name, duration, poster, price_elder, price_adult, price_kid, id_director, id_classif, id_protagonist) VALUES (1, 'Peli1', '1:45', 'poster1', 1400, 1500, 1200, 1, 2, 1);\n",null);
        db.rawQuery("INSERT INTO Projections (id, _time, id_movie, id_room) VALUES (1, '14:40', 1, 1);\n",null);
        db.rawQuery("INSERT INTO Protagonists (id, first_name, second_name, first_last_name, second_last_name) VALUES (1, 'Pnombre1', 'Pnombre1', 'Papellido1', 'Papellido1');\n",null);
        db.rawQuery("INSERT INTO Roles (id, name, description) VALUES (1, 'cajero', 'cobra dinero');",null);
        db.rawQuery("INSERT INTO Rooms (id, capacity, \"rows\", columns, id_branch) VALUES (1, 30, 6, 5, 1);\n",null);
        db.rawQuery("INSERT INTO Seats (id, _row, _column, _state, id_room) VALUES (1, 3, 4, 1, 1);\n",null);
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