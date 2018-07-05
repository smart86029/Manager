import { ProductCategory } from './product-category';

export class Store {
  storeId: number;
  name: string;
  description: string;
  phone: string;
  address: string;
  remark: string;
  createdOn: Date;
  productCategories: ProductCategory[] = [];
}
