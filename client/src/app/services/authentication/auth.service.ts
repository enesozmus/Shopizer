import { Injectable } from '@angular/core';
import { HttpClientService } from '../common/http-client.service';
import { Observable, firstValueFrom } from 'rxjs';
import { User } from 'src/app/shared/entities/user';
import { Register_User } from 'src/app/shared/contracts/users/register_user';
import { Login_User } from 'src/app/shared/contracts/users/login_user';

@Injectable({
    providedIn: 'root'
})

export class AuthService {

    constructor(private httpClientService: HttpClientService) { }

    // register
    async register(user: User): Promise<Register_User> {

        const observable: Observable<Register_User | User> = this.httpClientService.post<Register_User | User>({
            controller: "auth"
        }, user);
        return await firstValueFrom(observable) as Register_User;
    }

    // login
    async login(userName: string, password: string, callBackFunction?: () => void): Promise<Login_User> {

        const observable: Observable<Login_User | User> = this.httpClientService.post<Login_User | User>({
            controller: "auth",
            action: "login"
        }, { userName, password });

        const login: Login_User = await firstValueFrom(observable) as Login_User;
        debugger;
        if (login.token)
            localStorage.setItem("accessToken", login.token.accessToken);

        callBackFunction();
        return login;

    }
}