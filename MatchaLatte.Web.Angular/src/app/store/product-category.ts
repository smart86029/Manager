import { Guid } from '../shared/guid';
import { Product } from './product';

export class ProductCategory {
  id: Guid;
  name: string;
  isDefault: boolean;
  products: Product[] = [];
}
