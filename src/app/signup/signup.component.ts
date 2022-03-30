import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SignupRequest } from '../requests/signup-request';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  signupRequest: SignupRequest = {
    email: "",
    password: "",
    confirmPassword: "",
    firstName: "",
    lastName: "",
    ts: new Date()
  };
  isSuccessful = false;
  isSignUpFailed = false;
  errorMessage = '';
  constructor(private userService: UserService, private router:Router) { }
  ngOnInit(): void {
  }
  onSubmit(signupForm: any): void {
    console.log("kjdjkdldf,d");
    console.log(JSON.stringify(signupForm));
 
    this.userService.signup(this.signupRequest).subscribe({
      next: data => {
        console.log(data);
        console.log("success");
        this.isSuccessful = true;
        this.isSignUpFailed = false;
        this.router.navigate(['profile']);
      },
      error: err => {
        //this.errorMessage = err.error.message;
        this.isSignUpFailed = true;
      }
    });
  }

}
