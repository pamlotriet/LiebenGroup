export interface Order {
  id?: string;
  orderDate: string;
  items: OrderLineItem[];
}

export interface OrderLineItem {
  productId: string;
  productName: string;
  quantity: number;
  unitPrice: number;
}
