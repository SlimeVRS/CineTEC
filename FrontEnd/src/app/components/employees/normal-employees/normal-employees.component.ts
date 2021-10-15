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
      branch: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      
    })
  }
  
  ngOnInit(): void {
    this.employeeService.obtenerEmpleado().subscribe(data=>{
      console.log(data);
      this.empleado =data;
      this.form1.patchValue({
        nombre: this.empleado.first_Name_Employee,
        nombre2: this.empleado.second_Name_Employee,
        apellido1:this.empleado.first_Last_Name_Employee,
        apellido2:this.empleado.second_Last_Name_Employee,
        cedula: this.empleado.id_Employee,
        numeroTelefono: this.empleado.phone_Employee,
        fechaNacimiento: this.empleado.birth_Date_Employee,
        fechaIngreso: this.empleado.birth_Date_Employee,
        rol: this.empleado.id_Rol_Employee,
        usuario:this.empleado.user_Employee,
        contraseña: this.empleado.password_Employee,
        branch: this.empleado.id_Branch_Employee,
      })
    })
  }

  guardarEmpleado(){
    const empleado: employeesModel = {
      first_Name_Employee : this.form1.get('nombre').value,
      second_Name_Employee : this.form1.get('nombre2').value,
      first_Last_Name_Employee : this.form1.get('apellido1').value,
      second_Last_Name_Employee : this.form1.get('apellido2').value,
      id_Employee : this.form1.get('cedula').value,
      phone_Employee : this.form1.get('numeroTelefono').value,
      birth_Date_Employee : this.form1.get('fechaNacimiento').value,
      admission_Date_Employee: this.form1.get('fechaIngreso').value,
      id_Rol_Employee: this.form1.get('rol').value,
      user_Employee : this.form1.get('usuario').value,
      password_Employee : this.form1.get('contraseña').value,
      id_Branch_Employee: this.form1.get('branch').value,
    }
    this.employeeService.guardarEmpleado(empleado).subscribe(data=>{
      this.toastr.success('Tarjeta Guardada', 'Agregada Exitosamente');
      this.form1.reset();
    })
    
    console.log(this.form1);
    console.log(empleado);
  }

}
