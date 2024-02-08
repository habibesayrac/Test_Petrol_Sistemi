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

namespace Test_Petrol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestFuel;Integrated Security=True");
        void listele()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From TBLBENZIN where petroltur='Kursunsuz95' ", connection);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                LblKursunsuz95.Text = dr[3].ToString();
                progressBar1.Value = int.Parse(dr[4].ToString());
                Lblkursunsuz95litre.Text = dr[4].ToString();
            }
            connection.Close();

            //kurşunsuz97
            connection.Open();
            SqlCommand command1 = new SqlCommand("Select * From TBLBENZIN where petroltur='Kursunsuz97' ", connection);
            SqlDataReader dr1 = command1.ExecuteReader();
            if (dr1.Read())
            {
                LblKursunsuz97.Text = dr1[3].ToString();
                progressBar2.Value = int.Parse(dr1[4].ToString());
                Lblkursunsuz97litre.Text = dr1[4].ToString();


            }
            connection.Close();

            //eurodizel10
            connection.Open();
            SqlCommand command2 = new SqlCommand("Select * From TBLBENZIN  where petroltur='EuroDizel10' ", connection);
            SqlDataReader dr2 = command2.ExecuteReader();
            if (dr2.Read())
            {
                LblEuroDizel.Text = dr2[3].ToString();
                progressBar3.Value = int.Parse(dr2[4].ToString());
                LbleuroLitre.Text = dr2[4].ToString();


            }
            connection.Close();

            //YeniProDizel
            connection.Open();
            SqlCommand command3 = new SqlCommand("Select * From TBLBENZIN  where petroltur='YeniProDizel' ", connection);
            SqlDataReader dr3 = command3.ExecuteReader();
            if (dr3.Read())
            {
                LblYeniProDizel.Text = dr3[3].ToString();
                progressBar4.Value = int.Parse(dr3[4].ToString());
                LblYeniProlitre.Text = dr3[4].ToString();


            }
            connection.Close();

            //Gaz
            connection.Open();
            SqlCommand command4 = new SqlCommand("Select * From TBLBENZIN  where petroltur='Gaz' ", connection);
            SqlDataReader dr4 = command4.ExecuteReader();
            if (dr4.Read())
            {
                LblGaz.Text = dr4[3].ToString();
                progressBar5.Value = int.Parse(dr4[4].ToString());
                LblGazLitre.Text = dr4[4].ToString();


            }
            connection.Close();



            connection.Open();
            SqlCommand command6 = new SqlCommand("Select * from TBLKASA", connection);
            SqlDataReader dr6 = command6.ExecuteReader();
            while (dr6.Read())
            {
                LblKasa.Text = dr6[0].ToString();

            }


            connection.Close();


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95, litre, tutar;
            kursunsuz95 = Convert.ToDouble(LblKursunsuz95.Text);
            litre = Convert.ToDouble(numericUpDown1.Value);
            tutar = (kursunsuz95 * litre);
            TxtKursunsuz95Fiyat.Text = tutar.ToString();

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz97, litre, tutar;
            kursunsuz97 = Convert.ToDouble(LblKursunsuz97.Text);
            litre = Convert.ToDouble(numericUpDown2.Value);
            tutar = (kursunsuz97 * litre);
            TxtKursunsuz97Fiyat.Text = tutar.ToString();

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double eurodizel, litre, tutar;
            eurodizel = Convert.ToDouble(LblEuroDizel.Text);
            litre = Convert.ToDouble(numericUpDown3.Value);
            tutar = (eurodizel * litre);
            TxtEuroDizelFiyat.Text = tutar.ToString();


        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double yenipro, litre, tutar;
            yenipro = Convert.ToDouble(LblYeniProDizel.Text);
            litre = Convert.ToDouble(numericUpDown4.Value);
            tutar = (yenipro * litre);
            TxtYeniProFiyat.Text = tutar.ToString();

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            double gaz, litre, tutar;
            gaz = Convert.ToDouble(LblGaz.Text);
            litre = Convert.ToDouble(numericUpDown5.Value);
            tutar = (gaz * litre);
            TxtGazFiyat.Text = tutar.ToString();
        }

        private void BtnDepoDoldur_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0)
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"insert into TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) values (@p1,@p2,@p3,@p4)", connection);
                command.Parameters.AddWithValue("@p1", TxtPlaka.Text);
                command.Parameters.AddWithValue("@p2", "Kurşunsuz95");
                command.Parameters.AddWithValue("@p3", numericUpDown1.Value);
                command.Parameters.AddWithValue("@p4", Decimal.Parse(TxtKursunsuz95Fiyat.Text));
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Satış yapıldı");


                connection.Open();
                SqlCommand command2 = new SqlCommand("update TBLKASA set MIKTAR=MIKTAR+@p1", connection);
                command2.Parameters.AddWithValue("@p1", decimal.Parse(TxtKursunsuz95Fiyat.Text));
                command2.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Kasa Güncellendi");


                connection.Open();
                SqlCommand command3 = new SqlCommand("update TBLBENZIN set STOK=STOK-@p1 where petroltur='KURSUNSUZ95'", connection);
                command3.Parameters.AddWithValue("@p1", numericUpDown1.Value);
                command3.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Stok Güncellendi");

                listele();

            }
            if (numericUpDown2.Value != 0)
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"insert into TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) values (@p1,@p2,@p3,@p4)", connection);
                command.Parameters.AddWithValue("@p1", TxtPlaka.Text);
                command.Parameters.AddWithValue("@p2", "Kurşunsuz97");
                command.Parameters.AddWithValue("@p3", numericUpDown2.Value);
                command.Parameters.AddWithValue("@p4", Decimal.Parse(TxtKursunsuz97Fiyat.Text));
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Satış yapıldı");


                connection.Open();
                SqlCommand command2 = new SqlCommand("update TBLKASA set MIKTAR=MIKTAR+@p1", connection);
                command2.Parameters.AddWithValue("@p1", decimal.Parse(TxtKursunsuz97Fiyat.Text));
                command2.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Kasa Güncellendi");


                connection.Open();
                SqlCommand command3 = new SqlCommand("update TBLBENZIN set STOK=STOK-@p1 where petroltur='KURSUNSUZ97'", connection);
                command3.Parameters.AddWithValue("@p1", numericUpDown2.Value);
                command3.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Stok Güncellendi");
                listele();

            }
            if (numericUpDown3.Value != 0)
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"insert into TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) values (@p1,@p2,@p3,@p4)", connection);
                command.Parameters.AddWithValue("@p1", TxtPlaka.Text);
                command.Parameters.AddWithValue("@p2", "EuroDizel10");
                command.Parameters.AddWithValue("@p3", numericUpDown3.Value);
                command.Parameters.AddWithValue("@p4", Decimal.Parse(TxtEuroDizelFiyat.Text));
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Satış yapıldı");


                connection.Open();
                SqlCommand command2 = new SqlCommand("update TBLKASA set MIKTAR=MIKTAR+@p1", connection);
                command2.Parameters.AddWithValue("@p1", decimal.Parse(TxtEuroDizelFiyat.Text));
                command2.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Kasa Güncellendi");


                connection.Open();
                SqlCommand command3 = new SqlCommand("update TBLBENZIN set STOK=STOK-@p1 where petroltur='EuroDizel10'", connection);
                command3.Parameters.AddWithValue("@p1", numericUpDown3.Value);
                command3.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Stok Güncellendi");
                listele();

            }
            if (numericUpDown4.Value != 0)
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"insert into TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) values (@p1,@p2,@p3,@p4)", connection);
                command.Parameters.AddWithValue("@p1", TxtPlaka.Text);
                command.Parameters.AddWithValue("@p2", "YeniProDizel");
                command.Parameters.AddWithValue("@p3", numericUpDown1.Value);
                command.Parameters.AddWithValue("@p4", Decimal.Parse(TxtYeniProFiyat.Text));
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Satış yapıldı");


                connection.Open();
                SqlCommand command2 = new SqlCommand("update TBLKASA set MIKTAR=MIKTAR+@p1", connection);
                command2.Parameters.AddWithValue("@p1", decimal.Parse(TxtYeniProFiyat.Text));
                command2.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Kasa Güncellendi");


                connection.Open();
                SqlCommand command3 = new SqlCommand("update TBLBENZIN set STOK=STOK-@p1 where petroltur='YeniProDizel'", connection);
                command3.Parameters.AddWithValue("@p1", numericUpDown4.Value);
                command3.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Stok Güncellendi");

                listele();

            }
            if (numericUpDown5.Value != 0)
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"insert into TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) values (@p1,@p2,@p3,@p4)", connection);
                command.Parameters.AddWithValue("@p1", TxtPlaka.Text);
                command.Parameters.AddWithValue("@p2", "Gaz");
                command.Parameters.AddWithValue("@p3", numericUpDown5.Value);
                command.Parameters.AddWithValue("@p4", Decimal.Parse(TxtGazFiyat.Text));
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Satış yapıldı");


                connection.Open();
                SqlCommand command2 = new SqlCommand("update TBLKASA set MIKTAR=MIKTAR+@p1", connection);
                command2.Parameters.AddWithValue("@p1", decimal.Parse(TxtGazFiyat.Text));
                command2.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Kasa Güncellendi");


                connection.Open();
                SqlCommand command3 = new SqlCommand("update TBLBENZIN set STOK=STOK-@p1 where petroltur='Gaz'", connection);
                command3.Parameters.AddWithValue("@p1", numericUpDown5.Value);
                command3.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Stok Güncellendi");
                listele();

            }
        }
    }
}