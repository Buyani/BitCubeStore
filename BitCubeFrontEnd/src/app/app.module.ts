import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddProductTypeComponent } from './product-type/add-product-type/add-product-type.component';
import { ProductPurchaseComponent } from './product-purchase/product-purchase.component';
import { AddProductComponent } from './product-purchase/add-product/add-product.component';
import { ProductTypeComponent } from './product-type/product-type.component';
import { SharedService } from './shared.service';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    AddProductTypeComponent,
    ProductPurchaseComponent,
    AddProductComponent,
    ProductTypeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
