import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MenuComponent } from './menu/menu.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { JoblistingModule } from './joblisting/joblisting.module';
import { InternalServerComponent } from './error-pages/internal-server/internal-server.component';
import { EmployerListComponent } from './employer/employer-list/employer-list.component';
import { EmployerDetailsComponent } from './employer/employer-details/employer-details.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    NotFoundComponent,
    InternalServerComponent,
    EmployerListComponent,
    EmployerDetailsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CollapseModule.forRoot(),
    JoblistingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
