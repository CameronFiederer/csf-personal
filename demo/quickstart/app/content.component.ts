import { Component, Input, OnChanges } from '@angular/core';
import { NavBarEntry } from './nav-bar-entry.model';

@Component({
  selector: 'my-content',
  template: `<h1>This is boss ass {{entryData}}</h1>`,
})
export class ContentComponent  { 
    @Input() entryToDisplay: NavBarEntry;
    entryData:string;
    
    fetchEntryData() {
        // Retrieve this entry's data from an api
        this.entryData = this.entryToDisplay.name;
    }

    ngOnChanges() {
        this.fetchEntryData();
    }
}
