
import { ImageService } from 'src/app/services/image.service';
import { Component, OnInit } from '@angular/core';
import { ImageSnippet } from './imageSnipet.component';

@Component({
  selector: 'app-imagemanager',
  templateUrl: './imagemanager.component.html',
  styleUrls: ['./imagemanager.component.css']
})


export class ImagemanagerComponent implements OnInit {
  selectedFile: ImageSnippet;
  onFileSelected(event: any) {
    console.log(event);
  }
  onUpload() {

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

    reader.addEventListener('load', function (e) {
      e.preventDefault();
      let formData = new FormData();
      formData.append('file', file);
      fetch('http://localhost:15451/api/Movie', {
        method: 'POST',
        body: formData
      })
        .then(resp => resp.json())
        .then(data => {
          if (data.errors) {
            alert(data.errors)
          }
          else {
            console.log(data)
          }
        })
    });

    reader.readAsDataURL(file);
  }
  ngOnInit(): void {
  }

}
