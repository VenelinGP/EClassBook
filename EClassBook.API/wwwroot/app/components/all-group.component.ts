import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute }  from '@angular/router';
import { Group } from '../core/models/group';
import { DataService } from '../core/services/data.service';
import { UtilityService } from '../core/services/utility.service';
import { NotificationService } from '../core/services/notification.service';
import { OperationResult } from '../core/domain/operationResult';

@Component({
    selector: 'groups',
    providers: [NotificationService],
    templateUrl: './app/components/all-group.component.html',
    styleUrls: ['../../styles/all-group.component.css']
})

export class AllGroupComponent implements OnInit {
    private groupAPI: string = 'api/group';
    private groups: Group[];
    private newGroup: Group;

    constructor(public groupService: DataService,
        public dataService: DataService,
        public utilityService: UtilityService,
        public notificationService: NotificationService,
        private route: ActivatedRoute,
        private router: Router) {
    }

    ngOnInit() {
        this.groupService.set(this.groupAPI);
        this.getGroup();
        this.newGroup = new Group('');
    }

    getGroup(): void {
        this.groupService.get()
            .subscribe(res => {

                var data: any = res.json();
                this.groups = data;
            },
            error => console.error('Error: ' + error));
    }
    search(i): void {
        this.getGroup();
    };

    delete(group: Group) {
        var _removeResult: OperationResult = new OperationResult(false, '');

        this.notificationService.printConfirmationDialog('Are you sure you want to delete the Course?',
            () => {
                this.dataService.deleteResource(this.groupAPI + '/' + group.Id)
                    .subscribe(res => {
                        _removeResult.Succeeded = res.Succeeded;
                        _removeResult.Message = res.Message;
                    },
                    error => console.error('Error: ' + error),
                    () => {
                        if (_removeResult.Succeeded) {
                            this.notificationService.printSuccessMessage(group.Name + ' is removed.');
                            this.router.navigate(['api/group']);
                            this.ngOnInit();

                        }
                        else {
                            this.notificationService.printErrorMessage('Failed to remove course');
                        }
                    });
            });
    };
    add(name: string) {
        var _addingResult: OperationResult = new OperationResult(false, '');
        this.newGroup = new Group(name);
        //console.log(this.newGroup);
        this.groupService.set(this.groupAPI);
        this.dataService.post(this.newGroup, true)
            .subscribe(res => {
                _addingResult.Succeeded = res.Succeeded;
                _addingResult.Message = res.Message;

            },
            error => console.error('Error: ' + error),
            () => {
                if (_addingResult.Succeeded) {
                    this.router.navigate(['api/group']);
                    this.ngOnInit();

                }
                else {
                    this.notificationService.printErrorMessage(_addingResult.Message);
                    this.router.navigate(['api/group']);
                }
            });
    }
}