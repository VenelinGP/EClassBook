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
const router_1 = require('@angular/router');
const user_1 = require('../../core/models/user');
const operationResult_1 = require('../../core/domain/operationResult');
const membership_service_1 = require('../../core/services/membership.service');
const notification_service_1 = require('../../core/services/notification.service');
let LoginComponent = class LoginComponent {
    constructor(membershipService, notificationService, router) {
        this.membershipService = membershipService;
        this.notificationService = notificationService;
        this.router = router;
    }
    ngOnInit() {
        this._user = new user_1.User('', '');
    }
    login() {
        var _authenticationResult = new operationResult_1.OperationResult(false, '');
        this.membershipService.login(this._user)
            .subscribe(res => {
            _authenticationResult.Succeeded = res.Succeeded;
            _authenticationResult.Message = res.Message;
        }, error => console.error('Error: ' + error), () => {
            if (_authenticationResult.Succeeded) {
                this.notificationService.printSuccessMessage('Welcome back ' + this._user.Username + '!');
                localStorage.setItem('user', JSON.stringify(this._user));
                this.router.navigate(['home']);
            }
            else {
                this.notificationService.printErrorMessage(_authenticationResult.Message);
            }
        });
    }
    ;
};
LoginComponent = __decorate([
    core_1.Component({
        selector: 'albums',
        templateUrl: './app/components/account/login.component.html'
    }), 
    __metadata('design:paramtypes', [membership_service_1.MembershipService, notification_service_1.NotificationService, router_1.Router])
], LoginComponent);
exports.LoginComponent = LoginComponent;
