import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent }   from './app.component';
import { UserService } from './user.service';

@NgModule({
    imports: [BrowserModule,
            FormsModule,
            HttpModule],
    declarations: [AppComponent],
    providers: [
        UserService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }