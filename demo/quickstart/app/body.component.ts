import { Component } from '@angular/core';
import { NavBarEntry } from './nav-bar-entry.model';

@Component({
  selector: 'my-body',
  template: `<my-nav-bar (navSelectionUpdated)='onUpdate($event)'></my-nav-bar><my-content [entryToDisplay]=selectedEntry></my-content>`,
})
export class BodyComponent  { 
    selectedEntry: NavBarEntry = new NavBarEntry('hah','hah','hah');

    onUpdate(event:NavBarEntry){
        this.selectedEntry = event;
    }
}
