import { NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { userAdminModel } from 'src/app/models/userAModel';
import { userClientModel } from 'src/app/models/userCModel';
import { UserAdminService } from 'src/app/services/user-admin.service';
import { UserClientService } from 'src/app/services/user-client.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form2: FormGroup;
  list1: userAdminModel[];
  userAdmin: userAdminModel;
  list2: userClientModel[];
  userClient: userClientModel;
  constructor(private formBuilder: FormBuilder, private UserAdminService: UserAdminService,  private UserClientService: UserClientService, private toastr: ToastrService) {
    this.form2 = this.formBuilder.group({
      id: 0,
      myUser: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      password: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
    })

    this.grabar_localstorage();
    this.obtener_localstorage();
  }

  ngOnInit(): void {

  }

  onclick() {
    console.log(this.form2.get('myUser').value);
    localStorage.setItem("USER", this.form2.get('myUser').value);

    this.UserAdminService.obtenerRol().subscribe(data => {
      console.log(data);
      this.userAdmin = data;
      this.form2.patchValue({
        myUser: this.userAdmin.user_Employee,
        password: this.userAdmin.password_Employee,
       
      })
    })

    this.UserClientService.obtenerRol().subscribe(data => {
      console.log(data);
      this.userClient = data;
      this.form2.patchValue({
        myUser: this.userClient.user_Client,
        password: this.userClient.password_Client,
       
      })
    })
  }
verificar(){
  //aquí envía a base de datos para comprobar
  let sr = {
    tipo_user: "a",
    cdl: "302570883"
  }
  if ("c" === sr.tipo_user) {
    console.log('go to clientview.');
  }
  if ("a" === sr.tipo_user) {
    console.log('go to adminview.');
  }
  
  else {
    console.log('mensaje de contraseña o user incorrecto.');
  }
}


  obtener_localstorage() {
    let tipo = JSON.parse(localStorage.getItem("Cédula"));
    console.log(tipo);
  }

  grabar_localstorage() {
    let id_Client: string = "602570888";
    let tipo = {
      rol: "cliente",
      nombre: "Diogo"
    }
    localStorage.setItem("Cédula", id_Client);
    localStorage.setItem("Rol", JSON.stringify(tipo));

  }

  guardarCliente() {
    const userclientModel: userClientModel = {
      user_Client: this.form2.get('myUser').value,
      password_Client: this.form2.get('password').value
    }
    this.UserClientService.guardarRol(userclientModel).subscribe(data => {
      this.toastr.success('Tarjeta Guardada', 'Agregada Exitosamente');
      this.form2.reset();
    })

    console.log(this.form2);
    console.log(userclientModel);
  }

  guardarCliente2() {
    const useradminModel: userAdminModel = {
      user_Employee: this.form2.get('myUser').value,
      password_Employee: this.form2.get('password').value
    }
    this.UserAdminService.guardarRol(useradminModel).subscribe(data => {
      this.toastr.success('Tarjeta Guardada', 'Agregada Exitosamente');
      this.form2.reset();
    })

    console.log(this.form2);
    console.log(useradminModel);
  }

}
