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

namespace EC_sistema
{
    public partial class Vartotojas : Form
    {
        public Vartotojas()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();

            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minda\Desktop\Programavimas\Programos c#\EC sistema\EC sistema\DuomenuBaze.mdf;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select prekesPavadinimas, prekesKaina from Preke", conn);

                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(cmd.CommandText, conn);
                sda.Fill(ds, "Preke");

                foreach (DataRow dr in ds.Tables["Preke"].Rows)
                    dataGridView3.Rows.Add(dr[0].ToString(), dr[1].ToString());




            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }

            string connString1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minda\Desktop\Programavimas\Programos c#\EC sistema\EC sistema\DuomenuBaze.mdf;Integrated Security=True";

            SqlConnection conn1 = new SqlConnection(connString1);

            try
            {
                conn1.Open();
                SqlCommand cmd1 = new SqlCommand("select pavadinimas from Tiekejas", conn1);

                DataSet ds1 = new DataSet();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1.CommandText, conn1);
                sda1.Fill(ds1, "Tiekejas");

                foreach (DataRow dr1 in ds1.Tables["Tiekejas"].Rows)
                    dataGridView4.Rows.Add(dr1[0].ToString());

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn1.Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login frm = new Login();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ikelti prekes
            string connString1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minda\Desktop\Programavimas\Programos c#\EC sistema\EC sistema\DuomenuBaze.mdf;Integrated Security=True";

            SqlConnection conn1 = new SqlConnection(connString1);

            try
            {
                conn1.Open();
                SqlCommand cmd1 = new SqlCommand("select prekesPavadinimas from Preke", conn1);

                DataSet ds1 = new DataSet();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1.CommandText, conn1);
                sda1.Fill(ds1, "Preke");
                comboBox1.Items.Clear();
                comboBox1.SelectedIndex = -1;

                foreach (DataRow dr1 in ds1.Tables["Preke"].Rows)
                    comboBox1.Items.Add(dr1[0].ToString());

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn1.Close();
            }


            //ikelti prekes
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login frm = new Login();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //užsakymas

            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minda\Desktop\Programavimas\Programos c#\EC sistema\EC sistema\DuomenuBaze.mdf;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand cmd2 = new SqlCommand("select prekesPavadinimas from Preke where prekesPavadinimas=@prekesPavadinimas", conn);
                cmd2.Parameters.AddWithValue("prekesPavadinimas", comboBox1.Text);
               // int tiekejoKodas = Convert.ToInt32(getID.ExecuteScalar());

                // insert kaina pavadinimas id
                SqlCommand cmd = new SqlCommand("insert into Uzsakymas values (@prekesPavadinimas, @pristatymoAdresas)", conn);
                cmd.Parameters.AddWithValue("@prekesPavadinimas", comboBox1.Text); //
                cmd.Parameters.AddWithValue("@pristatymoAdresas", textBox1.Text);
                

                cmd.ExecuteNonQuery();
                MessageBox.Show("Nauja užsakymas atliktas!");
                //insert kaina pavadinimas id



            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);

            }
            finally
            {
                conn.Close();
            }


            //užsakymas
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //užsakymo rodymas


            dataGridView1.Rows.Clear();
            

            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minda\Desktop\Programavimas\Programos c#\EC sistema\EC sistema\DuomenuBaze.mdf;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select prekesPavadinimas, pristatymoAdresas from Uzsakymas", conn);

                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(cmd.CommandText, conn);
                sda.Fill(ds, "Uzsakymas");

                foreach (DataRow dr in ds.Tables["Uzsakymas"].Rows)
                    dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString());

                //

                



                //


            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login frm = new Login();
            frm.Show();
        }
    }
}
