import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { ModuleMapLoaderModule } from '@nguniversal/module-map-ngfactory-loader';
import { AppComponent } from './app.component';
import { AppModule } from './app.module';
import { TaskService } from './services/TaskService';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
    imports: [AppModule, ServerModule, ModuleMapLoaderModule],
    bootstrap: [AppComponent]
})
export class AppServerModule { }
