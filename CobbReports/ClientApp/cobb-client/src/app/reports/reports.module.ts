import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ReportsComponent } from "./reports.component";
import { SharedModule } from "../shared/shared.module";
// Note - this might need to go above shared module
import { ReportsService } from "./reports.service";
import { Ng2GoogleChartsModule } from 'ng2-google-charts';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: 'reports', component: ReportsComponent }
        ]),
        SharedModule,
        Ng2GoogleChartsModule
    ],
    declarations: [
        ReportsComponent
    ],
    providers: [ReportsService]
})
export class ReportsModule{ }