import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';
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
import { LoginLayoutComponent } from './login-layout/login-layout.component';
import { MainLayoutComponent } from './main-layout/main-layout.component';
import { AppConfigService } from './service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    NavSidebarComponent,
    SignInComponent,
    SignOutComponent,
    LoginLayoutComponent,
    MainLayoutComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: MainLayoutComponent, canActivate: [AuthenticatedGuard], children: [
        { path: '', component: HomeComponent, pathMatch: 'full'},
        { path: 'User/SignOut', component: SignOutComponent, pathMatch: 'full'},
        { path: 'counter', component: CounterComponent},
        { path: 'fetch-data', component: FetchDataComponent},
      ]},
      { path: '', component: LoginLayoutComponent, children: [
        { path: 'User/SignIn', component: SignInComponent }
      ]}
    ])
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: (config: AppConfigService) => () => config.load(),
      deps: [AppConfigService],
      multi: true,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
