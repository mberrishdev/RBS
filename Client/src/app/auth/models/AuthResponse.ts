export interface AuthResponse {
  userId: number;
  userName: string;
  token: string;
  expires: Date;
  refreshToken: string;
}

