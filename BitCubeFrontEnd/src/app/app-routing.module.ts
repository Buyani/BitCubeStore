import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import{ProductPurchaseComponent} from './product-purchase/product-purchase.component';
import { ProductTypeComponent } from './product-type/product-type.component';

const routes: Routes = [
  {path:'products',component:ProductPurchaseComponent},
  {path:'producty-type',component:ProductTypeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
