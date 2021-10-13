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
        nombre: this.cliente.first_name,
        nombre2: this.cliente.second_name,
        apellido1: this.cliente.first_last_name,
        apellido2: this.cliente.second_last_name,
        cedula: this.cliente.id,
        numeroTelefono: this.cliente.phone,
        fechaNacimiento: this.cliente.birth_date,
        usuario: this.cliente._user,
        password: this.cliente._password,
      })
    })
  }
  guardarCliente() {
    const cliente: clientsModel = {
      first_name: this.form.get('nombre').value,
      second_name: this.form.get('nombre2').value,
      first_last_name: this.form.get('apellido1').value,
      second_last_name: this.form.get('apellido2').value,
      id: this.form.get('cedula').value,
      phone: this.form.get('numeroTelefono').value,
      _password: this.form.get('password').value,
      _user: this.form.get('usuario').value,
      
      birth_date: this.form.get('fechaNacimiento').value+"T00:00:00",
    
    }
    this.clientService.guardarCliente(cliente).subscribe(data => {
      this.toastr.success('Tarjeta Guardada', 'Agregada Exitosamente');
      this.form.reset();
    })

    console.log(this.form);
    console.log(cliente);
  }

}
