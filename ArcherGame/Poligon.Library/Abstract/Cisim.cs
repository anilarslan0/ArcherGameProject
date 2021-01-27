using Poligon.Library.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poligon.Library.Interface;

namespace Poligon.Library.Abstract
{
    internal abstract class Cisim : PictureBox , IHareketler  //Hareketler ınterfacesine ulaşıyoruz.
    {
        
        public Size HareketAlaniBoyutlari { get; }

        public int HareketMesafesi { get; protected set; }

        public new int Right  //Right(sağ) kısmını left(sol) cinsinden baştan yazıyoruz.
        {
            get => base.Right;
            set => Left = value - Width;
        }

        public new int Bottom //Yükseklik cinsinden baştan yazıyoruz.
        {
            get => base.Bottom;
            set => Top = value - Height;
        }

        public int Center  //cismin merkezini belirlediğimiz kısım. Genişlik cinsinden.
        {
            get => Left + Width / 2;
            set => Left = value - Width / 2;
        }
        public int Middle     //cismin ortasını belirlediğimiz kısım. Yükseklik cinsinden cinsinden.
        {
            get => Top + Height / 2;
            set => Top = value - Height / 2;
        }
        protected Cisim(Size hareketAlaniBoyutlari)
        {
            Image = Image.FromFile($@"Resim\{GetType().Name}.png"); //Cisimleri görsellerini dosyadan çekmek için yazdığımız kod.
            HareketAlaniBoyutlari = hareketAlaniBoyutlari;
            SizeMode = PictureBoxSizeMode.AutoSize;
             
        }

        public bool HareketEttir (Yon yon) //Enumden yon bilgilerini cekerek swich 
        {                                  //kullanarak yönlerimizi fonksiyonelleştiriyoruz.
            switch (yon)
            {
                case Yon.Yukari:
                    return YukariHareketEttir();
                case Yon.Asagi:
                    return AsagiHareketEttir();
                case Yon.Saga:
                    return SagaHareketEttir();
                case Yon.Sola:
                    return SolaHareketEttir();
                default:
                    throw new ArgumentOutOfRangeException(nameof(yon), yon, null);
            }

        }

        private bool SolaHareketEttir()    //Sola hareket ettiren fonksiyonumuz.Ne kadar hareket edicekleriniz yazıyoruz.
        {
            if (Left == 0) return true;

            var yeniLeft = Left - HareketMesafesi; 
            var tasacakMi = yeniLeft < 0;           //platformumuzdan taşmaması için.
            Left = tasacakMi ? 0 : yeniLeft;

            return Left == 0;
        }

        private bool SagaHareketEttir() //Saga hareket ettiren fonksiyonumuz..Ne kadar hareket edicekleriniz yazıyoruz.
        {
            if (Right == HareketAlaniBoyutlari.Width) return true;

            var yeniRight = Right + HareketMesafesi;
            var tasacakMİ = yeniRight > HareketAlaniBoyutlari.Width; //platformumuzdan taşmaması için.

            Right = tasacakMİ ? HareketAlaniBoyutlari.Width : yeniRight;
            

            return Right == HareketAlaniBoyutlari.Width;
        }

        private bool AsagiHareketEttir()    //Asagi hareket ettiren fonksiyonumuz..Ne kadar hareket edicekleriniz yazıyoruz.
        {
            if (Bottom == HareketAlaniBoyutlari.Height) return true;

            var yeniBottom = Bottom + HareketMesafesi;   
            var tasacakMİ = yeniBottom > HareketAlaniBoyutlari.Height;  //platformumuzdan taşmaması için.

            Bottom = tasacakMİ ? HareketAlaniBoyutlari.Height : yeniBottom;


            return Bottom == HareketAlaniBoyutlari.Height;
        }

        private bool YukariHareketEttir()  //Yukari hareket ettiren fonksiyonumuz..Ne kadar hareket edicekleriniz yazıyoruz.
        {
            if (Top == 0) return true;

            var yeniTop = Top - HareketMesafesi;
            var tasacakMi = yeniTop < 0;    //platformumuzdan taşmaması için.
            Top = tasacakMi ? 0 : yeniTop;

            return Top == 0;
        }
    }
}
