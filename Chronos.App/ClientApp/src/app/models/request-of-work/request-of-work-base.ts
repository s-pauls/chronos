export abstract class RequestOfWorkBase {
    productId = 0;
    name = '';

    constructor(obj?: Partial<RequestOfWorkBase>) {
        if (obj)
            Object.assign(this, obj);
    }
}
