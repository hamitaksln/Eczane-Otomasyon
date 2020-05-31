<div><h3 align="center"> Erciyes Üniversitesi <br> Mühendislik Fakültesi <br> Bilgisayar Mühendisliği Bölümü<br>VTYS Vize Ödevi</h0></div>

<div>
<p><b>Numara:</b>1030516689<br>
<b>Ad Soyad:</b>Emrah Batıgün</p>
</div>
<div>
<p><b>Numara:</b>1030516477<br>
<b>Ad Soyad:</b>Kadir Ek</p>
</div>
<div>
<p><b>Numara:</b>1030516495<br>
<b>Ad Soyad:</b>Abdulhamit Akaslan</p>
</div>

*Döküman Markdown ile stackedit.io sitesinde hazırlandı. Daha iyi bir deneyim için .html uzantılı dosyadan çalıştırınız.*


### Bu otomasyon ile eczanenin çalışma sistemi daha kolay anlatılabilir. Bu vesileyle böyle bir görselleştirme yoluna gittik. C# Windows Form kullanılarak hazırlanmıştır. UI Framework olarak MaterialSkin ve Bunifu kullanılmıştır.

<div align="center">
<h3>Otomasyonda hem doktor hem de eczane girişi bulunmaktadır.</h3>
<img src="https://i.ibb.co/26b3ZpY/home-Screen.png">
<h3>Hasta doktora gider. Doktorun sisteminde bütün hastalar mevcuttur. </h3>
<img src="https://i.ibb.co/rvWnPJL/doctor-Patients.png">
<h3>Doktor hastayı TC veya isim soyisim ile bulabilir.</h3>
<img src="https://i.ibb.co/qsq8x9m/doctor-Patient-Search.png">
<h3>Doktor hastayı seçtikten sonra ilaç yazma ekranı gelir</h3>
<img src="https://i.ibb.co/K6JGZXL/doctor-Write-Medicine.png">
<h3>Yazacağı ilacın yaş sınırı bulunmaktadır. Bu yüzden yazacağı ilacın hastanın yaşına uygun olması gerekir.</h3>
<img src="https://i.ibb.co/Jp8QCcm/doctor-Write-Medicine-Age-Limit.png">
<h3>Doktor arama yaparak ta ilaçları bulabilir.</h3>
<img src="https://i.ibb.co/WpfB8bS/doctor-Medicine-Search.png">
<h3>Doktorun yazdığı ilaç sayısı sağ alttaki buttonda gösterilir ve o button'a bastığında yazılan ilaçlar sayfasına gider.</h3>
<img src="https://i.ibb.co/qRpWCGt/doctor-Goto-Written-Medicines.png">
<h3>Yazılan ilaçlar bu sayfada gösterilir.</h3>
<img src="https://i.ibb.co/bmfkDCP/doctor-Written-Medicines.png">
<h3>Doktor reçeteyi yazdıra bastığı zaman reçete sisteme yüklenir ve reçete bir numaraya sahip olur. Bu numarayla hasta eczaneye gidip ilaçlarını alabilir.</h3>
<img src="https://i.ibb.co/8MhpBXF/doctor-Written-Medicine-Succes.png">
<h3>Doktor E-Reçete sorgulaması yapabilir.</h3>
<img src="https://i.ibb.co/QkYsj6F/doctor-Searched-ERecipe.png">
<h3>Sıra hastanın eczaneye gitmesine geliyor. </h3>
<img src="https://i.ibb.co/BPx5kkk/Eczane-Main-Screen.png">
<h3>Hasta eczaneye gittiği zaman eczane personeli reçete numara veya hasta kimlik numarasını alarak E-Reçete sorgu yapıyor.</h3>
<img src="https://i.ibb.co/stQQRc0/eczane-Search-ERecipe.png">
<h3>Hastanın sigorta türüne göre indirim yapılıyor. Eğer sigorta yoksa indirim yapılmıyor. Satış yapıldıktan sonra satılan ilaçlar, satın alan hasta, ne zaman satın alındığı ve hangi personelin satışı yaptığı veritabanına ekleniyor.</h3>
<img src="https://i.ibb.co/TYy4Z3B/eczane-ERecipe-Sold-Succes.png">
<h3>Reçete satışı yapıldıysa bu reçete üzerinden tekrar ilaç satışı yapılamıyor.</h3>
<img src="https://i.ibb.co/s3ypBHm/eczane-ERecipe-Already-Soldand-Insurance.png">
<h3>Eczane sisteminde hasta sorgulama, ilaçlar ve diğer ürünler sekmeleride mevcut.</h3>
<img src="https://i.ibb.co/J5yTrHT/eczane-Patient-Search.png">
<img src="https://i.ibb.co/fdc57Pd/eczane-Medicine-Search.png">
<h3>Diğer ürünler kısmında ürünlere çift tıklama yapılarak sepete atılabilir.</h3>
<img src="https://i.ibb.co/Fzm8dTC/eczane-Other-Products.png">
<h3>Eklenen ürünler sepete gelir ve ardından satış yapılır.</h3>
<img src="https://i.ibb.co/pJnsMbB/eczane-Basket.png">
<h3>Satış yapıldıktan sonra satılan ürünler, ne zaman satıldığı ve hangi personelin sattığı veritabanına kayıt edilmektedir.</h3>
<img src="https://i.ibb.co/3CDNCys/eczane-Basket-Sold-Succes.png">
</div>

