import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { AuthLoginModel } from '../auth-model/authLoginModel';
import { RegisterModel } from '../auth-model/registerModel';
import { AuthService } from '../auth-service/auth.service';

declare var $: any;

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {

  constructor(
    private authService: AuthService,
    private router: Router,
    private messageService: MessageService
  ) { }

  email: string;
  password: string;

  ngOnInit(): void {
    $(document).ready(function () {
      $('.login-info-box').fadeOut();
      $('.login-show').addClass('show-log-panel');
    });


    $('.login-reg-panel input[type="radio"]').on('change', function () {
      if ($('#log-login-show').is(':checked')) {
        $('.register-info-box').fadeOut();
        $('.login-info-box').fadeIn();

        $('.white-panel').addClass('right-log');
        $('.register-show').addClass('show-log-panel');
        $('.login-show').removeClass('show-log-panel');

      }
      else if ($('#log-reg-show').is(':checked')) {
        $('.register-info-box').fadeIn();
        $('.login-info-box').fadeOut();

        $('.white-panel').removeClass('right-log');

        $('.login-show').addClass('show-log-panel');
        $('.register-show').removeClass('show-log-panel');
      }
    });

  }

  loginForm = new FormGroup({
    email: new FormControl("", [Validators.required, Validators.minLength(5), Validators.email]),
    password: new FormControl("", [Validators.required, Validators.minLength(6)]),
  });

  registerForm = new FormGroup({
    firstName: new FormControl("", Validators.required),
    lastName: new FormControl("", Validators.required),
    email: new FormControl("", [Validators.required, Validators.email]),
    password: new FormControl("", [Validators.required, Validators.minLength(6)]),
    confirmPassword: new FormControl("", [Validators.required, Validators.minLength(6)]),
  })

  login() {

    var model: AuthLoginModel = {
      email: this.email,
      password: this.password
    };

    this.authService.login(model).subscribe(response => {
      this.messageService.add({ severity: 'success', summary: response.message });
      this.router.navigate(["/home"])
    }, err => {
      this.messageService.add({ severity: 'error', summary: err.message })
    });

  }

  register() {
    let regisretModel: RegisterModel
    if (this.registerForm.valid) {

      let password = this.registerForm.value["password"];
      let confirmPassword = this.registerForm.value["confirmPassword"];

      if (password == confirmPassword) {

        regisretModel = {
          email: this.registerForm.value["email"],
          password: this.registerForm.value["password"],
          firstName: this.registerForm.value["firstName"],
          lastName: this.registerForm.value["lastName"],
        };

        this.authService.register(regisretModel).subscribe(response => {
          this.messageService.add({ severity: 'success', summary: response.message });
          this.router.navigate(["/home"]);
        }, err => {
          this.messageService.add({ severity: 'error', summary: err.message })
        });

      } else {
        this.messageService.add({ severity: 'error', summary: "Passwords do not match." })
      }
    }
  }

  clear() {
    this.messageService.clear();
  }

}
