import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";

import { Observable } from "rxjs/Rx";
import "rxjs/add/operator/toPromise";

@Injectable()
export class UserService {
    constructor(private _http: Http) { }

    loadData(): Promise<User[]> {
        return this._http.get('/api/user')
            .toPromise()
            .then(response => this.extractArray(response))
            .catch(this.handleErrorPromise);
    }

    protected extractArray(res: Response, showprogress: boolean = true) {
        let data = res.json();
        let address = data['Address'];
        let role = data['Role'];
        console.log(data.FirstName);
        return data || [];
    }

    protected handleErrorPromise(error: any): Promise<void> {
        try {
            error = JSON.parse(error._body);
        } catch (e) {
        }

        let errMsg = error.errorMessage
            ? error.errorMessage
            : error.message
                ? error.message
                : error._body
                    ? error._body
                    : error.status
                        ? `${error.status} - ${error.statusText}`
                        : 'unknown server error';

        console.error(errMsg);
        return Promise.reject(errMsg);
    }

}
export interface User {
    FirstName: string;
    LastName: string;
    Address: number;
    Role: string;
}