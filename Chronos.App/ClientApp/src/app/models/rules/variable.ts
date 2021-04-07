export class Variable {
    code = '';
    description = '';

    constructor (obj?: Partial<Variable>){
        if (obj){
            Object.assign(this, obj);
        }
    }
}