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
const group_1 = require('../core/models/group');
const data_service_1 = require('../core/services/data.service');
const utility_service_1 = require('../core/services/utility.service');
const notification_service_1 = require('../core/services/notification.service');
const operationResult_1 = require('../core/domain/operationResult');
let AllGroupComponent = class AllGroupComponent {
    constructor(groupService, dataService, utilityService, notificationService, route, router) {
        this.groupService = groupService;
        this.dataService = dataService;
        this.utilityService = utilityService;
        this.notificationService = notificationService;
        this.route = route;
        this.router = router;
        this.groupAPI = 'api/group';
    }
    ngOnInit() {
        this.groupService.set(this.groupAPI);
        this.getGroup();
        this.newGroup = new group_1.Group('');
    }
    getGroup() {
        this.groupService.get()
            .subscribe(res => {
            var data = res.json();
            this.groups = data;
        }, error => console.error('Error: ' + error));
    }
    search(i) {
        this.getGroup();
    }
    ;
    delete(group) {
        var _removeResult = new operationResult_1.OperationResult(false, '');
        this.notificationService.printConfirmationDialog('Are you sure you want to delete the Course?', () => {
            this.dataService.deleteResource(this.groupAPI + '/' + group.Id)
                .subscribe(res => {
                _removeResult.Succeeded = res.Succeeded;
                _removeResult.Message = res.Message;
            }, error => console.error('Error: ' + error), () => {
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
    }
    ;
    add(name) {
        var _addingResult = new operationResult_1.OperationResult(false, '');
        this.newGroup = new group_1.Group(name);
        //console.log(this.newGroup);
        this.groupService.set(this.groupAPI);
        this.dataService.post(this.newGroup, true)
            .subscribe(res => {
            _addingResult.Succeeded = res.Succeeded;
            _addingResult.Message = res.Message;
        }, error => console.error('Error: ' + error), () => {
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
};
AllGroupComponent = __decorate([
    core_1.Component({
        selector: 'groups',
        providers: [notification_service_1.NotificationService],
        templateUrl: './app/components/all-group.component.html',
        styleUrls: ['../../styles/all-group.component.css']
    }), 
    __metadata('design:paramtypes', [data_service_1.DataService, data_service_1.DataService, utility_service_1.UtilityService, notification_service_1.NotificationService, router_1.ActivatedRoute, router_1.Router])
], AllGroupComponent);
exports.AllGroupComponent = AllGroupComponent;
