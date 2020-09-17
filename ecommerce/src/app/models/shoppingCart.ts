import { ICartItem } from './cartItem';
export interface IShoppingCart{
    Id: number,
    Items: [ICartItem]
}