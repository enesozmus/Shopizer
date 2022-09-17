import { List_Product } from "../products/list_product";

export interface IPaginationWithParameters {
    items: List_Product[];
    index: number;
    size: number;
    count: number;
    pages: number;
    hasPrevious: boolean;
    hasNext: boolean;
}

export class IPaginationWithParameters implements IPaginationWithParameters {
    index: number;
    size: number;
    count: number;
    pages: number;
    hasPrevious: boolean;
    hasNext: boolean;
    items: List_Product[] = [];
}