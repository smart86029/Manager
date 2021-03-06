import { Guid } from '../guid';
import { Address } from './address';
import { ProductCategory } from './product-category';

export class Store {
  id: Guid;
  name: string;
  description: string;
  logoUri: string;
  phone: string;
  address = new Address();
  remark: string;
  createdOn: Date;
  productCategories: ProductCategory[] = [];
}
