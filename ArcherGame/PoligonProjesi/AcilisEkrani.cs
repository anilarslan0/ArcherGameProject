using System;
using System.Windows.Forms;

namespace PoligonProjesi
{
    public partial class AcilisEkrani : Form
    {
        public AcilisEkrani()
        {
            InitializeComponent();
        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            AnaForm yeni = new AnaForm(); //anaformu açmak için.
            yeni.Show();
            
        }

     
    }
}
