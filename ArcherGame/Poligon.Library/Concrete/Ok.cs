using Poligon.Library.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poligon.Library.Concrete
{
    internal class Ok : Cisim   //Cisim sınıfından kalıtım aldık.
    {
        public Ok(Size hareketAlaniBoyutlari, int okcuOrtasi) : base(hareketAlaniBoyutlari)
        {
            BaslangicKonumunuAyarla(okcuOrtasi);    //Okun okcunun hangi bölümünden baslayarak ilerleyeceğini belirledik.
            HareketMesafesi =(int)(Height * 1.5);  //okun 1 birimde ne kadar mesafe katedebileceğini belirledik.
        }

        private void BaslangicKonumunuAyarla(int okcuOrtasi)
        {
           // Center = HareketAlaniBoyutlari.Height;
            Bottom = okcuOrtasi;   //Okun hangi konumdan baslayacagini ayarladik.
        }
    }
}
