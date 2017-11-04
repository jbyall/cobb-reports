// For dependency injection
import { Injectable } from '@angular/core';

// For calls to API/web service
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

// For exception handling
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';

import { IReport, Report } from './report';

@Injectable()
export class ReportsService {
    private _reportsUrl = "http://localhost:59814/api/logs/23";
    //private _reportsUrl = './api/reports.json';

    constructor(private _http: HttpClient) { }

    //getReports(): IReport {
    //    return new Report();
    //    }
    //}
    getReports(): Observable<IReport[]> {
        return this._http.get<IReport[]>(this._reportsUrl);
            //.do(data => console.log('All: ' + JSON.stringify(data)));
    }
}