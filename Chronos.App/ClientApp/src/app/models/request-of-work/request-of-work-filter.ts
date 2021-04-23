import { RequestOfWorkStatus, RequestOfWorkType } from "src/app/enums";

export class RequestOfWorkFilter {
    requestOfWorkIds: number[] = [];
    statusIds: RequestOfWorkStatus[] = [];
    typeIds: RequestOfWorkType[] = [];
    productIds: string[] = [];

    constructor(obj?: Partial<RequestOfWorkFilter>) {
        if (obj)
            Object.assign(this, obj);
    }
}