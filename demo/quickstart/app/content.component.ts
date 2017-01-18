import { Component, Input } from '@angular/core';

@Component({
  selector: 'my-content',
  template: `<h1>This is boss ass {{name}}</h1>`,
})
export class ContentComponent  { 
    @Input() name = 'content'; 
}
