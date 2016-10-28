import { Component, OnInit } from '@angular/core';
import { HeadmasterService, Headmaster } from './headmaster.service';


@Component({
    selector: 'my-app',
    templateUrl: '../templates/headmaster.service.html',

    providers: [
        HeadmasterService
    ]
})
export class AppComponent extends OnInit {

    constructor(private _service: HeadmasterService) {
        super();
    }

    ngOnInit() {
        this._service.loadData().then(data => {
            this.headmasters = data;
            this.address = data['Address'];
            this.role = data['Role'];
        })
    }
    headmasters: Headmaster[] = [];
    address: Headmaster[] = [];
    role: Headmaster[] = [];
}