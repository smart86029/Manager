import { Guid } from '../guid';
import { Product } from './product';

export class ProductCategory {
  id: Guid;
  name: string;
  products: Product[] = [];
}
