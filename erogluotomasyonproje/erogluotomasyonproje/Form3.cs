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
    public partial class Form3 : Form
    {
        OleDbConnection connection;
        OleDbDataAdapter adapter;
        OleDbDataReader dataReader;
        OleDbCommand command;
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void Form3_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=eroglu.accdb");
            connection.Open();
            adapter = new OleDbDataAdapter("select * from tedarikci", connection);
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

        

        

        

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
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
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from tedarikci where firmaadi='" + textBox1.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        MessageBox.Show("Bu ada sahip bir firma bulunmakta !!");
                        connection.Close();
                    }
                    else
                    {
                        command = new OleDbCommand("insert into tedarikci(firmaadi,akumarka,alinanfiyat) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Tedarikçi bilgileri başarıyla kaydedildi");
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
                    command = new OleDbCommand("select * from tedarikci where firmaadi='" + textBox1.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        command = new OleDbCommand("delete from tedarikci where firmaadi='" + textBox1.Text + "'", connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Tedarikçi başarıyla silindi");
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bu ada sahip bir firma bulunmamakta !!");
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
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from tedarikci where firmaadi='" + textBox1.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        command = new OleDbCommand("update tedarikci set akumarka='" + textBox2.Text + "',alinanfiyat='" + textBox3.Text + "' where firmaadi='" + textBox1.Text + "'", connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Tedarikçi bilgileri başarıyla güncellendi");
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bu ada sahip bir firma bulunmamakta !!");
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
                    command = new OleDbCommand("select * from tedarikci where firmaadi='" + textBox7.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        adapter = new OleDbDataAdapter("select * from tedarikci where firmaadi='" + textBox7.Text + "'", connection);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bu ada sahip bir firma bulunmamakta !!");
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
                MessageBox.Show("Lütfen Firma Adını doğru giriniz !!");
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            connection.Open();
            adapter = new OleDbDataAdapter("select * from tedarikci", connection);
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
