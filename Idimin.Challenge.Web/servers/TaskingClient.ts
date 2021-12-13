/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.15.3.0 (NJsonSchema v10.6.4.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

import axios, { AxiosError, AxiosInstance, AxiosRequestConfig, AxiosResponse, CancelToken } from 'axios';

export class TaskingClient {
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
    citizenTasksAll(  cancelToken?: CancelToken | undefined): Promise<GetCitizenTaskQueryResponse[]> {
        let url_ = this.baseUrl + "/api/CitizenTasks";
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
            return this.processCitizenTasksAll(_response);
        });
    }

    protected processCitizenTasksAll(response: AxiosResponse): Promise<GetCitizenTaskQueryResponse[]> {
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
                    result200!.push(GetCitizenTaskQueryResponse.fromJS(item));
            }
            else {
                result200 = <any>null;
            }
            return Promise.resolve<GetCitizenTaskQueryResponse[]>(result200);

        } else if (status === 404) {
            const _responseText = response.data;
            let result404: any = null;
            let resultData404  = _responseText;
            result404 = ProblemDetails.fromJS(resultData404);
            return throwException("Not Found", status, _responseText, _headers, result404);

        } else if (status !== 200 && status !== 204) {
            const _responseText = response.data;
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
        }
        return Promise.resolve<GetCitizenTaskQueryResponse[]>(<any>null);
    }

    /**
     * @param body (optional) 
     * @return Success
     */
    citizenTasksPOST(body: CreateCitizenTaskCommand | undefined , cancelToken?: CancelToken | undefined): Promise<void> {
        let url_ = this.baseUrl + "/api/CitizenTasks";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_ = <AxiosRequestConfig>{
            data: content_,
            method: "POST",
            url: url_,
            headers: {
                "Content-Type": "application/json",
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
            return this.processCitizenTasksPOST(_response);
        });
    }

    protected processCitizenTasksPOST(response: AxiosResponse): Promise<void> {
        const status = response.status;
        let _headers: any = {};
        if (response.headers && typeof response.headers === "object") {
            for (let k in response.headers) {
                if (response.headers.hasOwnProperty(k)) {
                    _headers[k] = response.headers[k];
                }
            }
        }
        if (status === 201) {
            const _responseText = response.data;
            return Promise.resolve<void>(<any>null);

        } else if (status !== 200 && status !== 204) {
            const _responseText = response.data;
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
        }
        return Promise.resolve<void>(<any>null);
    }

    /**
     * @param body (optional) 
     * @return Success
     */
    citizenTasksPUT(body: UpdateCitizenTaskCommand | undefined , cancelToken?: CancelToken | undefined): Promise<void> {
        let url_ = this.baseUrl + "/api/CitizenTasks";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_ = <AxiosRequestConfig>{
            data: content_,
            method: "PUT",
            url: url_,
            headers: {
                "Content-Type": "application/json",
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
            return this.processCitizenTasksPUT(_response);
        });
    }

    protected processCitizenTasksPUT(response: AxiosResponse): Promise<void> {
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
            return Promise.resolve<void>(<any>null);

        } else if (status === 400) {
            const _responseText = response.data;
            let result400: any = null;
            let resultData400  = _responseText;
            result400 = ProblemDetails.fromJS(resultData400);
            return throwException("Bad Request", status, _responseText, _headers, result400);

        } else if (status !== 200 && status !== 204) {
            const _responseText = response.data;
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
        }
        return Promise.resolve<void>(<any>null);
    }

    /**
     * @return Success
     */
    citizenTasksGET(id: number , cancelToken?: CancelToken | undefined): Promise<GetCitizenTaskQueryResponse> {
        let url_ = this.baseUrl + "/api/CitizenTasks/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
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
            return this.processCitizenTasksGET(_response);
        });
    }

    protected processCitizenTasksGET(response: AxiosResponse): Promise<GetCitizenTaskQueryResponse> {
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
            result200 = GetCitizenTaskQueryResponse.fromJS(resultData200);
            return Promise.resolve<GetCitizenTaskQueryResponse>(result200);

        } else if (status === 404) {
            const _responseText = response.data;
            let result404: any = null;
            let resultData404  = _responseText;
            result404 = ProblemDetails.fromJS(resultData404);
            return throwException("Not Found", status, _responseText, _headers, result404);

        } else if (status !== 200 && status !== 204) {
            const _responseText = response.data;
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
        }
        return Promise.resolve<GetCitizenTaskQueryResponse>(<any>null);
    }

    /**
     * @return Success
     */
    citizenTasksDELETE(id: number , cancelToken?: CancelToken | undefined): Promise<void> {
        let url_ = this.baseUrl + "/api/CitizenTasks/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <AxiosRequestConfig>{
            method: "DELETE",
            url: url_,
            headers: {
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
            return this.processCitizenTasksDELETE(_response);
        });
    }

    protected processCitizenTasksDELETE(response: AxiosResponse): Promise<void> {
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
            return Promise.resolve<void>(<any>null);

        } else if (status === 400) {
            const _responseText = response.data;
            let result400: any = null;
            let resultData400  = _responseText;
            result400 = ProblemDetails.fromJS(resultData400);
            return throwException("Bad Request", status, _responseText, _headers, result400);

        } else if (status !== 200 && status !== 204) {
            const _responseText = response.data;
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
        }
        return Promise.resolve<void>(<any>null);
    }

    /**
     * @return Success
     */
    citizen(citizenId: string , cancelToken?: CancelToken | undefined): Promise<GetCitizenTasksQueryResponse> {
        let url_ = this.baseUrl + "/api/CitizenTasks/Citizen/{citizenId}";
        if (citizenId === undefined || citizenId === null)
            throw new Error("The parameter 'citizenId' must be defined.");
        url_ = url_.replace("{citizenId}", encodeURIComponent("" + citizenId));
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
            return this.processCitizen(_response);
        });
    }

    protected processCitizen(response: AxiosResponse): Promise<GetCitizenTasksQueryResponse> {
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
            result200 = GetCitizenTasksQueryResponse.fromJS(resultData200);
            return Promise.resolve<GetCitizenTasksQueryResponse>(result200);

        } else if (status === 404) {
            const _responseText = response.data;
            let result404: any = null;
            let resultData404  = _responseText;
            result404 = ProblemDetails.fromJS(resultData404);
            return throwException("Not Found", status, _responseText, _headers, result404);

        } else if (status !== 200 && status !== 204) {
            const _responseText = response.data;
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
        }
        return Promise.resolve<GetCitizenTasksQueryResponse>(<any>null);
    }

    /**
     * @return Success
     */
    dayOfWeek(dayOfWeek: number , cancelToken?: CancelToken | undefined): Promise<GetCitizenTasksQueryResponse> {
        let url_ = this.baseUrl + "/api/CitizenTasks/DayOfWeek/{dayOfWeek}";
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

    protected processDayOfWeek(response: AxiosResponse): Promise<GetCitizenTasksQueryResponse> {
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
            result200 = GetCitizenTasksQueryResponse.fromJS(resultData200);
            return Promise.resolve<GetCitizenTasksQueryResponse>(result200);

        } else if (status === 404) {
            const _responseText = response.data;
            let result404: any = null;
            let resultData404  = _responseText;
            result404 = ProblemDetails.fromJS(resultData404);
            return throwException("Not Found", status, _responseText, _headers, result404);

        } else if (status !== 200 && status !== 204) {
            const _responseText = response.data;
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
        }
        return Promise.resolve<GetCitizenTasksQueryResponse>(<any>null);
    }

    /**
     * @return Success
     */
    dayOfWeek2(  cancelToken?: CancelToken | undefined): Promise<GetDaysOfWeekQueryResponse> {
        let url_ = this.baseUrl + "/api/CitizenTasks/DayOfWeek";
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
            return this.processDayOfWeek2(_response);
        });
    }

    protected processDayOfWeek2(response: AxiosResponse): Promise<GetDaysOfWeekQueryResponse> {
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
            result200 = GetDaysOfWeekQueryResponse.fromJS(resultData200);
            return Promise.resolve<GetDaysOfWeekQueryResponse>(result200);

        } else if (status === 404) {
            const _responseText = response.data;
            let result404: any = null;
            let resultData404  = _responseText;
            result404 = ProblemDetails.fromJS(resultData404);
            return throwException("Not Found", status, _responseText, _headers, result404);

        } else if (status !== 200 && status !== 204) {
            const _responseText = response.data;
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
        }
        return Promise.resolve<GetDaysOfWeekQueryResponse>(<any>null);
    }
}

