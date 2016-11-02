import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import 'rxjs/add/operator/map';
import {enableProdMode} from '@angular/core';

import { UserComponent, User } from './components/user.component';


@Component({
    selector: 'eclassbook-app',
    templateUrl: './app/app.component.html',

    providers: [
        UserComponent
    ]
})
export class AppComponent extends OnInit {

    constructor(private _service: UserComponent) {
        super();
    }

    ngOnInit() {
        this._service.loadData().then(data => {
            this.user = data;
            this.address = data['Address'];
            this.role = data['Role'];
        })
    }
    user: User[] = [];
    address: User[] = [];
    role: User[] = [];
}