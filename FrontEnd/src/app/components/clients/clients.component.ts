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
      id: 0,
      nombre: ['', [Validators.required]],
      nombre2: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      apellido1: ['', [Validators.required, Validators.maxLength(16)]],
      apellido2: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      cedula: ['', [Validators.required, Validators.maxLength(16)]],
      numeroTelefono: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      fechaNacimiento: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      usuario: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      contraseña: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],

    })
  }
  
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
    const cliente: clientsModel = {
      nombre : this.form.get('nombre').value,
      nombre2 : this.form.get('nombre2').value,
      apellido1 : this.form.get('apellido1').value,
      apellido2 : this.form.get('apellido2').value,
      cedula : this.form.get('cedula').value,
      numeroTelefono : this.form.get('numeroTelefono').value,
      fechaNacimiento : this.form.get('fechaNacimiento').value,
      usuario : this.form.get('usuario').value,
      contraseña : this.form.get('contraseña').value,
      
    }
    this.clientService.guardarCliente(cliente).subscribe(data=>{
      this.toastr.success('Tarjeta Guardada', 'Agregada Exitosamente');
      this.form.reset();
    })
    
    console.log(this.form);
    console.log(cliente);
  }

}
