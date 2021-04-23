import { RequestOfWorkBase } from "./request-of-work-base";

export class StatementOfWorkForAdd extends RequestOfWorkBase {
    
    constructor(obj?: Partial<StatementOfWorkForAdd>) {
        super(obj);

        if (obj)
            Object.assign(this, obj);
    }
}
