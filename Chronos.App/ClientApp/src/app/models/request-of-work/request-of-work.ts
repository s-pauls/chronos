import { RequestOfWorkStatus } from "src/app/enums";

export class RequestOfWork {
    requestOfWorkId = 0;
    productName = '';
    name = '';
    fullNumber = '';
    priority?: number = null;
    status: RequestOfWorkStatus;
    statusName = '';

    constructor(obj?: Partial<RequestOfWork>) {
        if (obj)
            Object.assign(this, obj);
    }
}
