import { ICategory } from './category';
export interface IProduct{
    id: number,
    name: string,
    price: number,
    categoryId: number,
    imageUrl: string,
    category: ICategory
}