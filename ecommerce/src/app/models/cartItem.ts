import { IProduct } from './product';
export class ICartItem{
    id: number;
    name: string;
    price: number;
    quantity: number;
    productId: number;
    shoppingCartId: number;
    product: IProduct;
    get totalPrice(){
        return this.quantity*this.product.price;
    }
}