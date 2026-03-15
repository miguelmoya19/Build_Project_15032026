import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'rowHighlight'
})
export class RowHighlightPipe implements PipeTransform {

  transform(element:any): boolean {

    if(!element) return false;
    return (element?.openTasks!=undefined && element?.completedTasks !=undefined) ? (element.openTasks > element.completedTasks) : false;
  }

}
