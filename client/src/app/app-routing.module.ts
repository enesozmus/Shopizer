import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './admin/components/dashboard/dashboard.component';
import { LayoutComponent } from './admin/layout/layout.component';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './ui/components/home/home.component';

const routes: Routes = [
  {
    path: "admin", component: LayoutComponent, children: [
      { path: "dashboard", component: DashboardComponent, canActivate: [AuthGuard] },
      { path: "products", loadChildren: () => import("./admin/components/products/products.module").then(module => module.ProductsModule), canActivate: [AuthGuard] },
      { path: "create-product", loadChildren: () => import("./admin/components/products/products.module").then(module => module.ProductsModule), canActivate: [AuthGuard] }
    ], canActivate: [AuthGuard]
  },
  {
    path: "", component: HomeComponent
  },
  {
    path: "products", loadChildren: () => import("./ui/components/products/products.module").then(module => module.ProductsModule)
  },
  {
    path: "register", loadChildren: () => import("./ui/components/register/register.module").then(module => module.RegisterModule)
  },
  {
    path: "login", loadChildren: () => import("./ui/components/login/login.module").then(module => module.LoginModule)
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})


export class AppRoutingModule { }