export class CreateCitizenTaskCommand implements ICreateCitizenTaskCommand {
    citizenId?: string | undefined;
    dayOfWeek?: number;
    description?: string | undefined;
    isActive?: boolean;

    constructor(data?: ICreateCitizenTaskCommand) {
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
            this.dayOfWeek = _data["dayOfWeek"];
            this.description = _data["description"];
            this.isActive = _data["isActive"];
        }
    }

    static fromJS(data: any): CreateCitizenTaskCommand {
        data = typeof data === 'object' ? data : {};
        let result = new CreateCitizenTaskCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["citizenId"] = this.citizenId;
        data["dayOfWeek"] = this.dayOfWeek;
        data["description"] = this.description;
        data["isActive"] = this.isActive;
        return data;
    }
}

export interface ICreateCitizenTaskCommand {
    citizenId?: string | undefined;
    dayOfWeek?: number;
    description?: string | undefined;
    isActive?: boolean;
}

export class DayOfWeek implements IDayOfWeek {
    readonly name?: string | undefined;
    readonly id?: number;

    constructor(data?: IDayOfWeek) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            (<any>this).name = _data["name"];
            (<any>this).id = _data["id"];
        }
    }

    static fromJS(data: any): DayOfWeek {
        data = typeof data === 'object' ? data : {};
        let result = new DayOfWeek();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["name"] = this.name;
        data["id"] = this.id;
        return data;
    }
}

export interface IDayOfWeek {
    name?: string | undefined;
    id?: number;
}

