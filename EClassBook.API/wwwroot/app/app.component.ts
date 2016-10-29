import { Component, OnInit } from '@angular/core';
import { UserService, User } from './user.service';


@Component({
    selector: 'my-app',
    templateUrl: '../templates/user.service.html',

    providers: [
        UserService
    ]
})
export class AppComponent extends OnInit {

    constructor(private _service: UserService) {
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