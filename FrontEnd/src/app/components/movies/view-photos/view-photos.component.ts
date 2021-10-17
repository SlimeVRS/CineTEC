import { Component, OnInit } from '@angular/core';
import { ImageService } from 'src/app/services/image.service';

@Component({
  selector: 'app-view-photos',
  templateUrl: './view-photos.component.html',
  styleUrls: ['./view-photos.component.css']
})
export class ViewPhotosComponent implements OnInit {


  images:object[] = [];
  constructor(private imageService:ImageService) { }
 
  ngOnInit() {
    this.getAllImages();
  }
 
  getAllImages(){
    this.images = this.imageService.getImages();
  }
 
}
