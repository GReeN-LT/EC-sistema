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
    public partial class Registracija : Form
    {
        public Registracija()
        {
            InitializeComponent();
        }



        private void Registracija_Load(object sender, EventArgs e)
        {

            label5.Hide();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //registracija
            if (textBox3.Text == textBox4.Text)
            {
                string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minda\Desktop\Programavimas\Programos c#\EC sistema\EC sistema\DuomenuBaze.mdf;Integrated Security=True";

                SqlConnection conn = new SqlConnection(connString);

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Registracija values (@Slapyvardis, @Slaptazodis, @SlaptazodioP, @ElPastas)", conn);
                    cmd.Parameters.AddWithValue("@Slapyvardis", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Slaptazodis", textBox3.Text);
                    cmd.Parameters.AddWithValue("@SlaptazodioP", textBox4.Text);
                    cmd.Parameters.AddWithValue("@ElPastas", textBox2.Text);
                    
                    
                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Jūs sėkmingai užregistruotas!");
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
            else
            {
                label5.Show();
                label5.Text = "Slaptažodžiai nesutampa";
            }


        } //registracija end

        private void button2_Click(object sender, EventArgs e)
        {
            //atsaukimas
            Application.Exit();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login frm = new Login();
            frm.Show();
        }
    }
}
