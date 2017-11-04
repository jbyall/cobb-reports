import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import { IReport } from "./Report";
import { ReportsService } from "./reports.service";
import { ChartReadyEvent } from 'ng2-google-charts';

declare let google:any

@Component({
    selector: 'reports',
    templateUrl: 'reports.component.html',
    styleUrls: ['reports.component.css']
})
export class ReportsComponent implements OnInit, ChartReadyEvent {
    message: string;
    //reports: IReport[] = [];
    reports: IReport[];
    errorMessage: string;
    pieChartData: any;

    constructor(private _route: ActivatedRoute, private _router: Router, private _reportsService: ReportsService) { }

    //public ready(event: ChartReadyEvent) {
    //    this.pieChartData = {
    //        chartType: 'LineChart',
    //        dataTable: this.reports[0].chartData,
    //        options: { 'title': 'Tasks' },
    //    };
    //}

    getData(): void {
        //return this.reports["chartData"];
        this.pieChartData = {
            chartType: 'LineChart',
            dataTable: this.reports["chartData"],
            options: {
                title: 'Test',
                series: {
                    0: { targetAxisIndex: 0 },
                    1: { targetAxisIndex: 1 }
                },
                vAxes: {
                    0: { title: 'Boost Error' },
                    1: { title: 'Gear'}
                },
                hAxis: {
                    ticks: [2,4,6,8,10,12,14,16]
                },
                //vAxis: {
                //    viewWindow: {
                //        max:100
                //    }
                //},
                width: 1800,
                height: 1000
            },
        };
    }

    ngOnInit(): void {
        this._reportsService.getReports()
            .subscribe(
            reports => {
                this.reports = reports;
            },
            error => this.errorMessage = <any>error
            );
        this.pieChartData = {
            chartType: 'LineChart',
            dataTable: this.reports["chartData"],
            options: { chart: { 'title': 'Tasks' },width:900, height:1000 },
        };
        //var data = google.visualization.arrayToDataTable(this.reports.chartData, false);
        //this.pieChartData = {
        //    chartType: 'LineChart',
        //    dataTable: [
        //        ['Year', 'Sales', 'Expenses'],
        //        ['2001', 1000, 400],
        //        ['2002', 1170, 460],
        //        ['2003', 660, 1120],
        //        ['2004', 1030, 540]
        //    ],
        //    options: { 'title': 'Tasks' },
        //};
            
    }
}