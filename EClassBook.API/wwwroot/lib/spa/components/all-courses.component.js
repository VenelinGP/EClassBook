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
const course_1 = require('../core/models/course');
const teacher_1 = require('../core/models/teacher');
const data_service_1 = require('../core/services/data.service');
const utility_service_1 = require('../core/services/utility.service');
const notification_service_1 = require('../core/services/notification.service');
const operationResult_1 = require('../core/domain/operationResult');
let AllCoursesComponent = class AllCoursesComponent {
    constructor(courseService, teacherService, dataService, utilityService, notificationService, route, router) {
        this.courseService = courseService;
        this.teacherService = teacherService;
        this.dataService = dataService;
        this.utilityService = utilityService;
        this.notificationService = notificationService;
        this.route = route;
        this.router = router;
        this.courseAPI = 'api/courses';
        this.teacherAPI = 'api/teacher';
    }
    ngOnInit() {
        this.courseService.set(this.courseAPI);
        this.getCourses();
        this.teacherService.set(this.teacherAPI);
        this.getTeachers();
        this.newCourse = new course_1.Course('', null);
        this.addTeacher = new teacher_1.Teacher(null, '', '', '', null, null);
    }
    getCourses() {
        this.courseService.get()
            .subscribe(res => {
            var data = res.json();
            this.courses = data;
        }, error => console.error('Error: ' + error));
    }
    getTeachers() {
        this.teacherService.get()
            .subscribe(res => {
            var data = res.json();
            this.teachers = data;
        }, error => console.error('Error: ' + error));
    }
    search(i) {
        this.getCourses();
    }
    ;
    delete(course) {
        var _removeResult = new operationResult_1.OperationResult(false, '');
        this.notificationService.printConfirmationDialog('Are you sure you want to delete the Course?', () => {
            this.dataService.deleteResource(this.courseAPI + '/' + course.Id)
                .subscribe(res => {
                _removeResult.Succeeded = res.Succeeded;
                _removeResult.Message = res.Message;
            }, error => console.error('Error: ' + error), () => {
                if (_removeResult.Succeeded) {
                    this.notificationService.printSuccessMessage(course.Name + ' is removed.');
                    this.getCourses();
                }
                else {
                    this.notificationService.printErrorMessage('Failed to remove course');
                }
            });
            this.router.navigate(['api/courses']);
        });
    }
    ;
    add(name, teacher) {
        var _addingResult = new operationResult_1.OperationResult(false, '');
        //debugger;
        this.newCourse = new course_1.Course(name, teacher.Id);
        console.log(this.newCourse);
        this.courseService.set(this.courseAPI);
        this.dataService.post(this.newCourse, true)
            .subscribe(res => {
            _addingResult.Succeeded = res.Succeeded;
            _addingResult.Message = res.Message;
        }, error => console.error('Error: ' + error), () => {
            if (_addingResult.Succeeded) {
                //this.notificationService.printSuccessMessage('Dear ' + this._newUser.Username + ', please login with your credentials');
                this.router.navigate(['api/courses']);
            }
            else {
                this.notificationService.printErrorMessage(_addingResult.Message);
            }
        });
    }
};
AllCoursesComponent = __decorate([
    core_1.Component({
        selector: 'courses',
        providers: [notification_service_1.NotificationService],
        templateUrl: './app/components/all-courses.component.html'
    }), 
    __metadata('design:paramtypes', [data_service_1.DataService, data_service_1.DataService, data_service_1.DataService, utility_service_1.UtilityService, notification_service_1.NotificationService, router_1.ActivatedRoute, router_1.Router])
], AllCoursesComponent);
exports.AllCoursesComponent = AllCoursesComponent;
