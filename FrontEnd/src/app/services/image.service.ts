
import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
 
 
interface ImageInfo{
  title:string;
  description:string;
  link:string;
}
 
@Injectable({
  providedIn: 'root'
})
 
export class ImageService {
  private images:object[] = [];
  private url: string = 'https://api.imgur.com/3/image';
  private clientId: string = '73bec0473e40be8';
  imageLink:any;
 
 
  constructor(private http:HttpClient) { }
  
  async uploadImage(imageFile:File, infoObject:{}){
    let formData = new FormData();
    formData.append('image', imageFile, imageFile.name);
 
    let header = new HttpHeaders({
      "authorization": 'Client-ID '+this.clientId
    });
   
    const imageData = await this.http.post(this.url, formData, {headers:header}).toPromise();
    this.imageLink = imageData['data'].link;
 
    let newImageObject:ImageInfo = {
      title:infoObject["title"],
      description:infoObject["description"],
      link:this.imageLink
    };
 
    this.images.unshift(newImageObject);
 
  }
 
  getImages(){
    return this.images;
  }
}