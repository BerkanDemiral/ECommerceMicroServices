# E Commerce WEB Project

## 1. MongoDB:
* MongoDB bir NoSQL veritabanıdır ve diğer ilişkisel veritabanlarının aksine yatay olarka da çoğaltılabilir. Veriler JSON formatında tutulurlar. 
* İlişkisel veritabanından farkları şunlar gibidir;
    1. Tablolar - Collection
    2. Satırlar - Document
    3. Sütunlar - Field yapısına karşılık gelmektedir.
* MongoDB'de Migration kavramı kullanılmaz. Tablolar oluştrulup proje ayağa kaldırıldıktan sonra eşleşmeler sağlanır.
* .NET Core projesinde MongoDB geliştirmesi yapabilmek için bu 3 paketin kurulu olması gerekmektedir.

![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/772e777a-08db-43e7-bed7-1845792e1279)

### 1.2 .Net Entity Tanımları ve MongoDB Kullanımı

* Normalde EntityFramework ve MSSQL ile kullanırken belirli Key tanımları yapılabilmektedir. MongoDB'de de buna benzer şekilde belirli tanımlar yapılabilmektedir.
* Örneğin [BsonId] ve [BsonRepresentation(BsonType.ObjectId)] değeri o değerin bir Identity ID olduğunu belirtir
* Aynı şekilde bir Foreign Key anahtarı kullanırken Category Category alanının veritabanına yazılmasını istemeyiz ama program içerisinde kullanmamız gerekir. Bu durumda da [BsonIgnore] key'ini kullanmalıyız.
![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/68e3296c-0798-4287-b470-f1916722d112)
![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/25e0be23-22b6-4007-8ca8-e9dae6c1b5ca)


### 1.3 Connection Konfigürasyonu

* MongoDB ve Core geliştirirken Migration kullanılmaz. Bunun yerine bağlantılar appsettings.json tarafında yönetilir.
* EntityFramework'deki gibi bazı isimlendirmeler ile bu veritabanı değerlerinin kolay adlandırması ve eşlenmesi sağlanabilir. Örneğin Category olarak yazdığımız bir entitynin Categories olarak görünmesi için "CategoryCollectionName": "Categories", isimlendirmesi yapılır. Bu sayede bu entity'nin veritabanında otomatik olarak Categories'e dönüşmesi sağlanır.
![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/39efa40f-1ec3-48fe-9dc5-f9bb5ffdb91c)(apssettings.json)
![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/4612bee8-625c-4c6b-a179-8d50e3d87f47)(Interface)
![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/ac97c6c5-05fb-469b-a7c7-0b6b938a2382)(Class)

### 1.4 DTO Tanımları

* DTO'lar, direkt olarak veritabanına dışardan erişimi engelleyen, veritabanı kolonları ile işlem yapmak yerine bir nevi onların imzaları ile, görmek istediğimiz veya göstermek istediğimiz alanları ile işlem yapmamıza olanak sağlayan yapılardır.
* Burada tanımları kısmı karmaşık ve zor olsa da daha sonrasında programlama kısmında hem yapıyı daha da kolaylaştıracak hem de daha güvenli hale getirecektir.
* Güncel projemizdeki DTO mimarisi bu şekildedir.
* Sadece Create kısmında bir ID eklemesi yapmayacağımız için IDENTITY verinin ID'sini yazmayız. Onun dışında isteğe bağlı olsa da, genel olarka tüm veriler Entity ile benzer olacaktır.

![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/27f694f0-b490-4a49-b927-df78f1226791)
![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/86190233-68f4-4627-8301-b2e7272701da)(Create)
![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/bcc32b47-b89e-4f41-a27c-149872ab737f)(Result)

### 1.5 AutoMapper

* AutoMapper yapısı DTO'lar ve Entity'leri otomatik olarak eşleştirmeye olanak sağlayan bir kütüphanedir.
* Aynı zamanda normalde bir entity'nen new diyerek nesnesi oluşturulur ve atanacak değerler bu şekilde categor.Name = .. diyerek atanır. AutoMapper'lar sayesinde bu yapı daha hızlı ve otomatik bir şekilde yapılır. 
* Nuget paketi ile 2 adet kütüphane kurarak kullanılabilir. 
![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/5f0445df-1c75-4d76-a7a4-e6fce5a84d18)


* Ardından yine Catalog içerisinde bir Mapping klasörü açarak GeneralMapping işlemini buradaki gibi gerçekleştirebiliriz.
![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/626abd42-2842-45ac-8afb-3261766219f1)





