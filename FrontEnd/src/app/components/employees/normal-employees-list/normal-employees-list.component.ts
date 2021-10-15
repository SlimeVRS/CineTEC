import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { EmpleadoService } from 'src/app/services/empleado.service';

@Component({
  selector: 'app-normal-employees-list',
  templateUrl: './normal-employees-list.component.html',
  styleUrls: ['./normal-employees-list.component.css']
})
export class NormalEmployeesListComponent implements OnInit {

  enableEdit = false;
  enableEditIndex = null;
  constructor(public employeeService: EmpleadoService, public toastr: ToastrService) { }
  ngOnInit(): void {
    this.employeeService.obtenerEmpleados();
  }
  eliminarTarjeta(id) {
    if (confirm('Desea eliminar la tarjeta?')) {
      const index = this.employeeService.list.indexOf(id);
      this.employeeService.list.splice(index, 1);
      this.employeeService.eliminarEmpleado(id).subscribe(data => {
        this.toastr.warning('Eliminar Exitoso', 'Tarjeta Eliminada');

        this.employeeService.obtenerEmpleados();
      })
    }
  }
  editar(tarjeta) {
    this.employeeService.actualizar(tarjeta);
  }
  enableEditMethod(e, i) {
    this.enableEdit = true;
    this.enableEditIndex = i;
    console.log(i, e);
  }
}
