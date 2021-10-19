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
    return this.http.get<ProductType>(this.url+"/AllProductTypes")
  }

  createProductTypes(product_type:ProductType):Observable<ProductType>{
    const httpOptions={headers:new HttpHeaders({'Content-Type':'application/json'})};
    return this.http.post<ProductType>(this.url+'/InsertProduct/',product_type,httpOptions);
  }
}