<div align="center"><h1>NORMALİZASYON</h1>
</div>
Normalizasyon yapılırken uyulması gereken kurulların her birine normal
form adı verilir. 5 tip normalleştirme kuralından bahsedilebilir.

 - Birinci Normal Form (1NF)
 - İkinci Normal Form (2NF)
 - Üçüncü Normal Form (3NF)
 - Dördünü Normal Form (4NF) 
 - Beşinci Normal Form (5NF)

Bu Normal formlardan ilk üçü çok kullanılırken son ikisinin kullanımı daha
azdır. İlk üç normal form kayıt güncelleme, kayıt silme ve kayıt bulmada kolaylık
sağlar.
### Normalizasyon öncesi Hasta Tablosu
<div align="center"><img src="https://i.ibb.co/wN2Nk4J/0-NF-HASTA.png">
</div>

### 1. Normalizasyon
Veri tekrarı olduğu için 1. normalizasyonu uyguluyoruz.
<div align="center"><h3>Hasta Tablosu</h3><img src="https://i.ibb.co/NYn3m1H/1-NF-HASTA.png">
</div>

### 2. Normalizasyon

Bir tablo içinde tanımlı ancak anahtar olmaya uygun sütunlar anahtar
olarak tanımlanmalı ve tanımlı birincil anahtar sütunlara bağlanmalıdır. Bu yüzden ilaçlar ayrı bir tablo olması gerekiyor.

<div align="center"><h3>Hasta Tablosu</h3><img src="https://i.ibb.co/7pMPyWX/2-NF-HASTA.png">
</div>
<div align="center"><h3>İlaç Tablosu</h3><img src="https://i.ibb.co/VQ4L6rF/2NF-ILAC.png">
</div>

### 3. Normalizasyon

2NF'de karşılaşılan sorunları çözmek için geçişli bağımlılıkları da ortadan
kaldırmak gerekmektedir. Ayrıca Hasta İlaçları adında yeni bir tablo yapıp gereksiz sütunları ortadan kaldırıyoruz. Bu tabloda Hasta TC ve Ilaç Kodu olması yeterli.

<div align="center"><h3>HastaTablosu</h3><img src="https://i.ibb.co/vHgL1Y6/3-NF-HASTA.png">
</div>
<div align="center"><h3>İlaç Tablosu</h3><img src="https://i.ibb.co/L1441Gw/3NF-ILAC.png">
</div>
<div align="center"><h3>Hasta İlaçları Tablosu</h3><img src="https://i.ibb.co/Ms1wfKr/3-NF-HASTA-ILACLARI.png">
</div>
<div align="center"><h3>İl Tablosu</h3><img src="https://i.ibb.co/GWXTRf2/3NF-IL.png">
</div>
<div align="center"><h3>İlçe Tablosu</h3><img src="https://i.ibb.co/1X84zj0/3NF-ILCE.png">
</div>
<div align="center"><h3>Sigorta Tablosu</h3><img src="https://i.ibb.co/Fh7j8P8/3-NF-SIGORTA.png">
</div>

