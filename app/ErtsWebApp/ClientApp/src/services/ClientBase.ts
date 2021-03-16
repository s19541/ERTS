export class ClientBase {
    protected transformOptions(options: RequestInit) {
        options.credentials = "include";
        return Promise.resolve(options);
    }

    protected getBaseUrl(arg1: string, base?: string) {
        const preUrl = process.env.REACT_APP_PRE_URL;
        return `${preUrl}`;
    }

    protected transformResult(url: string, response: Response, processor: (response: Response) => any) {
        return processor(response);
    }
}