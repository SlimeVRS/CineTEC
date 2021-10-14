import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { oficcesModel } from 'src/app/models/oficcesModels';
import { OfficesService } from 'src/app/services/offices.service';

@Component({
  selector: 'app-offices',
  templateUrl: './offices.component.html',
  styleUrls: ['./offices.component.css']
})
export class OfficesComponent implements OnInit {
  list: oficcesModel[];
  offices: oficcesModel;
  form2: FormGroup;

  constructor(private formBuilder: FormBuilder, private officesService: OfficesService, private toastr: ToastrService) {
    this.form2 = this.formBuilder.group({
      id: 0,
      inputOfficesName: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      inputLocation: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(1)]],
      inputNumberRooms: ['', [Validators.required, Validators.maxLength(16)]],
    })
  }


  ngOnInit(): void {
    this.officesService.obtenerOffice().subscribe(data => {
      console.log(data);
      this.offices = data;
      this.form2.patchValue({
        inputOfficesName: this.offices.name_Branch,
        inputLocation: this.offices.address_Branch,
        inputNumberRooms: this.offices.cant_Rooms_Branch,
       
      })
    })
  }
  guardarOffices() {
    const offices: oficcesModel = {
      name_Branch: this.form2.get('inputOfficesName').value,
      cant_Rooms_Branch: this.form2.get('inputNumberRooms').value,
      address_Branch: this.form2.get('inputLocation').value,
    }
    this.officesService.guardarOffices(offices).subscribe(data => {
      this.toastr.success('Tarjeta Guardada', 'Agregada Exitosamente');
      this.form2.reset();
    })
    console.log(this.form2);
    console.log(offices);
  }


}
