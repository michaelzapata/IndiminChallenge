/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.15.3.0 (NJsonSchema v10.6.4.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

import axios, { AxiosError, AxiosInstance, AxiosRequestConfig, AxiosResponse, CancelToken } from 'axios';

export class BFFClient {
    private instance: AxiosInstance;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, instance?: AxiosInstance) {

        this.instance = instance ? instance : axios.create();

        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";

    }

    /**
     * @return Success
     */
    dayOfWeek(dayOfWeek: number , cancelToken?: CancelToken | undefined): Promise<CitizenTaskDataResponse> {
        let url_ = this.baseUrl + "/api/Witch/DayOfWeek/{dayOfWeek}";
        if (dayOfWeek === undefined || dayOfWeek === null)
            throw new Error("The parameter 'dayOfWeek' must be defined.");
        url_ = url_.replace("{dayOfWeek}", encodeURIComponent("" + dayOfWeek));
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <AxiosRequestConfig>{
            method: "GET",
            url: url_,
            headers: {
                "Accept": "application/json"
            },
            cancelToken
        };

        return this.instance.request(options_).catch((_error: any) => {
            if (isAxiosError(_error) && _error.response) {
                return _error.response;
            } else {
                throw _error;
            }
        }).then((_response: AxiosResponse) => {
            return this.processDayOfWeek(_response);
        });
    }

    protected processDayOfWeek(response: AxiosResponse): Promise<CitizenTaskDataResponse> {
        const status = response.status;
        let _headers: any = {};
        if (response.headers && typeof response.headers === "object") {
            for (let k in response.headers) {
                if (response.headers.hasOwnProperty(k)) {
                    _headers[k] = response.headers[k];
                }
            }
        }
        if (status === 200) {
            const _responseText = response.data;
            let result200: any = null;
            let resultData200  = _responseText;
            result200 = CitizenTaskDataResponse.fromJS(resultData200);
            return Promise.resolve<CitizenTaskDataResponse>(result200);

        } else if (status === 404) {
            const _responseText = response.data;
            return throwException("Not Found", status, _responseText, _headers);

        } else if (status !== 200 && status !== 204) {
            const _responseText = response.data;
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
        }
        return Promise.resolve<CitizenTaskDataResponse>(<any>null);
    }

    /**
     * @return Success
     */
    dayOfWeekAll(  cancelToken?: CancelToken | undefined): Promise<DayOfWeekData[]> {
        let url_ = this.baseUrl + "/api/Witch/DayOfWeek";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <AxiosRequestConfig>{
            method: "GET",
            url: url_,
            headers: {
                "Accept": "application/json"
            },
            cancelToken
        };

        return this.instance.request(options_).catch((_error: any) => {
            if (isAxiosError(_error) && _error.response) {
                return _error.response;
            } else {
                throw _error;
            }
        }).then((_response: AxiosResponse) => {
            return this.processDayOfWeekAll(_response);
        });
    }

    protected processDayOfWeekAll(response: AxiosResponse): Promise<DayOfWeekData[]> {
        const status = response.status;
        let _headers: any = {};
        if (response.headers && typeof response.headers === "object") {
            for (let k in response.headers) {
                if (response.headers.hasOwnProperty(k)) {
                    _headers[k] = response.headers[k];
                }
            }
        }
        if (status === 200) {
            const _responseText = response.data;
            let result200: any = null;
            let resultData200  = _responseText;
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(DayOfWeekData.fromJS(item));
            }
            else {
                result200 = <any>null;
            }
            return Promise.resolve<DayOfWeekData[]>(result200);

        } else if (status === 404) {
            const _responseText = response.data;
            return throwException("Not Found", status, _responseText, _headers);

        } else if (status !== 200 && status !== 204) {
            const _responseText = response.data;
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
        }
        return Promise.resolve<DayOfWeekData[]>(<any>null);
    }
}

export class DayOfWeekData implements IDayOfWeekData {
    id?: number;
    name?: string | undefined;

    constructor(data?: IDayOfWeekData) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.name = _data["name"];
        }
    }

    static fromJS(data: any): DayOfWeekData {
        data = typeof data === 'object' ? data : {};
        let result = new DayOfWeekData();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        return data;
    }
}

export interface IDayOfWeekData {
    id?: number;
    name?: string | undefined;
}

export class CitizenData implements ICitizenData {
    citizenId?: string | undefined;
    citizenName?: string | undefined;

    constructor(data?: ICitizenData) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.citizenId = _data["citizenId"];
            this.citizenName = _data["citizenName"];
        }
    }

    static fromJS(data: any): CitizenData {
        data = typeof data === 'object' ? data : {};
        let result = new CitizenData();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["citizenId"] = this.citizenId;
        data["citizenName"] = this.citizenName;
        return data;
    }
}

export interface ICitizenData {
    citizenId?: string | undefined;
    citizenName?: string | undefined;
}

export class CitizenTaskData implements ICitizenTaskData {
    citizen?: CitizenData;
    tasks?: string[] | undefined;

    constructor(data?: ICitizenTaskData) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.citizen = _data["citizen"] ? CitizenData.fromJS(_data["citizen"]) : <any>undefined;
            if (Array.isArray(_data["tasks"])) {
                this.tasks = [] as any;
                for (let item of _data["tasks"])
                    this.tasks!.push(item);
            }
        }
    }

    static fromJS(data: any): CitizenTaskData {
        data = typeof data === 'object' ? data : {};
        let result = new CitizenTaskData();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["citizen"] = this.citizen ? this.citizen.toJSON() : <any>undefined;
        if (Array.isArray(this.tasks)) {
            data["tasks"] = [];
            for (let item of this.tasks)
                data["tasks"].push(item);
        }
        return data;
    }
}

export interface ICitizenTaskData {
    citizen?: CitizenData;
    tasks?: string[] | undefined;
}

export class CitizenTaskDataResponse implements ICitizenTaskDataResponse {
    dayOfWeekData?: DayOfWeekData;
    citizenTasks?: CitizenTaskData[] | undefined;

    constructor(data?: ICitizenTaskDataResponse) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.dayOfWeekData = _data["dayOfWeekData"] ? DayOfWeekData.fromJS(_data["dayOfWeekData"]) : <any>undefined;
            if (Array.isArray(_data["citizenTasks"])) {
                this.citizenTasks = [] as any;
                for (let item of _data["citizenTasks"])
                    this.citizenTasks!.push(CitizenTaskData.fromJS(item));
            }
        }
    }

    static fromJS(data: any): CitizenTaskDataResponse {
        data = typeof data === 'object' ? data : {};
        let result = new CitizenTaskDataResponse();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["dayOfWeekData"] = this.dayOfWeekData ? this.dayOfWeekData.toJSON() : <any>undefined;
        if (Array.isArray(this.citizenTasks)) {
            data["citizenTasks"] = [];
            for (let item of this.citizenTasks)
                data["citizenTasks"].push(item.toJSON());
        }
        return data;
    }
}

export interface ICitizenTaskDataResponse {
    dayOfWeekData?: DayOfWeekData;
    citizenTasks?: CitizenTaskData[] | undefined;
}

export class ApiException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): any {
    if (result !== null && result !== undefined)
        throw result;
    else
        throw new ApiException(message, status, response, headers, null);
}

function isAxiosError(obj: any | undefined): obj is AxiosError {
    return obj && obj.isAxiosError === true;
}