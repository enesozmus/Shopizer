## E-Commerce Application
> * [Gençay Yıldız'ın](https://www.youtube.com/c/Gen%C3%A7ayY%C4%B1ld%C4%B1z/featured) `"Asp.NET Core 6 + Angular 13 | Mini E-Ticaret Uygulama Serisi"` adlı video serisi takip edilerek geliştirilen e-ticaret kurgulu bir **ASP.NET Core Web API** tüketen **Angular** uygulamasıdır.
> * Çalışma devam etmektedir.

<p align="right">
        <a href="https://docs.microsoft.com/en-us/dotnet/csharp/" target="_blank"> <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" alt="csharp" width="42" height="42"/></a>
        <a href="https://dotnet.microsoft.com/" target="_blank"> <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" alt="dotnetcore" width="43" height="43"/></a>
        <a href="https://www.microsoft.com/en-us/sql-server" target="_blank" rel="noreferrer"> <img src="https://www.svgrepo.com/show/303229/microsoft-sql-server-logo.svg" alt="mssql" width="43" height="43"/></a>
        <a href="https://angular.io/" target="_blank"> <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/angularjs/angularjs-original.svg" alt="angular" width="42" height="42"/></a>
        <a href="https://www.typescriptlang.org/" target="_blank"><img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/typescript/typescript-original.svg" alt="typescript" width="42" height="42"/></a>
</p>

## İzlence
> * **Onion Architecture** kullanıldı.
> * Gerçek hayattaki nesnelerin birer modellemeleri olan yazılımdaki Class'ları ilişkisel bir veri tabanının tablo ve sütunlarına eşlemeyi basitleştiren bir **Nesne İlişkisel Eşleyici** olan **Entity Framework Core** kullanıldı.
> * IEntityTypeConfiguration Interface'leri ile **veri tabanı konfigürasyonları** sağlandı.
> * Domain katmanında yer alan Entity'ler için **abstract bir base sınıf** kullanıldı.
> * **Optimal Generic Repository Design Pattern** kullanıldı.
> * **EF Core Tracking Performans Optimizasyonu** sağlandı.
> * Ekleme ve güncelleme işlemleri yaparken bu işlemlerin yapılış tarihlerini kaydetmeyi otomatik hale getiren **isteğe uyarlanmış SaveChangeAsync** yazıldı.
> * Kendi API'miz ve Angular uygulamamız arasında iletişimi sağlamak adına bir sunucunun default olarak sahip olduğu **same-origin-policy** politikasını gevşetmesine izin veren ve bir W3C standardı olan **Cross Origin Resource Sharing** izinleri sağlandı.
> * Client'ımızın bir başka uç noktayla (endpoint) iletişim kurması ve url üzerinden bu noktaya Http istekleri atabilmesini sağlayan özelleştirilmiş bir **HttpClient Servis** yazıldı.
> * Veri tabanı **tohumlandı**.
> * Mapping işlemleri için **AutoMapper Kütüphanesi** kullanıldı.
> * **'Command'** ve **'Query'** sorumluluklarının ayrılması prensibini esas alan bir yaklaşım olan **CQRS** ve bu yaklaşımı uygulayan **MediatR Kütüphanesi** kullanıldı.
> * Hem API hem de Client tarafında ürün ekleme işlemi gerçekleştirildi.
> * API tarafında **FluentValidation** kütüphanesi entegre edildi.
> * Fluent doğrulama hataları ürün ekleme formunda olası hataları yakalamak üzere **Client tarafına taşınarak** kullanıcıya gösterildi.
> * Bir request nesnesi doğrulanmak istendiğinde direkt geçersiz verilerle MediatR kütüphanesinin handler sınıflarına girmeyerek bu doğrulamayı daha önce kontrol etmeye yarayan **MediatR Pipeline Behaviour** entegre edildi.
> * Uygulama içindeki exception'larımızı merkezi bir konumdan yönetebilmemizi sağlayan ve bir middleware olan **"Global Excaption Handler"** middleware'i entegre edildi.
> * Sorgulama, sıralama ve sayfalama mantığının nereye yerleştirileceği sorununa bir **Domain-Driven-Design** tasarım çözümü olan **Specification Design Pattern** projeye entegre edildi.
> * 50'den fazla farklı **'loading spinners'** içeren bir kitaplık olan **ngx-spinner** projeye entegre edildi.
> * **Specification Design Pattern** kullanılarak hem API hem de Client tarafında **sayfalama**, isim ve fiyat değerlerine göre **sıralama** ve marka-renk-beden değerlerine göre **filtreleme** işlemleri tamamlandı.
> * Bütün delete operasyonlarında kullanılabilecek bir **custom directive** ve **modal dialog** yazıldı.

> * **!:** Client tarafında ayrıca doğrulama kuralları henüz yazılmadı ilerleyen günlerde yazılacaktır.
> * **!:** Ürün ekleme işleminde kullanılan form ilerleyen günlerde **"reactive forms"** kullanımına geçirilecektir.