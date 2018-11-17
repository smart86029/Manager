export class PaginationResult<T> {
  pageIndex: number;
  pageSize: number;
  itemCount: number;
  items: T[] = [];

  constructor(pageIndex?: number, pageSize?: number, itemCount?: number, items?: T[]) {
    this.pageIndex = pageIndex || 0;
    this.pageSize = pageSize || 10;
    this.itemCount = itemCount || 0;
    this.items = items || [];
  }
}
