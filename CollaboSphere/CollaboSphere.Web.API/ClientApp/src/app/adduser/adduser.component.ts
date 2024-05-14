import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserServiceService } from 'src/service/user-service.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-adduser',
  templateUrl: './adduser.component.html',
  styleUrls: ['./adduser.component.css']
})
export class AdduserComponent implements OnInit {
  userForm: FormGroup;
    initialIsActiveValue: boolean = false;
  roles: { roleId: number, roleName: string }[] = [
    { roleId: 1, roleName: 'Admin' },
    { roleId: 2, roleName: 'User' },
    { roleId: 3, roleName: 'Super Admin' }
    // Add more roles as needed
  ];
  constructor( public _fb: FormBuilder, private userService:UserServiceService,private router: Router) {
    this.userForm=this._fb.group({
      //userId: new FormControl('',Validators.compose([Validators.required])),
      roleId: new FormControl('1',Validators.compose([Validators.required])),
      username: new FormControl('',Validators.compose([Validators.required])),
      email: new FormControl('',Validators.compose([Validators.required])),
      password: new FormControl('',Validators.compose([Validators.required])),
      firstName: new FormControl('',Validators.compose([Validators.required])),
      lastName: new FormControl('',Validators.compose([Validators.required])),
      isActive: new FormControl(this.initialIsActiveValue,Validators.compose([Validators.required]))
   
    });
    // this.userForm = this._fb.group({
    //   isActive: [false, Validators.required], // Set initial value here
    //   // Other form controls...
    // });
   }

  ngOnInit(): void {

  }

  onSubmitForm(data)
  {
    if(this.userForm.valid)
      {
        if(data.isActive=="true")
          {
            var a=true;
          }
          else{
            var a=false;
          }
        const values={
         // "userId":data.userId,
          "username":data.username,
          "password":data.password,
          "email":data.email,
          "firstName":data.firstName,
          "lastName":data.lastName,
          "roleId":data.roleId,
          "isActive":a
          // "Documents": [
          //   {
          //     "documentId": 0,
          //     "documentName": "string",
          //     "uploadDate": "2024-05-13T17:47:53.121Z",
          //     "uploadedByUserId": 0,
          //     "projectId": 0
          //   }
          // ],
        }
        this.userService.postUser(values).subscribe((res)=>{
          if(res.responseStatusCode=="200")
            {
              alert(res.responseMessage);
              this.router.navigate(['/user']);   
            }
            else{
              alert(res.responseMessage);   
            }
        });
        
      }
    else{
     this.validateAllFields(this.userForm);
    }
  }
  clearAllFields()
  {
    this.userForm.reset();
  }
  validateAllFields(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach(field => {
      const control = formGroup.get(field);
      if (control instanceof FormControl) {
        control.markAsDirty({ onlySelf: true });
      } else if (control instanceof FormGroup) {
        this.validateAllFields(control);
      }
    });
  
  }

}
