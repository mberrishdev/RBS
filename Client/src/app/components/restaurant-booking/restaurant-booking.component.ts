import { Component, OnInit, Input } from '@angular/core';
import { ImageApiServiceService } from 'src/app/services/imageServices/image-api-service.service';
import { Image, Restaurant } from '../../models/models';
import { ActivatedRoute } from '@angular/router';
import { CountryApiService } from 'src/app/services/CountryService/country-api.service';
import { ReservationApiServiceService } from 'src/app/services/reservationService/reservation-api-service.service';
import { DomSanitizer } from '@angular/platform-browser';

interface ResrvationCommand {
  restaurantId: number,
  date: Date,
  timeId: number,
  personCount: number,
  occasionId: number,
  specialRequest: string,
  isUserLogIn: boolean,
  guestUser: GuestUserRestrationCommand | null,
  sendNewsOfRestaurant: boolean,
  sendNewsOfPlatform: boolean,
  sendReservationReminders: boolean,
  addBookingToCallendar: boolean,
}

interface GuestUserRestrationCommand {
  firstName: string,
  lastName: string,
  email: string,
  countryId: number,
  phoneNumber: string,
}

interface ReservationResponse {
  qrCode: QrModel;
}

interface QrModel {
  qrImage: string;
  fileName: string;
}

@Component({
  selector: 'app-restaurant-booking',
  templateUrl: './restaurant-booking.component.html',
  styleUrls: ['./restaurant-booking.component.scss']
})

export class RestaurantBookingComponent implements OnInit {
  restaurantId: number;
  restaurantName: string;
  peopleCount: number = 15;
  // @Input()
  bookDate: Date | any;
  image: Image;
  selectedCountry: string;
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: number;
  specialOccasion: string;
  specialOccasions: any[];
  diningOffers: boolean = false;
  singMeUp: boolean = false;
  getRemainder: boolean = false;
  countries: any[];
  checked: boolean = false;
  reservationResponse :ReservationResponse|any;
  qrModel: QrModel|any;
  displayModal: boolean = false;

  constructor(private imageApiService: ImageApiServiceService, private countryApiService: CountryApiService,
    private route: ActivatedRoute, private reservationService: ReservationApiServiceService,
    private sanitizer: DomSanitizer) {
  }

  ngOnInit(): void {
    this.specialOccasions = [{ name: "Birthday" }, { name: "Anniversary" }, { name: "Date night" }, { name: "Business Meal" }, { name: "Celebration" }];
    this.route.queryParams
      .subscribe(params => {
        console.log(params);
        this.restaurantId = params.restaurantId;
        this.restaurantName = params.restaurantName;
      }
      );

    this.bookDate = Date.now;
    this.loadRestaurantTopImage();
    // this.loadCountries();
  }

  loadRestaurantTopImage() {
    this.restaurantId = 1;
    this.imageApiService.GetRestaurantTopImage(this.restaurantId).subscribe((i: any) => {
      this.image = i;
    });
  }

  loadCountries() {
    this.countryApiService.ListOfCountry().subscribe((response: any) => {
      console.log(response);

      this.countries = response;
    })
  }

