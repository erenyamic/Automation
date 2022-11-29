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

namespace erogluotomasyonproje
{
    public partial class Form1 : Form
    {
        OleDbConnection connection;
        OleDbDataAdapter adapter;
        OleDbDataReader dataReader;
        DataTable table;
        OleDbCommand command;
        public Form1()
        {
            InitializeComponent();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=eroglu.accdb");
            
        }

       

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from yonetici where kullaniciadi='" + textBox1.Text + "' and sifre='" + textBox2.Text + "'", connection);
                    dataReader = command.ExecuteReader();

                    if (dataReader.Read())
                    {
                        Form2 form = new Form2();
                        form.Show();
                        this.Hide();

                    }
                    else
                        MessageBox.Show("Giriş Başarısız");
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Giriş Başarısız");
                    connection.Close();
                }
            }
            else
                MessageBox.Show("Boş Bırakılamaz !!");
            connection.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from yonetici where kullaniciadi='" + textBox1.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        MessageBox.Show("Bu kullanıcı adıyla kayıtlı hesap bulunmakta !!");
                        connection.Close();
                    }
                    else
                    {
                        command = new OleDbCommand("insert into yonetici(kullaniciadi,sifre) values('" + textBox1.Text + "','" + textBox2.Text + "')", connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("İşlem Başarılı");
                        connection.Close();
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show("İşlem Başarısız");
                    connection.Close();
                }
            }
            else
                MessageBox.Show("Boş Bırakılamaz");
        }
    }
}