Bu şekilde normalizasyonu yapıyoruz. Veri tekrarı ve karmaşıklığı ortadan kaldırmış oluyoruz.

<div align="center"> <h2> VERİTABANI ER DİYAGRAMI</h1>
<img src="https://i.ibb.co/tLSQvHk/ERD.png">
<a href="https://i.ibb.co/tLSQvHk/ERD.png">ERD Tam Boyut</a>
</div>
<div align="center"><h1>SORGULAR</h1>
</div>

## 1- Hayat Eczanesi stoğuna ilaç temin eden tedarikçiler
```SQL
SELECT Eczane.Ad, StogaGelenIlaclar.TedarikciId, Tedarikci.FirmaAdi
FROM Tedarikci INNER JOIN (Eczane INNER JOIN StogaGelenIlaclar 
ON Eczane.Id = StogaGelenIlaclar.EczaneId) 
ON Tedarikci.Id = StogaGelenIlaclar.TedarikciId
WHERE (((Eczane.Ad)="Hayat Eczanesi"));
```
<div align="center"><img src="https://i.ibb.co/7Yf8hKJ/1.png">
</div>

## 2- Bursa'da çalışan ve personel sayısı 2 den fazla olan eczanelerdeki personellerin cep telefonu numaraları
```SQL
SELECT Sehirler.[Plaka Kodu], Eczane.PersonelSayisi, 
EczanePersonelleri.CepNo, Sehirler.İl
FROM (Ilceler 
INNER JOIN (Eczane INNER JOIN EczanePersonelleri 
ON Eczane.Id = EczanePersonelleri.EczaneId) 
ON Ilceler.IlceId = Eczane.İlceId) 
INNER JOIN Sehirler ON Ilceler.İl = Sehirler.[Plaka Kodu]
WHERE (((Sehirler.[Plaka Kodu])=16) AND ((Eczane.PersonelSayisi)>2));
```
<div align="center"><img src="https://i.ibb.co/vwxjP41/2.png">
</div>

## 3- Çiçek Eczanesi'nde adı Ahmet olan personelin sattığı ilaçların listesi ve sattığı tarihler
```SQL
SELECT EczanePersonelleri.Ad, EczanePersonelleri.Soyad, 
Eczane.Ad, Ilaclar.UrunAdi, SatilanIlaclar.SatisTarihi
FROM Ilaclar 
INNER JOIN ((Eczane 
INNER JOIN EczanePersonelleri 
ON Eczane.Id = EczanePersonelleri.EczaneId) 
INNER JOIN SatilanIlaclar 
ON EczanePersonelleri.Id = SatilanIlaclar.SatanPersonelId) 
ON Ilaclar.Id = SatilanIlaclar.IlacId
WHERE (((EczanePersonelleri.Ad)="Ahmet") AND ((Eczane.Ad)="Çiçek Eczanesi"));
```
<div align="center"><img src="https://i.ibb.co/5Bmf47n/3.png">
</div>

## 4- Stoğunda 50' den fazla maske bulunan eczaneler ve o eczanenin müdürü
```SQL
SELECT Eczane.Ad, StogaGelenYanUrunler.UrunAdi, 
StogaGelenYanUrunler.Adet, EczanePersonelleri.Ad, 
EczanePersonelleri.Soyad, EczanePersonelleri.Unvan
FROM (Eczane 
INNER JOIN EczanePersonelleri 
ON Eczane.Id = EczanePersonelleri.EczaneId) 
INNER JOIN StogaGelenYanUrunler 
ON (EczanePersonelleri.EczaneId = StogaGelenYanUrunler.EczaneId) 
AND (Eczane.Id = StogaGelenYanUrunler.EczaneId)
WHERE (((StogaGelenYanUrunler.UrunAdi)="Maske") 
AND ((StogaGelenYanUrunler.Adet)>50) 
AND ((EczanePersonelleri.Unvan)="Müdür"));
```
<div align="center"><img src="https://i.ibb.co/BCW0LKq/4.png">
</div>

