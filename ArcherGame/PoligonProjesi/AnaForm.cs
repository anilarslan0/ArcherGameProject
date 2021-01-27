using Poligon.Library.Concrete;
using Poligon.Library.Enum;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PoligonProjesi
{
    public partial class AnaForm : Form
    {
        
        private readonly Oyun _oyun;
        public static int sırano = 1;  //Zemin için sıra noyu 1'e sabitliyoruz.

        public AnaForm()
        {
            InitializeComponent();
            _oyun = new Oyun(SavascıPanel,BalonPanel);
            _oyun.SureDegisti += Oyun_SureDegisti;
            
        }

        private void AnaForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode) //Bu switch ile Yon enumunuda kullanarak tuşlarını hangi metotları çalıştıracağını belirliyoruz.
            {
                case Keys.Enter:
                    _oyun.Baslat();
                    break;
                case Keys.Up:
                    _oyun.SavasciyiHareketEttir(Yon.Yukari);
                    break;
                case Keys.Down:
                    _oyun.SavasciyiHareketEttir(Yon.Asagi);
                    break;
                case Keys.Space:
                    _oyun.AtesEt();
                    break;              
            }
        }

        private void Oyun_SureDegisti(object sender, EventArgs e)
        {
            SüreLabel.Text = $"{_oyun.GecenSure.Minutes}:{_oyun.GecenSure.Seconds.ToString("D2")}";
            //Labela dakika ve saniyeyi yazdırıyoruz.
        }

        private void Oyun_PuanDegisti(object sender, EventArgs e)
        {
         
        }
        private void SavascıPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        void AnaForm_Load(object sender, EventArgs e)
        {
           pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\zemin\\" + 1 + ".jpg");
            //picturbox1'e zemin klosoründen jpg uzantılı fotoğrafları çekiyoruz.
            
        }

       

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (sırano == 4)
            {
                sırano = 0;
            }
            sırano += 1;
           
            //Dosyamızda bulunan 4 görseli 1 arttırarak picturboxa yerleştiriyoruz sırasıyla.
            //Görseli değiştirme işlemini bir başka picturebox ile yapıyoruz.

           pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\zemin\\" + sırano + ".jpg");
            
        }

      

      
    }
}
