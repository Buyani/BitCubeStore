import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from './product';
import { ProductType } from './product-type';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  url="loaclhost"
  constructor(public http:HttpClient) { }


  getAllProducts():Observable<Product[]>{
    return this.http.get<Product[]>(this.url+'/AllProducts');
  }


  createProduct(product:Product):Observable<Product>{
    const httpOptions={headers:new HttpHeaders({'Content-Type':'application/json'})};
    return this.http.post<Product>(this.url+'/InsertProduct/',product,httpOptions);
  }

  updateProduct(product:Product):Observable<Product>{
    const httpOptions={headers:new HttpHeaders({'Content-Type':'application/json'})};
    return this.http.put<Product>(this.url+'/UpdateProduct',product,httpOptions);
  }

  //Product Type Methods

  getAllProductTypes():Observable<ProductType>{
    return this.http.get<ProductType>(Observable.create(this.productslist))
  }

  createProductTypes(product_type:ProductType):Observable<ProductType>{
    const httpOptions={headers:new HttpHeaders({'Content-Type':'application/json'})};
    return this.http.post<ProductType>(this.url+'/InsertProduct/',product_type,httpOptions);
  }





    productslist: Product[] = [
    { ProductName:'Apples',Quantity:'500',UnitPrice:'200',ProductId:1,ProductTypeId:'2'},
    { ProductName:'Oranges',Quantity:'850',UnitPrice:'100',ProductId:2,ProductTypeId:'3'},
    { ProductName:'Bana',Quantity:'412',UnitPrice:'452',ProductId:3,ProductTypeId:'1'},
    { ProductName:'Mango',Quantity:'200',UnitPrice:'112',ProductId:4,ProductTypeId:'1'},
    { ProductName:'Peanuts',Quantity:'230',UnitPrice:'111',ProductId:5,ProductTypeId:'3'},
    { ProductName:'Tomatoe',Quantity:'78',UnitPrice:'120',ProductId:6,ProductTypeId:'3'},
    { ProductName:'Grape',Quantity:'441',UnitPrice:'300',ProductId:7,ProductTypeId:'2'},
    { ProductName:'Lemon',Quantity:'452',UnitPrice:'800',ProductId:8,ProductTypeId:'2'},
    
    ];
    
  producttypeslist:  ProductType[] = [
    { ProductTypeId:1,ProductTypeName:'Phones'},
    { ProductTypeId:2,ProductTypeName:'Laptops'},
    { ProductTypeId:3,ProductTypeName:'Screens'},
    { ProductTypeId:4,ProductTypeName:'Telephones'},
    { ProductTypeId:5,ProductTypeName:'Desks'}

    
    ];
}


