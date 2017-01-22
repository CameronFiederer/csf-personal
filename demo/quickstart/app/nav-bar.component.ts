import { Component, Output, EventEmitter, OnInit } from '@angular/core';
import { NavBarEntry } from './nav-bar-entry.model';

@Component({
  selector: 'my-nav-bar',
  template: `<li *ngFor="let navEntry of navEntries" (click)="selectNavEntry(navEntry)">
                <span> {{navEntry.name}} </span>
             </li>`,
})
export class NavBarComponent  { 
    @Output() navSelectionUpdated = new EventEmitter();
    navEntries: NavBarEntry[];

    ngOnInit(): void {
        this.getNavEntries();
    }

    getNavEntries(): void {
        // Replace with Api call
        this.navEntries = [{id:'1', name: 'Declaration of Intent', type: 'Post'},
                           {id:'2', name: 'Initial Goals', type: 'Post'}];
    }
    
    selectNavEntry(navEntry: NavBarEntry): void {
        this.navSelectionUpdated.emit(navEntry);
    }
}
