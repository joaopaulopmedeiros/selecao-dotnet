import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  constructor() {}

  login(user: any) {
    return new Promise((resolve) => {
      window.localStorage.setItem('token', 'mock');
      resolve(true);
    });
  }

  register(account: any) {
    return new Promise((resolve) => {
      resolve(true);
    });
  }
}
