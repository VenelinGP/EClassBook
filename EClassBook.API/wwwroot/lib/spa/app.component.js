"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
const core_1 = require('@angular/core');
const common_1 = require('@angular/common');
require('rxjs/add/operator/map');
const core_2 = require('@angular/core');
core_2.enableProdMode();
const membership_service_1 = require('./core/services/membership.service');
let AppComponent = class AppComponent {
    constructor(membershipService, location) {
        this.membershipService = membershipService;
        this.location = location;
    }
    ngOnInit() {
        this.location.go('/');
    }
    isUserLoggedIn() {
        return this.membershipService.isUserAuthenticated();
    }
    getUserName() {
        if (this.isUserLoggedIn()) {
            var _user = this.membershipService.getLoggedInUser();
            return _user.Username;
        }
        else
            return 'Account';
    }
    logout() {
        this.membershipService.logout()
            .subscribe(res => {
            localStorage.removeItem('user');
        }, error => console.error('Error: ' + error), () => { });
    }
};
AppComponent = __decorate([
    core_1.Component({
        selector: 'eclassbook-app',
        templateUrl: './app/app.component.html',
    }), 
    __metadata('design:paramtypes', [membership_service_1.MembershipService, common_1.Location])
], AppComponent);
exports.AppComponent = AppComponent;
