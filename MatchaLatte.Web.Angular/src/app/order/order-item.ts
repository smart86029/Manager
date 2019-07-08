import { Guid } from '../shared/guid';
import { ProductItem } from '../store/product-item';
import { Product } from '../store/product';

export class OrderItem {
  id: Guid;
  product: Product;
  productItem: ProductItem;
  quantity = 0;
}
