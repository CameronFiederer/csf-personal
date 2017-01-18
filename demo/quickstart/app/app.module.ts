import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent }  from './app.component';
import { BodyComponent }  from './body.component';
import { ContentComponent }  from './content.component';
import { NavBarComponent }  from './nav-bar.component';
import { HeaderComponent }  from './header.component';
import { FooterComponent }  from './footer.component';

@NgModule({
  imports:      [ BrowserModule, FormsModule ],
  declarations: [ AppComponent, BodyComponent, HeaderComponent, FooterComponent, NavBarComponent, ContentComponent ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
