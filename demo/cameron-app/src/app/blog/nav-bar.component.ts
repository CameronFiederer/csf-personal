import { Component } from '@angular/core';
import { NavBarEntry } from './nav-bar-entry.model';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'my-nav-bar',
  templateUrl: './nav-bar.component.html',
})
export class NavBarComponent  { 
    navEntries: NavBarEntry[];
    selectedEntryId: Number;
    constructor(
        private route: ActivatedRoute,
        private router: Router
    ) {}

    ngOnInit(): void {
        this.getNavEntries();
        let theseRams:Params= this.route.params;

        this.route.params.subscribe(params => {
            let id = params['id'];
            console.log(id);
            this.selectedEntryId = id;
        });
    }

    getNavEntries(): void {
        // Replace with Api call
        this.navEntries = [{id:1, name: 'Declaration of Intent', type: 'Post', isSelected: false},
                           {id:2, name: 'Initial Goals', type: 'Post', isSelected: false},
                           {id:3, name: 'Moving On', type: 'Post', isSelected: false}];
    }
    
    selectNavEntry(navEntry: NavBarEntry): void {
        this.router.navigate(['/blog', navEntry.id]);
    }
}
