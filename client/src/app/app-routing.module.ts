import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './admin/components/dashboard/dashboard.component';
import { LayoutComponent } from './admin/layout/layout.component';
import { HomeComponent } from './ui/components/home/home.component';

const routes: Routes = [
  {
    path: "admin", component: LayoutComponent, children: [
      { path: "dashboard", component: DashboardComponent },
      { path: "products", loadChildren: () => import("./admin/components/products/products.module").then(module => module.ProductsModule) },
      { path: "create-product", loadChildren: () => import("./admin/components/products/products.module").then(module => module.ProductsModule) }
    ]
  },
  {
    path: "", component: HomeComponent
  },
  {
    path: "products", loadChildren: () => import("./ui/components/products/products.module").then(module => module.ProductsModule)
  },
  {
    path: "register", loadChildren: () => import("./ui/components/register/register.module").then(module => module.RegisterModule)
  } 

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})


export class AppRoutingModule { }