  // {
  //   "restaurantId": 0,
  //   "dateTime": "2022-10-07T15:04:26.229Z",
  //   "personCount": 0,
  //   "tableId": 0,
  //   "occasionId": 0,
  //   "specialRequest": "string",
  //   "isUserLogIn": true,
  //   "guestUser": {
  //     "firstName": "string",
  //     "lastName": "string",
  //     "email": "string",
  //     "countryId": 0,
  //     "phoneNumber": "string"
  //   },
  //   "sendNewsOfRestaurant": true,
  //   "sendNewsOfPlatform": true,
  //   "sendReservationReminders": true,
  //   "addBookingToCallendar": true
  // }
  Book() {
    console.log("afdas");

    const request: ResrvationCommand = {
      restaurantId: 2,
      date: this.bookDate,
      timeId: 1,
      personCount: this.peopleCount,
      occasionId: 1,
      specialRequest: "5",
      isUserLogIn: false,
      guestUser: null,
      sendNewsOfRestaurant: false,
      sendNewsOfPlatform: false,
      sendReservationReminders: false,
      addBookingToCallendar: false,
    };

    // this.reservationService.Reservation(request).subscribe(data => {
    //   this.reservationResponse = data;
    //   this.qrModel = this.reservationResponse.qrCode;
    // })
    this.showQrCode();
    this.qrModel = {"qrImage":"asf","fileName":"asdf"};

    this.qrModel.qrImage = "data:image/png;base64,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qJvOqJTSVnXTGWq68TfUo6qUtiqlbaWUtqqbzlDddMaJuumMSiltVTedoaYbf0M9qkppq1LaVkppq7rpDNVNZ5yom86olNJWddMZarrxN9SjqpS2KqVtpZS2qpvOUN10xom66YxKKW1VN52hpht/Qz2qSmmrUtpWSmmruukM1U1nnKibzqiU0lZ10xlquvE31KOqlLYqpW2llLaqm85Q3XTGibrpjEopbVU3naGmG39DPapKaatS2lZKaau66QzVTWecqJvOqJTSVnXTGWq68TfUo06qm85QKW1VN51RqZvOUCltVUrbSiltVUpbNd34G+pRJ9VNZ6iUtqqbzqjUTWeolLYqpW2llLYqpa2abvwN9aiT6qYzVEpb1U1nVOqmM1RKW5XStlJKW5XSVk03/oZ61El10xkqpa3qpjMqddMZKqWtSmlbKaWtSmmrpht/Qz3qpLrpDJXSVnXTGZW66QyV0laltK2U0laltFXTjb+hHnVS3XSGSmmruumMSt10hkppq1LaVkppq1LaqunG31CPOqluOkOltFXddEalbjpDpbRVKW0rpbRVKW3VdONvqEedVDedoVLaqm46o1I3naFS2qqUtpVS2qqUtmq68TfUo06qm85QKW1VN51RqZvOUCltVUrbSiltVUpbNd34G+pRJ9VNZ6iUtqqbzqjUTWeolLYqpW2llLYqpa2abv4NV4n+KNV0urPqpjMqpbRVKW1VN52hppt/w1WiP0o1ne6suumMSiltVUpb1U1nqOnm33CV6I9STac7q246o1JKW5XSVnXTGWq6+TdcJfqjVNPpzqqbzqiU0laltFXddIaabv4NV4n+KNV0urPqpjMqpbRVKW1VN52hppt/w1WiP0o1ne6suumMSiltVUpb1U1nqOnm33CV6I9STac7q246o1JKW5XSVnXTGWq6+TdcJfqjVNPpzqqbzqiU0laltFXddIaabv4NV4n+KNV0urPqpjMqpbRVKW1VN52hppt/w1WiP0o1ne6suumMSiltVUpb1U1nqOnG31CPWimlbaWUtiqlrUppq1LaVppOd1bT6c6Vpht/Qz1qpZS2lVLaqpS2KqWtSmlbaTrdWU2nO1eabvwN9aiVUtpWSmmrUtqqlLYqpW2l6XRnNZ3uXGm68TfUo1ZKaVsppa1KaatS2qqUtpWm053VdLpzpenG31CPWimlbaWU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"
    this.qrModel.fileName = "ReservationQrCode"

  }

  showQrCode() {
    console.log("asfdasf");

    this.displayModal = true;
  }

  downloadQRImage()
  {
    const downloadLink = document.createElement('a');

    downloadLink.href = this.qrModel.qrIamge;
    downloadLink.download = this.qrModel.fileName;
    downloadLink.click();
  }
  handleChange(e: { checked: any; }) {
    console.log(e);

    var isChecked = e.checked;
  }
}
