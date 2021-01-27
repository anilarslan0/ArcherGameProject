using Poligon.Library.Enum;
using System;

namespace Poligon.Library.Interface
{
    internal interface IOyun  //oyun sınıfımız için oluşturmuş olduğumuz interface.
    {
        event EventHandler SureDegisti;
        bool DevamEdiyorMu { get;}

        TimeSpan GecenSure { get; }

        void Baslat();
        void AtesEt();
        void SavasciyiHareketEttir(Yon yon);



    }
}
