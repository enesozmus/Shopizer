import { Injectable } from '@angular/core';
import { HttpClientService } from '../common/http-client.service';
import { Observable, firstValueFrom } from 'rxjs';
import { User } from 'src/app/shared/entities/user';
import { Register_User } from 'src/app/shared/contracts/users/register_user';
import { Login_User } from 'src/app/shared/contracts/users/login_user';
import { SocialUser } from '@abacritt/angularx-social-login';
import { Token } from 'src/app/shared/contracts/tokens/token';

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
        
        if (login.token)
        {
            localStorage.setItem("accessToken", login.token.accessToken);
            localStorage.setItem("refreshToken", login.token.refreshToken);
        }
            

        callBackFunction();
        return login;
    }

    //
    async refreshTokenLogin(refreshToken: string, callBackFunction?: () => void): Promise<any> {

        const observable: Observable<any | Token> = this.httpClientService.post({
            action: "refreshtokenlogin",
            controller: "auth"
        }, { refreshToken: refreshToken });

        const token: Token = await firstValueFrom(observable) as Token;

        if (token) {
            localStorage.setItem("accessToken", token.accessToken);
            localStorage.setItem("refreshToken", token.refreshToken);
        }

        callBackFunction();
    }

    // google-login
    async googleLogin(user: SocialUser, callBackFunction?: () => void): Promise<any> {
        const observable: Observable<SocialUser | Token> = this.httpClientService.post<SocialUser | Token>({
            action: "google-login",
            controller: "auth"
        }, user);

        const token: Token = await firstValueFrom(observable) as Token;
        if (token) {
            localStorage.setItem("accessToken", token.accessToken);
            localStorage.setItem("refreshToken", token.refreshToken);
        }
        callBackFunction();
    }
}