import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserServiceService } from 'src/service/user-service.service'
@Component({
  selector: 'app-userdetail',
  templateUrl: './userdetail.component.html',
  styleUrls: ['./userdetail.component.css']
})

export class UserdetailComponent implements OnInit {
userId;
userDataById;
  constructor(private router: Router,private userService:UserServiceService) { 

    let param = this.router.parseUrl(this.router.url);
    this.userId = param.queryParams['userid'];
  }

  ngOnInit(): void {

    this.userService.getUserById(this.userId).subscribe(data=>{
      if(data.responseStatusCode==200)
      {
        this.userDataById=data.result;
      }
      else{
        alert("Unable to fetch data");
      }
     
    });
  }

  backToList()
  {
    this.router.navigate(['/user']);
  }

}
