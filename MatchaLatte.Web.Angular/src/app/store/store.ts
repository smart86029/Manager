import { Guid } from '../shared/guid';
import { ProductCategory } from './product-category';

export class Store {
  storeId: Guid;
  name: string;
  description: string;
  phone: string;
  address: string;
  remark: string;
  createdOn: Date;
  productCategories: ProductCategory[] = [];
}
