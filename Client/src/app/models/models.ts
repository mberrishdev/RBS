import { ImageType } from "../enums/enums";

export interface Language {
  id: number,
  name: string,
  countryId: number,
  isDefault: boolean,
  country: Country;
}

export interface Country {
  id: number,
  code: string,
  name: string,
  diallingCode: string,
  flagSrc: string;
}

export interface Restaurant {
  id: number,
  name: string,
  description: string,
  reviewCount: number,
  averageRate: number,
  mainType: string,
  address: Address,
}

export interface Image {
  id: number;
  src: string;
  alt: string;
  isMin: string;
  isTop: string;
  imageType: ImageType;
  orderNumber: number;
}


export interface Address {
  id: number,
  country: string,
  city: string,
  street: string,
  number: string,
}

export interface Review {
  id: number;
  text: string,
  reviewerName: string,
  sreviewerSurName: string,
  overallRate: number,
  foodRate: number,
  serviceRate: number,
  ambienceRate: number,
  reviewedDate: Date,
}

export interface ResrvationCommand {
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

export interface GuestUserRestrationCommand {
  firstName: string,
  lastName: string,
  email: string,
  countryId: number,
  phoneNumber: string,
}

export interface ReservationResponse {
  qrCode: QrModel;
}

export interface QrModel {
  qrImage: string;
  fileName: string;
}


export interface ReviewFullModel {
  reviews: Review[];
  overallRate: number;
  overallFoodRate: number;
  overallServiceRate: number;
  overallAmbienceRate: number;
}


export interface MenuType {
  subMenuId: number;
  Type: string;
}

export interface Menu {
  id: number;
  subMenuType: string;
  subMenus: SubMenu[];
  updateDate: Date;
}

export interface SubMenu {
  id: number;
  subMenuType: string;
  items: SubMenuItem[];
}

export interface SubMenuItem {
  id: number;
  name: string;
  description: string;
  allergy: string;
  price: number;
  currency: string;
  currencyIcon: string;
  src: string;
  alt: string;
  quantity: number;
}

export interface AdditionalInformationModel {
  key: string;
  value: string;
  icon: string;
  isUrl: boolean;
}


export interface RestaurantSearchModel {
  id: number;
  isNew: boolean;
  isOpen: boolean;
  name: string;
  address: Address;
  imgSrc: string;
  imgAlt: string;
  averageRate: number;
  mainType: string;
  reviewerCount: number;
  freeTime: string;
  googleMapUrl: string;
}


export interface TableModel {
  id: number;
  xCoordinate: number;
  yCoordinate: number;
  personCount: number;
  restaurantId: number;
  status: string;
}

export interface TableImageModel {
  id: number;
  src: string;
  alt: string;
  tableId: number;
}
