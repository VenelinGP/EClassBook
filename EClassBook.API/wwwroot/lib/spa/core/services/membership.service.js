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
const data_service_1 = require('./data.service');
const user_1 = require('../models/user');
let MembershipService = class MembershipService {
    constructor(accountService) {
        this.accountService = accountService;
        this._accountRegisterAPI = 'api/account/register/';
        this._accountLoginAPI = 'api/account/authenticate/';
        this._accountLogoutAPI = 'api/account/logout/';
    }
    register(newUser) {
        this.accountService.set(this._accountRegisterAPI);
        return this.accountService.post(JSON.stringify(newUser));
    }
    login(creds) {
        this.accountService.set(this._accountLoginAPI);
        return this.accountService.post(JSON.stringify(creds));
    }
    logout() {
        this.accountService.set(this._accountLogoutAPI);
        return this.accountService.post(null, false);
    }
    isUserAuthenticated() {
        var _user = localStorage.getItem('user');
        if (_user != null)
            return true;
        else
            return false;
    }
    getLoggedInUser() {
        var _user;
        if (this.isUserAuthenticated()) {
            var _userData = JSON.parse(localStorage.getItem('user'));
            _user = new user_1.User(_userData.Username, _userData.Password);
        }
        return _user;
    }
};
MembershipService = __decorate([
    core_1.Injectable(), 
    __metadata('design:paramtypes', [data_service_1.DataService])
], MembershipService);
exports.MembershipService = MembershipService;
