using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace degiskenler
{
    /// <summary>
    /// Eğitim amaçlı örnek uygulama.
    /// - Menü ile farklı küçük örnek modüller çalıştırılır.
    /// - Değişken adlandırmaları, fonksiyon yapısı ve hata kontrolü profesyonelleştirildi.
    /// </summary>
    internal static class Program
    {
        static void Main()
        {
            // Ana döngü: kullanıcı çıkana kadar menüyü gösterir ve seçimleri işler.
            while (true)
            {
                ShowMenu();
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
                    continue;
                }

                if (!int.TryParse(input, out var selection))
                {
                    Console.WriteLine("Geçersiz sayı formatı. Tekrar deneyin.");
                    continue;
                }

                Console.Clear();

                try
                {
                    // Seçilen modülü çalıştır
                    ExecuteModule(selection);
                }
                catch (OperationCanceledException)
                {
                    // Bazı modüller sonlandırılmayı gerektirebilir.
                    Console.WriteLine("İşlem iptal edildi.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Beklenmeyen hata: {ex.Message}");
                }

                Console.WriteLine("\nDevam etmek için bir tuşa basın...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        /// <summary>
        /// Konsol ekranında kullanıcıya sunulan menüyü yazdırır.
        /// </summary>
        private static void ShowMenu()
        {
            Console.WriteLine("=== Eğitim Demo: Değişkenler ve Fonksiyonlar ===");
            Console.WriteLine("1  - int ile bölme örneği");
            Console.WriteLine("2  - double ile bölme örneği");
            Console.WriteLine("3  - decimal ile bölme örneği");
            Console.WriteLine("4  - BMI (Kitle İndeksi) hesaplama");
            Console.WriteLine("5  - Karakter / replace ile e-posta oluşturma");
            Console.WriteLine("6  - float ile çevre hesaplama (basit örnek)");
            Console.WriteLine("7  - char ile evet/hayır kontrolü");
            Console.WriteLine("8  - string, decimal, bool örneği");
            Console.WriteLine("9  - Kelime ayırma (Split) ve döngü");
            Console.WriteLine("10 - Karenin alanı ve çevresi (string formatlama)");
            Console.WriteLine("11 - Yaşa göre ehliyet sınıfı (if/else)");
            Console.WriteLine("12 - Tek karakter kontrolü ('.' veya ',')");
            Console.WriteLine("13 - Pozitif/negatif/sıfır kontrolü (try/catch örneği)");
            Console.WriteLine("14 - Basit kullanıcı doğrulama (username/password)");
            Console.WriteLine("15 - Console renkleri ile örnek yazdırma");
            Console.WriteLine("16 - Split ile cinsiyet+yaş örneği");
            Console.WriteLine("17 - Çember çevresi / daire alanı");
            Console.WriteLine("18 - Tek/Çift kontrolü");
            Console.WriteLine("19 - Rakamı yazıyla yazdırma");
            Console.WriteLine("20 - Ay numarasına göre açıklama (switch)");
            Console.WriteLine("21 - Basit hesap makinesi (switch)");
            Console.WriteLine("22 - Starbucks örneği (sipariş simülasyonu)");
            Console.WriteLine("23 - Daktilo ile bakiye mesajı gösterme");
            Console.WriteLine("24 - Verilen aralıktaki 3'e bölünenleri yazdırma");
            Console.WriteLine("25 - ASCII sanatı oluşturma");
            Console.WriteLine("0  - Çıkış");
            Console.Write("Seçiminizi girin: ");
        }

        /// <summary>
        /// Menüdeki seçime göre ilgili metodu çağırır.
        /// Her modül kendi küçük sorumluluğuna sahiptir; giriş validasyonu yapılır.
        /// </summary>
        private static void ExecuteModule(int selection)
        {
            switch (selection)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    IntDivision();
                    break;
                case 2:
                    DoubleDivision();
                    break;
                case 3:
                    DecimalDivision();
                    break;
                case 4:
                    CalculateBmi();
                    break;
                case 5:
                    CreateSafeEmail();
                    break;
                case 6:
                    FloatCircumference();
                    break;
                case 7:
                    CharYesNo();
                    break;
                case 8:
                    StringDecimalBoolExample();
                    break;
                case 9:
                    SplitAndForLoop();
                    break;
                case 10:
                    SquareAreaPerimeter();
                    break;
                case 11:
                    DrivingLicenseByAge();
                    break;
                case 12:
                    DotOrComma();
                    break;
                case 13:
                    NumberSignExample();
                    break;
                case 14:
                    SimpleAuthentication();
                    break;
                case 15:
                    TeamColorShowcase();
                    break;
                case 16:
                    SplitGenderAge();
                    break;
                case 17:
                    CircleAreaOrCircumference();
                    break;
                case 18:
                    EvenOrOdd();
                    break;
                case 19:
                    DigitToWord();
                    break;
                case 20:
                    MonthSwitch();
                    break;
                case 21:
                    SimpleCalculator();
                    break;
                case 22:
                    StarbucksSimulation();
                    break;
                case 23:
                    TypewriterBalanceMessage();
                    break;
                case 24:
                    ListMultiplesOfThree();
                    break;
                case 25:
                    AsciiArtFlow();
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim. Menüdeki bir sayı girin.");
                    break;
            }
        }

        #region Modüller - Her biri küçük, tek sorumluluklu fonksiyonlar

        private static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            int value;
            while (true)
            {
                var line = Console.ReadLine();
                if (int.TryParse(line, out value))
                    break;
                Console.Write("Geçersiz sayı. Tekrar girin: ");
            }
            return value;
        }

        private static double ReadDouble(string prompt)
        {
            Console.Write(prompt);
            double value;
            while (!double.TryParse(Console.ReadLine(), NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out value))
            {
                Console.Write("Geçersiz sayı. Tekrar girin (örnek: 3.14): ");
            }
            return value;
        }

        private static decimal ReadDecimal(string prompt)
        {
            Console.Write(prompt);
            decimal value;
            while (!decimal.TryParse(Console.ReadLine(), NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out value))
            {
                Console.Write("Geçersiz sayı. Tekrar girin (örnek: 12.34): ");
            }
            return value;
        }

        // 1
        private static void IntDivision()
        {
            // int kullanımı: tam sayı bölme (kayan nokta olmadan)
            int a = ReadInt("1. tam sayıyı girin: ");
            int b = ReadInt("2. tam sayıyı girin: ");
            if (b == 0)
            {
                Console.WriteLine("Sıfıra bölme hatası.");
                return;
            }
            int result = a / b;
            Console.WriteLine($"Bölme sonucu (int): {result}");
        }

        // 2
        private static void DoubleDivision()
        {
            // double kullanımı: ondalıklı bölme
            double a = ReadDouble("1. sayıyı girin: ");
            double b = ReadDouble("2. sayıyı girin: ");
            if (Math.Abs(b) < double.Epsilon)
            {
                Console.WriteLine("Sıfıra çok yakın bölen. İşlem iptal edildi.");
                return;
            }
            Console.WriteLine($"Bölme sonucu (double): {a / b}");
        }

        // 3
        private static void DecimalDivision()
        {
            // decimal genelde para ve hassas ondalık hesaplamalar için
            decimal a = ReadDecimal("1. decimal sayıyı girin: ");
            decimal b = ReadDecimal("2. decimal sayıyı girin: ");
            if (b == 0m)
            {
                Console.WriteLine("Sıfıra bölme hatası.");
                return;
            }
            Console.WriteLine($"Bölme sonucu (decimal): {a / b}");
        }

        // 4
        private static void CalculateBmi()
        {
            // Kitle İndeksi (BMI): kilo / (boy * boy)
            double heightMeters = ReadDouble("Boyunuzu metre cinsinden girin (örnek: 1.75): ");
            double weightKg = ReadDouble("Kilonuzu kg girin: ");
            if (heightMeters <= 0)
            {
                Console.WriteLine("Geçersiz boy değeri.");
                return;
            }
            double bmi = weightKg / (heightMeters * heightMeters);
            Console.WriteLine($"BMI: {bmi:F2}");
        }

        // 5
        private static void CreateSafeEmail()
        {
            // Türkçe karakterleri ASCII'ye yakın hale getirip e-posta oluşturma örneği
            Console.Write("Adınızı girin: ");
            var name = SanitizeTurkishLetters(Console.ReadLine() ?? string.Empty);
            Console.Write("Soyadınızı girin: ");
            var surname = SanitizeTurkishLetters(Console.ReadLine() ?? string.Empty);
            var email = $"{name.ToLowerInvariant()}_{surname.ToLowerInvariant()}@kodkardesligi.com.tr";
            Console.WriteLine($"Oluşturulan e-posta: {email}");
        }

        // 6
        private static void FloatCircumference()
        {
            // float örneği: basit çevre hesabı (float kullanımında hassasiyet kaybına dikkat)
            Console.Write("Yarıçapı girin (örnek: 2.5): ");
            if (!float.TryParse(Console.ReadLine(), NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var r))
            {
                Console.WriteLine("Geçersiz sayı.");
                return;
            }
            const float pi = 3.14f;
            float circumference = 2 * pi * r;
            Console.WriteLine($"Çevre (float ile): {circumference}");
        }

        // 7
        private static void CharYesNo()
        {
            Console.Write("Evet için 'y', Hayır için 'n' tuşuna basın: ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Geçersiz giriş.");
                return;
            }
            var ch = char.ToLowerInvariant(input[0]);
            if (ch == 'y') Console.WriteLine("Evet dediniz. Teşekkürler.");
            else if (ch == 'n') Console.WriteLine("Hayır dediniz. Teşekkürler.");
            else Console.WriteLine("Bilinmeyen seçim.");
        }

        // 8
        private static void StringDecimalBoolExample()
        {
            // string, decimal ve bool örneği
            Console.Write("Adınızı girin: ");
            var name = Console.ReadLine() ?? string.Empty;
            Console.Write("Soyadınızı girin: ");
            var surname = Console.ReadLine() ?? string.Empty;
            decimal height = ReadDecimal("Boyunuzu girin (örnek: 1.75): ");
            decimal weight = ReadDecimal("Kilonuzu girin (örnek: 75.5): ");
            bool isDeveloper = true; // örnek amaçlı sabit

            Console.WriteLine($"{name} {surname}");
            Console.WriteLine($"Boy: {height}, Kilo: {weight}");
            Console.WriteLine(isDeveloper ? $"{name} bir yazılımcıdır." : $"{name} bir yazılımcı değildir.");
        }

        // 9
        private static void SplitAndForLoop()
        {
            Console.Write("Bir cümle girin: ");
            var sentence = Console.ReadLine() ?? string.Empty;
            var parts = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
            {
                Console.WriteLine($"{i + 1}. kelime: {parts[i]}");
            }
        }

        // 10
        private static void SquareAreaPerimeter()
        {
            int side = ReadInt("Karenin bir kenarını girin (tam sayı): ");
            int perimeter = 4 * side;
            int area = side * side;
            // iki farklı string formatlama gösterimi
            Console.WriteLine("Karenin Alanı: {0}. Karenin Çevresi: {1}", area, perimeter);
            Console.WriteLine($"Karenin Alanı: {area}. Karenin Çevresi: {perimeter}");
        }

        // 11
        private static void DrivingLicenseByAge()
        {
            int age = ReadInt("Kaç yaşındasınız: ");
            if (age >= 24) Console.WriteLine("E sınıfı ehliyet alabilirsiniz.");
            else if (age >= 18) Console.WriteLine("B sınıfı ehliyet alabilirsiniz.");
            else if (age >= 15) Console.WriteLine("A2 sınıfı ehliyet alabilirsiniz.");
            else Console.WriteLine("Ehliyet alamazsınız.");
        }

        // 12
        private static void DotOrComma()
        {
            Console.Write("Lütfen '.' veya ',' tuşuna basın: ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Geçersiz giriş.");
                return;
            }
            var ch = input[0];
            if (ch == '.') Console.WriteLine("Noktaya bastınız.");
            else if (ch == ',') Console.WriteLine("Virgüle bastınız.");
            else Console.WriteLine("Beklenmeyen karakter.");
        }

        // 13
        private static void NumberSignExample()
        {
            try
            {
                int number = ReadInt("Bir sayı girin: ");
                if (number < 0) Console.WriteLine("Sayı negatif.");
                else if (number == 0) Console.WriteLine("Sayı sıfırdır.");
                else Console.WriteLine("Sayı pozitif.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }
        }

        // 14
        private static void SimpleAuthentication()
        {
            Console.Write("Kullanıcı adı: ");
            var username = Console.ReadLine() ?? string.Empty;
            Console.Write("Parola: ");
            var password = Console.ReadLine() ?? string.Empty;

            if (username == "admin" && password == "123")
                Console.WriteLine("Hoşgeldiniz.");
            else
                Console.WriteLine("Kullanıcı adı veya parola yanlış.");
        }

        // 15
        private static void TeamColorShowcase()
        {
            Console.Write("Takımınız (fb/gs/bjk): ");
            var team = (Console.ReadLine() ?? string.Empty).Trim().ToLowerInvariant();
            if (team == "fb")
            {
                // kısa gösterim: renkleri birkaç kez yazdır
                for (int i = 0; i < 6; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("En Büyük Fenerbahçe".PadRight(Console.WindowWidth));
                    Console.ResetColor();
                }
            }
            else if (team == "gs")
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GALATASARAY");
                Console.ResetColor();
            }
            else if (team == "bjk")
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("BEŞİKTAŞ");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Bilinmeyen takım.");
            }
        }

        // 16
        private static void SplitGenderAge()
        {
            Console.WriteLine("Cinsiyet ve yaşınızı girin (örnek: erkek 18):");
            var input = (Console.ReadLine() ?? string.Empty).Trim().ToLowerInvariant();
            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2 || !int.TryParse(parts[1], out var age))
            {
                Console.WriteLine("Geçerli format: 'erkek 18' gibi.");
                return;
            }

            var gender = parts[0];
            if (gender == "erkek" && age >= 18) Console.WriteLine("Arabayı Bakıma Götür.");
            else if (gender == "kadın" && age >= 18) Console.WriteLine("Kuaföre Git.");
            else if (gender == "erkek") Console.WriteLine("Arabayla Oyna.");
            else if (gender == "kadın") Console.WriteLine("Bebekle Oyna.");
            else Console.WriteLine("Bilinmeyen cinsiyet.");
        }

        // 17
        private static void CircleAreaOrCircumference()
        {
            double r = ReadDouble("Yarıçapı girin: ");
            Console.WriteLine("1 - Çemberin çevresi\n2 - Dairenin alanı");
            int choice = ReadInt("Seçiminiz: ");
            if (choice == 1)
            {
                double circumference = 2 * Math.PI * r;
                Console.WriteLine($"Çemberin Çevresi: {circumference:F2}");
            }
            else if (choice == 2)
            {
                double area = Math.PI * Math.Pow(r, 2);
                Console.WriteLine($"Dairenin Alanı: {area:F3}");
            }
            else
            {
                Console.WriteLine("Geçersiz seçim.");
            }
        }

        // 18
        private static void EvenOrOdd()
        {
            try
            {
                int value = ReadInt("Bir sayı girin: ");
                if (value == 0) { Console.WriteLine("0 girdiniz."); return; }
                bool isOdd = Math.Abs(value % 2) == 1;
                Console.WriteLine(isOdd ? "Tek" : "Çift");
            }
            catch
            {
                Console.WriteLine("Lütfen rakam girin.");
            }
        }

        // 19
        private static void DigitToWord()
        {
            try
            {
                int digit = ReadInt("0-9 arası bir rakam girin: ");
                if (digit < 0 || digit > 9) { Console.WriteLine("Lütfen 0-9 arası rakam girin."); return; }
                var words = new[] { "Sıfır", "Bir", "İki", "Üç", "Dört", "Beş", "Altı", "Yedi", "Sekiz", "Dokuz" };
                Console.WriteLine($"#{words[digit]}#");
            }
            catch
            {
                Console.WriteLine("Geçersiz giriş.");
            }
        }

        // 20
        private static void MonthSwitch()
        {
            try
            {
                int month = ReadInt("1..12 arası ay numarası girin: ");
                switch (month)
                {
                    case 1: Console.WriteLine("Ocak - Kış | Muharrem"); break;
                    case 2: Console.WriteLine("Şubat - Kış | Safer"); break;
                    case 3: Console.WriteLine("Mart - İlkbahar | Rebiülevvel"); break;
                    case 4: Console.WriteLine("Nisan - İlk Bahar | Rebiülahir"); break;
                    case 5: Console.WriteLine("Mayıs - İlk Bahar | Cemaziyülevvel"); break;
                    case 6: Console.WriteLine("Haziran - Yaz | Cemaziyülahir"); break;
                    case 7: Console.WriteLine("Temmuz - Yaz | Recep"); break;
                    case 8: Console.WriteLine("Ağustos - Yaz | Şaban"); break;
                    case 9: Console.WriteLine("Eylül - Sonbahar | Ramazan"); break;
                    case 10: Console.WriteLine("Ekim - Sonbahar | Şevval"); break;
                    case 11: Console.WriteLine("Kasım - Sonbahar | Zilkade"); break;
                    case 12: Console.WriteLine("Aralık - Kış | Zilhicce"); break;
                    default: Console.WriteLine("1-12 arasında bir değer girin."); break;
                }
            }
            catch
            {
                Console.WriteLine("Geçersiz giriş.");
            }
        }

        // 21
        private static void SimpleCalculator()
        {
            try
            {
                double a = ReadDouble("1. sayıyı girin: ");
                double b = ReadDouble("2. sayıyı girin: ");
                Console.Write("İşlemi seçin (+ - * / %): ");
                var op = (Console.ReadLine() ?? "+").Trim();
                switch (op)
                {
                    case "/":
                        if (Math.Abs(b) < double.Epsilon) Console.WriteLine("Sıfıra bölme hatası."); else Console.WriteLine(a / b);
                        break;
                    case "*": Console.WriteLine(a * b); break;
                    case "-": Console.WriteLine(a - b); break;
                    case "+": Console.WriteLine(a + b); break;
                    case "%":
                        if (Math.Abs(b) < double.Epsilon) Console.WriteLine("Sıfıra bölüm hatası."); else Console.WriteLine(a % b);
                        break;
                    default: Console.WriteLine("Bilinmeyen işlem."); break;
                }
            }
            catch
            {
                Console.WriteLine("Hatalı işlem girişi.");
            }
        }

        // 22 - Starbucks simulation (kısaltılmış ve daha sağlam giriş kontrolüyle)
        private static void StarbucksSimulation()
        {
            Typewriter(@"
  #####   ######     ##     ######   ######   ##   ##    ####   ###  ##   #####
 ##   ##  # ## #    ####     ##  ##   ##  ##  ##   ##   ##  ##   ##  ##  ##   ##
  #####     ##     ##  ##    #####    #####   ##   ##  ##        ####     #####
", 2, newline: true);

            decimal balance = 500m;
            Console.WriteLine($"Mevcut bakiyeniz: {balance} TL");
            int quantity = ReadInt("Kaç adet kahve almak istiyorsunuz?: ");
            if (quantity <= 0) { Console.WriteLine("Geçersiz adet."); return; }

            var priceTable = new Dictionary<string, Dictionary<string, decimal>>
            {
                { "Macchiato", new() { { "Tall", 160m }, { "Grande", 170m }, { "Venti", 180m } } },
                { "Caramel Macchiato", new() { { "Tall", 165m }, { "Grande", 175m }, { "Venti", 185m } } },
                { "Latte", new() { { "Tall", 150m }, { "Grande", 160m }, { "Venti", 170m } } },
                { "White Chocolate Mocha", new() { { "Tall", 175m }, { "Grande", 185m }, { "Venti", 195m } } }
            };

            var orders = new List<string>();
            decimal total = 0m;
            for (int i = 1; i <= quantity; i++)
            {
                Console.WriteLine($"\n== {i}. kahve ==");
                Console.WriteLine("1-Macchiato 2-Caramel Macchiato 3-Latte 4-White Chocolate Mocha");
                var kind = Console.ReadLine() ?? "1";
                string kindName = kind switch
                {
                    "2" => "Caramel Macchiato",
                    "3" => "Latte",
                    "4" => "White Chocolate Mocha",
                    _ => "Macchiato"
                };

                Console.WriteLine("Boyut: 1-Tall 2-Grande 3-Venti");
                var size = Console.ReadLine() ?? "1";
                string sizeName = size switch
                {
                    "2" => "Grande",
                    "3" => "Venti",
                    _ => "Tall"
                };

                Console.WriteLine("Sıcaklık: 1-Sıcak 2-Soğuk");
                var temp = Console.ReadLine() ?? "1";
                string tempName = temp == "2" ? "Soğuk" : "Sıcak";

                Console.WriteLine("Süt: 1-Normal 2-Soya 3-Badem");
                var milk = Console.ReadLine() ?? "1";
                string milkName = milk switch
                {
                    "2" => "Soya",
                    "3" => "Badem",
                    _ => "Normal"
                };

                Console.WriteLine("Yumuşak içim isterseniz 1, istemezseniz 2");
                var soft = Console.ReadLine() ?? "2";
                bool isSoft = soft == "1";
                decimal softExtra = isSoft ? 20m : 0m;

                decimal price = priceTable[kindName][sizeName] + softExtra;
                total += price;
                orders.Add($"{kindName} ({sizeName}, {tempName}, {milkName}{(isSoft ? ", Extra Yumuşak" : "")}) = {price} TL");
            }

            if (total > balance)
            {
                Console.WriteLine($"Yetersiz bakiye. Toplam: {total} TL, Bakiye: {balance} TL");
            }
            else
            {
                balance -= total;
                Console.WriteLine("\n----- Sipariş Özeti -----");
                for (int i = 0; i < orders.Count; i++) Console.WriteLine($"{i + 1}. {orders[i]}");
                Console.WriteLine($"Toplam: {total} TL\nKalan bakiye: {balance} TL\nAfiyet olsun!");
            }
        }

        // 23
        private static void TypewriterBalanceMessage()
        {
            decimal total = 250m;
            decimal balance = 200m;
            string message = $"Yeterli bakiye yok! Toplam tutar: {total} TL, mevcut bakiye: {balance} TL";
            Typewriter(message, milisecondsPerChar: 50, newline: true);
        }

        // 24
        private static void ListMultiplesOfThree()
        {
            int start = ReadInt("Başlangıç değerini girin: ");
            int end = ReadInt("Bitiş değerini girin: ");
            if (start > end) (start, end) = (end, start); // kolaylık: ters girildiğinde düzelt
            Console.WriteLine($"{start} ile {end} arasındaki 3'e bölünen sayılar:");
            for (int i = start; i <= end; i++)
            {
                if (i % 3 == 0) Console.WriteLine(i);
            }
        }

        // 25
        private static void AsciiArtFlow()
        {
            Console.Write("ASCII'ye çevirmek istediğiniz metni girin: ");
            string text = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("0 - Varsayılan (#)\n1 - Özel karakter");
            int type = ReadInt("Seçiminiz: ");
            char asciiChar = '#';
            if (type == 1)
            {
                Console.Write("ASCII karakteri girin (tek karakter): ");
                var ch = Console.ReadLine();
                if (!string.IsNullOrEmpty(ch)) asciiChar = ch[0];
            }
            AsciiArt(text, asciiChar);
        }

        #endregion

        #region Yardımcı fonksiyonlar

        /// <summary>
        /// Türkçe karakterleri Latin temel karakterlere dönüştürür (basit sanitizasyon).
        /// Eğitim amaçlı, gerçek uygulamada düzgün normalization tercih edin.
        /// </summary>
        private static string SanitizeTurkishLetters(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            return input
                .Replace('ç', 'c').Replace('Ç', 'C')
                .Replace('ğ', 'g').Replace('Ğ', 'G')
                .Replace('ı', 'i').Replace('İ', 'I')
                .Replace('ö', 'o').Replace('Ö', 'O')
                .Replace('ş', 's').Replace('Ş', 'S')
                .Replace('ü', 'u').Replace('Ü', 'U');
        }

        /// <summary>
        /// Ekrana yazıyı karakter karakter yazdırır (daktilo efekti).
        /// milisecondsPerChar: her karakter için bekleme süresi (ms).
        /// newline: true ise işlem sonunda satır atlar.
        /// </summary>
        private static void Typewriter(string text, int milisecondsPerChar = 10, bool newline = false)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(milisecondsPerChar);
            }
            if (newline) Console.WriteLine();
        }

        /// <summary>
        /// Basit ASCII sanat fonksiyonu.
        /// Eğitim amaçlı, yalnızca A-Z arası harfleri ve boşluğu işler.
        /// Türkçe karakterler önce Latin karşılıklarına dönüştürülür.
        /// </summary>
        static void AsciiArt(string metin, char asciiChar)
        {
            int indexB, indexK;
            metin = metin

                .Replace("ç", "c")
                .Replace("Ç", "C")
                .Replace("ğ", "g")
                .Replace("Ğ", "G")
                .Replace("ı", "i")
                .Replace("İ", "I")
                .Replace("ö", "o")
                .Replace("Ö", "O")
                .Replace("ş", "s")
                .Replace("Ş", "S")
                .Replace("ü", "u")
                .Replace("Ü", "U");

            string[] asciiMetin = { "", "", "", "", "", "", "", "" };
            string[][][] asciiHarf =
            {
                new string[][] //büyük harf
                    {
                        new string[] { "  ##  ", "######", "  #### ", "#####  ", "#######", "########", "  #### ", "##   ##", " #### ", "  ####", " ###  ##", "####   ", "##   ##", "##   ##", " ##### ", " ######", " ##### ", " ######", " ##### ", "######", "##   ##", "##   ##", "##   ##", "##  ##", "##  ##", "#######" },
                        new string[] { " #### ", "##  ##", " ##  ##", " ## ## ", " ##   #", " ##     ", " ##  ##", "##   ##", "  ##  ", "    ##", " ##  ## ", " ##    ", "### ###", "###  ##", "##   ##", " ##  ##", "##   ##", " ##  ##", "##   ##", "# ## #", "##   ##", "##   ##", "##   ##", "##  ##", "## ##", "#   ## " },
                        new string[] { "##  ##", "##  ##", "##     ", " ##  ##", " ## #  ", " ##     ", "##     ", "##   ##", "  ##  ", "    ##", " ## ##  ", " ##    ", "#######", "#### ##", "##   ##", " ##  ##", "##   ##", " ##  ##", "#      ", "  ##  ", "##   ##", " ## ## ", "##   ##", " #### ", "##  ##", "   ##  " },
                        new string[] { "##  ##", "##### ", "##     ", " ##  ##", " ####  ", " ###### ", "##     ", "#######", "  ##  ", "    ##", " ####   ", " ##    ", "#######", "## ####", "##   ##", " ##### ", "##   ##", " ##### ", " ##### ", "  ##  ", "##   ##", " ## ## ", "## # ##", "  ##  ", " #### ", "  ##   " },
                        new string[] { "######", "##  ##", "##     ", " ##  ##", " ## #  ", " ##     ", "##  ###", "##   ##", "  ##  ", "##  ##", " ## ##  ", " ##   #", "## # ##", "##  ###", "##   ##", " ##    ", "##  ###", " ## ## ", "     ##", "  ##  ", "##   ##", "  ###  ", "#######", " #### ", "  ##  ", " ##    " },
                        new string[] { "##  ##", "##  ##", " ##  ##", " ## ## ", " ##   #", " ##     ", " ##  ##", "##   ##", "  ##  ", "##  ##", " ##  ## ", " ##  ##", "##   ##", "##   ##", "##   ##", " ##    ", " ##### ", " ##  ##", "##   ##", "  ##  ", "##   ##", "  ###  ", "### ###", "##  ##", "  ##  ", "##    #" },
                        new string[] { "##  ##", "######", "  #### ", "#####  ", "#######", "###     ", "  #####", "##   ##", " #### ", " #### ", "###  ## ", "#######", "##   ##", "##   ##", " ##### ", "####   ", "   ####", "#### ##", " ##### ", " #### ", " ##### ", "   #   ", "##   ##", "##  ##", " #### ", "#######" },
                        new string[] { "      ", "      ", "       ", "       ", "       ", "        ", "       ", "       ", "      ", "       ","        ", "       ", "       ", "       ", "       ", "       ", "       ", "       ", "       ", "      ", "       ", "       ", "       ", "      ", "      ", "       " }
                    },
                new string[][] //küçük harf
                    {
                        new string[] { "      ", "###    ", "      ", "   ### ", "      ", "  ### ", "       ", "###    ", "  ##  ", "    ##", "###    ", "### ", "       ", "      ", "      ", "       ", "       ", "       ", "       ", " ##   ", "       ", "      ", "       ", "      ", "      ", "      "},
                        new string[] { "      ", " ##    ", "      ", "    ## ", "      ", " ## ##", "       ", " ##    ", "      ", "      ", " ##    ", " ## ", "       ", "      ", "      ", "       ", "       ", "       ", "       ", " ##   ", "       ", "      ", "       ", "      ", "      ", "      "},
                        new string[] { " #### ", " ##    ", " #### ", "    ## ", " #### ", "  #   ", " ### ##", " ##    ", " ###  ", "   ###", " ##  ##", " ## ", "##  ## ", "##### ", " #### ", "###### ", " ######", "###### ", " ##### ", "##### ", "##  ## ", "##  ##", "##   ##", "##  ##", "##  ##", "######"},
                        new string[] { "    ##", " ##### ", "##  ##", " ##### ", "##  ##", "####  ", "##  ## ", " ##### ", "  ##  ", "    ##", " ## ## ", " ## ", "#######", "##  ##", "##  ##", " ##  ##", "##  ## ", " ##  ##", "##     ", " ##   ", "##  ## ", "##  ##", "## # ##", " #### ", "##  ##", "#  ## "},
                        new string[] { " #####", " ##  ##", "##    ", "##  ## ", "######", " ##   ", "##  ## ", " ##  ##", "  ##  ", "    ##", " ####  ", " ## ", "## # ##", "##  ##", "##  ##", " ##  ##", "##  ## ", " ##    ", " ##### ", " ##   ", "##  ## ", "##  ##", "#######", "  ##  ", "##  ##", "  ##  "},
                        new string[] { "##  ##", " ##  ##", "##  ##", "##  ## ", "##    ", " ##   ", " ##### ", " ##  ##", "  ##  ", "##  ##", " ## ## ", " ## ", "##   ##", "##  ##", "##  ##", " ##### ", " ##### ", " ##    ", "     ##", " ## ##", "##  ## ", " #### ", "#######", " #### ", " #####", " ##  #"},
                        new string[] { " #####", "###### ", " #### ", " ######", " #####", "####  ", "    ## ", "###  ##", " #### ", "##  ##", " ##  ##", "####", "##   ##", "##  ##", " #### ", " ##    ", "    ## ", "####   ", "###### ", "  ### ", "###### ", "  ##  ", " ## ## ", "##  ##", "    ##", "######"},
                        new string[] { "      ", "       ", "      ", "       ", "      ", "      ", "#####  ", "       ", "      ", " #### ", "       ", "    ", "       ", "      ", "      ", "####   ", "   ####", "       ", "       ", "      ", "       ", "      ", "  # #  ", "      ", "##### ", "      "}

                    }
             };

            foreach (char c in metin)
            {
                indexB = c - 'A';
                indexK = c - 'a';

                if (indexB >= 0 && indexB <= 25)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        asciiMetin[i] += asciiHarf[0][i][indexB] + " ";
                    }
                }
                else if (indexK >= 0 && indexK <= 25)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        asciiMetin[i] += asciiHarf[1][i][indexK] + " ";
                    }
                }
                else if (c == ' ')
                {
                    for (int i = 0; i < 8; i++)
                    {
                        asciiMetin[i] += "    ";
                    }
                }
            }


            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(asciiMetin[i].Replace("#", asciiChar.ToString()));
            }
        }

        #endregion
    }
}