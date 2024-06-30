# E Commerce WEB Project

## 1. MongoDB:
* MongoDB bir NoSQL veritabanıdır ve diğer ilişkisel veritabanlarının aksine yatay olarka da çoğaltılabilir. Veriler JSON formatında tutulurlar. 
* İlişkisel veritabanından farkları şunlar gibidir;
    1. Tablolar - Collection
    2. Satırlar - Document
    3. Sütunlar - Field yapısına karşılık gelmektedir.
* MongoDB'de Migration kavramı kullanılmaz. Tablolar oluştrulup proje ayağa kaldırıldıktan sonra eşleşmeler sağlanır.
* .NET Core projesinde MongoDB geliştirmesi yapabilmek için bu 3 paketin kurulu olması gerekmektedir.

  ![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/d2d5bc25-6779-4e6b-8252-bea481c239f0)

### 1.2 .Net Entity Tanımları ve MongoDB Kullanımı

* Normalde EntityFramework ve MSSQL ile kullanırken belirli Key tanımları yapılabilmektedir. MongoDB'de de buna benzer şekilde belirli tanımlar yapılabilmektedir.
* Örneğin [BsonId] ve [BsonRepresentation(BsonType.ObjectId)] değeri o değerin bir Identity ID olduğunu belirtir
* Aynı şekilde bir Foreign Key anahtarı kullanırken Category Category alanının veritabanına yazılmasını istemeyiz ama program içerisinde kullanmamız gerekir. Bu durumda da [BsonIgnore] key'ini kullanmalıyız.
* ![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/00b2c802-c17a-43fa-9b48-5ff8765e0bec) --- ![image](https://github.com/BerkanDemiral/ECommerceWeb/assets/54038172/3f594b48-be3b-4ff8-92d4-75b2e71a5e77)

### 1.3 Connection Konfigürasyonu

* MongoDB ve Core geliştirirken Migration kullanılmaz. Bunun yerine bağlantılar appsettings.json tarafında yönetilir.
* EntityFramework'deki gibi bazı isimlendirmeler ile bu veritabanı değerlerinin kolay adlandırması ve eşlenmesi sağlanabilir. Örneğin Category olarak yazdığımız bir entitynin Categories olarak görünmesi için "CategoryCollectionName": "Categories", isimlendirmesi yapılır. Bu sayede bu entity'nin veritabanında otomatik olarak Categories'e dönüşmesi sağlanır.
![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/63391de1-1503-4f2e-b05d-90c2bc66851a)(apssettings.json)
![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/f04c0806-14ce-42e4-aa85-f558c2f73648)(Interface)
![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/c48ec193-a8d6-4b1a-b283-d15fd6fa5dde)(Class)

### 1.4 DTO Tanımları

* DTO'lar, direkt olarak veritabanına dışardan erişimi engelleyen, veritabanı kolonları ile işlem yapmak yerine bir nevi onların imzaları ile, görmek istediğimiz veya göstermek istediğimiz alanları ile işlem yapmamıza olanak sağlayan yapılardır.
* Burada tanımları kısmı karmaşık ve zor olsa da daha sonrasında programlama kısmında hem yapıyı daha da kolaylaştıracak hem de daha güvenli hale getirecektir.
* Güncel projemizdeki DTO mimarisi bu şekildedir.
* Sadece Create kısmında bir ID eklemesi yapmayacağımız için IDENTITY verinin ID'sini yazmayız. Onun dışında isteğe bağlı olsa da, genel olarka tüm veriler Entity ile benzer olacaktır.

![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/d01825b5-65ac-4a18-a1b6-eb032899aa10)
![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/6d8ae115-f668-4f1e-8fd4-310bc26c5e90) (Create)
![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/87071150-2419-4fe6-a09c-7c4ca88a029c) (Result)

### 1.5 AutoMapper

* AutoMapper yapısı DTO'lar ve Entity'leri otomatik olarak eşleştirmeye olanak sağlayan bir kütüphanedir.
* Aynı zamanda normalde bir entity'nen new diyerek nesnesi oluşturulur ve atanacak değerler bu şekilde categor.Name = .. diyerek atanır. AutoMapper'lar sayesinde bu yapı daha hızlı ve otomatik bir şekilde yapılır. 
* Nuget paketi ile 2 adet kütüphane kurarak kullanılabilir. 
![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/66c48327-1ce6-418d-8a24-d08d9ae53d72)
![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/5f0445df-1c75-4d76-a7a4-e6fce5a84d18)


* Ardından yine Catalog içerisinde bir Mapping klasörü açarak GeneralMapping işlemini buradaki gibi gerçekleştirebiliriz.
![image](https://github.com/BerkanDemiral/ECommerceMicroServices/assets/54038172/df2b5482-8482-49bb-8e27-5928591e2bae)




