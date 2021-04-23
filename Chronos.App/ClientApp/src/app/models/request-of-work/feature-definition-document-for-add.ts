import { RequestOfWorkBase } from "./request-of-work-base";

export class FeatureDefinitionDocumentForAdd extends RequestOfWorkBase {
    numberSuffix = '';

    constructor(obj?: Partial<FeatureDefinitionDocumentForAdd>) {
        super(obj);
        
        if (obj)
            Object.assign(this, obj);
    }
}
