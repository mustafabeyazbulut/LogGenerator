# VeriketApp Generator Log and Log List
Bu uygulama C# programlama dili kullanılarak .Net Framework ile geliştirilmiştir.
1. Bir Solution içerisinde 2 proje ve setup bulunuyor.
<pre>
    1. Windows servis kullanılarak log üretimi gerçekleştiriyor.
    2. C# Winform ile bu üretilen loglari grid içerisinde listeliyor
</pre>
2. Servis tarafından üretilen loglar CSV formatında VeriketAppTest.txt isim dosyada Tarih, bilgisayar adı, kullanıcı adı bilgilerini yazıyor.
3. İki uygulama da tek bir MSI paketinden kurulabiliyor ya da kurulan uygulamalar silinebiliyor.
4. Program Windows’un yüklü olduğu sürücü içerisindeki Program Files içerisine VeriketApp klasörü altına kuruluyor.
5. Program kurulduktan sonra istenen tüm logları Windows’un yüklü olduğu sürücü içerisindeki ProgramData klasörünün altına VeriketApp adındaki bir klasörün altına oluşturuyor.
6. Yukarıda bahsedilen klasörlerin yolları kod içerisinde statik olarak kullanılmıyor, gerekli sürücü ve klasör isimleri programatik olarak alınıyor.