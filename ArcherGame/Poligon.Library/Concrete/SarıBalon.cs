using Poligon.Library.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Poligon.Library.Concrete
{
    internal class SarıBalon :Cisim //Cisim sınıfından kalıtım alınıyor.
    {
        private static readonly Random Random = new Random(); //Balonların random gelmesi için oluşturuyoruz.

        public SarıBalon(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {

            HareketMesafesi = (int)(Height * .05); //Hareket mesafesini belirliyoruz.
            Left = Random.Next(hareketAlaniBoyutlari.Width-Width+1);


        }

        public Ok vurulduMu(List<Ok> oklar) //Burada veri tipi olarak ok kullanarak balonun vurulmasını sağlıyoruz.
        {
            foreach (var ok in oklar)
            {
                var vurulduMu = ok.Top < Bottom && ok.Right > Left && ok.Left < Right;//Hangi şartlarda vurulacağı balonun.
                if (vurulduMu) return ok;    
            }
            return null; //eğer hiç bir ok balonu vurmamıssa.
        }
    }
}
