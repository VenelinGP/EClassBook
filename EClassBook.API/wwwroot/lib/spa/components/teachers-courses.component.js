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
let AlbumPhotosComponent = class AlbumPhotosComponent {
    constructor(dataService, utilityService, notificationService, route, router) {
        this.dataService = dataService;
        this.utilityService = utilityService;
        this.notificationService = notificationService;
        this.route = route;
        this.router = router;
        this._albumsAPI = 'api/albums/';
        this._photosAPI = 'api/photos/';
        super(0, 0, 0);
    }
    ngOnInit() {
        this.sub = this.route.params.subscribe(params => {
            this._albumId = params['id']; // (+) converts string 'id' to a number
            this._albumsAPI += this._albumId + '/photos/';
            this.dataService.set(this._albumsAPI, 12);
            this.getAlbumPhotos();
        });
    }
    getAlbumPhotos() {
        this.dataService.get(this._page)
            .subscribe(res => {
            var data = res.json();
            this._photos = data.Items;
            this._displayingTotal = this._photos.length;
            this._page = data.Page;
            this._pagesCount = data.TotalPages;
            this._totalCount = data.TotalCount;
            this._albumTitle = this._photos[0].AlbumTitle;
        }, error => {
            if (error.status == 401 || error.status == 302) {
                this.utilityService.navigateToSignIn();
            }
            console.error('Error: ' + error);
        }, () => console.log(this._photos));
    }
    search(i) {
        super.search(i);
        this.getAlbumPhotos();
    }
    ;
    convertDateTime(date) {
        return this.utilityService.convertDateTime(date);
    }
    delete(photo) {
        var _removeResult = new operationResult_1.OperationResult(false, '');
        this.notificationService.printConfirmationDialog('Are you sure you want to delete the photo?', () => {
            this.dataService.deleteResource(this._photosAPI + photo.Id)
                .subscribe(res => {
                _removeResult.Succeeded = res.Succeeded;
                _removeResult.Message = res.Message;
            }, error => console.error('Error: ' + error), () => {
                if (_removeResult.Succeeded) {
                    this.notificationService.printSuccessMessage(photo.Title + ' removed from gallery.');
                    this.getAlbumPhotos();
                }
                else {
                    this.notificationService.printErrorMessage('Failed to remove photo');
                }
            });
        });
    }
};
AlbumPhotosComponent = __decorate([
    core_1.Component({
        selector: 'teacher-courses',
        providers: [notification_service_1.NotificationService],
        templateUrl: './app/components/teacher-courses.component.html'
    }), 
    __metadata('design:paramtypes', [data_service_1.DataService, utility_service_1.UtilityService, notification_service_1.NotificationService, router_1.ActivatedRoute, router_1.Router])
], AlbumPhotosComponent);
exports.AlbumPhotosComponent = AlbumPhotosComponent;
