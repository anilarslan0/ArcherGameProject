using Poligon.Library.Enum;
using Poligon.Library.Interface;
using Poligon.Library.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Poligon.Library.Concrete
{
    public class Oyun : IOyun //Oyun interfacesine bağlanıyoruz.
    {       //ınterval= ifadesi hızı belirler.
        private readonly Timer _gecenSureTimer = new Timer {Interval=1000 };
        private readonly Timer _hareketTimer = new Timer { Interval = 100};
        private readonly Timer _balonOlusturmaTimer = new Timer { Interval = 2000 };
        private readonly Timer _SarıbalonOlusturmaTimer = new Timer { Interval = 20000/3 };
        private readonly Timer _KırmızıbalonOlusturmaTimer = new Timer { Interval = 10000 };
        private TimeSpan _gecensure;
        private readonly Panel _SavascıPanel;
        private Okcu _okcu;
        private readonly Panel _BalonPanel;
        private readonly List<Ok> _oklar = new List<Ok>();         //Balonlar ve Ok için list oluşturuldu.
        private readonly List<Balon> _balonlar = new List<Balon>();
        private readonly List<SarıBalon> _sarıBalonlar = new List<SarıBalon>();
        private readonly List<KırmızıBalon> _kırmızıBalonlar = new List<KırmızıBalon>();


        public event EventHandler SureDegisti;
        

        public bool DevamEdiyorMu { get; private set; }

        public TimeSpan GecenSure   //Timespan komutu bir zaman aralığını ifade eder burada gecen süreyi buluyor.
        {    get =>_gecensure;
            private set
            {
                _gecensure = value;

                SureDegisti?.Invoke(this, EventArgs.Empty);
                //Invoke Denetimin temel alınan pencere tanıtıcısına sahip iş parçacığında belirtilen temsilciyi yürütür.
            }
        }


        public Oyun(Panel SavascıPanel, Panel BalonPanel)
        {
            _BalonPanel = BalonPanel;
            _SavascıPanel = SavascıPanel;
            _gecenSureTimer.Tick += GecenSureTimer_Tick;
            _hareketTimer.Tick += HareketTimer_Tick;
            _balonOlusturmaTimer.Tick += BalonOlusturmaTimer_Tick;
            _SarıbalonOlusturmaTimer.Tick += SarıBalonOlusturmaTimer_Tick;
            _KırmızıbalonOlusturmaTimer.Tick += KırmızBalonOlusturmaTimer_Tick;
        }

        private void GecenSureTimer_Tick(object sender, EventArgs e)
        {                                             //Gecen süreyi hesaplamamızı sağlar.
            GecenSure += TimeSpan.FromSeconds(1); //Parantez içine yazdığımız saniyedik 5 yazarsak süre 5 saniye olarak artar.
        }                                         

        private void HareketTimer_Tick(object sender, EventArgs e)
        {
            OklariHareketEttir();        //Timerları bir araya topladığımız alan
            BalonlariHareketEttir();     //Ok , balonlar ve vurulan balonların silindiği timerlar.
            SarıBalonlarıHareketEttir();
            KırmızıBalonlarıHareketEttir();
            VurulanBalonlariSil();
            VurulanSarıBalonlarıSil();
            VurulanKırmızıBalonlarıSil();
        }

        private void VurulanKırmızıBalonlarıSil()   //Ok ile vurulan sarı bolonları silmeye yarayan fonksiyon.
        {
            for(var i=_kırmızıBalonlar.Count-1; i>=0;i--)
            {
                var kırmızıBalon = _kırmızıBalonlar[i];

                var vuranOk = kırmızıBalon.vurulduMu(_oklar);  //ok ile balon  carpıstımı kontrolü yapılır.
                if (vuranOk is null) continue;

                _kırmızıBalonlar.Remove(kırmızıBalon);  //ok ile balon carpisinca ikisinide Remove komutu ile sileriz. 
                _oklar.Remove(vuranOk);                 //ok ile balonu paneldende siliyoruz.
                _BalonPanel.Controls.Remove(kırmızıBalon);
                _BalonPanel.Controls.Remove(vuranOk); 
                
            }
        }

        private void KırmızıBalonlarıHareketEttir() //kırmızı balonları hareket ettirdiğimiz metot.
        {
            foreach (var kırmızıBalon in _kırmızıBalonlar)
            {
                var carptiMi=kırmızıBalon.HareketEttir(Yon.Asagi);  //Balonları Aşağı yönünde hareket ettiriyoruz.
                if (!carptiMi) continue;  //Balonlar Zemine carptı mı kontrolü yapıyoruz.Çarpmadıysa devam ettir diyoruz.

                Bitir();
                break; //burada döngüyü kırıyoruz.
                
            }
        }

        private void VurulanSarıBalonlarıSil() //Ok ile vurulan sarı bolonları silmeye yarayan fonksiyon.
        {
           for(var i=_sarıBalonlar.Count-1;i>=0;i--)
            {
                var sarıBalon = _sarıBalonlar[i];
                var vuranOk=sarıBalon.vurulduMu(_oklar); //ok ile balon  carpıstımı kontrolü yapılır.
                if (vuranOk is null) continue;

                _sarıBalonlar.Remove(sarıBalon);  //ok ile balon carpisinca ikisinide Remove komutu ile sileriz. 
                _oklar.Remove(vuranOk);            //ok ile balonu paneldende siliyoruz.
                _BalonPanel.Controls.Remove(sarıBalon);
                _BalonPanel.Controls.Remove(vuranOk);

               
            }
        }

        private void SarıBalonlarıHareketEttir() //Sarı balonları hareket ettirdiğimiz metot.
        {
            foreach (var sarıBalon in _sarıBalonlar)
            {
                var carptiMi=sarıBalon.HareketEttir(Yon.Asagi); //Balonları Aşağı yönünde hareket ettiriyoruz.
                if (!carptiMi) continue;   //Balonlar Zemine carptı mı kontrolü yapıyoruz.Çarpmadıysa devam ettir.

                Bitir();
                break;   //burada döngüyü kırıyoruz.

            }
        }

        private void VurulanBalonlariSil() //Ok ile vurulan bolonları silmeye yarayan fonksiyon.
        {
            for (int i = _balonlar.Count-1; i >= 0; i--)
            {
                var balon = _balonlar[i];

                var vuranOk= balon.VurulduMu(_oklar);   //ok ile balon  carpıstımı kontrolü yapılır.
                if (vuranOk is null) continue;

                _balonlar.Remove(balon);                //ok ile balon carpisinca ikisinide Remove komutu ile sileriz. 
                _oklar.Remove(vuranOk);                 //ok ile balonu paneldende siliyoruz.
                _BalonPanel.Controls.Remove(balon);
                _BalonPanel.Controls.Remove(vuranOk);
            }
        }

        private void BalonlariHareketEttir() //Balonlaron hareket etmesini sağlayan metot.
        {
            foreach (var balon in _balonlar)
            {
                var carptiMi = balon.HareketEttir(Yon.Asagi); //Balonları aşağı yönde hareket etmesini sağlar.
                if (!carptiMi) continue;                      //Balonların zemine carpıp carpmadığını kontrol eder.
                
                Bitir();
                break;
                
            }
        }

        private void BalonOlusturmaTimer_Tick(object sender, EventArgs e)
        {
            BalonOlustur();     //Balon olusturma timerı.

        }

        private void SarıBalonOlusturmaTimer_Tick(object sender, EventArgs e)
        {
            SarıBalonOlustur();             //Sarı balonların oluşturulurken kullanılar timer tick.
        }
        private void KırmızBalonOlusturmaTimer_Tick(object sender, EventArgs e)
        {
            KırmızıBalonOlustur();    //Kırmızı balonların oluşturulurken kullanılar timer tick.
        }

        private void OklariHareketEttir()  //Okları hareket ettirmemizi sağlayan metot
        {
            for (int i = _oklar.Count-1; i >=0 ; i--)
            {
                var ok = _oklar[i];
                var carptiMi = ok.HareketEttir(Yon.Saga); //Okların sağa doğru hareket etmesini sağlar.
                if (carptiMi)                             //Okların carpınca Remove komutu ile yok olmasını sağlar.
                {
                    _oklar.Remove(ok);
                    _BalonPanel.Controls.Remove(ok);
                }
             
            }
            
        }

        public void AtesEt()   //Ok atmamızı sağlayan fonksiyon.
        {
            if (!DevamEdiyorMu) return;
            var ok = new Ok(_BalonPanel.Size,_okcu.Bottom); //Okları Balon panelinde oluşturur.
            _oklar.Add(ok);
            _BalonPanel.Controls.Add(ok);
            
            
        }

        public void Baslat()   //oyunu başlatmak için kullandığımız fonksiyon.
        {                      //Başlattığımız anda zamanı başlatım okcu ve balonlarıda oluşturuyor.
            if (DevamEdiyorMu) return;
            
                DevamEdiyorMu = true;
            ZamanlayicilariBaslat();
            OkcuOlustur();
            BalonOlustur();
            SarıBalonOlustur();
            KırmızıBalonOlustur();
        }

        private void KırmızıBalonOlustur()  //kırmızı balon oluşturduğumuz metot.
        {
            var kırmızıBalon = new KırmızıBalon(_BalonPanel.Size);
            _kırmızıBalonlar.Add(kırmızıBalon);             //Ve balonları panele ekliyoruz.
            _BalonPanel.Controls.Add(kırmızıBalon);
        }

        private void SarıBalonOlustur()  //sarı balon oluşturduğumuz metot.
        {
            var sarıbalon = new SarıBalon(_BalonPanel.Size); 
            _sarıBalonlar.Add(sarıbalon);
            _BalonPanel.Controls.Add(sarıbalon);  //Ve balonları panele ekliyoruz.
        }

        private void BalonOlustur()
        {
            var balon = new Balon(_BalonPanel.Size);    //Balon paneline balonları eklediğimiz fonksiyon.
            _balonlar.Add(balon);
            _BalonPanel.Controls.Add(balon);
        }

        private void ZamanlayicilariBaslat()   //Zamanlayıcıların baslamasini sağlayan fonksiyon.
        {                                     //Start komutu ile bu işlem gercekleştirilmiştir.
            _gecenSureTimer.Start();
            _hareketTimer.Start();
            _balonOlusturmaTimer.Start();
            _SarıbalonOlusturmaTimer.Start();
            _KırmızıbalonOlusturmaTimer.Start();
        }

        private void OkcuOlustur()   //Savasci panelinde okcu olusturmamızı sağlar.
        {
            _okcu = new Okcu(_SavascıPanel.Width, _SavascıPanel.Size);
            
            _SavascıPanel.Controls.Add(_okcu);

            
        }

        private void Bitir()  //Oyunu bitirmek için oluşturduğumuz fonksiyon.
        {                     //Oyun false durumuna gelirse süreyide durduruyoruz.
           
            if (!DevamEdiyorMu) return;
            DevamEdiyorMu = false;
            ZamanlayicilariDurdur();

        }

        private void ZamanlayicilariDurdur()
        {                               //Stop komutu ile zamanlayıcıları durdurmaya yarayan fonksiyon.
            _gecenSureTimer.Stop();
            _hareketTimer.Stop();
            _balonOlusturmaTimer.Stop();
            _SarıbalonOlusturmaTimer.Stop();
            _KırmızıbalonOlusturmaTimer.Stop();
        }

        public void SavasciyiHareketEttir(Yon yon)
        {
            if (!DevamEdiyorMu) //İstediğimiz yönde savaşciyi hareket ettirmek için kullandığımız fonksiyon.
            {
                return;
            }
            _okcu.HareketEttir(yon);
        }
    }
}
