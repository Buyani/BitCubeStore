import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-products',
  templateUrl: './show-products.component.html',
  styleUrls: ['./show-products.component.css']
})
export class ShowProductsComponent implements OnInit {

  constructor(private service:SharedService) { }

  ProductsList:any=[];

  ngOnInit(): void {

    this.refreshProductList();
  }

  refreshProductList(){
    this.service.getProducts().subscribe(data=>{
      this.ProductsList=data;
    })
  }

}
