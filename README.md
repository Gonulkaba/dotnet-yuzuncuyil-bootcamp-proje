## Techcareer.net Cumhuriyet'imizin 100. Yılına Özel - Back-End .Net Bootcamp Proje
### Proje Açıklaması:
Bu proje, .NET Core kullanılarak geliştirilmiş ve katmanlı mimariyi temel alarak _Duty_, _Employee_ ve _EmployeeProfile_ gibi veritabanı nesneleri üzerinde temel CRUD (Create, Read, Update, Delete) işlemlerini gerçekleştiren bir uygulamayı içermektedir.

### Proje Hedefi
* Temiz bir kod yapısı oluşturmak ve sürdürülebilirlik sağlamak için katmanlı mimari kullanımı.
* .NET Core'un güçlü özelliklerinden faydalanarak veritabanı işlemlerini yönetmek.
* RESTful API yapısı üzerinde CRUD operasyonlarını gerçekleştirmek.
* Örnek bir proje üzerinden .NET Core'un yeteneklerini ve pratik kullanımını göstermek.
  
### Kullanılan Teknolojiler
* .NET Core 6.0: Uygulama geliştirmek için kullanılan temel platform.
* Entity Framework Core: Nesne ilişkisel eşleme (ORM) için kullanılmıştır.
* Swagger: API dokümantasyonu ve testi için kullanılmıştır.

### Katmanlı Mimaride Yapı
Proje, aşağıdaki katmanlı mimariye dayanmaktadır:

**Core Katmanı:** Bu katman, genel işlevleri ve ortak kod parçalarını içeren temel bir katmandır. Bu katmanda, uygulamanın çekirdek işlevleri ve iş mantığı yer alır. İçerisinde; _Model_, _DTOs_, _Repository Interfaces_, _Service Interfaces_, _UnitofWork Interfaces_ yapılarını içerir.

**Veritabanı Katmanı (Repository Layer):** Bu katmanda, veritabanı işlemlerini soyutlar ve veri erişimini kolaylaştırırken, iş mantığı ve veri erişimi arasındaki bağı azaltır. İçerisinde; _Migrations_, _Seeds_, _Repository Implementation_, _UnitofWork Implementation_ yapılarını içerir.

**İş Katmanı (Service Layer):** Bu katmanda, iş mantığı ve veritabanı etkileşimlerini içerir. İçerisinde; _Mapping_, _Service Implementation_, _Validations_, _Exceptions_ yapılarını içerir.

**API Katmanı:** RESTful API yapıları burada bulunmaktadır. HTTP isteklerini alır, ilgili işlemi Core katmanındaki servislere yönlendirir ve sonuçları istemcilere döndürür.

### Nasıl Çalıştırılır
Projeyi klonlayın:
`git clone https://github.com/Gonulkaba/dotnet-yuzuncuyil-bootcamp-proje.git`

Visual Studio veya Visual Studio Code gibi bir IDE kullanarak projeyi açın.

Veritabanı bağlantı ayarlarını yapın ve veritabanını oluşturun. Bu adım için appsettings.json dosyasını düzenleyebilirsiniz.

Proje üzerinde çalıştırın. API, belirlediğiniz portta çalışacaktır.

### Daha Fazla Bilgi
Bu proje hakkında daha fazla ayrıntı için [Medium makalemi](https://medium.com/@gonulkaba/net-core-ile-katmanl%C4%B1-mimaride-proje-geli%C5%9Ftirme-0f78e0d18fe6) okuyabilirsiniz. Her katmanın oluşturulma aşamalarını ve içerikleri hakkındaki detaylı bilgileri makalelerimde paylaştım :)
