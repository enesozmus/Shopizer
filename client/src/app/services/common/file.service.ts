import { Injectable } from '@angular/core';
import { firstValueFrom, Observable } from 'rxjs';
import { BaseStorageUrl } from 'src/app/shared/contracts/base_storage_url';
import { HttpClientService } from './http-client.service';


@Injectable({
    providedIn: 'root'
})


export class FileService {

    constructor(private httpClientService: HttpClientService) { }

    async getBaseStorageUrl(): Promise<BaseStorageUrl> {

        const getObservable: Observable<BaseStorageUrl> = this.httpClientService.get<BaseStorageUrl>({
            controller: "files",
            action: "getbasestorageurl"
        });

        return await firstValueFrom(getObservable);
    }

}