using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Steganografi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Bitmap bmp = null;
        private string cikarilanYazi = string.Empty;
        private void btnAc_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Resim Dosyaları (*.png,*.bmp,*.jpg)|*.png;*.bmp;*.jpg";


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                picIsleme.Image = Image.FromFile(dialog.FileName);
                btnGizle.Enabled = true;
            }
            int lsb1,lsb2;
            for (int i = 0; i < picIsleme.Height; i++)
            {
                for (int j = 0; j < picIsleme.Width; j++)
                {
                    lsb1 = picIsleme.Height * picIsleme.Width * 3;
                    lsb2 = lsb1 / 8;
                    toolStripSayi.Text = lsb2.ToString();
                }
            }


        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_dialog = new SaveFileDialog();
            save_dialog.Filter = "Png Image|*.png|Bitmap Image|*.bmp";

            if (save_dialog.ShowDialog() == DialogResult.OK)
            {
                switch (save_dialog.FilterIndex)
                {
                    case 0:
                        {
                            bmp.Save(save_dialog.FileName, ImageFormat.Png);
                        }
                        break;
                    case 1:
                        {
                            bmp.Save(save_dialog.FileName, ImageFormat.Bmp);
                        }
                        break;
                }

            }
        }
        private void btnGizle_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Girmiyorum Hocam");
            bmp = (Bitmap)picIsleme.Image;
            string yazi = txtMesaj.Text;
            bmp = StegoIslem.yaziGizle(yazi, bmp);
            MessageBox.Show("İşlendi. Resmi Kaydetmeyi unutmayın!");
        }

        private void btnCoz_Click(object sender, EventArgs e)
        {
            bmp = (Bitmap)picIsleme.Image;
            string coz = StegoIslem.Coz(bmp);
            txtMesaj.Text = "";
            txtMesaj.Text = coz;
        }

        private void menuCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuIletisim_Click(object sender, EventArgs e)
        {
            MessageBox.Show("*omr_kcmn@outlook.com\n*Ömer Kocaman");
        }
    }
}
