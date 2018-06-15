export class PaginationResult<T> {
  pageIndex: number;
  pageSize: number;
  itemCount: number;
  items: T[] = [];

  constructor(itemCount?: number, items?: T[]) {
    this.itemCount = itemCount == null ? 0 : itemCount;
    this.items = items == null ? [] : items;
  }
}
