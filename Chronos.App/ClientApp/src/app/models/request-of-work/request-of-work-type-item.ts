export class RequestOfWorkTypeItem {
    id = 0;
    name = '';
    
    constructor(obj?: Partial<RequestOfWorkTypeItem>) {
        if (obj)
            Object.assign(this, obj);
    }
}
