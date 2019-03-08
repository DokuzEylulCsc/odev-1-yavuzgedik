# Ödev 1
<p>İki boyutlu bir *“meydan”*(oyunun geçeceği haritanın ismi) üzerinde iki ayrı takımın farklı rütbelerdeki
askerlerinin savaşarak rakip takımdaki askerlerin tamamını oyun dışı bırakmayı amaçladığı bir
canlandırma istenmektedir.</p>

- Askerlerin temel sınıfta (base/super class) temsil edilmeleri gerekir. Hayatta olup olmama (bool),
takım bilgisi, sağlık miktarı (başlangıçta 100, asker vuruldukça azalır, 0’ın altına düşemez) ve
*meydan* üzerindeki pozisyonu (x,y koordinat bilgisi içeren Point) gibi özelikleri içersin.
- Bütün askerlerde mevcut olacak şekilde, Asker sınıfının temel olarak Bekle() (Bulunduğu
pozisyonu koruma), Hareket_et() (harita üzerinde pozisyonunu değiştirme) ve Ateş_et()
(haritadaki komşu karelerdeki düşman askerinin sağlığını azaltma) olmak üzere 3 adet metodu
olmalı. Bu metotların içerikleri alt sınıflarda (rütbelerde) tanımlanmalıdır.
- Üç rütbeli asker tipi mevcut (Asker sınıfından türetilen alt sınıflar) : Er, Teğmen ve Yüzbaşı. Savaş
sırasında kendi metotlarından hangisini gerçekleştireceğini belirli olasılıklarla belirliyor. Örneğin
%10 aşağı yürüme, %20 yukarı yürüme, %20 ateş etme ve %50 bekleme olasılıkları belirlenmişse,
(0-1) aralığında ürettiğiniz sayı [0-0,1) arasında olursa aşağı, [0,1-0,3) arasında olursa yukarı
yürür. Hareket işlemlerinde işgal edilmek istenen kare üzerinde asker **yoksa** işlem
gerçekleştirilebilir ve Er sınır kareye ulaştıysa yukarıda kare yoksa bir sağ kareye, aşağıda ilave
kare yoksa bir sol kareye ilerler.
- Er, bulunduğu pozisyonu koruma (Bekle() ), harita üzerinde 1 kare yukarı veya 1 kare aşağı
yürüme ( Hareket_et()) ve 1 kare komşuluğundaki düşman askerini vurma (Ateş_et()) işlemlerini
gerçekleştirebiliyor. Ateş ettiğinde 5, 10, 15 birim olmak üzere düşman askerinin sağlığını azaltır.
- Teğmen 1 kare ilerlemek üzere 4 yöne doğru hareket edebilir. Ayrıca ateş etme işlemi
gerçekleştirebilir. 2 kare komşuluğundaki düşman askerine isabet ettirebilir ve farklı olasılıklarla
10, 20, 25 birim düşman askerinin sağlığını azaltır.
- Yüzbaşı 1 kare ilerlemek üzere 8 yöne doğru (çapraz hareketler dahil) hareket edebilir. Ayrıca
ateş etme işlemi gerçekleştirebilir. 3 kare komşuluğundaki düşman askerine isabet ettirebilir ve
farklı olasılıklarla 15, 25, 40 birim düşman askerinin sağlığını azaltır.
- Oyun 16 x 16’lık bir meydan üzerinde oynansın. Koordinatlar (0,0) ile (15,15) arasında olabilir.
- Her 2 takımın her rütbeden birer askeri aynı “bölge”yi (meydan üzerindeki her bir kareye verilen
isim) işgal etmeyecek şekilde başlangıçta her takımın üyeleri aynı alan içinde (5x5 lik bir komşu
bölgeler topluluğu) pozisyonlara yerleştirilsin. Her iki takım için meydanın uç kısımlarına denk
gelecek farklı başlangıç alanları belirlensin. Örneğin A takımı ( (0,0) – (4,4) ) ve B Takımı ( (11,11)
– (15,15) ) şeklinde.
- Her 2 takım için en fazla 1 Yüzbaşı, en az 1 en fazla 2 Teğmen ve kalanı da erlerden oluşmak
üzere 7 kişilik bir takım oluşturunuz.
- Her bir turda sırayla bir takım içinden bir asker işlem yapabilir. Takım içinde işlem yapacak
rütbeli askeri rastgele sayı ile belirleyebilirsiniz.
- Bir takımdaki bütün askerler oyun dışı kalana kadar (sağlık değerleri 0 olana kadar) oyun devam
eder. 

### **Son Teslim: _18.03.2019 22:30_**

## Örnek UML Sınıf diyagramı

![alt text](https://github.com/DokuzEylulCsc/Odev1/raw/master/Odev_1_UML.png)