## 5- İade edilen yan ürünleri satan personelin adı,soyadı, işe giriş tarihi, sattığı ürünün adı ve hangi eczanede çalıştığı
```SQL
SELECT EczanePersonelleri.Ad, 
EczanePersonelleri.Soyad, 
EczanePersonelleri.IseGirisTarihi, 
YanUrunler.UrunAdi, IadeEdilenYanUrunler.IadeTarihi, Eczane.Ad
FROM (Eczane INNER JOIN (EczanePersonelleri 
INNER JOIN IadeEdilenYanUrunler 
ON (EczanePersonelleri.Id = IadeEdilenYanUrunler.IadeAlanPersonelId) 
AND (EczanePersonelleri.Id = IadeEdilenYanUrunler.SatanPersonelId))
ON (Eczane.Id = EczanePersonelleri.EczaneId))
INNER JOIN YanUrunler ON IadeEdilenYanUrunler.Id = YanUrunler.Id;
```
<div align="center"><img src="https://i.ibb.co/KbGSDx8/5.png">
</div>

## 6- 6 numaralı reçetedeki ilaçlar, yazan doktor, verilen hasta, veren eczane ve satan personel
```SQL
SELECT Recete.ReceteId, Ilaclar.UrunAdi, 
Doktor.Ad, Doktor.Soyad, Sehirler.İl, 
Ilceler.Ilce, EczanePersonelleri.Ad, EczanePersonelleri.Soyad,
 Hasta.Ad, Hasta.Soyad, Ilaclar.Fiyat
FROM Hasta INNER JOIN ((Ilceler 
INNER JOIN ((Ilaclar INNER JOIN ((Eczane 
INNER JOIN EczanePersonelleri 
ON Eczane.Id = EczanePersonelleri.EczaneId) 
INNER JOIN SatilanIlaclar 
ON EczanePersonelleri.Id = SatilanIlaclar.SatanPersonelId) 
ON Ilaclar.Id = SatilanIlaclar.IlacId) 
INNER JOIN ((Hastane INNER JOIN Doktor 
ON Hastane.Id = Doktor.HastaneId) 
INNER JOIN Recete ON Doktor.Id = Recete.YazanDoktorId) 
ON SatilanIlaclar.ReceteId = Recete.ReceteId) 
ON Ilceler.IlceId = Hastane.IlceId) 
INNER JOIN Sehirler ON Ilceler.İl = Sehirler.[Plaka Kodu])
 ON Hasta.HastaTc = Recete.HastaTcKimlikNo
WHERE (((Recete.ReceteId)=6));
```
<div align="center"><img src="https://i.ibb.co/c3yhmtB/6.png">
</div>

## 7 - 1 numaralı receteyi yazan doktorun adı, soyadı, çalıştığı hastane, meslekteki deneyimi çalıştığı il
```SQL
SELECT Recete.ReceteId, Doktor.Ad, Doktor.Soyad,
 Doktor.Tecrube, Sehirler.İl
FROM (Ilceler INNER JOIN ((Hastane 
INNER JOIN Doktor ON Hastane.Id = Doktor.HastaneId) 
INNER JOIN Recete ON Doktor.Id = Recete.YazanDoktorId)
 ON Ilceler.IlceId = Hastane.IlceId) 
 INNER JOIN Sehirler ON Ilceler.İl = Sehirler.[Plaka Kodu]
WHERE (((Recete.ReceteId)=1));
```
<div align="center"><img src="https://i.ibb.co/2qF5LDW/7.png">
</div>

## 8- Tarık Saklı adlı hastanın aldığı ilaçların toplam fiyatı
```SQL
SELECT Sum(Ilaclar.Fiyat) AS ToplaFiyat
FROM Ilaclar 
INNER JOIN ((Hasta 
INNER JOIN Recete ON Hasta.HastaTc = Recete.HastaTcKimlikNo) 
INNER JOIN IlacRecete ON Recete.ReceteId = IlacRecete.ReceteId)
 ON Ilaclar.Id = IlacRecete.IlacId
HAVING (((Hasta.Ad)="Tarık") AND ((Hasta.Soyad)="SAKLI"));
```
<div align="center"><img src="https://i.ibb.co/1vnj4L5/8.png">
</div>

