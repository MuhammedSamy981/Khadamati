import { HttpClient, HttpHeaders } from '@angular/common/http';
import UserReadDto from '../Types/Users/UserReadDto';
import { Observable } from 'rxjs';
import { UserDetailsDTO } from '../Types/Users/UserDetailsDto';
import UserLoginDTO from '../Types/Users/UserLoginDto';
import UserAddDTO from '../Types/Users/UserAddDto';
import { UserUpdateDto } from '../Types/Users/UserUpdateDto';
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private client: HttpClient,private router:Router) { }

  getAllUsers(): Observable<UserReadDto[]> {
    return this.client.get<UserReadDto[]>("http://localhost:5033/GetAll");
  }
  getAdmins(): Observable<UserReadDto[]> {
    return this.client.get<UserReadDto[]>("http://localhost:5033/GetAllAdmins");
  }
  getUsers(): Observable<UserReadDto[]> {
    return this.client.get<UserReadDto[]>("http://localhost:5033/GetAllUsers");
  }
  getUser(): Observable<UserDetailsDTO> {
    const requestOptions = { headers: this.RequestOption() };
    return this.client.get<UserDetailsDTO>(`http://localhost:5033/GetDetailsbyID`, requestOptions);
  }
  UpdateUser(UserDetails: UserUpdateDto): Observable<any> {
    const requestOptions = { headers: this.RequestOption() };
    return this.client.put<string>(`http://localhost:5033/Update`, UserDetails, requestOptions);
  }
  logInUser(UserLogin: UserLoginDTO): Observable<any> {
    return this.client.post<string>(`http://localhost:5033/login`, UserLogin);
  }
  RegisterUser(UserRegister: UserAddDTO): Observable<any> {
    return this.client.post<string>(`http://localhost:5033/User/Register`, UserRegister);
  }
  RegisterAdmin(UserRegister: UserAddDTO): Observable<any> {
    return this.client.post<string>(`http://localhost:5033/Admin/Register`, UserRegister);
  }
  IsLoggedIn(): Boolean {
    var logged=false;
    if (sessionStorage.getItem("Token") != null) {
      logged= true;
      const expiry = (JSON.parse(atob(sessionStorage.getItem("Token")!.split('.')[1]))).exp;
      if ((Math.floor((new Date).getTime() / 1000)) > expiry) {
        this.Logout();
        logged= false;
      }
    }
    if (localStorage.getItem("Token") != null) {
      logged= true;
      const expiry = (JSON.parse(atob(localStorage.getItem("Token")!.split('.')[1]))).exp;
      if ((Math.floor((new Date).getTime() / 1000)) > expiry) {
        this.Logout();
        logged= false;
      }
    }
    return logged;
  }
  IsUser(): Boolean {
    if (localStorage.getItem("Claims") != null && localStorage.getItem("Claims")?.includes("User")) {
      return true;
    }
    if (sessionStorage.getItem("Claims") != null && sessionStorage.getItem("Claims")?.includes("User")) {
      return true;
    }
    return false;
  }
  IsAdmin(): Boolean {
    //this.refreshClaims();
    if (localStorage.getItem("Claims") != null && localStorage.getItem("Claims")?.includes("Admin")) {
      return true;
    }
    if (sessionStorage.getItem("Claims") != null && sessionStorage.getItem("Claims")?.includes("Admin")) {
      return true;
    }
    return false;
  }
  IsManger(): Boolean {
    if (localStorage.getItem("Claims") != null && localStorage.getItem("Claims")?.includes("Manger")) {
      return true;
    }
    if (sessionStorage.getItem("Claims") != null && sessionStorage.getItem("Claims")?.includes("Manger")) {
      return true;
    }
    return false;
  }
  GetUserId(): string | null {
    if (localStorage.getItem("UserId") != null) {
      return localStorage.getItem("UserId");
    }
    else {
      return sessionStorage.getItem("UserId");
    }

  }
  Logout(): void {
    if (localStorage.getItem("UserId") != null) {
      localStorage.removeItem("UserId");
      localStorage.removeItem("Token");
      localStorage.removeItem("Claims");
    }
    else {
      sessionStorage.removeItem("UserId");
      sessionStorage.removeItem("Token");
      sessionStorage.removeItem("Claims");
    }

  }
  RequestOption(): HttpHeaders {
    var api_key;
    if (localStorage.getItem("Token") != null) {
      api_key = localStorage.getItem("Token");
    } else {
      api_key = sessionStorage.getItem("Token");
    }
    console.log(api_key);
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${api_key}`
    });
    return headers;
  }
  DeleteUser(userId: string) {
    return this.client.delete(`http://localhost:5033/Remove?id=${userId}`);
  }
  DeleteService(Id: Number) {
    return this.client.delete(`http://localhost:5033/api/Service/${Id}`);
  }
  DeleteRequest(Id: Number) {
    return this.client.delete(`http://localhost:5033/api/Request/${Id}`);
  }
  DeleteNotification(Id: Number) {
    return this.client.delete(`http://localhost:5033/api/Notification/${Id}`);
  }
  DeleteBookMark(Id: Number) {
    const requestOptions = { headers: this.RequestOption() };
    return this.client.delete(`http://localhost:5033/DeleteBookmark?serviceID=${Id}`, requestOptions);
  }
  AddBookMark(Id: Number) {
    const requestOptions = { headers: this.RequestOption() };
    return this.client.post(`http://localhost:5033/AddBookmark?serviceID=${Id}`, Id, requestOptions);
  }
  getClaims() {
    const requestOptions = { headers: this.RequestOption() };
    const string="Call"
    return this.client.post(`http://localhost:5033/Claims`,string,requestOptions);
  }
  CheackClaims(){
    if (this.IsLoggedIn()) {
      const RememberMe = localStorage.getItem("Token") != null;
      this.getClaims().subscribe(
        {
          next: (Utoken: any) => {
            if (RememberMe == true) {
              if (localStorage.getItem("Claims")?.includes("User") != Utoken["userclaims"].includes("User")) {
                this.Logout();
                this.router.navigateByUrl("/Login");
              }
            }
            else {
              if (sessionStorage.getItem("Claims")?.includes("User") != Utoken["userclaims"].includes("User")) {
                this.Logout();
                this.router.navigateByUrl("/Login");
              }
            }
          },
          error: (error) => {
            console.log(error.message);
          },
        }
      )
    }
  }
}
