import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { clientsModel } from 'src/app/models/clientsModel';
import { ClienteService } from 'src/app/services/cliente.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent implements OnInit {

  list: clientsModel[];
  cliente: clientsModel;
  form: FormGroup;

  constructor(private formBuilder: FormBuilder, private clientService: ClienteService, private toastr: ToastrService) {
    this.form = this.formBuilder.group({
      id1:0,
      nombre: ['', [Validators.required]],
      nombre2: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      apellido1: ['', [Validators.required, Validators.maxLength(16)]],
      apellido2: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      cedula: ['', [Validators.required, Validators.maxLength(16)]],
      numeroTelefono: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      fechaNacimiento: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      usuario: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      password: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],

    });
  }

  ngOnInit(): void {
    this.clientService.obtenerCliente().subscribe(data => {
      console.log(data);
      this.cliente = data;
      this.form.patchValue({
        nombre: this.cliente.first_Name_Client,
        nombre2: this.cliente.second_Name_Client,
        apellido1: this.cliente.first_Last_Name_Client,
        apellido2: this.cliente.second_Last_Name_Client,
        cedula: this.cliente.id_Client,
        numeroTelefono: this.cliente.phone_Client,
        fechaNacimiento: this.cliente.birth_Date_Client,
        usuario: this.cliente.user_Client,
        password: this.cliente.password_Client,
      })
    })
  }
  guardarCliente() {
    const cliente: clientsModel = {
      first_Name_Client: this.form.get('nombre').value,
      second_Name_Client: this.form.get('nombre2').value,
      first_Last_Name_Client: this.form.get('apellido1').value,
      second_Last_Name_Client: this.form.get('apellido2').value,
      id_Client: this.form.get('cedula').value,
      phone_Client: this.form.get('numeroTelefono').value,
      password_Client: this.form.get('password').value,
      user_Client: this.form.get('usuario').value,
      
      birth_Date_Client: this.form.get('fechaNacimiento').value+"T00:00:00",
    
    }
    this.clientService.guardarCliente(cliente).subscribe(data => {
      this.toastr.success('Tarjeta Guardada', 'Agregada Exitosamente');
      this.form.reset();
    })

    console.log(this.form);
    console.log(cliente);
  }

}
