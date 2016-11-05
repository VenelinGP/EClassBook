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
const data_service_1 = require('../core/services/data.service');
let TeachersComponent = class TeachersComponent {
    constructor(teacherService) {
        this.teacherService = teacherService;
        this.teacherAPI = 'api/teacher';
    }
    ngOnInit() {
        this.teacherService.set(this.teacherAPI);
        this.getTeachers();
    }
    getTeachers() {
        this.teacherService.get()
            .subscribe(res => {
            var data = res.json();
            this.teachers = data;
        }, error => console.error('Error: ' + error));
    }
    search(i) {
        this.getTeachers();
    }
    ;
};
TeachersComponent = __decorate([
    core_1.Component({
        selector: 'teachers',
        templateUrl: './app/components/teachers.component.html'
    }), 
    __metadata('design:paramtypes', [data_service_1.DataService])
], TeachersComponent);
exports.TeachersComponent = TeachersComponent;
