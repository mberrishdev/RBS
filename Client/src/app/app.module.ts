import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { LoginComponent } from './auth/login/login.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { FooterComponent } from './shared/footer/footer.component';
import { PasswordModule } from 'primeng/password';
import { DividerModule } from "primeng/divider";
import { AccordionModule } from 'primeng/accordion';
import { ToastModule } from 'primeng/toast';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CarouselModule } from 'primeng/carousel';
import { TopRestaurantCarculerComponent } from './components/top-restaurant-carculer/top-restaurant-carculer.component';
import { RestaurantComponent } from './components/restaurant/restaurant.component';
import { SignupComponent } from './auth/signup/signup.component';
import { RestaurantImageSectionComponent } from './components/restaurant-image-section/restaurant-image-section.component';
import { RestaurantMenuSectionComponent } from './components/restaurant-menu-section/restaurant-menu-section.component';
import { RestaurantReviewsSectionComponent } from './components/restaurant-reviews-section/restaurant-reviews-section.component';
import { RestaurantReservationSectionComponent } from './components/restaurant-reservation-section/restaurant-reservation-section.component';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { ProgressBarModule } from 'primeng/progressbar';
import { BadgeModule } from 'primeng/badge';
import { SkeletonModule } from 'primeng/skeleton';
import { GoogleMapsModule } from '@angular/google-maps'
import { CalendarModule } from "primeng/calendar";
import { GalleriaModule } from 'primeng/galleria';
import { RestaurantAdditionalInformationComponent } from './components/restaurant-additional-information/restaurant-additional-information.component';
import { RestaurantBookingComponent } from './components/restaurant-booking/restaurant-booking.component';
import { PrivacyPolicyComponent } from './components/privacy-policy/privacy-policy.component';
import { DropdownModule } from 'primeng/dropdown';
import { RatingModule } from 'primeng/rating';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { CheckboxModule } from 'primeng/checkbox';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { DialogModule } from 'primeng/dialog';
import { I18nModule } from './i18n/i18n.module';
import { InputSwitchModule } from 'primeng/inputswitch';
import { ChipModule } from 'primeng/chip';
import { TermsAndConditionsComponent } from './components/terms-and-conditions/terms-and-conditions.component';
import { httpInterceptorProviders } from './interceptors';
import { LoaderComponent } from './components/loader/loader.component';
import { ErrorModalComponent } from './components/error-modal/error-modal.component';
import { SearchComponent } from './components/search/search.component';
import { InputNumberModule } from 'primeng/inputnumber';
import { RestaurantListComponent } from './components/restaurant-list/restaurant-list.component';
import { HomeBodyComponent } from './components/home-body/home-body.component';
import { SearchListComponent } from './components/search-list/search-list.component';
import { RestaurantTablesComponent } from './components/restaurant-tables/restaurant-tables.component'
import { ImageModule } from 'primeng/image';
import { ThreeSixtyModule } from '@mediaman/angular-three-sixty';
import { ThreeSixtyImageComponent } from './components/three-sixty-image/three-sixty-image.component';
import { DynamicDialogModule } from 'primeng/dynamicdialog';
import { TableImagesComponent } from './components/table-images/table-images.component';
import { ConfirmPopupModule } from "primeng/confirmpopup";

@NgModule({
  declarations: [
    LoaderComponent,
    FooterComponent,
    NavbarComponent,
    AppComponent,
    LoginComponent,
    TopRestaurantCarculerComponent,
    RestaurantComponent,
    SignupComponent,
    RestaurantImageSectionComponent,
    RestaurantMenuSectionComponent,
    RestaurantReviewsSectionComponent,
    RestaurantReservationSectionComponent,
    RestaurantAdditionalInformationComponent,
    RestaurantBookingComponent,
    PrivacyPolicyComponent,
    TermsAndConditionsComponent,
    LoaderComponent,
    ErrorModalComponent,
    SearchComponent,
    RestaurantListComponent,
    HomeBodyComponent,
    SearchListComponent,
    RestaurantTablesComponent,
    ThreeSixtyImageComponent,
    TableImagesComponent,
  ],
  imports: [
    ConfirmPopupModule,
    DynamicDialogModule,
    ThreeSixtyModule,
    ImageModule,
    InputNumberModule,
    ChipModule,
    InputSwitchModule,
    I18nModule,
    DialogModule,
    MessagesModule,
    MessageModule,
    ToggleButtonModule,
    CheckboxModule,
    InputTextareaModule,
    RatingModule,
    DropdownModule,
    GalleriaModule,
    CalendarModule,
    GoogleMapsModule,
    SkeletonModule,
    BadgeModule,
    ProgressBarModule,
    ProgressSpinnerModule,
    CarouselModule,
    BrowserAnimationsModule,
    ToastModule,
    AccordionModule,
    DividerModule,
    FormsModule,
    ReactiveFormsModule,
    PasswordModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ButtonModule,
    InputTextModule,
    I18nModule,
  ],
  exports: [],
  providers: [httpInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
