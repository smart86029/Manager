import { Product } from './product';

export class Store {
  storeId: number;
  name: string;
  description: string;
  phone: string;
  address: string;
  remark: string;
  createdOn: Date;
  products: Product[];
}
