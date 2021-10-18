import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { protagonistModel } from 'src/app/models/protagonistModel';
import { ProtagonistService } from 'src/app/services/protagonist.service';

@Component({
  selector: 'app-protagonist',
  templateUrl: './protagonist.component.html',
  styleUrls: ['./protagonist.component.css']
})
export class ProtagonistComponent implements OnInit {

  list: protagonistModel[];
  cliente: protagonistModel;
  form: FormGroup;

  constructor(private formBuilder: FormBuilder, private clientService: ProtagonistService, private toastr: ToastrService) {
    this.form = this.formBuilder.group({
      id1:0,
      name_Protagonist: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
    this.clientService.obtenerCliente().subscribe(data => {
      console.log(data);
      this.cliente = data;
      this.form.patchValue({
        name_Protagonist: this.cliente.name_Protagonist,

      })
    })
  }
  guardarCliente() {
    const cliente: protagonistModel = {
      name_Protagonist: this.form.get('name_Protagonist').value,
      
    }
    this.clientService.guardarCliente(cliente).subscribe(data => {
      this.toastr.success('Protagonista Guardado', 'Agregada Exitosamente');
      this.form.reset();
    })

    console.log(this.form);
    console.log(cliente);
  }

}
