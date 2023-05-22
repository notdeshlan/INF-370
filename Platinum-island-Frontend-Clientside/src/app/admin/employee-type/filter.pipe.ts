import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter1'
})
export class FilterPipe2 implements PipeTransform {
  transform(items: any[], searchText: string): any[] {
    if (!items) return [];
    if (!searchText) return items;

    searchText = searchText.toLowerCase();

    return items.filter(item => {
      return item.typeName.toLowerCase().includes(searchText) ||
             item.typeDescription.toLowerCase().includes(searchText);
    });
  }
}
