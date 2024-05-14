import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError  } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { User } from  '../app/model/user.interface';


@Injectable({
  providedIn: 'root'
})

export class UserService {
  private apiUrl = 'https://localhost:7217/api/user'; // Replace with your API URL

  constructor(private http: HttpClient) { }

  addUser(user: User): Observable<void> {
    return this.http.post<void>(this.apiUrl, user).pipe(
      catchError(error => {
        // Log the error or handle it as needed
        console.error('Error occurred while adding user:', error);
  
        return throwError(() => error);
      })
    );
  }
  

  updateUser(user: User): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/UpdateUser`, user).pipe(
        catchError(error => {
          // Log the error or handle it as needed
          console.error('Error occurred while adding user:', error);
    
          return throwError(() => error);
        })
      );
  }

//   getUsers(): Observable<User[]> {
//     return this.http.get<User[]>(this.apiUrl);
//   }

  getUser(userId: number): Observable<User> {
    return this.http.get<User>(`${this.apiUrl}/${userId}`);
  }

  deleteUser(userId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}?userId=${userId}`);
  }

  getUsers(): Observable<User[]> {
    return this.http.get<any[]>(this.apiUrl).pipe(
      map((data: any[]) => data.map((item: any) => this.mapToUserModel(item)))
    );
  }

  private mapToUserModel(data: any): User {
    debugger;
    return {
      userId: data.userId,
      username: data.username,
      email: data.email,
      // Map other fields as needed
    };
  }

}
