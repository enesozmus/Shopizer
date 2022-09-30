import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './admin/components/dashboard/dashboard.component';
import { LayoutComponent } from './admin/layout/layout.component';
import { AuthGuard } from './guards/auth.guard';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { TestErrorsComponent } from './shared/components/test-errors/test-error.component';
import { HomeComponent } from './ui/components/home/home.component';

const routes: Routes = [


  { path: '', component: HomeComponent },
  { path: 'test-errors', component: TestErrorsComponent },
  { path: 'not-found', component: NotFoundComponent },
  // { path: '**', redirectTo: '', pathMatch: 'full' },

  {
    path: 'admin', component: LayoutComponent, children: [
      { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
      { path: 'products', loadChildren: () => import("./admin/components/products/products.module").then(module => module.ProductsModule), canActivate: [AuthGuard] },
      { path: 'create-product', loadChildren: () => import("./admin/components/products/products.module").then(module => module.ProductsModule), canActivate: [AuthGuard] }
    ], canActivate: [AuthGuard]
  },
  {
    path: 'products', loadChildren: () => import("./ui/components/products/products.module").then(module => module.ProductsModule)
  },
  {
    path: 'products/:pageNo', loadChildren: () => import("./ui/components/products/products.module").then(module => module.ProductsModule)
  },
  {
    path: 'register', loadChildren: () => import("./ui/components/register/register.module").then(module => module.RegisterModule)
  },
  {
    path: 'login', loadChildren: () => import("./ui/components/login/login.module").then(module => module.LoginModule)
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})


export class AppRoutingModule { }
