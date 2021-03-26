import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { AuthenticatedGuard } from './guard/authenticated.guard';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { NavSidebarComponent } from './nav-sidebar/nav-sidebar.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import { SignOutComponent } from './user/sign-out/sign-out.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    NavSidebarComponent,
    SignInComponent,
    SignOutComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthenticatedGuard]},
      { path: 'User/SignIn', component: SignInComponent, pathMatch: 'full', },
      { path: 'User/SignOut', component: SignOutComponent, pathMatch: 'full', canActivate: [AuthenticatedGuard] },
      { path: 'counter', component: CounterComponent, canActivate: [AuthenticatedGuard] },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthenticatedGuard] },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
