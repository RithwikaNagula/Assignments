export interface SignupRequest {
  username: string;
  email: string;
  password: string;
  fullName: string;
  role: string;
}

export interface LoginCredentials {
  username: string;
  password: string;
  captchaToken: string;
}

export interface TokenResponse {
  token: string;
  username: string;
  role: string;
  expiresAt: string;
}

export interface UserProfileDto {
  id: string;
  username: string;
  email: string;
  fullName: string;
  role: string;
}
