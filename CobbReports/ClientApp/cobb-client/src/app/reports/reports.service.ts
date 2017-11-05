// For dependency injection
import { Injectable } from '@angular/core';

// For calls to API/web service
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

// For exception handling
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';

import { IReport, Report, ILog } from './report';

@Injectable()
export class ReportsService {
    private _reportsUrl = "http://localhost:59814/api/logs";
    private _logsUrl = "http://localhost:59814/api/loginfos";
    //private _reportsUrl = './api/reports.json';

    constructor(private _http: HttpClient) { }

    //getReports(): IReport {
    //    return new Report();
    //    }
    //}
    getReports(id: number): Observable<IReport[]> {
    return this._http.get<IReport[]>(this._reportsUrl + '/' + id.toString());
            //.do(data => console.log('All: ' + JSON.stringify(data)));
    }

    getLogs(): Observable<ILog[]> {
        return this._http.get<ILog[]>(this._logsUrl);
    }
}