import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute }  from '@angular/router';
import { Teacher } from '../core/models/teacher';
import { Course } from '../core/models/course';
import { DataService } from '../core/services/data.service';
import { UtilityService } from '../core/services/utility.service';
import { NotificationService } from '../core/services/notification.service';
import { OperationResult } from '../core/domain/operationResult';
import { Subscription }  from 'rxjs/Subscription';

@Component({
    selector: 'teacher-courses',
    providers: [NotificationService],
    templateUrl: './app/components/teacher-courses.component.html'
})
export class TeacherCoursesComponent implements OnInit {
    private coursesAPI: string = 'api/:id';
    private teacherAPI: string = 'api/teacher';
    private teacherId: string;
    private courses: Course[];
    private teacherName: string;
    private sub: Subscription;

    constructor(public dataService: DataService,
        public utilityService: UtilityService,
        public notificationService: NotificationService,
        private route: ActivatedRoute,
        private router: Router) {
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.teacherId = params['id']; // (+) converts string 'id' to a number
            this.teacherAPI += '/' + this.teacherId;
            this.dataService.set(this.teacherAPI);
            this.getTeacherCourses();
        });
    }

    getTeacherCourses(): void {
        this.dataService.get()
            .subscribe(res => {

                var data: any = res.json();
                this.courses = data;
                this.teacherName = this.courses[0].TeacherName;
            },
            error => {

                if (error.status == 401 || error.status == 302) {
                    this.utilityService.navigateToSignIn();
                }

                console.error('Error: ' + error)
            },
            () => console.log(this.courses));
    }

    search(i): void {
        this.getTeacherCourses();
    };

    convertDateTime(date: Date) {
        return this.utilityService.convertDateTime(date);
    }

    delete(course: Course) {
        var _removeResult: OperationResult = new OperationResult(false, '');

        this.notificationService.printConfirmationDialog('Are you sure you want to delete the course?',
            () => {
                this.dataService.deleteResource(this.coursesAPI + course.Id)
                    .subscribe(res => {
                        _removeResult.Succeeded = res.Succeeded;
                        _removeResult.Message = res.Message;
                    },
                    error => console.error('Error: ' + error),
                    () => {
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
}