import { NgModule,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import{ HttpClientModule } from'@angular/common/http';
import { AppComponent } from './app.component';
import { ServicesListComponent } from './services-list/services-list.component';
import { RouterModule } from '@angular/router';
import { ServiceDetailsComponent } from './service-details/service-details.component';
import { AddServiceComponent } from './add-service/add-service.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EditServiceComponent } from './edit-service/edit-service.component';
import { DeleteServiceComponent } from './delete-service/delete-service.component';
import { ServicesListForClientsComponent } from './services-list-for-clients/services-list-for-clients.component';
import { PaginatorComponent } from './paginator/paginator.component';
import { SearchSpecificServicesComponent } from './search-specific-services/search-specific-services.component';
import { RatingServiceComponent } from './rating-service/rating-service.component';
import { StarRatingComponent } from './star-rating/star-rating.component';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { 
	IgxCarouselModule,
	IgxSliderModule
 } from "igniteui-angular";
import { RequestPageComponent } from './pages/request-page/request-page.component';
import { AddRequestComponent } from './pages/add-request/add-request.component';
import { UpdateRequestComponent } from './pages/update-request/update-request.component';
import { AddCategoryComponent } from './pages/add-category/add-category.component';
import { DeleteCategoryComponent } from './pages/delete-category/delete-category.component';
import { CategoryPageComponent } from './pages/category-page/category-page.component';

import { RequestListComponent } from './pages/request-list/request-list.component';
import { UserComponent } from './user/user.component';
import { AdminComponent } from './admin/admin.component';
import { DetailComponent } from './user/detail/detail.component';
import { NotificationsComponent } from './user/notifications/notifications.component';
import { UserRequestsComponent } from './user/user-requests/user-requests.component';
import { UserServicesComponent } from './user/user-services/user-services.component';
import { UserServicesRequestsComponent } from './user/user-services-requests/user-services-requests.component';
import { BookmarkComponent } from './user/bookmark/bookmark.component';
import { AdminRegisterComponent } from './admin/register/adminregister.component';
import { AdminlistComponent } from './admin/adminlist/adminlist.component';
import { UserlistComponent } from './admin/userlist/userlist.component';
import { NavbarComponent } from './navbar/navbar.component';
import { LoginModule } from './login/login.module';
import { registerComponent } from 'igniteui-webcomponents/components/common/definitions/register';
import { LoginComponent } from './login/login/login.component';
import { RegisterComponent } from './login/register/register.component';
import { DatePipe } from '@angular/common';


@NgModule({
  
  schemas: [CUSTOM_ELEMENTS_SCHEMA],

  declarations: [
    AppComponent,
    UserComponent,
    AdminComponent,
    RequestPageComponent,
    AddRequestComponent,
    UpdateRequestComponent,
    AddCategoryComponent,
    DeleteCategoryComponent,
    CategoryPageComponent,
    ServicesListComponent,
    ServiceDetailsComponent,
    AddServiceComponent,
    EditServiceComponent,
    DeleteServiceComponent,
    ServicesListForClientsComponent,
    PaginatorComponent,
    SearchSpecificServicesComponent,
    RatingServiceComponent,
    StarRatingComponent,
    DetailComponent,
    NotificationsComponent,
    UserRequestsComponent,
    UserServicesComponent,
    UserServicesRequestsComponent,
    BookmarkComponent,
    RequestListComponent,
    AdminRegisterComponent,
    AdminlistComponent,
    UserlistComponent,
    NavbarComponent,
    
  ],
  imports: 
  [ 
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      {
        path:"",
        component:ServicesListForClientsComponent,
      },
      {
        path:"search/:location/:category",
        component:SearchSpecificServicesComponent,
      },
      {
        path:"service",
        component:ServicesListComponent,
      },
      {
        path:"service/add",
        component:AddServiceComponent,
      },
      {
        path:"service/edit/:id",
        component:EditServiceComponent,
      },
      {
        path:"service/delete/:id",
        component:DeleteServiceComponent,
      },
      {
        path:"service/:id",
        component:ServiceDetailsComponent,
      },
      {
        path:"Login",
        loadChildren: ()=>import('./login/login.module').then((m)=>m.LoginModule)
      },
      {
        path:"User",
        component:UserComponent,
        loadChildren: ()=>import('./user/user.module').then((m)=>m.UserModule)
      },
      {
        path:"Admin",
        component:AdminComponent
      },
      {
        path:"Request",
        component:RequestPageComponent
      }
    ]),
    ReactiveFormsModule,
    BrowserAnimationsModule,
    FormsModule,
    IgxCarouselModule,
    IgxSliderModule
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent],
})
export class AppModule {}
