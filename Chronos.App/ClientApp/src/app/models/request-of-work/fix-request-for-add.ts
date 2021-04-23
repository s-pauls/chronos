import { RequestOfWorkBase } from "./request-of-work-base";

export class FixRequestForAdd extends RequestOfWorkBase {
    isPartner = false;

    constructor(obj?: Partial<FixRequestForAdd>) {
        super(obj);
        
        if (obj)
            Object.assign(this, obj);
    }
}
