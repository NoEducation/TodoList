import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { RouterModule, ActivatedRoute } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';


import { TaskService } from './services/TaskService';
import { TodoTask } from './model/TodoTask';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductEditorComponent } from './productEditor/productEditor.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProductEditorComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'task/:mode/:id', component: ProductEditorComponent },
      { path: 'task', component: ProductEditorComponent },
    ])
  ],
  providers: [HttpClientModule, TaskService, TodoTask, FormBuilder],
  bootstrap: [AppComponent]
})
export class AppModule { }
