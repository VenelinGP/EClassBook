import { Component, OnInit } from '@angular/core';
import { Teacher } from '../core/models/teacher';
import { DataService } from '../core/services/data.service';

@Component({
    selector: 'teachers',
    templateUrl: './app/components/teachers.component.html'
})

export class TeachersComponent implements OnInit {
    private teacherAPI: string = 'api/teacher';
    private teachers: Teacher[];

    constructor(public teacherService: DataService) {
    }

    ngOnInit() {
        this.teacherService.set(this.teacherAPI);
        this.getTeachers();
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
        this.getTeachers();
    };
}