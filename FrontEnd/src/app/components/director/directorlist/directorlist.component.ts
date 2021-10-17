import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { DirectorService } from 'src/app/services/director.service';

@Component({
  selector: 'app-directorlist',
  templateUrl: './directorlist.component.html',
  styleUrls: ['./directorlist.component.css']
})
export class DirectorlistComponent implements OnInit {


  enableEdit = false;
  enableEditIndex = null;
  constructor(public directorService:DirectorService, public toastr:ToastrService) { }
  ngOnInit(): void {
    this.directorService.obtenerClientes();
  }
  eliminarTarjeta(id){
    if(confirm('Desea eliminar la tarjeta?')){
    const index = this.directorService.list.indexOf(id);
     this.directorService.list.splice(index,1);
      this.directorService.eliminarCliente(id).subscribe(data=>{
         this.toastr.warning('Eliminar Exitoso', 'Tarjeta Eliminada');
 
         this.directorService.obtenerClientes();
      })
    }
   }
   editar(tarjeta){
     this.directorService.actualizar(tarjeta);
   }
   enableEditMethod(e, i) {
     this.enableEdit = true;
     this.enableEditIndex = i;
     console.log(i, e);
   }
}
