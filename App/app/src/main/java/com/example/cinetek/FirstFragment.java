package com.example.cinetek;

import android.os.Bundle;
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
    private ImageView img_asientos;
    private ArrayAdapter<String> adapterCines;
    private ArrayAdapter<String> adapterPeli;
    private ArrayAdapter<String> adapterHora;
    private ArrayList<String> cines;
    private ArrayList<String> peli;
    private ArrayList<String> hora;
    private String cinema;
    private String pelicula;
    private String horario;


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
                if (!cinema.equals("Seleccione un cine")){
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
                pelicula = (String) SpinPeli.getAdapter().getItem(posicion);
                if (!pelicula.equals("Seleccione una pelicula")){
                    spin_hora();
                }

            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });
    }

    private void spin_hora(){
        //Obtencion del spin
        SpinHora = getActivity().findViewById(R.id.spin_hora);
        //creacion de los arrays
        hora=new ArrayList();
        //llamada de la funcion de carga de los cines
        hora();
        //carga de los arrays a los adapters
        adapterHora=new ArrayAdapter<String>(getActivity(),android.R.layout.simple_spinner_item,hora);
        adapterHora.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        //asignacion de los adapters a los spinners
        SpinHora.setAdapter(adapterHora);
        SpinHora.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int posicion, long l) {
                horario = (String) SpinHora.getAdapter().getItem(posicion);
                if (!horario.equals("Seleccione una Hora")){
                    Toast.makeText(getActivity(),"cine:"+cinema+", pelicula:"+pelicula+", hora:"+horario,Toast.LENGTH_LONG).show();
                    img_asientos = getActivity().findViewById(R.id.asientos_img);
                    img_asientos.setImageResource(R.drawable.sala_1);
                }

            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });
    }
    private void hora(){
        hora.add("Seleccione una Hora");
        hora.add("10:00 pm");
        hora.add("04:30 pm");
        hora.add("11:20 am");
    }
    private void pelicula() {
        peli.add("Seleccione una pelicula");
        peli.add("Son como niños");
        peli.add("Quieren volverme loco");
        peli.add("Las locuras del emperador");
    }
    private void cine(){
        cines.add("Seleccione un cine");
        cines.add("Terramall");
        cines.add("Cartago");
        cines.add("Heredia");

    }
    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }

}