export class GetCitizenTaskQueryResponse implements IGetCitizenTaskQueryResponse {
    id?: number;
    citizenId?: string | undefined;
    description?: string | undefined;
    isActive?: boolean;
    dayOfWeek?: DayOfWeek;

    constructor(data?: IGetCitizenTaskQueryResponse) {
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
            this.citizenId = _data["citizenId"];
            this.description = _data["description"];
            this.isActive = _data["isActive"];
            this.dayOfWeek = _data["dayOfWeek"] ? DayOfWeek.fromJS(_data["dayOfWeek"]) : <any>undefined;
        }
    }

    static fromJS(data: any): GetCitizenTaskQueryResponse {
        data = typeof data === 'object' ? data : {};
        let result = new GetCitizenTaskQueryResponse();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["citizenId"] = this.citizenId;
        data["description"] = this.description;
        data["isActive"] = this.isActive;
        data["dayOfWeek"] = this.dayOfWeek ? this.dayOfWeek.toJSON() : <any>undefined;
        return data;
    }
}

export interface IGetCitizenTaskQueryResponse {
    id?: number;
    citizenId?: string | undefined;
    description?: string | undefined;
    isActive?: boolean;
    dayOfWeek?: DayOfWeek;
}

export class GetCitizenTasksQueryResponse implements IGetCitizenTasksQueryResponse {
    citizenTasks?: GetCitizenTaskQueryResponse[] | undefined;

    constructor(data?: IGetCitizenTasksQueryResponse) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            if (Array.isArray(_data["citizenTasks"])) {
                this.citizenTasks = [] as any;
                for (let item of _data["citizenTasks"])
                    this.citizenTasks!.push(GetCitizenTaskQueryResponse.fromJS(item));
            }
        }
    }

    static fromJS(data: any): GetCitizenTasksQueryResponse {
        data = typeof data === 'object' ? data : {};
        let result = new GetCitizenTasksQueryResponse();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        if (Array.isArray(this.citizenTasks)) {
            data["citizenTasks"] = [];
            for (let item of this.citizenTasks)
                data["citizenTasks"].push(item.toJSON());
        }
        return data;
    }
}

export interface IGetCitizenTasksQueryResponse {
    citizenTasks?: GetCitizenTaskQueryResponse[] | undefined;
}

export class GetDaysOfWeekQueryResponse implements IGetDaysOfWeekQueryResponse {
    daysOfWeek?: DayOfWeek[] | undefined;

    constructor(data?: IGetDaysOfWeekQueryResponse) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            if (Array.isArray(_data["daysOfWeek"])) {
                this.daysOfWeek = [] as any;
                for (let item of _data["daysOfWeek"])
                    this.daysOfWeek!.push(DayOfWeek.fromJS(item));
            }
        }
    }

    static fromJS(data: any): GetDaysOfWeekQueryResponse {
        data = typeof data === 'object' ? data : {};
        let result = new GetDaysOfWeekQueryResponse();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        if (Array.isArray(this.daysOfWeek)) {
            data["daysOfWeek"] = [];
            for (let item of this.daysOfWeek)
                data["daysOfWeek"].push(item.toJSON());
        }
        return data;
    }
}

export interface IGetDaysOfWeekQueryResponse {
    daysOfWeek?: DayOfWeek[] | undefined;
}

export class ProblemDetails implements IProblemDetails {
    type?: string | undefined;
    title?: string | undefined;
    status?: number | undefined;
    detail?: string | undefined;
    instance?: string | undefined;

    constructor(data?: IProblemDetails) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.type = _data["type"];
            this.title = _data["title"];
            this.status = _data["status"];
            this.detail = _data["detail"];
            this.instance = _data["instance"];
        }
    }

    static fromJS(data: any): ProblemDetails {
        data = typeof data === 'object' ? data : {};
        let result = new ProblemDetails();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["title"] = this.title;
        data["status"] = this.status;
        data["detail"] = this.detail;
        data["instance"] = this.instance;
        return data;
    }
}

export interface IProblemDetails {
    type?: string | undefined;
    title?: string | undefined;
    status?: number | undefined;
    detail?: string | undefined;
    instance?: string | undefined;
}

export class UpdateCitizenTaskCommand implements IUpdateCitizenTaskCommand {
    id?: number;
    dayOfWeek?: number;
    description?: string | undefined;
    isActive?: boolean;

    constructor(data?: IUpdateCitizenTaskCommand) {
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
            this.dayOfWeek = _data["dayOfWeek"];
            this.description = _data["description"];
            this.isActive = _data["isActive"];
        }
    }

    static fromJS(data: any): UpdateCitizenTaskCommand {
        data = typeof data === 'object' ? data : {};
        let result = new UpdateCitizenTaskCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["dayOfWeek"] = this.dayOfWeek;
        data["description"] = this.description;
        data["isActive"] = this.isActive;
        return data;
    }
}

export interface IUpdateCitizenTaskCommand {
    id?: number;
    dayOfWeek?: number;
    description?: string | undefined;
    isActive?: boolean;
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