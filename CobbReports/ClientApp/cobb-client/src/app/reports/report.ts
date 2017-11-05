//export interface IReport {
//    id: number,
//    logInfoId: number,
//    logInfo: number,
//    time: number,
//    accelPosition: number,
//    ambientAirTemp: number,
//    baroPressure: number,
//    boost: number,
//    gearPosition: number,
//    ignitionTiming: number,
//    intakeTemp: number,
//    intakeTempManifold: number,
//    manAbsPress: number,
//    rpm: number,
//    tdBoostError: number,
//    tdIntegral: number,
//    tdProportional: number,
//    targetBoost: number,
//    targetBoostAbs: number,
//    targetThrottle: number,
//    throttlePos: number,
//    vehicleSpeed: number,
//    wastegateDuty: number,
//    wategateMax: number
//}
export interface IReport {
    chartData: any[];
}

export interface ILog {
    id: number,
    logs: any,
    loggerVersionInfo: string,
    vehicleInfo: string,
    mapInfo: string,
    logCount: number
}

export class Report implements IReport {
    chartData: any[];

    constructor() {
        this.chartData = [
            ["Year", "Sales", "Expenses"],
            ["2004", 1000, 400],
            ["2005", 1170, 460],
            ["2006", 1120, 1120],
            ["2007", 1030, 540]
        ];
    }
}