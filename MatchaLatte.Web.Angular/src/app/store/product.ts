import { ProductItem } from './product-item';

export class Product {
  productId: number;
  name: string;
  productItems: ProductItem[] = [];
}
