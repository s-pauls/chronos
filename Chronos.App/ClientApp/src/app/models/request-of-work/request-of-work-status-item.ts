export class RequestOfWorkStatusItem {
    id = 0;
    name = '';
    
    constructor(obj?: Partial<RequestOfWorkStatusItem>) {
        if (obj)
            Object.assign(this, obj);
    }
}
