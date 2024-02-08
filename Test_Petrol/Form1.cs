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


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95, litre, tutar;
            kursunsuz95 = Convert.ToDouble(LblKursunsuz95.Text) * Convert.ToDouble(numericUpDown1.Value);
            TxtKursunsuz95Fiyat.Text = kursunsuz95.ToString();


        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz97, litre, tutar;
            kursunsuz97 = Convert.ToDouble(LblKursunsuz97.Text) * Convert.ToDouble(numericUpDown2.Value);
            TxtKursunsuz97Fiyat.Text = kursunsuz97.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double eurodizel, litre, tutar;
            eurodizel = Convert.ToDouble(LblEuroDizel.Text) * Convert.ToDouble(numericUpDown3.Value);
            TxtEuroDizelFiyat.Text = eurodizel.ToString();

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double yenipro, litre, tutar;
            yenipro = Convert.ToDouble(LblYeniProDizel.Text) * Convert.ToDouble(numericUpDown4.Value);
            TxtYeniProFiyat.Text = yenipro.ToString();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            double gaz, litre, tutar;
            gaz = Convert.ToDouble(LblGaz.Text) * Convert.ToDouble(numericUpDown5.Value);
            TxtGazFiyat.Text = gaz.ToString();
        }
    }
}
