import { Guid } from '../shared/guid';
import { Address } from './address';
import { ProductCategory } from './product-category';

export class Store {
  storeId: Guid;
  name: string;
  description: string;
  phone: string;
  address: Address;
  remark: string;
  createdOn: Date;
  productCategories: ProductCategory[] = [];
}
