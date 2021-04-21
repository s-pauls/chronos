import { CheckedItem } from "./checked-item";

export class Filter {
    name = '';
    checkedItems: CheckedItem[] = []
    anyChecked = false;

    constructor(obj?: Partial<Filter>) {
        if (obj)
            Object.assign(this, obj);
    }
}