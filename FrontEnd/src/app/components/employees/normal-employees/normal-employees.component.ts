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
        nombre: this.empleado.first_name,
        nombre2: this.empleado.second_name,
        apellido1:this.empleado.first_last_name,
        apellido2:this.empleado.second_last_name,
        cedula: this.empleado.id,
        numeroTelefono: this.empleado.phone,
        fechaNacimiento: this.empleado.birth_date,
        fechaIngreso: this.empleado.birth_date,
        rol: this.empleado.rol,
        usuario:this.empleado._user,
        contraseña: this.empleado._password
      })
    })
  }

  guardarEmpleado(){
    const empleado: employeesModel = {
      first_name : this.form1.get('nombre').value,
      second_name : this.form1.get('nombre2').value,
      first_last_name : this.form1.get('apellido1').value,
      second_last_name : this.form1.get('apellido2').value,
      id : this.form1.get('cedula').value,
      phone : this.form1.get('numeroTelefono').value,
      birth_date : this.form1.get('fechaNacimiento').value,
      admission_date: this.form1.get('fechaIngreso').value,
      rol: this.form1.get('rol').value,
      _user : this.form1.get('usuario').value,
      _password : this.form1.get('contraseña').value,
      
    }
    this.employeeService.guardarEmpleado(empleado).subscribe(data=>{
      this.toastr.success('Tarjeta Guardada', 'Agregada Exitosamente');
      this.form1.reset();
    })
    
    console.log(this.form1);
    console.log(empleado);
  }

}
