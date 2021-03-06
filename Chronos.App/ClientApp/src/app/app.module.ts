import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { QuillModule } from 'ngx-quill';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TypeaheadModule } from 'ngx-bootstrap/typeahead';

import { AppComponent } from './app.component';
import { AuthenticatedGuard } from './guard/authenticated.guard';
import { NavMenuComponent } from './component/nav-menu/nav-menu.component';
import { HomeComponent } from './component/home/home.component';
import { NavSidebarComponent } from './component/nav-sidebar/nav-sidebar.component';
import { SignInComponent } from './component/user/sign-in/sign-in.component';
import { SignOutComponent } from './component/user/sign-out/sign-out.component';
import { LoginLayoutComponent } from './component/login-layout/login-layout.component';
import { MainLayoutComponent } from './component/main-layout/main-layout.component';
import { AppConfigService } from './service';
import { ToastrHttpInterceptorService } from './service/toastr-http-interceptor.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TagsComponent } from './component/tags/tags.component';
import { FeatureRulesListComponent } from './component/rules/feature-rules-list/feature-rules-list.component';
import { FeatureRulesComponent } from './component/rules/feature-rules/feature-rules.component';
import { StoryRulesComponent } from './component/rules/story-rules/story-rules.component';
import { TaskRulesComponent } from './component/rules/task-rules/task-rules.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { RequestsOfWorkComponent } from './component/request-of-work/requests-of-work/requests-of-work.component';
import { FilterComponent } from './component/filter/filter.component';
import { EstimateComponent } from './component/request-of-work/estimate/estimate.component';
import { FeatureDefinitionDocumentComponent } from './component/request-of-work/feature-definition-document/feature-definition-document.component';
import { StatementOfWorkComponent } from './component/request-of-work/statement-of-work/statement-of-work.component';
import { FixRequestComponent } from './component/request-of-work/fix-request/fix-request.component';
import { FeatureComponent } from './component/feature/feature.component';
import { AssigmentComponent } from './component/assigment/assigment.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    NavSidebarComponent,
    SignInComponent,
    SignOutComponent,
    LoginLayoutComponent,
    MainLayoutComponent,
    FeatureRulesComponent,    
    TagsComponent,
    StoryRulesComponent,
    TaskRulesComponent,
    FeatureRulesListComponent,
    RequestsOfWorkComponent,
    FilterComponent,
    EstimateComponent,
    FeatureDefinitionDocumentComponent,
    StatementOfWorkComponent,
    FixRequestComponent,
    FeatureComponent,
    AssigmentComponent
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
        { path: 'requests-of-work', component: RequestsOfWorkComponent},
        { path: 'feature-rules-list', component: FeatureRulesListComponent},
        { path: 'feature-rules', component: FeatureRulesComponent},
        { path: 'feature-rules/:id', component: FeatureRulesComponent}
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
    NgxDatatableModule,
    TabsModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    CollapseModule.forRoot(),
    TypeaheadModule.forRoot()
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
