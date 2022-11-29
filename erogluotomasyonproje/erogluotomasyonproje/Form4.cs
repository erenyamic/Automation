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
    public partial class Form4 : Form
    {
        OleDbConnection connection;
        OleDbDataAdapter adapter;
        OleDbDataReader dataReader;
        OleDbCommand command;
        public Form4()
        {
            InitializeComponent();
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void Form4_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=eroglu.accdb");
            connection.Open();
            DataTable table2 = new DataTable();
            adapter = new OleDbDataAdapter("select * from musteri", connection);
            adapter.Fill(table2);
            dataGridView1.DataSource = table2;
            connection.Close();
            adapter = new OleDbDataAdapter("select * from iller order by id ASC", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "sehir";
            comboBox1.DataSource = table;

            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#de6262");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
            if(comboBox1.SelectedIndex!=-1)
            {
                
                adapter = new OleDbDataAdapter("select * from ilceler where sehir=" + comboBox1.SelectedValue, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                comboBox2.ValueMember = "id";
                comboBox2.DisplayMember = "ilce";
                comboBox2.DataSource = table;
                
            }



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
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox9.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "")
            {
                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from musteri where TC='" + textBox3.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        MessageBox.Show("Bu TC ile kayıtlı müşteri bulunmakta !!");
                        connection.Close();
                    }
                    else
                    {
                        command = new OleDbCommand("insert into musteri(Ad,Soyad,TC,Telefon,il,ilçe,Adres,ödeme,araçtipi) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox9.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "')", connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Müşteri bilgileri başarıyla kaydedildi");
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
            if (textBox3.Text != "")
            {
                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from musteri where TC='" + textBox3.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        command = new OleDbCommand("delete from musteri where TC='" + textBox3.Text + "'", connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Müşteri başarıyla silindi");
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bu TC ile kayıtlı müşteri bulunmamakta !!");
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
                MessageBox.Show("Lütfen TC bilgisini doldurunuz !!");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox9.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "")
            {
                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from musteri where TC='" + textBox3.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        command = new OleDbCommand("update musteri set Ad='" + textBox1.Text + "',Soyad='" + textBox2.Text + "',Telefon='" + textBox4.Text + "',il='" + comboBox1.Text + "',ilçe='" + comboBox2.Text + "',Adres='" + textBox9.Text + "',ödeme='" + comboBox3.Text + "',araçtipi='" + comboBox4.Text + "' where TC='" + textBox3.Text + "'", connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Müşteri bilgileri başarıyla güncellendi");
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bu TC ile kayıtlı müşteri bulunmamakta !!");
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
            if (textBox5.Text != "")
            {
                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from musteri where TC='" + textBox5.Text + "'", connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        adapter = new OleDbDataAdapter("select * from musteri where TC='" + textBox5.Text + "'", connection);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bu TC ile kayıtlı müşteri bulunmamakta !!");
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
                MessageBox.Show("Lütfen TC bilgisini doğru giriniz !!");
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            connection.Open();
            adapter = new OleDbDataAdapter("select * from musteri", connection);
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
