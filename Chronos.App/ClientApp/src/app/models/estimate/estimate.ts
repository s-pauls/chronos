export class Estimate {
    estimateId = 0;
    version = '';
    featureDefinitionDocumentUrl = '';
    designDocumentUrl = '';
    grandTotal = 0;

    constructor(obj?: Partial<Estimate>) {
        if (obj)
            Object.assign(this, obj);
    }
}
