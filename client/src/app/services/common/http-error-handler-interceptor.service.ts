import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpStatusCode } from '@angular/common/http';
import { catchError, Observable, of } from 'rxjs';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../authentication/auth.service';


@Injectable({
    providedIn: 'root'
})

export class HttpErrorHandlerInterceptorService implements HttpInterceptor {

    constructor(private route: Router, private toastr: ToastrService, private authService: AuthService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        // her http isteğinde buraya girer
        //console.log('first');

        return next.handle(req).pipe(catchError(error => {
            // hata varsa buraya girer
            console.log('second');

            // start - switch
            switch (error.status) {
                case HttpStatusCode.NotFound:
                    this.route.navigateByUrl('not-found');
                    this.toastr.error(error.message, error.statusText);
                    //alert('not-found');
                    /*this.toastrService.message("Sayfa bulunamadı!", "Sayfa bulunamadı!", {
                        messageType: ToastrMessageType.Warning,
                        position: ToastrPosition.BottomFullWidth
                    });*/
                    break;
                case HttpStatusCode.BadRequest:
                    //this.route.navigateByUrl('not-found');
                    //alert('bad-request');
                    this.toastr.error(error.message, error.statusText);
                    /*this.toastrService.message("Geçersiz istek yapıldı!", "Geçersiz istek!", {
                        messageType: ToastrMessageType.Warning,
                        position: ToastrPosition.BottomFullWidth
                    });*/
                    break;
                case HttpStatusCode.InternalServerError:
                    //this.route.navigateByUrl('not-found');
                    //alert('server-error');
                    this.toastr.error(error.message, error.statusText);
                    /*this.toastrService.message("Sunucuya erişilmiyor!", "Sunucu hatası!", {
                        messageType: ToastrMessageType.Warning,
                        position: ToastrPosition.BottomFullWidth
                    });*/
                    break;
                case HttpStatusCode.Unauthorized:
                    //this.route.navigateByUrl('not-found');
                    //alert('unauthorized-error');
                    this.toastr.error(error.message, error.statusText);
                    this.authService.refreshTokenLogin(localStorage.getItem("refreshToken")).then(data => { });
                    /*this.toastrService.message("Bu işlemi yapmaya yetkiniz bulunmamaktadır!", "Yetkisiz işlem!", {
                        messageType: ToastrMessageType.Warning,
                        position: ToastrPosition.BottomFullWidth
                    });*/
                    break;
                default:
                    alert('http-error');
                    /*this.toastrService.message("Beklenmeyen bir hata meydana gelmiştir!", "Hata!", {
                        messageType: ToastrMessageType.Warning,
                        position: ToastrPosition.BottomFullWidth
                    });*/
                    break;
            }
            // end -switch
            return of(error);
        }))
    }

}