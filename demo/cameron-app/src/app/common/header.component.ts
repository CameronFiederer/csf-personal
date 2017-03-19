import { Component } from '@angular/core';

@Component({
  selector: 'my-header',
  template: `<h1>This is a boss ass {{name}}</h1>`,
})
export class HeaderComponent  { name = 'header'; }