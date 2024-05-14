import { Injectable } from '@angular/core';

import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { AppSettings } from 'src/app/common';
@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  constructor(private httpClient: HttpClient) { }

  getAllUsers()
  {
    return this.httpClient.get<any>(
      AppSettings.URLs.User.GetAllUser,  
    );
  }

  deleteUserById(id:number)
  {
    return this.httpClient.delete<any>(AppSettings.URLs.User.DeleteUserById + id);
  }

  postUser(value)
  {
    debugger;
    return this.httpClient.post<any>(AppSettings.URLs.User.AddUser,value);
  }
  
  getUserById(studentid)
  {
    return this.httpClient.get<any>(AppSettings.URLs.User.GetUserById+studentid);
  }
}
