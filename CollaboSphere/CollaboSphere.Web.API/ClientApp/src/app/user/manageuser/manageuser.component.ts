import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';
import { FormGroup, FormBuilder } from '@angular/forms';

import { User } from '../../model/user.interface'; // Adjust the path as necessary
import { UserService } from 'src/app/user.service';

@Component({
  selector: 'app-manageuser',
  templateUrl: './manageuser.component.html',
  styleUrls: ['./manageuser.component.css']
})
export class ManageuserComponent implements OnInit {
  userForm: FormGroup;
  userService: UserService;
  userId!: number;

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private fb: FormBuilder,
    private us: UserService
  ) { 
    this.userForm = this.fb.group({
      firstName: '',
      lastName: '',
      username: '',
      email: '',
      roleId: 0,
      isActive: false
    }); 
    this.userService = us;
  }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.userId = +params['id']; // + converts string to number
      if (this.userId === 0) {
        this.userForm = this.initializeForm();
      } else {
        debugger;
       this.userService.getUser(this.userId)
      .subscribe((data: User) => {
        this.userForm = this.initializeForm(data);
      }, (error: any) => {
        console.error('Error fetching user data:', error);
      });
      }
    });
  }

  initializeForm(userData?:User): FormGroup {
    debugger;
    return this.fb.group({
      userId:userData?.userId || 0,
      firstName: userData?.firstName || '',
      lastName: userData?.lastName || '',
      username: userData?.username || '',
      email: userData?.email || '',
      roleId: userData?.roleId || null,
      isActive: userData?.isActive || false
    });
  }

  goBack(): void {
    this.location.back();
  }

  onSubmit(): void {
   debugger;
    if (this.userForm.valid) {
      // Handle form submission
      if(this.userId == 0)
      {
        this.userService.addUser(this.userForm.value).subscribe({
          next: () => {
            // Handle successful addition of the user
          }
        });
      }
      else
      {
        this.userService.updateUser(this.userForm.value).subscribe({
          next: () => {
            // Handle successful addition of the user
          }
        });
      }
      
    }
  }

  
}
