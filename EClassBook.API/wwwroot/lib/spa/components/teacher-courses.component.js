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
const data_service_1 = require('../core/services/data.service');
const utility_service_1 = require('../core/services/utility.service');
const notification_service_1 = require('../core/services/notification.service');
const operationResult_1 = require('../core/domain/operationResult');
let TeacherCoursesComponent = class TeacherCoursesComponent {
    constructor(dataService, utilityService, notificationService, route, router) {
        this.dataService = dataService;
        this.utilityService = utilityService;
        this.notificationService = notificationService;
        this.route = route;
        this.router = router;
        this.coursesAPI = 'api/:id';
        this.teacherAPI = 'api/teacher';
    }
    ngOnInit() {
        this.sub = this.route.params.subscribe(params => {
            this.teacherId = params['id']; // (+) converts string 'id' to a number
            this.teacherAPI += '/' + this.teacherId;
            this.dataService.set(this.teacherAPI);
            this.getTeacherCourses();
        });
    }
    getTeacherCourses() {
        this.dataService.get()
            .subscribe(res => {
            var data = res.json();
            this.courses = data;
            this.teacherName = this.courses[0].TeacherName;
        }, error => {
            if (error.status == 401 || error.status == 302) {
                this.utilityService.navigateToSignIn();
            }
            console.error('Error: ' + error);
        }, () => console.log(this.courses));
    }
    search(i) {
        this.getTeacherCourses();
    }
    ;
    convertDateTime(date) {
        return this.utilityService.convertDateTime(date);
    }
    delete(course) {
        var _removeResult = new operationResult_1.OperationResult(false, '');
        this.notificationService.printConfirmationDialog('Are you sure you want to delete the course?', () => {
            this.dataService.deleteResource(this.coursesAPI + course.Id)
                .subscribe(res => {
                _removeResult.Succeeded = res.Succeeded;
                _removeResult.Message = res.Message;
            }, error => console.error('Error: ' + error), () => {
                if (_removeResult.Succeeded) {
                    this.notificationService.printSuccessMessage(course.Name + ' removed from gallery.');
                    this.getTeacherCourses();
                }
                else {
                    this.notificationService.printErrorMessage('Failed to remove course');
                }
            });
        });
    }
};
TeacherCoursesComponent = __decorate([
    core_1.Component({
        selector: 'teacher-courses',
        providers: [notification_service_1.NotificationService],
        templateUrl: './app/components/teacher-courses.component.html'
    }), 
    __metadata('design:paramtypes', [data_service_1.DataService, utility_service_1.UtilityService, notification_service_1.NotificationService, router_1.ActivatedRoute, router_1.Router])
], TeacherCoursesComponent);
exports.TeacherCoursesComponent = TeacherCoursesComponent;
