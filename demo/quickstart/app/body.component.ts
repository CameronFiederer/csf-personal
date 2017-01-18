import { Component } from '@angular/core';

@Component({
  selector: 'my-body',
  template: `<my-nav-bar (selectionUpdated)='onUpdate($event)'></my-nav-bar><my-content [name]=name></my-content>`,
})
export class BodyComponent  { 
    name = 'body';

    onUpdate(event:any){
        console.log(event);
        this.name = event;
    }
}
