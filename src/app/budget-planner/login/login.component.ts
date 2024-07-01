import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  loginForm: any;
  registerForm: any;
  activeForm: 'login' | 'register' = 'login';

  private baseUrl = 'http://localhost:5000/api/user/register'; // Replace with your ASP.NET Core backend URL

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private snackBar: MatSnackBar,
    private http: HttpClient
  ) {}

  ngOnInit() {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });

    this.registerForm = this.fb.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  toggleForm(form: 'login' | 'register') {
    this.activeForm = form;
  }

  login() {
    // Implement login logic here
  }

  register() {
    if (this.registerForm.valid) {
      this.http.post(this.baseUrl, this.registerForm.value)
        .subscribe(
          () => {
            console.log('Registration successful');
            this.snackBar.open('Registration successful!', 'Close', { duration: 3000 });
            setTimeout(() => {
              this.router.navigate(['/budget-planner/login']);
              this.registerForm.reset();
            }, 2000);
          },
          error => {
            console.error('Registration failed:', error);
            this.snackBar.open('Registration failed. Please try again.', 'Close', { duration: 3000 });
          }
        );
    } else {
      this.snackBar.open('Please fill in all fields correctly', 'Close', { duration: 3000 });
    }
  }
}
