import { Component } from '@angular/core';
import { Inject } from '@angular/core';

@Component({
    template: ''
  })
export class ImageSnippet {
    pending: boolean = false;
    status: string = 'init';
    constructor(@Inject(String) public src: string, public file: File) {}
  }
  