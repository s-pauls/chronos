export class EstimateTemplate {
    id = 0;
    name = '';

    constructor(obj?: Partial<EstimateTemplate>) {
        if (obj)
            Object.assign(this, obj);
    }
}
