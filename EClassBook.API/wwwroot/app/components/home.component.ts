import {Component} from '@angular/core';
import {enableProdMode} from '@angular/core';

enableProdMode();
import { MembershipService } from '../core/services/membership.service';
import { User } from '../core/models/user';

@Component({
    selector: 'home',
    templateUrl: './app/components/home.component.html'
})
export class HomeComponent {

    constructor(public membershipService: MembershipService) {

    }
    isUserLoggedIn(): boolean {
        return this.membershipService.isUserAuthenticated();
    }
}