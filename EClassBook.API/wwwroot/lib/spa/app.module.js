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
const platform_browser_1 = require('@angular/platform-browser');
const http_1 = require('@angular/http');
const forms_1 = require('@angular/forms');
const common_1 = require('@angular/common');
const http_2 = require('@angular/http');
const account_module_1 = require('./components/account/account.module');
const app_component_1 = require('./app.component');
const home_component_1 = require('./components/home.component');
const teachers_component_1 = require('./components/teachers.component');
const teacher_courses_component_1 = require('./components/teacher-courses.component');
const all_courses_component_1 = require('./components/all-courses.component');
const all_group_component_1 = require('./components/all-group.component');
const routes_1 = require('./routes');
const data_service_1 = require('./core/services/data.service');
const membership_service_1 = require('./core/services/membership.service');
const utility_service_1 = require('./core/services/utility.service');
const notification_service_1 = require('./core/services/notification.service');
class AppBaseRequestOptions extends http_2.BaseRequestOptions {
    constructor() {
        super();
        this.headers = new http_2.Headers();
        this.headers.append('Content-Type', 'application/json');
        this.body = '';
    }
}
let AppModule = class AppModule {
};
AppModule = __decorate([
    core_1.NgModule({
        imports: [
            platform_browser_1.BrowserModule,
            forms_1.FormsModule,
            http_1.HttpModule,
            routes_1.routing,
            account_module_1.AccountModule
        ],
        declarations: [app_component_1.AppComponent, home_component_1.HomeComponent, teachers_component_1.TeachersComponent, teacher_courses_component_1.TeacherCoursesComponent,
            all_courses_component_1.AllCoursesComponent, all_group_component_1.AllGroupComponent],
        providers: [data_service_1.DataService, membership_service_1.MembershipService, utility_service_1.UtilityService, notification_service_1.NotificationService,
            { provide: common_1.LocationStrategy, useClass: common_1.HashLocationStrategy },
            { provide: http_2.RequestOptions, useClass: AppBaseRequestOptions }],
        bootstrap: [app_component_1.AppComponent]
    }), 
    __metadata('design:paramtypes', [])
], AppModule);
exports.AppModule = AppModule;
