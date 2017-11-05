import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import { IReport } from "./Report";
import { ReportsService } from "./reports.service";
import { ChartReadyEvent } from 'ng2-google-charts';
import { DxChartModule } from 'devextreme-angular';

declare let google:any

@Component({
    selector: 'reports',
    templateUrl: 'reports.component.html',
    styleUrls: ['reports.component.css']
})
export class ReportsComponent implements OnInit, ChartReadyEvent {
    message: string = "test";
    reports: IReport[];
    errorMessage: string;
    pieChartData: any;
    dxChartData: IReport[];
    types: string[] = ["spline"];
    chartTitle: string;

    constructor(private _route: ActivatedRoute, private _router: Router, private _reportsService: ReportsService) { }

    ngOnInit(): void {
        const id = +this._route.snapshot.paramMap.get('id');
        const time = +this._route.snapshot.paramMap.get('time');
        this.chartTitle = this._route.snapshot.paramMap.get('title');
        var dur = time / 67;
        var tix = [];
        var ct = 2;
        for (var i = 0; i < dur; i+=2) {
            tix.push(ct);
            ct = ct + 2;
        }
        this._reportsService.getReports(id)
            .subscribe(resp => {
                this.reports = resp;
                this.dxChartData = resp;
                // this.pieChartData = {
                //     chartType: 'LineChart',
                //     dataTable: this.reports["chartData"],
                //     options: {
                //         title: title,
                //         series: {
                //             0: { targetAxisIndex: 0 },
                //             1: { targetAxisIndex: 1 }
                //         },
                //         vAxes: {
                //             0: { title: 'Boost Error' },
                //             1: { title: 'Gear' }
                //         },
                //         hAxis: {
                //             ticks: tix
                //         },
                //         width: 1800,
                //         height: 800
                //     },
                // };
            });
    }
}