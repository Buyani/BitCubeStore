import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable  } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl="http://localhost:3000/api";

  constructor(private http:HttpClient){}

  getProducts():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'products');
  }

  addNewProductInstock(val:any){
    return this.http.post(this.APIUrl+'/products',val)
  }  
  
  updateProductInstock(val:any){
    return this.http.put(this.APIUrl+'/products',val)
  }
}
