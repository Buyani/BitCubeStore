import { Component, OnInit ,ViewChild} from '@angular/core';
import { Product } from '../product';
import { Observable } from 'rxjs';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { FormBuilder, Validators } from '@angular/forms';
import { MatTableDataSource, } from '@angular/material/table';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { ProductService } from '../product.service';
import { ProductType } from '../product-type';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  dataSaved = false;
  showModal: boolean;
  submitted = false;
  allProductTypes: Observable<ProductType>;
 
  productForm:any;
  allEmployees: Observable<Product[]>;
  dataSource: MatTableDataSource<Product>;
  columnsToDisplay : string[] = ['ProductId','ProductTypeId','ProductName', 'Quantity', 'UnitPrice'];

  horizontalPosition: MatSnackBarHorizontalPosition = 'center';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;



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
    
constructor(private formbulider: FormBuilder,private productService: ProductService, private _snackBar: MatSnackBar) { 

}
show()
{
  this.showModal = true; // Show-Hide Modal Check
  
}
//Bootstrap Modal Close event
hide()
{
  this.showModal = false;
}

ngOnInit():void {
  this.productForm = this.formbulider.group({
    ProductName: ['', [Validators.required]],
    Quantity: ['', [Validators.required]],
    UnitPrice: ['', [Validators.required]],
    ProductTypeId: ['', [Validators.required]]
  });
  this.loadProducts();
  this.dataSource.paginator = this.paginator;
  this.dataSource.sort = this.sort;
}


loadProducts(){
this.dataSource= new MatTableDataSource<Product>(this.productslist);
this.dataSource.paginator = this.paginator;
this.dataSource.sort = this.sort;
}

FillProductTypeDDL() {
  this.allProductTypes =this.productService.getAllProductTypes();
}


resetForm() {
  this.productForm.reset();
  this.dataSaved=false;
  this.loadProducts();
}

onFormSubmit() {
  this.dataSaved = true;
  const product = this.productForm.value;
  //call save method here
  console.log(product);
  this.SavedSuccessful(1);
  this.productForm.reset();
}
CreateProduct(product: Product) {
  this.productService.createProduct(product);
  this.dataSaved=true;
  this.loadProducts();
  this.SavedSuccessful(1);
  this.productForm.reset();
}

SavedSuccessful(isUpdate:any) {
  if (isUpdate == 0) {
    this._snackBar.open('Record Updated Successfully!', 'Close', {
      duration: 2000,
      horizontalPosition: this.horizontalPosition,
      verticalPosition: this.verticalPosition,
    });
  } 
  else if (isUpdate == 1) {
    this._snackBar.open('Record Saved Successfully!', 'Close', {
      duration: 2000,
      horizontalPosition: this.horizontalPosition,
      verticalPosition: this.verticalPosition,
    });
  }
  else if (isUpdate == 2) {
    this._snackBar.open('Record Deleted Successfully!', 'Close', {
      duration: 2000,
      horizontalPosition: this.horizontalPosition,
      verticalPosition: this.verticalPosition,
    });
  }
}

}
