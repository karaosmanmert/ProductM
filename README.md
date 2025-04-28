# ProductM
# Ürün Yönetim Sistemi (Product Management System)

Bu proje, ASP.NET Core MVC kullanarak geliştirilmiş basit bir Ürün Yönetim Sistemi uygulamasıdır. Ürün verileri uygulama belleğinde (in-memory) static bir liste olarak saklanmaktadır.

## Proje Konusu

Bir şirketin ürünlerini yönetebileceği, kullanıcıların sisteme giriş yapmadan ürün listeleme, ekleme, güncelleme, silme ve detay görme işlemlerini yapabildiği bir web uygulaması geliştirmek.

## Uygulama Özellikleri (CRUD İşlemleri)

Uygulama ana sayfası üzerinden aşağıdaki işlemleri gerçekleştirebilirsiniz:

- Ürün Listeleme: Sisteme ekli tüm ürünleri ana sayfada görüntüleme.
- Yeni Ürün Ekleme: Yeni ürün bilgileri girerek listeye ekleme.
- Ürün Bilgilerini Güncelleme: Mevcut bir ürünün bilgileri düzenleme ve kaydetme.
- Ürünü Silme: Listedeki bir ürünü sistemden kalıcı olarak silme (onay adımı ile).
- Ürün Detaylarını Görme: Bir ürünün detaylarını görüntüleme.


## Teknik Gereksinimler ve Kullanılan Teknolojiler
ASP.NET Core MVC Yapısı: Model, View, Controller (MVC) tasarım deseni kullanılmıştır.
View Sayfaları: Razor (.cshtml) motoru ile oluşturulmuştur.
Veri Saklama: Veriler, uygulama çalıştığı sürece bellekte static bir `List<Product>` nesnesinde saklanmaktadır (in-memory). Uygulama kapatıldığında veya yeniden başlatıldığında veriler kaybolur.

Not: Ürün verileri uygulama çalıştığı sürece bellekte (static liste) tutulur. Uygulama durdurulduğunda veya yeniden başlatıldığında tüm veriler kaybolur.

## Kurulum ve Çalıştırma

Projeyi kendi yerel ortamınızda kurmak ve çalıştırmak için aşağıdaki adımları izleyin:

1.  .NET SDK Kurulumu: .NET 8.0 ait SDK'nın bilgisayarınızda kurulu olduğundan emin olun. [.NET İndirme Sayfası](https://dotnet.microsoft.com/download)
2.  Proje Dosyalarını Edinin: Projenin kaynak kodunu zip olarak indirin veya Git kullanarak depodan klonlayın.
3.  IDE ile Açma: Projeyi Visual Studio veya Visual Studio Code gibi uyumlu bir IDE ile açın. `.csproj` dosyasını açmanız yeterlidir.
4.  Bağımlılıkları Yükleme: IDE genellikle projeyi açtığınızda gerekli NuGet paketlerini otomatik olarak geri yükleyecektir. Eğer otomatik olmazsa, IDE'nin terminalinde veya sistem komut isteminde projenin ana klasörüne giderek `dotnet restore` komutunu çalıştırın.
5.  Uygulamayı Çalıştırın: IDE üzerinden projeyi çalıştırın (genellikle `F5` hata ayıklama ile veya `Ctrl+F5` hata ayıklama olmadan). Uygulama yerel bir web sunucusunda başlayacak ve varsayılan tarayıcınızda açılacaktır.

Uygulama varsayılan olarak `https://localhost:XXXX` gibi bir adreste çalışacaktır.