## 9- 18.05.2020 tarihinde satılan ilaçların adı, ruhsat sahibi, ruhsat numarası, kimin sattığı ve satılan eczanenin adı
```SQL
SELECT SatilanIlaclar.SatisTarihi, Ilaclar.UrunAdi, 
Ilaclar.RuhsatSahibi, Ilaclar.RuhsatNumarasi, 
EczanePersonelleri.Ad, EczanePersonelleri.Soyad, Eczane.Ad
FROM Ilaclar INNER JOIN ((Eczane 
INNER JOIN EczanePersonelleri ON Eczane.Id = EczanePersonelleri.EczaneId) 
INNER JOIN SatilanIlaclar 
ON EczanePersonelleri.Id = SatilanIlaclar.SatanPersonelId) 
ON Ilaclar.Id = SatilanIlaclar.IlacId
WHERE (((SatilanIlaclar.SatisTarihi)=#5/18/2020#));
```
<div align="center"><img src="https://i.ibb.co/ThrLTCS/9.png">
</div>

## 10 - Murat HAS adlı çalışanın sattığı ilaçların adı, sattığı tarihler, satış şekli ve hangi hastalara sattığı
```SQL
SELECT EczanePersonelleri.Ad, EczanePersonelleri.Soyad,
 Ilaclar.UrunAdi, SatilanIlaclar.SatisTarihi, 
 SatilanIlaclar.SatisSekli, Hasta.Ad, Hasta.Soyad
FROM (Hasta INNER JOIN Recete 
ON Hasta.HastaTc = Recete.HastaTcKimlikNo) 
INNER JOIN (Ilaclar INNER JOIN (EczanePersonelleri 
INNER JOIN SatilanIlaclar 
ON EczanePersonelleri.Id = SatilanIlaclar.SatanPersonelId) 
ON Ilaclar.Id = SatilanIlaclar.IlacId) 
ON Recete.ReceteId = SatilanIlaclar.ReceteId
WHERE (((EczanePersonelleri.Ad)="Murat") 
AND ((EczanePersonelleri.Soyad)="HAS"));
```
<div align="center"><img src="https://i.ibb.co/fd96Krd/10.png">
</div>

## 11- Mart 2020'den sonra satılan yan ürünlerin adı, satış tarihi, kaç adet satıldığı, satış şekli, hangi personelin sattığı, satan personelin aylık maaşı ve satan personelin hangi eczanede çalıştığı
```SQL
SELECT SatilanYanUrunler.SatisTarihi, SatilanYanUrunler.UrunAdi, 
SatilanYanUrunler.Adet, SatilanYanUrunler.SatisSekli,
 EczanePersonelleri.Ad, EczanePersonelleri.Soyad, 
 EczanePersonelleri.Maaş, Eczane.Ad
FROM YanUrunler INNER JOIN ((Eczane 
INNER JOIN EczanePersonelleri ON Eczane.Id = EczanePersonelleri.EczaneId) 
INNER JOIN SatilanYanUrunler 
ON EczanePersonelleri.Id = SatilanYanUrunler.SatanPersonelId) 
ON YanUrunler.Id = SatilanYanUrunler.Id
WHERE (((SatilanYanUrunler.SatisTarihi)>#3/31/2020#));
```
<div align="center"><img src="https://i.ibb.co/W0xhV1T/11.png">
</div>

## 12- SGK'lı olan hastaların adı soyadı, hangi şehirde yaşadığı, hangi ilaçları aldığı, ilaçların hangi etkin maddeyi içerdiği, hastanın doktorunun adı soyadı ve uzmanlık alanı
```SQL
SELECT Hasta.SigortaTuru, Hasta.Ad, Hasta.Soyad, Sehirler.İl,
Ilaclar.UrunAdi, Ilaclar.EtkinMadde, Doktor.Ad, Doktor.Soyad, 
Doktor.UzmanlıkAlani
FROM Doktor INNER JOIN (((Ilceler 
INNER JOIN (Hasta INNER JOIN Recete 
ON Hasta.HastaTc = Recete.HastaTcKimlikNo) ON Ilceler.IlceId = Hasta.IlceId) 
INNER JOIN Sehirler 
ON Ilceler.İl = Sehirler.[Plaka Kodu]) 
INNER JOIN (Ilaclar INNER JOIN SatilanIlaclar 
ON Ilaclar.Id = SatilanIlaclar.IlacId) 
ON Recete.ReceteId = SatilanIlaclar.ReceteId) 
ON Doktor.Id = Recete.YazanDoktorId
WHERE (((Hasta.SigortaTuru)="SGK"));
```
<div align="center"><img src="https://i.ibb.co/YP2Xx1G/12.png">
</div>

