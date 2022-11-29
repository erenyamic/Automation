using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace erogluotomasyonproje
{
    public partial class settings : Form
    {
        OleDbConnection connection;
        OleDbDataAdapter adapter;
        OleDbDataReader dataReader;
        OleDbCommand command;
        public settings()
        {
            InitializeComponent();
        }

        

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void settings_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=eroglu.accdb");
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                if (textBox5.Text == textBox6.Text)
                {
                    connection.Open();
                    command = new OleDbCommand("select * from yonetici where kullaniciadi='" + textBox4.Text + "' and sifre='" + textBox5.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        command = new OleDbCommand("delete from yonetici where kullaniciadi='" + textBox4.Text + "' and sifre='" + textBox5.Text + "'", connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Hesap başarıyla silindi");
                        Form1 form1 = new Form1();
                        form1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hatalı kullanıcı adı veya şifre !!");
                    }

                    connection.Close();
                }
                else
                    MessageBox.Show("Şifreler eşleşmiyor !!");
            }
            else
                MessageBox.Show("Bilgiler boş bırakılamaz !!");
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                if (textBox5.Text == textBox6.Text)
                {
                    connection.Open();
                    command = new OleDbCommand("select * from yonetici where kullaniciadi='" + textBox4.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        command = new OleDbCommand("update yonetici set sifre='" + textBox5.Text + "' where kullaniciadi='" + textBox4.Text + "'", connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Şifre başarıyla değiştirildi");
                    }
                    else
                    {
                        MessageBox.Show("Bu kullanıcı adıyla kayıtlı hesap bulunamadı !!");
                    }

                    connection.Close();
                }
                else
                    MessageBox.Show("Şifreler eşleşmiyor !!");
            }
            else
                MessageBox.Show("Bilgiler boş bırakılamaz !!");
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeComponent();
        }
    }
}
