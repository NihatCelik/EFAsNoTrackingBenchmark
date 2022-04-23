# EF AsNoTracking Benchmark
Yazılım mülakatlarında da sorulan bir kavram olan AsNoTracking nedir, ne işe yarar gibi soruların cevaplarını arayacağız.
Öncelikle default olarak çalışan Entity Framework’ün Select işlemleri döndürdüğü datayı cachleyerek takibe alır. Bunun sebebi datayı güncelleyip SaveChanges metodunu çağırdığımızda değişikliklerin veritabanına yansımasını sağlamaktır. 

![image](https://miro.medium.com/max/700/1*cIoAxomg49yh4wVH2UDalQ.png)

Test sonuçlarına bakarsak eğer 50 bin kayıt için AsNoTracking kullanmazsak .Net 5 için 200ms ve 71MB, AsNoTracking kullanırsak 106ms ve 34MB gibi değer almışız. .NET 6 için ise ram bakımından değerler aynı, süre olarak biraz daha iyileştirme var fakat fark yaklaşık 2 katı. Yani çıkardığımız sonuç eğer select işleminde update işlemi yapmayacaksak AsNoTracking kullanmakta fayda var.

### Medium'da daha detaylı okumak için [tıklayınız.](https://medium.com/@nihatclk/ef-asnotracking-kullan%C4%B1m%C4%B1-ea4c4d959e24)
