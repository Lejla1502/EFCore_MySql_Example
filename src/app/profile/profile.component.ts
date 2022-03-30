import { Component, OnInit } from '@angular/core';
import { UserResponse } from '../responses/user-response';
import { TokenService } from '../services/token.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  user: UserResponse = {
    email: '',
    firstName: '',
    lastName: '',
    creationDate: new Date()
  }


  userId:number=+(window.localStorage.getItem('ID') || 0);

  constructor(private userService: UserService, private tokenService: TokenService) { }
 
  ngOnInit(): void {
   
    this.userService.getUserInfo().subscribe(
      {
        next: (data => {
          console.log("data");
          console.log(data);
          this.user = data;
        }),
        error: (() => {
          console.log('failed to get the use info');
        })
      }
 
    );
  }
}
