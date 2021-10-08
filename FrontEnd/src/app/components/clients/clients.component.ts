import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { clientsModel } from 'src/app/models/clientsModel';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent implements OnInit {

  list: clientsModel[];
  cliente: clientsModel;

  constructor(private formBuilder: FormBuilder, private clientService: ClienteService) {
    this.form = this.formBuilder.group({
      id: 0,
      nombre: ['', [Validators.required]],
      nombre2: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      apellido1: ['', [Validators.required, Validators.maxLength(16)]],
      apellido2: ['', [Validators.required, Validators.maxLength(5), Validators.minLength(5)]],
      cedula: ['', [Validators.required, Validators.maxLength(16)]],
      numeroTelefono: ['', [Validators.required, Validators.maxLength(6), Validators.minLength(3)]],
      fechaNacimiento: ['', [Validators.required, Validators.maxLength(5), Validators.minLength(1)]],
      usuario: ['', [Validators.required, Validators.maxLength(5), Validators.minLength(1)]],
      contraseña: ['', [Validators.required, Validators.maxLength(5), Validators.minLength(1)]],

    })
  }
  form: FormGroup;
  ngOnInit(): void {
    this.clientService.obtenerCliente().subscribe(data=>{
      console.log(data);
      this.cliente =data;
      this.form.patchValue({
        nombre: this.cliente.nombre,
        nombre2: this.cliente.nombre2,
        apellido1:this.cliente.apellido1,
        apellido2:this.cliente.apellido2,
        cedula: this.cliente.cedula,
        numeroTelefono: this.cliente.numeroTelefono,
        fechaNacimiento: this.cliente.fechaNacimiento,
        usuario:this.cliente.usuario,
        contraseña: this.cliente.contraseña
      })
    })
  }
  guardarCliente(){
    
  }

}
