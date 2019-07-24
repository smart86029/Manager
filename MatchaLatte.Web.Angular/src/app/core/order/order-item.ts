import { Guid } from '../guid';
import { Product } from '../store/product';
import { ProductItem } from '../store/product-item';

export class OrderItem {
  id: Guid;
  product: Product;
  productItem: ProductItem;
  quantity = 0;
}
