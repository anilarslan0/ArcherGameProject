
using Poligon.Library.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Poligon.Library.Concrete
{
    internal class Balon : Cisim //Cisim sınıfından kalıtım aldık.
    {
        
        private static readonly Random Random = new Random(); //Balonların random gelmesi için oluşturuyoruz.
        

        public Balon(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
            HareketMesafesi = (int)(Height * .05);  //Balonun kendi yüksekliğinie oranla bir ilerleme yazdık.
            Left = Random.Next(hareketAlaniBoyutlari.Width - Width +1);

        }

        public Ok VurulduMu(List<Ok> oklar)   //Balonun ok tarafından vurulduğu durumlaro belirledik.
        {
            foreach (var ok in oklar)
            {
                var vurulduMu = ok.Top < Bottom && ok.Right > Left && ok.Left < Right;
                if (vurulduMu) return ok;   //Eğer vuruldu ise döndür.
            }
            return null;
        }
    }
}
