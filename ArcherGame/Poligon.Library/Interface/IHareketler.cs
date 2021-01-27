using Poligon.Library.Enum;
using System.Drawing;

namespace Poligon.Library.Interface
{
    interface IHareketler  //Ok , okcu ve balon sınıflarımız için gerekli olan Interfacemiz.
    {
        Size HareketAlaniBoyutlari{ get; }
        
        int HareketMesafesi { get; }
   
        bool HareketEttir(Yon yon); 
    }
}
