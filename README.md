# Kütüphane Projesi

Proje Açıklaması: Bu proje basit bir kütüphane uygulmaası demosudur. Admin ve kullanıcı panelleriyle kitap ve kullanıcı kaydı yapılıp, uygunluğuna göre kitabı ödünç alma sistemi sağlamaktadır. 

Kurulum

-Projeyi yerel bir geliştirme ortamında çalıştırmak ve özelleştirmek için aşağıdaki adımları izleyebilirsiniz:

-Gereksinimler: Projeyi çalıştırmak için Visual Studio veya benzeri bir C# geliştirme ortamına ihtiyacınız olacak. Ayrıca, bir SQL veritabanı sunucusuna erişim gereklidir.

-Veri Tabanı Ayarları: Repository içerisindeki kütüphane.db.mdf ve kütüphane_log.ldf dosyalarını indirin. MsSQL Program Files/Microsoft SQL Server/MSSQL16.SQLEXPRESS/MSSQL/DATA içine kopyalayın.

-Veri Tabanına Ekleme: Bağlantıyı kurduktan sonra Databases'e sağ tıklayıp Attach deyin. Açılan sayfada mdf file location kısmına az önce eklediğimiz mdf uzantılı dosyayı ekleyin. Otomatik olarak gelen log dosyasıyla birilikte 'OK' diyerek yüklemeyi tamamlayın.

-Visual Studio'da Bağlantı Kurma: Varsayılan olarak adres girilidir fakat bir sorun çıkması halinde; Project-> Add New Data Source-> Database-> Dataset deyip new connection kısmından veri tabanını ekleyin. Daha sonra altta bulunan "show the connection string..." seçeneğine tıklayarak gelen adresi kopyalayıp kapatın.

-Projeye Ekleme: baglanti.cs sınıfını açıp SQLConnection sınıfına metod olarak adresi yapıştırın.

-Proje İndirme: Bu GitHub deposunu klonlayın veya ZIP olarak indirin.

-Projeyi Açma: Visual Studio'da proje dosyasını açın (.sln uzantılı dosya).

Kullanım

-Giriş Yapma: 2 farklı giriş yöntemi mevcut: Admin ve Kullanıcı Girişi. Kolaylık olması açısından iki giriş yeri de kayıtlı verilerle doldurulmuştur.

-Admin Panel: Kullanıcı ve kitap kaydının yapıldığı alandır. Güncelleme ve silme işlemleri için ilgili satıra çift tıklayıp bilgileri textboxlara atayabilirsiniz. Daha sonrasında istenilen işlem yapılabilir.

-Kullanıcı Panel: Kitao kiralamaları burada yapılır. Açılan tabloda ilgili satıra çift tıklandığında kitap bilgileri textboxlara atanır. Tarih seçerek kiralama yapılır. Alt tarafta ise geçmiş kiralamalar görüntülenir.
Not: Kitabı kiralayaabilmek için 'durum' sütutunda 'müsait' yazması gerekmektedir. Diğer türlü kiralama yapılmamaktadır.

