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
      name: ['', [Validators.required]],
      description: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
    });
   }


  ngOnInit() {
    this.rolService.obtenerRol().subscribe(data => {
      console.log(data);
      this.rol = data;
      this.form.patchValue({
        name: this.rol.name,
        description: this.rol.description,
       
      })
    })
  }

  guardarCliente() {
    const rol: rolModel = {
      name: this.form.get('name').value,
      description: this.form.get('description').value
    }
    this.rolService.guardarRol(rol).subscribe(data => {
      this.toastr.success('Tarjeta Guardada', 'Agregada Exitosamente');
      this.form.reset();
    })

    console.log(this.form);
    console.log(rol);
  }
}
