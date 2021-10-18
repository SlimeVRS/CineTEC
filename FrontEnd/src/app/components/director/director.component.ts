import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { directorModel } from 'src/app/models/directorModel';
import { DirectorService } from 'src/app/services/director.service';

@Component({
  selector: 'app-director',
  templateUrl: './director.component.html',
  styleUrls: ['./director.component.css']
})
export class DirectorComponent implements OnInit {

  list: directorModel[];
  cliente: directorModel;
  form: FormGroup;

  constructor(private formBuilder: FormBuilder, private directorService: DirectorService, private toastr: ToastrService) {
    this.form = this.formBuilder.group({
      id1:0,
      name_Director: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
    this.directorService.obtenerCliente().subscribe(data => {
      console.log(data);
      this.cliente = data;
      this.form.patchValue({
        name_Director: this.cliente.name_Director,

      })
    })
  }
  guardarCliente() {
    const cliente: directorModel = {
      name_Director: this.form.get('name_Director').value,
      
    }
    this.directorService.guardarCliente(cliente).subscribe(data => {
      this.toastr.success('Director Guardada', 'Agregada Exitosamente');
      this.form.reset();
    })

    console.log(this.form);
    console.log(cliente);
  }

}
