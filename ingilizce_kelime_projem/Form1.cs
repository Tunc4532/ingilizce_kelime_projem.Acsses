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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\90536\\OneDrive\\Belgeler\\Database1.accdb");
        Random rastgele = new Random();
        int süre = 90;
        int kelime = 0;
        void deger()
        {
            int sayı;
            sayı = rastgele.Next(1, 4);
            lblcevap.Text = sayı.ToString();

            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * from Tablo1 where ıd=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", sayı);
            OleDbDataReader dre = komut.ExecuteReader();
            while (dre.Read())
            {
                txtingilizce.Text = dre[1].ToString();
                lblcevap.Text = dre[2].ToString();
                lblcevap.Text = lblcevap.Text.ToLower();
            }
            baglanti.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            deger();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            süre--;
            lblsüre.Text = süre.ToString();
            if(süre==0)
            {
                txtingilizce.Enabled=false;
                txttürkce.Enabled=false;
                timer1.Stop();
            }
        }

        private void txttürkce_TextChanged(object sender, EventArgs e)
        {
            if(txttürkce.Text==lblcevap.Text)
            {
                kelime++;
                lblkelime.Text=kelime.ToString();
                deger();
                txttürkce.Clear();
            }
        }
    }
}
