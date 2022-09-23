import { Injectable } from '@angular/core';
import { HttpClientService } from '../common/http-client.service';
import { Observable, firstValueFrom } from 'rxjs';
import { User } from 'src/app/shared/entities/user';
import { Create_User } from 'src/app/shared/contracts/users/create_user';

@Injectable({
    providedIn: 'root'
})

export class AuthService{

    constructor(private httpClientService: HttpClientService){}

    async register(user: User): Promise<Create_User> {
        
        const observable: Observable<Create_User | User> = this.httpClientService.post<Create_User | User>({
            controller: "auth"
        }, user);
        return await firstValueFrom(observable) as Create_User;
    }
}