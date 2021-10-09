import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { employeesModel } from 'src/app/models/employeesModel';
import { EmpleadoService } from 'src/app/services/empleado.service';

@Component({
  selector: 'app-normal-employees',
  templateUrl: './normal-employees.component.html',
  styleUrls: ['./normal-employees.component.css']
})
export class NormalEmployeesComponent implements OnInit {

  
  list: employeesModel[];
  empleado: employeesModel;
  form1: FormGroup;


  constructor(private formBuilder: FormBuilder, private employeeService: EmpleadoService, private toastr: ToastrService) { 
    this.form1 = this.formBuilder.group({
      id: 0,
      nombre: ['', [Validators.required]],
      nombre2: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      apellido1: ['', [Validators.required, Validators.maxLength(16)]],
      apellido2: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      cedula: ['', [Validators.required, Validators.maxLength(16)]],
      numeroTelefono: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      fechaNacimiento: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      fechaIngreso: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      rol: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      usuario: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      contraseña: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],

    })
  }
  
  ngOnInit(): void {
    this.employeeService.obtenerEmpleado().subscribe(data=>{
      console.log(data);
      this.empleado =data;
      this.form1.patchValue({
        nombre: this.empleado.nombre,
        nombre2: this.empleado.nombre2,
        apellido1:this.empleado.apellido1,
        apellido2:this.empleado.apellido2,
        cedula: this.empleado.cedula,
        numeroTelefono: this.empleado.numeroTelefono,
        fechaNacimiento: this.empleado.fechaNacimiento,
        fechaIngreso: this.empleado.fechaNacimiento,
        rol: this.empleado.rol,
        usuario:this.empleado.usuario,
        contraseña: this.empleado.contraseña
      })
    })
  }

  guardarEmpleado(){
    const empleado: employeesModel = {
      nombre : this.form1.get('nombre').value,
      nombre2 : this.form1.get('nombre2').value,
      apellido1 : this.form1.get('apellido1').value,
      apellido2 : this.form1.get('apellido2').value,
      cedula : this.form1.get('cedula').value,
      numeroTelefono : this.form1.get('numeroTelefono').value,
      fechaNacimiento : this.form1.get('fechaNacimiento').value,
      fechaIngreso: this.form1.get('fechaIngreso').value,
      rol: this.form1.get('rol').value,
      usuario : this.form1.get('usuario').value,
      contraseña : this.form1.get('contraseña').value,
      
    }
    this.employeeService.guardarEmpleado(empleado).subscribe(data=>{
      this.toastr.success('Tarjeta Guardada', 'Agregada Exitosamente');
      this.form1.reset();
    })
    
    console.log(this.form1);
    console.log(empleado);
  }

}
