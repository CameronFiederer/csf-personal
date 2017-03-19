import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params }   from '@angular/router';
import { Location }                 from '@angular/common';
import 'rxjs/add/operator/switchMap';
import { NavBarEntry } from './nav-bar-entry.model';

@Component({
  selector: 'my-blog',
  template: `<my-nav-bar (navSelectionUpdated)='onUpdate($event)'>
             </my-nav-bar><my-content [entryToDisplay]=selectedEntry></my-content>`,
})
export class BlogComponent implements OnInit { 
    constructor(
        private route: ActivatedRoute,
        private location: Location
    ) {}
    ngOnInit(): void {
    // this.route.params
    //     .switchMap((params: Params) => this.heroService.getHero(+params['id']))
    //     .subscribe(hero => this.hero = hero);
        console.log(this.route.params['id']);
    }

    selectedEntry: NavBarEntry = new NavBarEntry(0,'hah','hah');

    onUpdate(event:NavBarEntry){
        this.selectedEntry = event;
    }
}