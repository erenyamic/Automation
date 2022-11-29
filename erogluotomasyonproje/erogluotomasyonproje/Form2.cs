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
    public partial class Form2 : Form
    {
        OleDbConnection connection;
        OleDbDataAdapter adapter;
        OleDbCommand command;
        OleDbDataReader dataReader;
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void Form2_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=eroglu.accdb");
            connection.Open();
            adapter = new OleDbDataAdapter("select * from aku", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#de6262");



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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            settings settings = new settings();
            settings.Show();
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
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox8.Text != "")
            {
                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from aku where Kod='" + textBox1.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        MessageBox.Show("Bu koda sahip bir model bulunmakta !!");
                        connection.Close();
                    }
                    else
                    {
                        command = new OleDbCommand("insert into aku(Kod,Marka,Volt,Amper,Tipi,Fiyatı,Adet) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox8.Text + "')", connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Ürün bilgileri başarıyla kaydedildi");
                        connection.Close();
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Bir hata oluştu");
                    connection.Close();
                }
            }
            else
                MessageBox.Show("Lütfen boş yer bırakmayınız !!");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from aku where Kod='" + textBox1.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        command = new OleDbCommand("delete from aku where Kod='" + textBox1.Text + "'", connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Ürün başarıyla silindi");
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bu koda sahip bir model bulunmamakta !!");
                        connection.Close();
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Bir hata oluştu");
                    connection.Close();
                }
            }
            else
                MessageBox.Show("Lütfen gerekli alanı doldurunuz !!");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox8.Text != "")
            {
                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from aku where Kod='" + textBox1.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        command = new OleDbCommand("update aku set Marka='" + textBox2.Text + "',Volt='" + textBox3.Text + "',Amper='" + textBox4.Text + "',Tipi='" + textBox5.Text + "',Fiyatı='" + textBox6.Text + "',Adet='" + textBox8.Text + "' where Kod='" + textBox1.Text + "'", connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Ürün bilgileri başarıyla güncellendi");
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bu koda sahip bir model bulunmamakta !!");
                        connection.Close();
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Bir hata oluştu");
                    connection.Close();
                }
            }
            else
                MessageBox.Show("Lütfen boş yer bırakmayınız !!");
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from aku where Kod='" + textBox7.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        adapter = new OleDbDataAdapter("select * from aku where Kod='" + textBox7.Text + "'", connection);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bu koda sahip bir model bulunmamakta !!");
                        connection.Close();
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Bir hata oluştu");
                    connection.Close();
                }
            }
            else
                MessageBox.Show("Lütfen kod bilgisini doğru giriniz !!");
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            connection.Open();
            adapter = new OleDbDataAdapter("select * from aku", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeComponent();
        }
    }
}
