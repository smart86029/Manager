import { Guid } from '../guid';

export class OrderItem {
  id: Guid;
  productId: Guid;
  productName: string;
  productItemId: Guid;
  productItemName: string;
  productItemPrice: number;
  price: number;
  quantity = 0;
}
