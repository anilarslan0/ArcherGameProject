using Poligon.Library.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Poligon.Library.Concrete
{
    internal class Okcu : Cisim //Cisim sınıfından kalıtım aldık.
    {
        public Okcu(int panelGenisliği,Size hareketAlaniBoyutlari) : base (hareketAlaniBoyutlari)
        {
            Center = panelGenisliği / 2;         
            HareketMesafesi = Width/4;

            //okcunun konumunu ve bir tuşa basildiğinda ne kadar hareket etmesi gerektigini belirledik.
        }
    }
}
