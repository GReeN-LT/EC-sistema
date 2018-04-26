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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            label3.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //isejimas
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //prisijungimas
            try
            {
                string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minda\Desktop\Programavimas\Programos c#\EC sistema\EC sistema\DuomenuBaze.mdf;Integrated Security=True";

                SqlConnection conn = new SqlConnection(connString);


                conn.Open();
                    
                    string queryText = @"SELECT Count(*) FROM Registracija 
                             WHERE Slapyvardis = @Slapyvardis AND Slaptazodis = @Slaptazodis";
                    using (SqlConnection cn = new SqlConnection(connString))
                    using (SqlCommand cmd = new SqlCommand(queryText, cn))
                    {
                        cn.Open();
                        cmd.Parameters.AddWithValue("@Slapyvardis", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Slaptazodis", textBox2.Text);
                        int result = (int)cmd.ExecuteScalar();
                        if (result > 0)
                            MessageBox.Show("Jūs sėkmingai prisijungete!");



                        if (textBox1.Text == "admin" && textBox2.Text == "admin")
                        {
                            this.Hide();
                            Admin frm3 = new Admin();
                            frm3.Show();
                        }
                            else if (textBox1.Text != "admin" && textBox2.Text != "admin")
                            {

                            this.Hide();
                            Vartotojas frm4 = new Vartotojas();  //ant user raso sekmingai pris, ant neregistruoto neraso
                            frm4.Show();

                        //keiciau

                        if (result == 0)
                        { 
                            MessageBox.Show("Toks vartotojas neregistruotas", "Pranešimas", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            frm4.Close();
                        Login frm = new Login();
                        frm.Show();
                          
                        }
                    }



                }
           
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
    





            //prisijungimas
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //registracija

            this.Hide();
            Registracija frm2 = new Registracija();
            frm2.Show();


            //registracija
        }

        
    }
}
