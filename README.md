# MusteriHatirlatici

Geçen sene, kombi bakım işleri yapan bir arkadaşımın isteği ve gereksinimleri üzerine hazırlamış olduğum C# Form projesidir. Bakım tarihi yaklaşan veya borcu olan müşterilerin takibini kolaylaştırması hedeflenmiştir.

### !!!Önemli not: 
Bu projede yazılımsal olarak bir hata bulunmamasına ve düzgün bir şekilde çalışmasına rağmen, önceden yazmış olduğum bir proje olmasından ve o zamanki bilgi düzeyimdeki eksiklikten dolayı -sürdürülebilirlik- açısından bazı sıkıntılar vardır. Bundaki önemli bir sebepte veritabanı olarak Access kullanmam ve veriye erişim yöntemi olarak Ado.net kullanmamdır. Ado.net; Entity Framework, Dapper gibi ORM'lere nazaran pek modüler bir yapıda olmamasından dolayı kod maliyetini ve karmaşasını artırmaktadır. Daha düzgün ve profesyonel tekniklerle yazılmış bir proje için NorthwindProject repomu inceleyebilirsiniz.
###

Projede katmanlı mimari kullanılmıştır. Veritabanı olarak yukarıda da belirttiğim gibi Access kullanılmıştır (Arkadaşım ileride müşterileri excel tablosu gibi de görüntüleyebilmek istediğini belirttiği için. Ayrıca arkadaşımın bilgisayarına ekstra bir program kurulmasına da gerek kalmamıştır). Veritabanı dosyası proje klasörü içindeki UI.WinForm\bin\Debug\Database yolu altındaki MusteriHatirlaticiDB.veritabani dosyasıdır. Bu dosyanın uzantısı normalde .mdb 'dir ve Access programı ile doğrudan görüntülemek isteyenler .veritabani yazan kısımı .mdb olarak değiştirmelidir.

Kısaca nasıl çalıştığından bahsetmek gerekirse yukarıda Müşteri Bilgiler ve İşlem olarak 2 panel bulunmaktadır. Program ilk çalıştığında Müşteri Bilgileri paneli ve aktiftir. Diğeri ise deaktif durumdadır. Yeni bir müşteri eklenmek istendiğinde ilgili kutucuklar doldurularak Müşteri ekle butonuna tıklanmalıdır. Bir müşteriye ulaşılmak istendiğinde ise müşterinin ismi girilerek İsimden Müşteri Ara butonuna tıklanmalıdır. İlgili müşteri aşağıdaki panelde görüntülenecektir. Tüm müşterileri görüntülemek için ise sağ alt taraftaki "Özel" panelinden Müşterileri Görüntüleye tıklanmalıdır. Eğer bakım işlemi için 1 gün, 3 gün , 1 hafta gibi belirli bir süre kalan müşteriler görüntülenmek istenirse yine sağ orta kısımdaki Hatırlatıcı Panelinden Gün sayısı seçildikten sonra Günden Az Kalanlar butonuna tıklanmalıdır.

Bir müşterinin bilgileri güncellenmek istenirse aşağıdaki tablodan ilgili müşteri seçildiğinde bilgileri kutucuklara yüklenir ve kutucuklardaki ilgili kısımlar değiştirildikten sonra Müşteri Bilgileri Güncelleye tıklandığında güncelleme işlemi yapılır. Kutucuklara yüklenen bilgiler temizlenmek istenirse aktif durumda olmayan panelin üzerine tıklanırsa kutucuklardaki bilgiler silinir. Bu da programda kullanım kolaylığı sağlamaktadır.

Adres bilgisi gibi tabloda satıra sığmayan bir bilgi görüntülenmek istendiğinde ilgili hücre üzerine mouse imleci ile gelindiği takdirde programın Hoover özelliği sayesinde içindeki bilginin geniş bir kutucuk içerisinde görüntülenmesi sağlanır.

Bir müşteri bilgisi eklendikten sonra o müşteri ile ilgili bir işlem eklenmek isteniyorsa aşağıdaki panelden müşteri seçildikten sonra Müşteri İşlem Görüntüle butonuna tıklanarak İşlem paneli aktif hale gelir ve müşteri ile ilgili bir işlem girdisi eklenebilir veya müşterinin var olan işlemleri görüntülenebilir.

Ayrıca Özel panelinde Toplam yazan kısım Görüntülenen tabloda o an kaç satır olduğunu gösterir. Yani örneğin Borcu Olanları Görüntüle butonuna tıklanırsa o an tüm borcu olan kişiler tabloda görüntülenecektir ve bu kişilerinin sayısı 50 kişi ise orada gözükecektir.

Burada arkadaşımın senaryosu müşterinin kombisi için bakım işlemi yapılması, müşteri için belirli bir miktar hesap ücretinin çıkması ve müşterinin bunun belirli bir miktarını ödeyebileceğiydi. Daha sonra bu kişiye belirli bir süre sonra örneğin 1 sene sonra tekrar bakım yaptıklarını belirtti. Dolayısıyla 1 sene sonra, örneğin akşamları programa baktıklarında; yarın veya 3 gün sonra bakıma gidecekleri kişileri kolayca takip etmek istediklerini belirtmişlerdi. Bu programda bu gereksinimleri yerine getirmektedir.
