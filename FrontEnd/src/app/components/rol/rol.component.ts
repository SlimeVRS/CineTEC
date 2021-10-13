import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { rolModel } from 'src/app/models/rolModel';
import { RolService } from 'src/app/services/rol.service';

@Component({
  selector: 'app-rol',
  templateUrl: './rol.component.html',
  styleUrls: ['./rol.component.css']
})
export class RolComponent implements OnInit {
  form: FormGroup;
  list: rolModel[];
  rol: rolModel;
  constructor(private formBuilder: FormBuilder, private rolService: RolService, private toastr: ToastrService) {
    this.form = this.formBuilder.group({
      name_rol: ['', [Validators.required]],
      description_rol: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
    });
   }


  ngOnInit() {
    this.rolService.obtenerRol().subscribe(data => {
      console.log(data);
      this.rol = data;
      this.form.patchValue({
        name_rol: this.rol.name_Rol,
        description_rol: this.rol.description_Rol,
       
      })
    })
  }
  guardarCliente() {
    const rol: rolModel = {
      name_Rol: this.form.get('name_rol').value,
      description_Rol: this.form.get('description_rol').value
    }
    this.rolService.guardarRol(rol).subscribe(data => {
      this.toastr.success('Tarjeta Guardada', 'Agregada Exitosamente');
      this.form.reset();
    })

    console.log(this.form);
    console.log(rol);
  }
}
