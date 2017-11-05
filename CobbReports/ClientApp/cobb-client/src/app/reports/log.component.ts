import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IReport, ILog } from "./Report";
import { ReportsService } from "./reports.service";


@Component({
    selector: 'logs',
    templateUrl: 'logs.component.html',
    styleUrls: ['logs.component.css']
})
export class LogsComponent implements OnInit {
    logs: ILog[];

    constructor(private _route: ActivatedRoute, private _router: Router, private _reportsService: ReportsService) { }

    ngOnInit(): void {
        this._reportsService.getLogs()
            .subscribe(resp => {
                this.logs = resp;
            })
    }
}