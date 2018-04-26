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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //iregistruoti tiekeja prad

            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minda\Desktop\Programavimas\Programos c#\EC sistema\EC sistema\DuomenuBaze.mdf;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Tiekejas values (@pavadinimas, @kodas)", conn);
                cmd.Parameters.AddWithValue("@kodas", textBox1.Text);
                cmd.Parameters.AddWithValue("@pavadinimas", textBox2.Text);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("insert into Sutartis values (@kodas, @sutartiesPradzia, @sutartiesPabaiga)", conn);
                cmd2.Parameters.AddWithValue("@kodas", textBox2.Text);
                cmd2.Parameters.AddWithValue("@sutartiesPradzia", dateTimePicker1.Value);
                cmd2.Parameters.AddWithValue("@sutartiesPabaiga", dateTimePicker2.Value);
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Naujas tiekejas įregistrutas!");
            }

            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                conn.Close();
            }



            // iregistruoti tiekeja pab
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // atsijungimas

            this.Hide();
            Login frm = new Login();
            frm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // rodyti tiekju informacija 
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();


            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minda\Desktop\Programavimas\Programos c#\EC sistema\EC sistema\DuomenuBaze.mdf;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select pavadinimas, kodas from Tiekejas", conn);

                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(cmd.CommandText, conn);
                sda.Fill(ds, "Tiekejas");

                foreach (DataRow dr in ds.Tables["Tiekejas"].Rows)
                    dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString());




            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }

            //suatartys

            string connString1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minda\Desktop\Programavimas\Programos c#\EC sistema\EC sistema\DuomenuBaze.mdf;Integrated Security=True";

            SqlConnection conn1 = new SqlConnection(connString1);

            try
            {
                conn1.Open();
                SqlCommand cmd1 = new SqlCommand("select sutartiesPradzia, sutartiesPabaiga from Sutartis", conn1);

                DataSet ds1 = new DataSet();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1.CommandText, conn1);
                sda1.Fill(ds1, "Sutartis");

                foreach (DataRow dr1 in ds1.Tables["Sutartis"].Rows)
                    dataGridView2.Rows.Add(dr1[0].ToString(), dr1[1].ToString());

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn1.Close();
            }

            //sutartys


            // rodyti tiekju informacija  pab
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //atsijungti
            this.Hide();
            Login frm = new Login();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //pratesti sutarti
            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minda\Desktop\Programavimas\Programos c#\EC sistema\EC sistema\DuomenuBaze.mdf;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connString);

            try // ant and klaida
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Sutartis set sutartiesPabaiga=@sutartiesPabaiga where kodas=@kodas", conn);
                cmd.Parameters.AddWithValue("@pavadinimas", textBox3.Text);
                cmd.Parameters.AddWithValue("@kodas", textBox4.Text);
                cmd.Parameters.AddWithValue("@sutartiesPradzia", dateTimePicker3.Value);
                cmd.Parameters.AddWithValue("@sutartiesPabaiga", dateTimePicker4.Value);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Informacija įrašyta");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }

            //sutarties pratesinmas
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            
            // tiekejo pasirinkimas

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // tiekejo pasirinkimas

            string connString1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minda\Desktop\Programavimas\Programos c#\EC sistema\EC sistema\DuomenuBaze.mdf;Integrated Security=True";

            SqlConnection conn1 = new SqlConnection(connString1);

            try
            {
                conn1.Open();
                SqlCommand cmd1 = new SqlCommand("select pavadinimas from Tiekejas", conn1);

                DataSet ds1 = new DataSet();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1.CommandText, conn1);
                sda1.Fill(ds1, "Tiekejas");
                comboBox1.Items.Clear();
                comboBox1.SelectedIndex = -1;

                foreach (DataRow dr1 in ds1.Tables["Tiekejas"].Rows)
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



            // tiekejo pasirinkimas

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // pridedi preke
            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minda\Desktop\Programavimas\Programos c#\EC sistema\EC sistema\DuomenuBaze.mdf;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand getID = new SqlCommand("select kodas from Tiekejas where pavadinimas=@pavadinimas", conn);
                getID.Parameters.AddWithValue("pavadinimas", comboBox1.Text);
                int tiekejoKodas = Convert.ToInt32(getID.ExecuteScalar());

                // insert kaina pavadinimas id
                SqlCommand cmd = new SqlCommand("insert into Preke values (@prekesPavadinimas, @prekesKaina, @kodas)", conn);
                cmd.Parameters.AddWithValue("@prekesPavadinimas", textBox5.Text);
                cmd.Parameters.AddWithValue("@prekesKaina", textBox6.Text);
                cmd.Parameters.AddWithValue("@kodas", tiekejoKodas);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Nauja prekė pridėta!");
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
            //

            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // prekiu informacija

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


            //prekiu informacija
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login frm = new Login();
            frm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView5.Rows.Clear();


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
                    dataGridView5.Rows.Add(dr[0].ToString(), dr[1].ToString());




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


        //dalykai


    }
}
