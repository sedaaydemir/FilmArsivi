using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FilmArsivi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Data Source=DESKTOP-BIP870C;Initial Catalog=DbSecimProje;Integrated Security=True;Encrypt=True;Trust Server Certificate=True

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-BIP870C;Initial Catalog=FilmArsivi;Integrated Security=True");
        void filmler()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TblFilm",baglanti); 
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            filmler();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into TblFilm (Ad, Kategori, Link) values(@P1,@P2,@P3)", baglanti);
            komut.Parameters.AddWithValue("@P1", TxtFilmAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtKategori.Text);
            komut.Parameters.AddWithValue("@P3", TxtLink.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film Listenize Eklendi..", "Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Information);
            filmler();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            webBrowser1.Navigate(link);
        }

        private void BtnHakkimizda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu proje Seda Aydemir tarafından 25 Temmuz da kodlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnRenkdegis_Click(object sender, EventArgs e)
        {
            //belirlenen renk dızısınden rastgele her tıklandıgında arka planı degıstır
        }

        private void BtnTamekran_Click(object sender, EventArgs e)
        {
            //web browser yenı form a yonlendır. o formda web browserın docinpen.. contaıer secılı old. bu form o tarafa tasınsın
        }
    }
}
