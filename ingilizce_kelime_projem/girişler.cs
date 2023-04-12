using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace ingilizce_kelime_projem
{
    public partial class girişler : Form
    {
        public girişler()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\90536\\OneDrive\\Belgeler\\Database1.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut1 = new OleDbCommand("select * from Tablo2 where Ad=@p1 and Telefon=@p2", baglanti);
            komut1.Parameters.AddWithValue("@p1", txtad.Text);
            komut1.Parameters.AddWithValue("@p2", msktel.Text);
            OleDbDataReader drer = komut1.ExecuteReader();
            if (drer.Read())
            {
                Form1 def = new Form1();
                def.Show();
                this.Hide();
            }
            else
            {

                MessageBox.Show("Hatalı Ad veya Telefon Girişi", "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            baglanti.Close();
        }
        
    }
}
