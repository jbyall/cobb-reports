import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IReport, ILog } from "./Report";
import { ReportsService } from "./reports.service";
import { HttpParams } from '@angular/common/http';
import { DxDataGridComponent, DxButtonComponent } from 'devextreme-angular';
import DataSource from 'devextreme/data/data_source';


@Component({
    selector: 'logs',
    templateUrl: 'logs.component.html',
    styleUrls: ['logs.component.css']
})
export class LogsComponent implements OnInit {
    logs: ILog[];
    gridDataSource: any = {};
    rowsSelected: boolean;

    @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent;

    constructor(private _route: ActivatedRoute, private _router: Router, private _reportsService: ReportsService) {
        this.rowsSelected = false;
    }

    onSelectionChanged(e){
        var count = this.dataGrid.instance.getSelectedRowKeys();
        this.rowsSelected = count.length > 0;
    }

    reportRedirect(e){
        var test = this.dataGrid.instance.getSelectedRowKeys();
        this._router.navigate(['/reports', test[0]["id"], test[0]["logCount"], test[0]["mapInfo"]])
    }

    ngOnInit(): void {
        this._reportsService.getLogs()
            .subscribe(resp => {
                this.logs = resp;
                this.gridDataSource = new DataSource({
                    store: this.logs,
                    select: ["id", "loggerVersionInfo", "vehicleInfo", "mapInfo", "logCount"]
                });
            })
    }


}