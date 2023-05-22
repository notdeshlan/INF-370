import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter2'
})
export class FilterPipe3 implements PipeTransform {
  transform(items: any[], searchText: string): any[] {
    if (!items) return [];
    if (!searchText) return items;

    searchText = searchText.toLowerCase();

    return items.filter(item => {
      return item.employeeName.toLowerCase().includes(searchText) ||
             item.idNum.toLowerCase().includes(searchText)||
             item.cellNum.toLowerCase().includes(searchText);
    });
  }
}
