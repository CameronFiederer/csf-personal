import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes }   from '@angular/router';

import { AppComponent } from './app.component';
import { BlogComponent }  from './blog/blog.component';
import { ContentComponent }  from './blog/content.component';
import { NavBarComponent }  from './blog/nav-bar.component';
import { HeaderComponent }  from './common/header.component';
import { FooterComponent }  from './common/footer.component';

const appRoutes: Routes = [
  // { path: 'crisis-center', component: CrisisListComponent },
  // { path: 'hero/:id',      component: HeroDetailComponent },
  {
    path: 'blog/:id',
    component: BlogComponent,
    data: { title: 'Blog' }
  },
  { 
    path: '',
    redirectTo: '/blog/1',
    pathMatch: 'full'
  },
  { path: '**', component: AppComponent }
];

@NgModule({
  declarations: [
    AppComponent, 
    BlogComponent,
    HeaderComponent,
    FooterComponent,
    NavBarComponent, 
    ContentComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
