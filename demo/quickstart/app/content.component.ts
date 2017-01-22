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
        if(this.entryToDisplay.id == 1) {
            this.entryData = 'I am Cameron Fiederer. This website through which I intend to both showcase and experiment with various technologies in my free time. At the time of this writing, I am building this using Angular 2, and intend to host the static content via AWS Cloudfront. Once I have the initial setup for this complete, I plan to build out backing services via AWS Lambda and AWS Api Gateway. Somewhere along the way I\'m going to need to figure out a solution for automating testing and deployments. This may all change, and I certainly hope in the long term it does, but with the power of proper source control everything will be tracked. Maybe I use too many commas while writing - hell this will give me a chance to improve my grammar while I am at it. Here\'s to the wild world of programming.';
        } if(this.entryToDisplay.id == 2) {
            this.entryData = 'So now that I have covered some of the long term goals, let\'s see what things I need to improve for this site. Firstly - typing these entries directly into my javascript is probably a bad idea. Or rather, just not as clean as it could be if I set up a backing data store or even just moved these logs into a json file. And perhaps even typing all this out is a bit silly - I should probably just track this in some kind of workflow management tool. But I need content to display and I was hoping for something of a blogging app for my first demo so we\'ll stick with this for now. I believe that my first actual \'story\' will be implementing Angular SPA like routing to display these posts. Afterwords I\'ll look at prettifying the page a bit.';
        } else {
            this.entryData = this.entryToDisplay.name;
        }
    }

    ngOnChanges() {
        this.fetchEntryData();
    }
}
