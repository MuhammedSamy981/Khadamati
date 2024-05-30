export interface NotificationDto {
  Id: number;
  Text: string;
  date: string;
  seen: boolean;
  UserId?: string;
  User?: NotificationUserDto;
}

export interface NotificationUserDto {
  UserId?: string;
  UserName?: string;
  Email?: string;
}
export interface NotificationAddDto {
  text: string;
  date: string;
  seen: boolean;
  userId: string | null;
}