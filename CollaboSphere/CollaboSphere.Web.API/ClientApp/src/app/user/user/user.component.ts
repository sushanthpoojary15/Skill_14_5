import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/model/user.interface';
import { UserServiceService } from 'src/service/user-service.service'
import { Router } from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  
 userList:any;
 userId;
  constructor(private userService:UserServiceService, private router: Router) { }

  ngOnInit(): void {

    this.userService.getAllUsers().subscribe(data=>{
      this.userList = data.sort((a, b) => {
        if (a.isActive === b.isActive) {
          return 0;
        } else if (a.isActive) {
          return -1;
        } else {
          return 1;
        }
      });

    });
  }

  redirectToView(userId)
  {
    this.router.navigate(["/user-details"], {
      queryParams: { userid: userId},
      skipLocationChange: true,
    });
  }

  redirectToEdit(userId)
  {
    this.router.navigate(["/edit-user"], {
      queryParams: { userid: userId},
      skipLocationChange: true,
    });
  }

  intializeId(userId:number)
  {
    this.userId=userId;
  }
  deleteUser(userid:number)
  {
    debugger;
    if(userid!=0)
    {
      this.userService.deleteUserById(userid).subscribe((res)=>{
        if(res.responseStatusCode=="200")
        {
          alert(res.responseMessage);
          window.location.reload();
        }
        else{
          alert(res.responseMessage);
          window.location.reload();
        }
      });
    }
   
  }

  closeModel()
  {
    this.userId=0;
  }

  

}
