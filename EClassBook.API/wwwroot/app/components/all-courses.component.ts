import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute }  from '@angular/router';
import { Course } from '../core/models/course';
import { Teacher } from '../core/models/teacher';
import { DataService } from '../core/services/data.service';
import { UtilityService } from '../core/services/utility.service';
import { NotificationService } from '../core/services/notification.service';
import { OperationResult } from '../core/domain/operationResult';


@Component({
    selector: 'courses',
    providers: [NotificationService],
    templateUrl: './app/components/all-courses.component.html'
})

export class AllCoursesComponent implements OnInit {
    private courseAPI: string = 'api/courses';
    private teacherAPI: string = 'api/teacher';
    private courses: Course[];
    private teachers: Teacher[];
    private newCourse: Course;
    private addTeacher: Teacher;

    constructor(public courseService: DataService,
                public teacherService: DataService,
                public dataService: DataService,
                public utilityService: UtilityService,
                public notificationService: NotificationService,
                private route: ActivatedRoute,
                private router: Router) {
    }

    ngOnInit() {
        this.courseService.set(this.courseAPI);
        this.getCourses();
        this.teacherService.set(this.teacherAPI);
        this.getTeachers();
        this.newCourse = new Course('', null);
        this.addTeacher = new Teacher(null, '', '', '', null, null);
    }

    getCourses(): void {
        this.courseService.get()
            .subscribe(res => {

                var data: any = res.json();
                this.courses = data;
            },
            error => console.error('Error: ' + error));
    }
    getTeachers(): void {
        this.teacherService.get()
            .subscribe(res => {

                var data: any = res.json();
                this.teachers = data;
            },
            error => console.error('Error: ' + error));
    }
    search(i): void {
        this.getCourses();
    };

    delete(course: Course) {
        var _removeResult: OperationResult = new OperationResult(false, '');

        this.notificationService.printConfirmationDialog('Are you sure you want to delete the Course?',
            () => {
                this.dataService.deleteResource(this.courseAPI +'/'+ course.Id)
                    .subscribe(res => {
                        _removeResult.Succeeded = res.Succeeded;
                        _removeResult.Message = res.Message;
                    },
                    error => console.error('Error: ' + error),
                    () => {
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
    };
    add(name: string, teacher: Teacher) {
        var _addingResult: OperationResult = new OperationResult(false, '');
        //debugger;
        this.newCourse = new Course(name, teacher.Id);
        console.log(this.newCourse);
        this.courseService.set(this.courseAPI);
        this.dataService.post(this.newCourse, true)
            .subscribe(res => {
                _addingResult.Succeeded = res.Succeeded;
                _addingResult.Message = res.Message;

            },
            error => console.error('Error: ' + error),
            () => {
                if (_addingResult.Succeeded) {
                    //this.notificationService.printSuccessMessage('Dear ' + this._newUser.Username + ', please login with your credentials');
                    this.router.navigate(['api/courses']);
                }
                else {
                    this.notificationService.printErrorMessage(_addingResult.Message);
                }
            });
    } 
}