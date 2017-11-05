import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ReportsComponent } from "./reports.component";
import { SharedModule } from "../shared/shared.module";
import { ReportsService } from "./reports.service";
import { Ng2GoogleChartsModule } from 'ng2-google-charts';
import { LogsComponent } from "./log.component";
import { DxDataGridModule, DxChartModule, DxSelectBoxModule, DxButtonModule } from 'devextreme-angular';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: 'reports/:id/:time/:title', component: ReportsComponent },
            { path: 'logs', component: LogsComponent }
        ]),
        SharedModule,
        Ng2GoogleChartsModule,
        DxDataGridModule,
        DxChartModule,
        DxSelectBoxModule,
        DxButtonModule
    ],
    declarations: [
        ReportsComponent,
        LogsComponent
    ],
    providers: [ReportsService]
})
export class ReportsModule{ }