
import { ImageService } from 'src/app/services/image.service';
import { Component, OnInit} from '@angular/core';
import { ImageSnippet } from './imageSnipet.component';

@Component({
  selector: 'app-imagemanager',
  templateUrl: './imagemanager.component.html',
  styleUrls: ['./imagemanager.component.css']
})


export class ImagemanagerComponent implements OnInit {
  selectedFile: ImageSnippet;
  onFileSelected(event:any){
    console.log(event);
  }
  onUpload(){
    
  }

  constructor(private imageService: ImageService) { }
  private onSuccess() {
    this.selectedFile.pending = false;
    this.selectedFile.status = 'ok';
  }

  private onError() {
    this.selectedFile.pending = false;
    this.selectedFile.status = 'fail';
    this.selectedFile.src = '';
  }

  processFile(imageInput: any) {
    const file: File = imageInput.files[0];
    const reader = new FileReader();

    reader.addEventListener('load', (event: any) => {

      this.selectedFile = new ImageSnippet(event.target.result, file);

      this.imageService.uploadImage(this.selectedFile.file).subscribe(
        (res) => {
          this.onSuccess();
        },
        (err) => {
        this.onError();
        })
    });

    reader.readAsDataURL(file);
  }
  ngOnInit(): void {
  }

}
