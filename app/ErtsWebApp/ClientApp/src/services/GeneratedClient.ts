/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.10.8.0 (NJsonSchema v10.3.11.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

import { ClientBase } from './ClientBase';
import moment from 'moment';

export class LeagueClient extends ClientBase {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        super();
        this.http = http ? http : <any>window;
        this.baseUrl = this.getBaseUrl("", baseUrl);
    }

    get(signal?: AbortSignal | undefined): Promise<LeagueDto[] | null> {
        let url_ = this.baseUrl + "/api/League/Get";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            signal,
            headers: {
                "Accept": "application/json"
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.transformResult(url_, _response, (_response: Response) => this.processGet(_response));
        });
    }

    protected processGet(response: Response): Promise<LeagueDto[] | null> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(LeagueDto.fromJS(item));
            }
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<LeagueDto[] | null>(<any>null);
    }

    getLeagueImages(signal?: AbortSignal | undefined): Promise<LeagueImageDto[] | null> {
        let url_ = this.baseUrl + "/api/League/GetLeagueImages";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            signal,
            headers: {
                "Accept": "application/json"
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.transformResult(url_, _response, (_response: Response) => this.processGetLeagueImages(_response));
        });
    }

    protected processGetLeagueImages(response: Response): Promise<LeagueImageDto[] | null> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(LeagueImageDto.fromJS(item));
            }
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<LeagueImageDto[] | null>(<any>null);
    }
}

export class TournamentClient extends ClientBase {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        super();
        this.http = http ? http : <any>window;
        this.baseUrl = this.getBaseUrl("", baseUrl);
    }

    getTournamentsShort(leagueId: number, signal?: AbortSignal | undefined): Promise<TournamentShortDto[] | null> {
        let url_ = this.baseUrl + "/api/Tournament/GetTournamentsShort/{leagueId}";
        if (leagueId === undefined || leagueId === null)
            throw new Error("The parameter 'leagueId' must be defined.");
        url_ = url_.replace("{leagueId}", encodeURIComponent("" + leagueId));
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            signal,
            headers: {
                "Accept": "application/json"
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.transformResult(url_, _response, (_response: Response) => this.processGetTournamentsShort(_response));
        });
    }

    protected processGetTournamentsShort(response: Response): Promise<TournamentShortDto[] | null> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(TournamentShortDto.fromJS(item));
            }
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<TournamentShortDto[] | null>(<any>null);
    }
}

export class LeagueDto implements ILeagueDto {
    name!: string | undefined;
    imageUrl!: string | undefined;
    url!: string | undefined;

    constructor(data?: ILeagueDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.name = _data["name"];
            this.imageUrl = _data["imageUrl"];
            this.url = _data["url"];
        }
    }

    static fromJS(data: any): LeagueDto {
        data = typeof data === 'object' ? data : {};
        let result = new LeagueDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["name"] = this.name;
        data["imageUrl"] = this.imageUrl;
        data["url"] = this.url;
        return data; 
    }
}

export interface ILeagueDto {
    name: string | undefined;
    imageUrl: string | undefined;
    url: string | undefined;
}

export class LeagueImageDto implements ILeagueImageDto {
    id!: number;
    imageUrl!: string | undefined;

    constructor(data?: ILeagueImageDto) {
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
            this.imageUrl = _data["imageUrl"];
        }
    }

    static fromJS(data: any): LeagueImageDto {
        data = typeof data === 'object' ? data : {};
        let result = new LeagueImageDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["imageUrl"] = this.imageUrl;
        return data; 
    }
}

export interface ILeagueImageDto {
    id: number;
    imageUrl: string | undefined;
}

export class TournamentShortDto implements ITournamentShortDto {
    id!: number;
    name!: string | undefined;
    startTime!: moment.Moment;
    endTime!: moment.Moment;

    constructor(data?: ITournamentShortDto) {
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
            this.startTime = _data["startTime"] ? moment(_data["startTime"].toString()) : <any>undefined;
            this.endTime = _data["endTime"] ? moment(_data["endTime"].toString()) : <any>undefined;
        }
    }

    static fromJS(data: any): TournamentShortDto {
        data = typeof data === 'object' ? data : {};
        let result = new TournamentShortDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["startTime"] = this.startTime ? this.startTime.toISOString() : <any>undefined;
        data["endTime"] = this.endTime ? this.endTime.toISOString() : <any>undefined;
        return data; 
    }
}

export interface ITournamentShortDto {
    id: number;
    name: string | undefined;
    startTime: moment.Moment;
    endTime: moment.Moment;
}

export class SwaggerException extends Error {
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

    protected isSwaggerException = true;

    static isSwaggerException(obj: any): obj is SwaggerException {
        return obj.isSwaggerException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): any {
    throw new SwaggerException(message, status, response, headers, result);
}