import { Product } from './product';

export class Store {
  StoreId: number;
  Name: string;
  Description: string;
  Phone: string;
  Address: string;
  Remark: string;
  CreatedOn: Date;
  Products: Product[];
}
