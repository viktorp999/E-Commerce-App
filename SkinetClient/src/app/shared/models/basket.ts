import cuid from 'cuid';
import { BasketItem } from './basketItem';

export interface Basket {
  id: string;
  items: BasketItem[];
}

export class Basket implements Basket {
  id = cuid();
  items: BasketItem[] = [];
}