## 13- 2010'dan itibaren işe giren personellerin işe giriş tarihi adı soyadı,ünvanı, aylık maaşı, sattığı ilaçların adı, sattığı ilaçların satış tarihi, çalıştığı eczanenin adı ve eczanenin hangi şehirde bulunduğu
```SQL
SELECT EczanePersonelleri.IseGirisTarihi, EczanePersonelleri.Ad, 
EczanePersonelleri.Soyad, EczanePersonelleri.Unvan, 
EczanePersonelleri.Maaş, Ilaclar.UrunAdi,
 SatilanIlaclar.SatisTarihi, Eczane.Ad, Sehirler.İl
FROM (Ilaclar INNER JOIN ((Ilceler 
INNER JOIN (Eczane 
INNER JOIN EczanePersonelleri 
ON Eczane.Id = EczanePersonelleri.EczaneId) 
ON Ilceler.IlceId = Eczane.İlceId) 
INNER JOIN SatilanIlaclar
 ON EczanePersonelleri.Id = SatilanIlaclar.SatanPersonelId) 
ON Ilaclar.Id = SatilanIlaclar.IlacId)
 INNER JOIN Sehirler ON Ilceler.İl = Sehirler.[Plaka Kodu]
WHERE (((EczanePersonelleri.IseGirisTarihi)>#12/31/2009#));
```
<div align="center"><img src="https://i.ibb.co/JRVbmSJ/13.png">
</div>

## 14- İl, ilçe ve ünvanlara göre çalışanların maaşları, hangi eczanede çalıştıkları ve çalıştıkları eczanenin personel sayısı 
```SQL
SELECT Sehirler.İl, Ilceler.Ilce, EczanePersonelleri.Unvan, 
EczanePersonelleri.Maaş, Eczane.PersonelSayisi, Eczane.Ad
FROM (Ilceler INNER JOIN (Eczane 
INNER JOIN EczanePersonelleri 
ON Eczane.Id = EczanePersonelleri.EczaneId) 
ON Ilceler.IlceId = Eczane.İlceId) INNER JOIN Sehirler 
ON Ilceler.İl = Sehirler.[Plaka Kodu];
```
<div align="center"><img src="https://i.ibb.co/ZdMtF85/14.png">
</div>

## 15- Özel hastanede çalışan doktorların ad soyad ve uzmanlık alanları, yazdıkları ilaçlar, yazılan hastanın ad,soyad ve doğum tarihleri, yazılan ilacı satan eczane personelinin adı,soyadı, yazılan ilacı hastaya veren eczane 
```SQL
SELECT Hastane.Tur, Doktor.Ad, Doktor.Soyad, Doktor.UzmanlıkAlani,
Ilaclar.UrunAdi, Hasta.Ad, Hasta.Soyad, Hasta.DogumTarihi
FROM Hasta INNER JOIN ((((Hastane 
INNER JOIN Doktor ON Hastane.Id = Doktor.HastaneId) 
INNER JOIN Recete ON Doktor.Id = Recete.YazanDoktorId) 
INNER JOIN (Ilaclar INNER JOIN IlacRecete 
ON Ilaclar.Id = IlacRecete.IlacId) 
ON Recete.ReceteId = IlacRecete.ReceteId) 
INNER JOIN SatilanIlaclar 
ON (Recete.ReceteId = SatilanIlaclar.ReceteId) 
AND (IlacRecete.ReceteId = SatilanIlaclar.ReceteId)
 AND (Ilaclar.Id = SatilanIlaclar.IlacId))
  ON Hasta.HastaTc = Recete.HastaTcKimlikNo
WHERE (((Hastane.Tur)="Özel"));
```
<div align="center"><img src="https://i.ibb.co/Fg89Vwp/15.png">
</div>





