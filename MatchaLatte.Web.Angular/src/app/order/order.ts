import { Guid } from '../shared/guid';
import { OrderItem } from './order-item';

export class Order {
  id: Guid;
  groupId: Guid;
  buyerId: Guid;
  createdOn: Date;
  orderItems: OrderItem[] = [];
}
