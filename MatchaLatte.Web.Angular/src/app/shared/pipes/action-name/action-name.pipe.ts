import { Pipe, PipeTransform } from '@angular/core';
import { SaveMode } from 'src/app/core/save-mode.enum';

@Pipe({
  name: 'actionName'
})
export class ActionNamePipe implements PipeTransform {
  transform(value: SaveMode, args?: any): string {
    switch (value) {
      case SaveMode.Create:
        return '新增';
      case SaveMode.Update:
        return '修改';
    }
  }
}
