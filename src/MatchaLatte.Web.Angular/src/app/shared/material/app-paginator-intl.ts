import { Injectable } from '@angular/core';
import { MatPaginatorIntl } from '@angular/material/paginator';

@Injectable()
export class AppPaginatorIntl extends MatPaginatorIntl {
  itemsPerPageLabel = '每頁';
  nextPageLabel = '下一頁';
  previousPageLabel = '上一頁';
  firstPageLabel = '第一頁';
  lastPageLabel = '最末頁';

  getRangeLabel = (page: number, pageSize: number, length: number): string => {
    const itemCount = Math.max(length, 0);
    const pageCount = Math.max(Math.ceil(itemCount / pageSize), 1);
    return `第 ${page + 1} 頁 共 ${pageCount} 頁 共 ${itemCount} 筆`;
  }
}
