import { Guid } from '../guid';
import { ProductItem } from './product-item';

export class Product {
  id: Guid;
  name: string;
  sequence: number;
  productItems: ProductItem[] = [];
}
