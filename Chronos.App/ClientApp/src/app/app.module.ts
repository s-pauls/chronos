import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { QuillModule } from 'ngx-quill';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

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
import { ToastrHttpInterceptorService } from './service/toastr-http-interceptor.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TagsComponent } from './tags/tags.component';
import { FeatureRulesComponent } from './rules/feature-rules/feature-rules.component';
import { StoryRulesComponent } from './rules/story-rules/story-rules.component';
import { TaskRulesComponent } from './rules/task-rules/task-rules.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

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
    MainLayoutComponent,
    FeatureRulesComponent,    
    TagsComponent,
    StoryRulesComponent,
    TaskRulesComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,    
    RouterModule.forRoot([
      { path: '', component: MainLayoutComponent, canActivate: [AuthenticatedGuard], children: [
        { path: '', component: HomeComponent, pathMatch: 'full'},
        { path: 'User/SignOut', component: SignOutComponent, pathMatch: 'full'},
        { path: 'counter', component: CounterComponent},
        { path: 'fetch-data', component: FetchDataComponent},
        { path: 'feature-rules', component: FeatureRulesComponent}
      ]},
      { path: '', component: LoginLayoutComponent, children: [
        { path: 'User/SignIn', component: SignInComponent }
      ]}
    ]),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    QuillModule.forRoot({
      modules: {
        toolbar: [
          ['bold', 'italic', 'underline'],
          [{ 'list': 'ordered'}, { 'list': 'bullet' }],          
          [{ 'header': [1, 2, 3, 4, 5, 6, false] }],
          [{ 'color': [] }, { 'background': [] }],
          ['link']
        ]
      }
    }),
    BsDropdownModule.forRoot(),
    NgxDatatableModule
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: (config: AppConfigService) => () => config.load(),
      deps: [AppConfigService],
      multi: true,
    },
    { 
      provide: HTTP_INTERCEPTORS, 
      useClass: ToastrHttpInterceptorService, 
      multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
