import { Component } from '@angular/core';

@Component({
  selector: 'my-footer',
  template: `<h1>This is a boss ass {{name}}</h1>`,
})
export class FooterComponent  { name = 'footer'; }