import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-imagemanager',
  templateUrl: './imagemanager.component.html',
  styleUrls: ['./imagemanager.component.css']
})
export class ImagemanagerComponent implements OnInit {
  selectedFile:null;
  onFileSelected(event:any){
    console.log(event);
  }
  onUpload(){
    
  }

  constructor() { }

  ngOnInit(): void {
  }

}
