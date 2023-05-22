export class ItemCategory {
    itemCategoryId?:number;
    categoryName?: string;
    categoryDescription?:string;
}

export class ItemType {
    itemTypeId?:number;
    typeName?:string;
    typeDescription?:string;
    itemCategoryId?:number;
}

export class Item {
    itemId?:number;
    itemName?:string;
    qtyOnHand?:number;
    itemDescription?:string;
    itemTypeId?:number;

}